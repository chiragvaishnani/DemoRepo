namespace DIApp.Models
{
    public class Person : IPerson
    {
        private IHome _home;
        private IEducationalInstitute _school;
        private IHospital _hospital;

        public Person(IHome home, IHospital hospital, IEducationalInstitute school)
        {
            _home = home;
            _school = school;
            _hospital = hospital;
        }

        public void TakeRefuge()
        {
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

    }
}
