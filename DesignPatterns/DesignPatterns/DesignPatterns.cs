using DesignPatterns.FactoryMethod;
using DesignPatterns.Model;
using DesignPatterns.Singleton;
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

        public static void Singleton()
        {
            var carSingleton = SingletonCar.GetInstance;

            Console.WriteLine("Hi! Im singleton car with Id: " + carSingleton.GetHashCode());

            var otherCarSingleton = SingletonCar.GetInstance;

            Console.WriteLine("Hi! Im singleton car with Id: " + otherCarSingleton.GetHashCode());
        }
    }
}
