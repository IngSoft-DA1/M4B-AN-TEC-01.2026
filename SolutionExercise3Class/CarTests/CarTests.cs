namespace TestProject;

[TestClass]
public class CarTests
{

    [TestMethod]
    public void Should_CreateACar_When_TheConstructorIsCalled()
    {
        Car myCar = new Car(4, "Blue");
    }

}