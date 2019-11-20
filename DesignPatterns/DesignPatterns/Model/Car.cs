using System;

namespace DesignPatterns.Model
{
    public class Car : IVehicle
    {
        public string Enrollment { get; set; }

        public double HorsePower { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int WheelsNumber => 4;

        public string drive()
        {
            return "Im driving in a car";
        }

        public override string ToString()
        {
            return $"Car with {nameof(Enrollment)}: {Enrollment}, {nameof(HorsePower)}:{HorsePower}, {nameof(EnrollmentDate)}:{EnrollmentDate}";
        }
    }
}
