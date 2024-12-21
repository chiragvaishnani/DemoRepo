namespace TestApp
{
    public interface ICarBody
    {
        int WheelCount(int count);

        int DoorCount();

        int ModelNumber();

        int MakeYear();

      
    }

    public interface ICarFeature
    {
        bool Touchscreen();

        bool Sunroof();

    }

    public interface ICarEmployee
    {
        string EmployeeName();
    }
}
