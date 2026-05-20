namespace Services.DTOs;

public class EditMovieDto
{
    public  int Id { get; set; }
    public string OriginalName { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
}
