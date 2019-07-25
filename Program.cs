using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class MyCustomException : System.Exception
    {
        public MyCustomException(string message) : base(message) // pass the message up to the base class    
        {
        } 
        class Tester
        {
            public void Run()
            {
                try
                {
                    Console.WriteLine("Open file here");
                    double a = 0;
                    double b = 5;
                    Console.WriteLine("{0} / {1} = {2}", a, b, DoDivide(a, b));

                    Console.WriteLine("This line may or may not print");
                }
                // most derived exception type first    
                catch (System.DivideByZeroException e)
                {

                    Console.WriteLine("\nDivideByZeroException! Msg: {0}",e.Message);
                    Console.WriteLine("\nHelpLink: {0}\n", e.HelpLink);
                }
                // catch custom exception     
                catch (MyCustomException e)
                {
                    Console.WriteLine("\nMyCustomException! Msg: {0}", e.Message);
                    Console.WriteLine("\nHelpLink: {0}\n", e.HelpLink);
                }
                catch // catch any uncaught exceptions     
                {
                    Console.WriteLine("Unknown exception caught");
                }
                finally
                {

                    Console.WriteLine("Close file here.");
                }
            }
            // do the division if legal    
            public double DoDivide(double a, double b)
            {
                if (b == 0)
                {
                    DivideByZeroException e = new DivideByZeroException();

                    e.HelpLink = "http://www.libertyassociates.com";
                    throw e;
                }
                if (a == 0)

                {
                    // create a custom exception instance   
                    MyCustomException e = new MyCustomException("Can't have zero dividend");
                    e.HelpLink = "http://www.libertyassociates.com/NoZeroDividend.htm"; throw e;
                }
                return a / b;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Main...");
            Tester t = new Tester();
            t.Run();
            Console.WriteLine("Exit Main...");
        }
    }
}
