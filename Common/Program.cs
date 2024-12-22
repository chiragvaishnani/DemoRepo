namespace Common;
using System.IO;  // include the System.IO namespace

public class Common
{
    public static void Main(string[] args)
    {
        ////file class methods

        ////File.WriteAllText("D:/Test/test.txt","This is a text content 123");

        //string readText = File.ReadAllText("D:/Test/test1.txt");  // Read the contents of the file
        //Console.WriteLine("test1.txt content => " + readText);

        try
        {
            PrintNumbers();
        }
        catch (Exception e)
        {
            //handle
            File.WriteAllText("D:/Test/error.txt", $"{DateTime.Now} => Error message : {e.Message} \n Stacktrace : {e.StackTrace.ToString()}");


            //throw;
            //return string.Empty;
        }
        finally {
            //code
        }


    }


    private static void PrintNumbers()
    {
        try
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Console.WriteLine(numbers[10]);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
