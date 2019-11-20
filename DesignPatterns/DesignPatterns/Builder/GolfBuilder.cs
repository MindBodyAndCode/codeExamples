using DesignPatterns.Model;
using System;

namespace DesignPatterns.Builder
{
    public class GolfBuilder : ICarBuilder
    {
        private Car _car;

        public GolfBuilder()
        {
            _car = new Car();
        }

        public ICarBuilder SetEnrollment(string enrollment)
        {
            _car.Enrollment = enrollment;
            return this;
        }

        public ICarBuilder SetHorsePower()
        {
            _car.HorsePower = 170;
            return this;
        }

        public ICarBuilder SetEnrollmentDate(DateTime enrollmentDate)
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
