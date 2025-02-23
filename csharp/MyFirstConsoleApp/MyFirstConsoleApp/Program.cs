using System;

namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");

            OperatorExamples();
        }

        private static void OperatorExamples()
        {

            int width = 3;

            width++;

            int height = 2 + 4;
            int area = height * width;

            Console.WriteLine(area);

            string result = "The area";

            result = result + " is " + area;

            Console.WriteLine(result);

            bool truthValue = true;

            Console.WriteLine(truthValue);

            int someValue = 20;

            string msg = "";

            if (someValue == 24)
            {
                msg = "Yes, it's 24!";
            }
            Console.WriteLine(msg);

            if (someValue == 24)
            {
                msg = "The value was 24.";
            }
            else
            {
                msg = "The value wasn't 24.";
            }
                
            Console.WriteLine(msg);
        }
    }
}