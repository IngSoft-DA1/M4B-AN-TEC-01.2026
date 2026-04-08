namespace Domain;

public class Car
{
    public int DoorQuantity { get; set; }
    public string Color { get; set; }

    public Car(int doorQuantity, string color)
    {
        ValidateDoorsQuantity(doorQuantity);
        //ValidateColor
        //ValidateCarModel
        DoorQuantity = doorQuantity;
        Color = color;
    }

    private static void ValidateDoorsQuantity(int doorQuantity)
    {
        int maximumDoorsQuantity = 4;
        if (doorQuantity > maximumDoorsQuantity)
        {
            throw new ArgumentException("Doors exceeded");
        }
    }
}