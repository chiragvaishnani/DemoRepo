using DIDemoApp.Models;

namespace DIDemoApp;

internal class Program
{
    static void Main(string[] args)
    {
        Home home = new Home();
        School school = new School();
        College college = new College();    
        Hospital hospital = new Hospital();

        Person person1 = new Person(home, school, hospital);
        person1.TakeRefuge();
        person1.Study();
        person1.GetTreatment();

        Person person = new Person(home, college, hospital);
        person.TakeRefuge();
        person.Study();
        person.GetTreatment();
    }
}