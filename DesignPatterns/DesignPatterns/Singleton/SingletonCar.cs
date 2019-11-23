using DesignPatterns.Model;

namespace DesignPatterns.Singleton
{
    public class SingletonCar : IVehicle
    {
        private SingletonCar() { }

        private static SingletonCar _instance;

        public static SingletonCar GetInstance
        {
            get
            {
                if (_instance is null)
                    _instance = new SingletonCar();

                return _instance;
            }
        }

        public int WheelsNumber => 4;

        public string drive()
        {
            return "Im driving in a unique car";
        }
    }
}

