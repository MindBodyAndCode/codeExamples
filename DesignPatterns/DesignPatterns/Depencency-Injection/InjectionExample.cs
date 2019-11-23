using DesignPatterns.FactoryMethod;
using DesignPatterns.Model;

namespace DesignPatterns.Depencency_Injection
{
    public class InjectionExample
    {
        private readonly IFactory _vehicleFactory;

        public MotorBike MotorBike { get; set; }

        public InjectionExample(IFactory vehicleFactory)
        {
            _vehicleFactory = vehicleFactory ?? throw new System.ArgumentNullException(nameof(vehicleFactory));
        }

        public IVehicle GetCar()
        {
            return _vehicleFactory.Create(typeof(Car));
        }


    }
}
