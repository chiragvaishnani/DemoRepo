using Autofac;

namespace DIApp.Models
{
    public class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<School>().As<IEducationalInstitute>();
            builder.RegisterType<Home>().As<IHome>();
            builder.RegisterType<Hospital>().As<IHospital>();


            return builder.Build();
        }
    }
}
