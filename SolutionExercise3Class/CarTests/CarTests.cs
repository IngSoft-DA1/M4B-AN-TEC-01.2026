using Domain;

namespace TestProject;

[TestClass]
public class CarTests
{
    
    //Happy cases
    [TestMethod]
    public void Should_CreateACarAndAssignProperties_When_TheConstructorIsCalled()
    {
        int doorQuantity = 4;
        string color = "Blue";
        
        Car myCar = new Car(doorQuantity, color);
        
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




}