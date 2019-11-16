using Autofac;
using DesignPatterns.Depencency_Injection;
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

        public static void DependencyInjection()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            var diContainer = containerBuilder.Build();

            // Constructor injection example
            var injectionExample = diContainer.Resolve<InjectionExample>();
            var car = injectionExample.GetCar();
            Console.WriteLine(car.drive());

            // Property injection example
            var motorBike = injectionExample.MotorBike;
            Console.WriteLine(motorBike.drive());

            // Method injection example
            var methodInjectionExample = diContainer.Resolve<MethodInjectionExample>();
            var truck = methodInjectionExample.GetTruck();
            Console.WriteLine(truck.drive());
        }
    }
}
