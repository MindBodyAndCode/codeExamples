using DesignPatterns.Model;
using System;

namespace DesignPatterns.FactoryMethod
{
    public interface IFactory
    {
        IVehicle Create(Type type);
    }
}
