namespace DIDemoApp.Models
{
    public class Hospital : IHospital
    {
        public void Cure(Person person)
        {
            Console.WriteLine("Cure viral flu");
        }
    }
}
