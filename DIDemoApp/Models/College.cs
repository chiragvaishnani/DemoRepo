namespace DIDemoApp.Models
{
    public class College : IEductionalInstitute
    {
        public void Teach(Person person)
        {
            Console.WriteLine("Learn DI Concepts in college");
        }
    }
}
