using DesignPatterns.Model;

namespace DesignPatterns.Depencency_Injection
{
    public class MethodInjectionExample
    {
        private Truck _truk;

        public void SetTruck(Truck truck)
        {
            _truk = truck;
        }

        public Truck GetTruck()
        {
            return _truk;
        }
    }
}
