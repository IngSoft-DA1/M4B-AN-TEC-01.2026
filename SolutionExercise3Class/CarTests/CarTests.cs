using Domain;

namespace TestProject;

[TestClass]
public class CarTests
{
    
    //Happy cases

    [TestMethod]
    public void Should_CreateACar_When_TheConstructorIsCalled()
    {
        int doorQuantity = 4;
        string color = "Blue";
        
        Car myCar = new Car(doorQuantity, color);
    }

}