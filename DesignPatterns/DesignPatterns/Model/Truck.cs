namespace DesignPatterns.Model
{
    public class Truck : IVehicle
    {
        public int WheelsNumber => 4;

        public string drive()
        {
            return "Driving a Truck!";
        }
    }
}
