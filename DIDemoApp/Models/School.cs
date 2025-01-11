namespace DIDemoApp.Models
{
    public class School : IEductionalInstitute
    {
        public void Teach(Person person)
        {
            Console.WriteLine("Learn DI Concepts in school");
        }
    }
}
