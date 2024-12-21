namespace TestApp;

class Program : BaseCar
{

    public static void Main(string[] args)
    {
        //tata car class
        TataCars tcars = new TataCars();

        tcars.TataCarSafty();
        tcars.WheelCount(4);

        MarutiCars maruti = new MarutiCars();
        maruti.MarutiCarSafty(); //maruti
        maruti.MakeYear(); //base

        MahindraCars mahindra = new MahindraCars();
        mahindra.MahindraCarSafty();
        mahindra.MakeYear(); //base

        Console.WriteLine(tcars.TataCarSafty() + " " + tcars.WheelCount(4));
        Console.WriteLine(maruti.MarutiCarSafty() + " " + maruti.MakeYear());
        Console.WriteLine(mahindra.MahindraCarSafty() + " " + mahindra.MakeYear());

    }

}



