using System;

namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDelegate method = Print;

            method("myvalue");

            method = PrintWithText;

            method("myvalue");
            Console.ReadKey();

            var cat1 = new Cat();
            cat1.Name = "Barsik";

            cat1.OnNameChanged += PrintOldNew;
            cat1.Name = "Barsik1";

            Console.ReadKey();
        }

        private static void Print(string value)
        {
            Console.WriteLine(value);
        }

        private static void PrintWithText
            (string value)
        {
            Console.WriteLine("Value: " + value);
        }

        private static void PrintOldNew
            (string oldValue, string newValue)
        {
            Console.WriteLine($"Cat name was changed! Old value: {oldValue}, new value: {newValue}");
        }
    }
}
