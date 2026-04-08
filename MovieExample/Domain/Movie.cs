namespace Domain;

public class Movie
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Movie()
    {
        
    }

    public Movie(string name, DateTime releaseDate)
    {
        Name= name;
        ReleaseDate=releaseDate;
    }
}