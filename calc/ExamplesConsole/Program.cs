using Examples.Compare;
using Examples.Dispose;
using Examples.Exception;
using Examples.Fraction;
using System;

namespace ExamplesConsole
{
    public class Program
    {        static void Main(string[] args)
        {
            #region trycatch

            try
            {
                var fraction = new Fraction(2, 0);

                try
                {
                    throw new ArithmeticException("My exception 12345");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (FractionDivideByZeroException ex) when (ex.Data.Count > 0)
            {
                Console.WriteLine($"{ex.Message}. Exception occurs: {ex.ExceptionOccurs.ToString("MM:dd:yyyy")}. Fraction cannot be created: {ex.Data["FractionDeatils"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Other Exception");
                //throw new Exception("New exception");
            }
            //catch
            //{
            //    throw;
            //}
            finally
            {
                Console.WriteLine("Finally");
            }

            //try
            //{
            //    invalid
            //}
            
            try
            {
                var fraction = new Fraction(2, 1);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            Console.ReadLine();
            #endregion

            #region IComparable

            var studentArr = new[] {
                new Student() { Name = "Vasya", StudentId = 2 },
                new Student() { Name = "Petya", StudentId = 3 },
                new Student() { Name = "Sasha", StudentId = 1 }
            };
            Array.Sort(studentArr);
            foreach (var student in studentArr)
            {
                Console.WriteLine(student.Name);
            }
            Console.ReadLine();

            Array.Sort(studentArr, new StudentComparer());
            foreach (var student in studentArr)
            {
                Console.WriteLine(student.Name);
            }
            Console.ReadLine();
            #endregion

            #region IDisposable

            var someVar1 = new SomeClass();
            //some code
            someVar1.Dispose();


            var someVar2 = new SomeClass();
            try
            {
                //some code
            }
            finally
            {
                someVar2.Dispose();
            }
            
            using (var someVar3 = new SomeClass())
            {
                //someCode
            }

            var someVar4 = new SomeClass();
            //some code

            #endregion
            
        }
    }
}
