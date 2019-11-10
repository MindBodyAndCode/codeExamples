using DesignPatterns.FactoryMethod;
using DesignPatterns.Model;

namespace DesignPatterns.Depencency_Injection
{
    public class AutofacExample
    {
        private readonly IFactory _vehicleFactory;

        public MotorBike MotorBike { get; set; }

        public AutofacExample(IFactory vehicleFactory)
        {
            _vehicleFactory = vehicleFactory ?? throw new System.ArgumentNullException(nameof(vehicleFactory));
        }

        public IVehicle GetCar()
        {
            return _vehicleFactory.Create(typeof(Car));
        }


    }
}
