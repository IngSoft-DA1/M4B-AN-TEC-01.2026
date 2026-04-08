using Domain;

namespace TestProject;

[TestClass]
public class CarTests
{
    
    //Happy cases
    [TestMethod]
    public void Should_CreateACarAndAssignProperties_When_TheConstructorIsCalled()
    {
        // Arrange 
        int doorQuantity = 4;
        string color = "Blue";
        
        //Act
        Car myCar = new Car(doorQuantity, color);
        
        //Assert
        Assert.AreEqual(doorQuantity, myCar.DoorQuantity);
        Assert.AreEqual(color, myCar.Color);
    }
    
    //wrong cases 

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Should_ThrowException_When_TheDoorsQuantityIsExceededTheMaximum()
    {
        Car myCar = new Car(6,"Blue");
        
    }
    
    //Para practicar:
    
    //Should_ThrowException_When_TheDoorsQuantityIsNegative
    
    
    //Should_ThrowException_When_TheColorIsEmpty
    
    




}