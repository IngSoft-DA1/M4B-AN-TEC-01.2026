using Domain;
using Services.DTOs;

namespace Services.Mappers;

public static class MovieMapper
{
    public static Movie ToMovie(AddMovieDto dto) => new Movie { Name = dto.Name, ReleaseDate = dto.ReleaseDate };

    public static Movie ToMovie(EditMovieDto dto) => new Movie { Name = dto.Name, ReleaseDate = dto.ReleaseDate };

    public static MovieDto ToMovieDto(Movie movie) => new MovieDto { Name = movie.Name, ReleaseDate = movie.ReleaseDate };

    public static EditMovieDto ToEditMovieDto(Movie movie) => new EditMovieDto { OriginalName = movie.Name, Name = movie.Name, ReleaseDate = movie.ReleaseDate };
}
