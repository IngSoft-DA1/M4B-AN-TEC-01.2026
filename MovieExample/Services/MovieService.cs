using DataAccess.Repositories;
using Domain;
using Services.DTOs;
using Services.Mappers;

namespace Services;

public class MovieService
{
    private readonly MovieRepositorySql _movieRepository;
    public MovieService(MovieRepositorySql movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void AddMovie(AddMovieDto dto)
    {
        _movieRepository.AddMovie(MovieMapper.ToMovie(dto));
    }

    public List<MovieDto> ListAllMovies()
    {
        return _movieRepository.ListAllMovies().Select(MovieMapper.ToMovieDto).ToList();
    }

    public EditMovieDto? GetMovieByName(string name)
    {
        Movie? movie = _movieRepository.GetMovieByName(name);
        if (movie == null) return null;
        return MovieMapper.ToEditMovieDto(movie);
    }

    public void UpdateMovie(EditMovieDto dto)
    {
        _movieRepository.UpdateMovie(MovieMapper.ToMovie(dto));
    }

}