using System;
 
public class Vehicle
{
    public virtual void StartEngine()
    {
        Console.WriteLine("Vehicle engine started.");
    }
} 
public class Car : Vehicle
{
    public override void StartEngine()
    {
        Console.WriteLine("Car-specific checks...");
        base.StartEngine(); // Call base class method
    }
} 
class Program
{
    static void Main()
    {
        Car myCar = new Car();
        myCar.StartEngine();
    }
}