using Domain;

namespace DataAccess.Repositories;

public class MovieRepository
{

    private readonly InMemoryDatabase _inMemoryDb;
    
    public MovieRepository(InMemoryDatabase inMemoryDb)
    {
        _inMemoryDb = inMemoryDb;
        
    }
    
    public void AddMovie(Movie movie)
    {
        _inMemoryDb.Movies.Add(movie);
    }
    
}