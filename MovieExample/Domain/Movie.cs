namespace Domain;

public class Movie
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    private string FirmaPrivada { get; set; }

    public Movie()
    {
        FirmaPrivada = Random.Shared.Next(10000, 100000).ToString();
    }

    public Movie(string name, DateTime releaseDate)
    {
        FirmaPrivada = Random.Shared.Next(10000, 100000).ToString();
        Name = name;
        ReleaseDate = releaseDate;
    }
}