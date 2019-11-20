using DesignPatterns.Model;
using System;

namespace DesignPatterns.Builder
{
    public interface ICarBuilder
    {
        ICarBuilder SetEnrollment(string enrollment);
        public ICarBuilder SetHorsePower();
        public ICarBuilder SetEnrollmentDate(DateTime enrollmentDate);
        public Car Build();
    }
}
