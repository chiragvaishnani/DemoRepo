namespace DIApp.Models
{
    public class Hospital : IHospital
    {
        public void Cure(IPerson person)
        {
            Console.WriteLine("Cure viral flu");
        }
    }
}
