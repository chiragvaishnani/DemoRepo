namespace DIApp.Models
{
    public class School : IEducationalInstitute
    {
        public void Teach(IPerson person)
        {
            Console.WriteLine("Learn DI Concepts in School");
        }
    }
}
