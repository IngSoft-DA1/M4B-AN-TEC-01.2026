## Modelo base común

```csharp
public class Animal
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

public class Perro : Animal
{
    public string Raza { get; set; }
}

public class Gato : Animal
{
    public bool EsMansito { get; set; }
}

public class Castor : Animal
{
    public bool EsAgresivo { get; set; }
}
```

---

## 1. TPH — Table Per Hierarchy

Una sola tabla para toda la jerarquía. EF agrega una columna `Discriminator` para saber de qué tipo es cada fila. Las columnas de los hijos quedan en `NULL` cuando no aplican.

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Animal> Animales { get; set; }
    // Solo registrás la base, EF infiere las hijas
}

```

**Tabla resultante: `Animales`**

| Id  | Nombre    | Edad | Discriminator | Raza     | EsMansito | EsAgresivo |
| --- | --------- | ---- | ------------- | -------- | --------- | ---------- |
| 1   | Rex       | 3    | Perro         | Labrador | NULL      | NULL       |
| 2   | Michi     | 5    | Gato          | NULL     | true      | NULL       |
| 3   | Castorito | 2    | Castor        | NULL     | NULL      | false      |

**Ventaja:** una sola tabla, queries simples y rápidas. **Desventaja:** muchas columnas `NULL` si los hijos tienen muchos campos propios.

---

## 2. TPT — Table Per Type

Una tabla por cada clase. La tabla hija solo tiene sus columnas propias y una FK al padre. EF hace un JOIN cuando necesita los datos completos.

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Animal> Animales { get; set; }
    public DbSet<Perro> Perros { get; set; }
    public DbSet<Gato> Gatos { get; set; }
    public DbSet<Castor> Castores { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Perro>().ToTable("Perros");
        mb.Entity<Gato>().ToTable("Gatos");
        mb.Entity<Castor>().ToTable("Castores");
    }
}

```

**Tabla `Animales`**

| Id  | Nombre    | Edad |
| --- | --------- | ---- |
| 1   | Rex       | 3    |
| 2   | Michi     | 5    |
| 3   | Castorito | 2    |

**Tabla `Perros`**

| Id (FK) | Raza     |
| ------- | -------- |
| 1       | Labrador |

**Tabla `Gatos`**

| Id (FK) | EsMansito |
| ------- | --------- |
| 2       | true      |

**Tabla `Castores`**

| Id (FK) | EsAgresivo |
| ------- | ---------- |
| 3       | false      |

**Ventaja:** estructura normalizada, sin NULLs. **Desventaja:** cada query hace un JOIN entre la tabla padre y la hija.

---

## 3. TPC — Table Per Concrete Type

Una tabla por cada clase concreta, pero cada tabla tiene todas las columnas incluyendo las del padre. No hay tabla `Animales`, no hay JOINs, no hay FKs entre tablas.

```csharp
public abstract class Animal { ... } // abstract: no se instancia directo

public class AppDbContext : DbContext
{
    public DbSet<Perro> Perros { get; set; }
    public DbSet<Gato> Gatos { get; set; }
    public DbSet<Castor> Castores { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Animal>().UseTpcMappingStrategy();
        mb.Entity<Perro>().ToTable("Perros");
        mb.Entity<Gato>().ToTable("Gatos");
        mb.Entity<Castor>().ToTable("Castores");
    }
}

```

**Tabla `Perros`**

| Id  | Nombre   | Edad | Raza     |
| --- | -------- | ---- | -------- |
| 1   | Rex      | 3    | Labrador |
| 4   | Firulais | 7    | Poodle   |

**Tabla `Gatos`**

| Id  | Nombre | Edad | EsMansito |
| --- | ------ | ---- | --------- |
| 2   | Michi  | 5    | true      |
| 5   | Pelusa | 2    | false     |

**Tabla `Castores`**

| Id  | Nombre    | Edad | EsAgresivo |
| --- | --------- | ---- | ---------- |
| 3   | Castorito | 2    | false      |

**Ventaja:** queries ultra rápidas, sin JOINs. **Desventaja:** los datos del padre se repiten en cada tabla, y consultar de forma polimórfica genera un `UNION ALL` entre las tres tablas.
