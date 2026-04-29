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

    public List<Movie> ListAllMovies()
    {
        return _inMemoryDb.Movies;
    }

    public Movie? GetMovieByName(string name)
    {
        return _inMemoryDb.Movies.FirstOrDefault(m => m.Name == name);
    }

    public void UpdateMovie(Movie movie)
    {
        int indexOfMovieToUpdate = _inMemoryDb.Movies.FindIndex(m => m.Name == movie.Name);
        _inMemoryDb.Movies.RemoveAt(indexOfMovieToUpdate);
        _inMemoryDb.Movies.Insert(indexOfMovieToUpdate, movie);
    }

}