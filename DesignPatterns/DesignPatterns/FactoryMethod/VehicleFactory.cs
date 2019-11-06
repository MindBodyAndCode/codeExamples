using DesignPatterns.Model;
using System;

namespace DesignPatterns.FactoryMethod
{
    public class VehicleFactory : IFactory
    {
        public IVehicle Create(Type type)
        {
            if (type == typeof(Car))
                return new Car();

            if (type == typeof(MotorBike))
                return new MotorBike();

            return null;
        }
    }
}
