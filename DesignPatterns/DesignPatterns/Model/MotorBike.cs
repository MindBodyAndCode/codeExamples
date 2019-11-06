namespace DesignPatterns.Model
{
    public class MotorBike : IVehicle
    {
        public int WheelsNumber => 2;

        public string drive()
        {
            return "Im on a MotorBike";
        }
    }
}
