using Autofac;
using DIApp.Models;

namespace DIApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Person person = new Person();
        //person.TakeRefuge();
        //person.Study();
        //person.GetTreatment();

        var container = ContainerConfiguration.Configure();

        using (var scope = container.BeginLifetimeScope())
        {
            IPerson person = scope.Resolve<IPerson>();
            person.TakeRefuge();
            person.Study();
            person.GetTreatment();

        }

         
    }
}