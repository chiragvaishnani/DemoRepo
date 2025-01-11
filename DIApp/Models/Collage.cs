namespace DIApp.Models
{
    public class Collage : IEducationalInstitute
    {
        public void Teach(IPerson person)
        {
            Console.WriteLine("Learn DI Concepts in Collage");
        }

      
    }
}
