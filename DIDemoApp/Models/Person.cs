namespace DIDemoApp.Models
{
    public class Person : IDisposable
    {
        private IHome _home;
        private IEductionalInstitute _school;
        private IHospital _hospital;

        public Person(IHome home, IEductionalInstitute school, IHospital hospital) //con DI 
        {
            _home = home;
            _school = school;
            _hospital = hospital;
        }
 
        public void TakeRefuge()
        {
            int a = 10;
            _home.ProvideSchelter(this);
        }

        public void Study()
        {
            _school.Teach(this);
        }

        public void GetTreatment()
        {
            _hospital.Cure(this);
        }

        public void Dispose()
        {
            
        }

        ~Person() { } //des

        
    }
}
