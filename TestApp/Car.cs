using System.Reflection.Metadata.Ecma335;

namespace TestApp
{
    public class BaseCar : ICarBody, ICarFeature
    {
        //default ctor
        public BaseCar()
        {
                
        }

        //parm ctor
        public BaseCar(int MakeYear)
        {
            MakeYear = MakeYear;
        }

        //property default
        public string Name { get { return "Tiago"; }  }

        
        //variable
        public int DoorNumber = 4;

        public string Print(string companyName = "tata")
        {
            //return companyName + " " +Name + " " + MakeYear + " " + DoorNumber;
            return string.Format("companyName : {0}, Name: {1}, MakeYear : {2}, DoorNumber : {3}", companyName , Name , MakeYear , DoorNumber);
            //return $"companyName {companyName} Name  {Name} MakeYear {MakeYear}  DoorNumber {DoorNumber}";
        }

        public int WheelCount(int count)
        {
            return count;
        }

        public int DoorCount()
        {
            return 5;
        }

        public int ModelNumber()
        {
            return 1001;
        }

        public int MakeYear()
        {
            return 2024;
        }

        public bool Touchscreen()
        {
            return true;
        }

        public bool Sunroof()
        {
            return false;
        }

        public int enginePower()
        {
            throw new NotImplementedException();
        }
    }
}
