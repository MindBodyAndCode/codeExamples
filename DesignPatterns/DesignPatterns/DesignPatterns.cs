using DesignPatterns.FactoryMethod;
using DesignPatterns.Model;
using System;

namespace DesignPatterns
{
    public static class DesignPatterns
    {
        public static void FactoryMethod()
        {
            var vehicleFactory = new VehicleFactory();

            var vehicle = vehicleFactory.Create(typeof(Car));

            Console.WriteLine(vehicle.drive());

            vehicle = vehicleFactory.Create(typeof(MotorBike));

            Console.WriteLine(vehicle.drive());
        }
    }
}
