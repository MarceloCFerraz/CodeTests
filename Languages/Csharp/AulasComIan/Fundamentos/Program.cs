// paradigma orientacao a objetos

public class Company
{
    public string Name { get; set; }
}

public class Vehicle
{
    public Vehicle() { }

    public Vehicle(int doorCount)
    {
        DoorCount = doorCount;
    }

    public Vehicle(int doorCount, int wheelCount)
    {
        DoorCount = doorCount;
        WheelCount = wheelCount;
    }

    public Company Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Milleage { get; set; }
    public int WheelCount { get; set; }
    public int DoorCount { get; set; }
}

public class Car : Vehicle
{
    public Car() : base(4) { }
    public Car(int doorCount) : base(doorCount) { }
}

public class Bike : Vehicle
{
    public Bike(int doorCount) : base(doorCount) { }
    public Bike(int doorCount, int wheelCount) : base(doorCount, wheelCount) { }
}

class Program
{
    public static void Main(string[] args)
    {
    }
}
