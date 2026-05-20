using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class MovieRepositorySql
{
    private readonly SqlContext _context;

    public MovieRepositorySql(SqlContext context)
    {
        _context = context;
    }
    
    public void AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }
    
    public List<Movie> ListAllMovies()
    {
        return _context.Movies.AsNoTracking().ToList();
    }
    
    public Movie? GetMovieByName(string name)
    {
        return _context.Movies.AsNoTracking().FirstOrDefault(m => m.Name == name);
    }
    
    public void UpdateMovie(Movie movie)
    {
        //Importante, sino nos crea uno nuevo por DTOs (NO USAR Update)
        _context.Entry(movie).State = EntityState.Modified;
        _context.SaveChanges();
    }
}