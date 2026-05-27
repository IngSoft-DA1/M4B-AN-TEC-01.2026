using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Tests;

[TestClass]
public class MovieRepositoryTests
{
    private SqlContext _context;
    private MovieRepositorySql _movieRepository;

    [TestInitialize]
    public void Initialize()
    {
        var optionBuilder = new DbContextOptionsBuilder<SqlContext>();
        optionBuilder.UseInMemoryDatabase("MovieTestsDb");
        _context =  new SqlContext(optionBuilder.Options);
        _movieRepository = new MovieRepositorySql(_context);
    }

    [TestMethod]
    public void Given_AddMovie_WithValidValidValues_ShouldAddMovieToDatabase()
    {
        //Arrange
        Movie movieToCreate = new  Movie("Shreck", DateTime.Now);
        
        //Act
        _movieRepository.AddMovie(movieToCreate);
        
        //Assert
        Assert.IsTrue(_context.Movies.Count() == 1);
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }

}