namespace Domain;

public class Car
{
    public int DoorQuantity { get; set; }
    public string Color { get; set; }

    public Car(int doorQuantity, string color)
    {
        if (doorQuantity > 4)
        {
            throw new ArgumentException("Doors exceeded");
        }

        DoorQuantity = doorQuantity;
        Color = color;


    }

}