## Cuando usar Eager Loading

```csharp
// ✅ EAGER → ideal cuando SIEMPRE necesitás los datos relacionados
var blog = context.Blogs
    .Include(b => b.Posts)
        .ThenInclude(p => p.Comments)
    .First(b => b.Id == 1);

// Todo ya está en memoria, sin queries extra
foreach (var post in blog.Posts)
{
    Console.WriteLine(post.Title);
    foreach (var comment in post.Comments)
        Console.WriteLine(comment.Content);
}


// ❌ El problema: a veces no necesitás todo pero igual lo trae
var blog = context.Blogs
    .Include(b => b.Posts)       // ← trae los posts aunque
        .ThenInclude(p => p.Comments) // ← no los uses en este flujo
    .First(b => b.Id == 1);

Console.WriteLine(blog.Title);   // solo usás el título

// Todas las filas de la db viajaron igual
```

---

## ¿Por qué no siempre usar Eager?

Porque el `Include` no es condicional. Una vez que lo pusiste, EF siempre hace el JOIN y trae todo, **aunque en ese flujo no lo necesites**.

Con Explicit podés poner la carga adentro de un `if`. Con Eager tenés que decidir antes de saber si lo vas a usar.

---

## Cuando usar Lazy Loading

### Algunas configuraciones iniciales

```csharp
// Las propiedades de navegación necesitan virtual
// para que EF pueda generar el proxy que intercepta el acceso

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }

    public virtual ICollection<Post> Posts { get; set; } // ✅ virtual
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int BlogId { get; set; }

    public virtual Blog Blog { get; set; }                    // ✅ virtual
    public virtual ICollection<Comment> Comments { get; set; } // ✅ virtual
}

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int PostId { get; set; }

    public virtual Post Post { get; set; } // ✅ virtual
}

// Las propiedades simples (Id, Title, BlogId) NO necesitan virtual
// Solo las de navegación → las que apuntan a otra entidad o colección
```

La regla es simple: si el tipo de la propiedad es **otra entidad o una colección de entidades**, necesita `virtual`. Si es `int`, `string`, `DateTime`, etc., no.

```csharp
// Configuración necesaria (una sola vez)
services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(connectionString)
       .UseLazyLoadingProxies());


// ✅ LAZY → accedés como si ya estuviera cargado, EF se encarga solo
var blog = context.Blogs.First(b => b.Id == 1); // solo trae el Blog

Console.WriteLine(blog.Title);   // sin query extra

// Recién acá EF dispara: SELECT * FROM Posts WHERE BlogId = 1
foreach (var post in blog.Posts)
{
    Console.WriteLine(post.Title);

    // Y acá: SELECT * FROM Comments WHERE PostId = @id
    foreach (var comment in post.Comments)
        Console.WriteLine(comment.Content);
}


// ❌ El problema: si tenés muchos blogs, N+1 queries sin darte cuenta
var blogs = context.Blogs.ToList(); // 1 query → 100 blogs

foreach (var blog in blogs)
{
    // 1 query por cada blog → 100 queries más
    foreach (var post in blog.Posts)
        Console.WriteLine(post.Title);
}
// Total: 101 queries. Con Eager hubiera sido 1.
```

---

## ¿Por qué no siempre usar Lazy?

Porque la comodidad esconde el costo. Cada vez que tocás una propiedad de navegación **hay una query viajando a la DB**, y dentro de un `foreach` eso se multiplica sin que lo veas en el código.

---

## Cuando usar Explicit Laoding

```csharp
// ❌ EAGER → trae los 500 comments en SQL, el Take filtra EN MEMORIA
var post = context.Posts
    .Include(p => p.Comments)   // SELECT * FROM Comments WHERE PostId = 1
    .First(p => p.Id == 1);     // 500 filas viajan por la red

var primeros10 = post.Comments.Take(10).ToList(); // filtra en C#, tarde


// ❌ LAZY → igual, trae todos y filtrás en memoria
var post = context.Posts.First(p => p.Id == 1);
var primeros10 = post.Comments.Take(10).ToList(); // ya cargó los 500


// ✅ EXPLICIT → el Take va dentro del SQL, solo viajan 10 filas
var post = context.Posts.First(p => p.Id == 1);

context.Entry(post)
    .Collection(p => p.Comments)
    .Query()                    // IQueryable → todavía no fue a la DB
    .OrderByDescending(c => c.Id)
    .Take(10)                   // SELECT TOP 10 ... → solo 10 filas viajan
    .Load();
```

---

## ¿Por qué Eager no puede hacer eso?

Porque el `Include` genera el SQL **completo de una vez** antes de que puedas agregar condiciones sobre la colección. Una vez que pusiste `.Include(p => p.Comments)`, EF ya armó la query y trae todo.

Con Explicit el `.Query()` te devuelve un `IQueryable` que **todavía no ejecutó nada**, entonces podés seguir componiendo la query antes de dispararla con `.Load()`.

---

## Regla simple para recordarlo

| Necesito...                                 | Usá                 |
| ------------------------------------------- | ------------------- |
| Todo siempre, desde el principio            | Eager + Include     |
| Acceso cómodo, no me importa la performance | Lazy                |
| Traer solo una parte filtrada               | Explicit + .Query() |
