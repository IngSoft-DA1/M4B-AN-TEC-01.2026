namespace Domain;

public class Car
{
    public int DoorQuantity { get; set; }
    public string Color { get; set; }

    public Car(int doorQuantity, string color)
    {
        int maximumDoorsQuantity = 4;
        if (doorQuantity > maximumDoorsQuantity)
        {
            throw new ArgumentException("Doors exceeded");
        }

        DoorQuantity = doorQuantity;
        Color = color;


    }

}