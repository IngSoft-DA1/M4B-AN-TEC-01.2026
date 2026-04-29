using DataAccess.Repositories;
using Domain;

namespace Services;

public class MovieService
{
    private readonly MovieRepository _movieRepository;
    public MovieService(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    //Aca la clase que viene lo cambiamos por MovieDTO
    public void AddMovie(Movie movie)
    {
        //Verificar si la peli ya estaba en la db
        //Crear Movie usando el constructor
        _movieRepository.AddMovie(movie);
    }

    public List<Movie> ListAllMovies()
    {
        // Valido que no haya peliculas Shreck
        return _movieRepository.ListAllMovies();
    }

    public Movie? GetMovieByName(string name)
    {
        return _movieRepository.GetMovieByName(name);
    }

    public void UpdateMovie(Movie movie)
    {
        _movieRepository.UpdateMovie(movie);
    }

}