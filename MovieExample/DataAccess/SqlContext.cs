using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class SqlContext : DbContext
{
    
    public DbSet<Movie> Movies { get; set; }
    
    //Un db set por cada entidad que sea necesario persistir
    
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configuraciones manuales en caso de ser necesario
        //Mapear relaciones de entidades
    }

}