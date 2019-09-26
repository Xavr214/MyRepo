using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.ExpressionBodiedElements
{
    public class ExpressionBodied
    {

        public class Person
        {
            private string _firstName;
            private string _lastName;

            private Dictionary<int, string> Children => new Dictionary<int, string> { { 1, "Sasha" }, { 2, "Vasya" }, { 3, "Petya" } };

            //readonly property
            public string FirstName => _firstName;

            //property
            public string LastName
            {
                get => _lastName;
                set => _lastName = value;
            }

            //constructor
            public Person(string firstName) => _firstName = firstName;

            //method
            public void DisplayName() => Console.WriteLine(FirstName);
            public override string ToString() => FirstName + " " + LastName;

            //finalizer
            ~Person() => Console.WriteLine($"The {ToString()} destructor is executing.");

            //indexer
            public string this[int number] => Children[number];
        }

        class Example
        {
            static void M() //usage
            {
                //constructor call
                Person p = new Person("Mandy");
                
                //property call
                Console.WriteLine(p.FirstName);
                //p.FirstName = "123"; //not aplicable, expression-bodied property is read-only

                //method call
                p.DisplayName();

                //set call
                p.LastName = "Johnson";
                //get call
                Console.WriteLine(p.LastName);

                //indexer call
                Console.WriteLine($"Second child is { p[2]}");
            }
        }
    }
}
