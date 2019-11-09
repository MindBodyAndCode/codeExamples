namespace DesignPatterns.Model
{
    public class Car : IVehicle
    {

        public int WheelsNumber => 4;

        public string drive()
        {
            return "Im driving in a car";
        }
    }
}
