namespace Domain;

public class Car
{
    public int DoorQuantity { get; set; }
    public string Color { get; set; }

    public Car(int doorQuantity, string color)
    {
        DoorQuantity = doorQuantity;
        Color = color;
    }

}