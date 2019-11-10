using Autofac;
using DesignPatterns.FactoryMethod;
using DesignPatterns.Model;

namespace DesignPatterns.Depencency_Injection
{
    public class AutofacModule : Module
    {
        public AutofacModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleFactory>().As<IFactory>().SingleInstance();

            builder.RegisterType<MotorBike>().InstancePerDependency();

            builder.RegisterType<AutofacExample>()
                .PropertiesAutowired()
                .InstancePerDependency();
        }
    }
}
