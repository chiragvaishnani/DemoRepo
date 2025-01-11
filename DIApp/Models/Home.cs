namespace DIApp.Models
{
    public class Home : IHome
    {
        public void ProvideSchelter(IPerson person)
        {
            Console.WriteLine("Stay Home");
        }
    }
}
