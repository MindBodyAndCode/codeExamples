using DesignPatterns.Model;
using System;

namespace DesignPatterns.Builder
{
    public class CarBuilder
    {
        private Car _car;

        public CarBuilder()
        {
            _car = new Car();
        }

        public CarBuilder SetEnrollment(string enrollment)
        {
            _car.Enrollment = enrollment;
            return this;
        }

        public CarBuilder SetHorsePower(double horsePower)
        {
            _car.HorsePower = horsePower;
            return this;
        }

        public CarBuilder SetEnrollmentDate(DateTime enrollmentDate)
        {
            _car.EnrollmentDate = enrollmentDate;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }
}
