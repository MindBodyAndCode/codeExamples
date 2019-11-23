namespace DesignPatterns.Model
{
    public interface IVehicle
    {
        public int WheelsNumber { get; }

        public string drive();
    }
}
