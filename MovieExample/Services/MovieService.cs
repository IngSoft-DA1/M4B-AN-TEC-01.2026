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
}