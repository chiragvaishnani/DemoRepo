namespace DIDemoApp.Models
{
    public class Home : IHome
    {
        public void ProvideSchelter(Person person)
        {
            Console.WriteLine("Stay Home");
        }
    }
}
