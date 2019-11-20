using DesignPatterns.Model;
using System;

namespace DesignPatterns.Builder
{
    public class HondaBuilder : ICarBuilder
    {
        private Car _car;

        public HondaBuilder()
        {
            _car = new Car();
        }

        public ICarBuilder SetEnrollment(string enrollment)
        {
            _car.Enrollment = enrollment;
            return this;
        }

        public ICarBuilder SetEnrollmentDate(DateTime enrollmentDate)
        {
            _car.EnrollmentDate = enrollmentDate;
            return this;
        }

        public ICarBuilder SetHorsePower()
        {
            _car.HorsePower = 150;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }
}
