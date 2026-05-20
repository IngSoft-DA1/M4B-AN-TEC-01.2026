using Domain;
using Services.DTOs;

namespace Services.Mappers;

public static class MovieMapper
{
    public static Movie ToMovie(AddMovieDto dto) => new Movie { Name = dto.Name, ReleaseDate = dto.ReleaseDate };

    public static Movie ToMovie(EditMovieDto dto) => new Movie { Id = dto.Id, Name = dto.Name, ReleaseDate = dto.ReleaseDate };

    public static MovieDto ToMovieDto(Movie movie) => new MovieDto { Id = movie.Id, Name = movie.Name, ReleaseDate = movie.ReleaseDate };

    public static EditMovieDto ToEditMovieDto(Movie movie) => new EditMovieDto {Id = movie.Id, OriginalName = movie.Name, Name = movie.Name, ReleaseDate = movie.ReleaseDate };
}