using System;
using System.Diagnostics;

namespace Examples.DelegatesEvents
{
    //public delegate void EventHandler(object sender, EventArgs e);
    public delegate void PrintDelegate(int value);


    public class Delegates
    {
        public void M()//usage
        {
            PrintDelegate printDel = PrintNumber;
            //same result:
            //PrintDelegate printDel = new PrintDelegate(PrintNumber);

            printDel(100000);
            printDel(200);

            printDel = PrintMoney;

            printDel(10000);
            printDel(200);
        }

        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }
    }

    public delegate int MyDelegate(string value);
    public class Delegate2
    {
        public static int Method1(string name)
        {
            return name.Length;
        }

        public static int Method2(string name)
        {
            return name.Split(' ').Length;
        }

        public static void M()//usage
        {
            MyDelegate myDelegate = Method1;
            //same result: 
            //var myDelegate1 = new MyDelegate(Method1);

            int a = myDelegate("123");
            //a = 3

            myDelegate += Method2;
            a = myDelegate("123 123");
            //a = 2

            //receive all results from multicast delegate
            var param = "123 123";
            string result = string.Empty;
            foreach (MyDelegate del in myDelegate.GetInvocationList())
            {
                result += del(param) + " ";
            }
        }
    }


    public delegate void EventDelegate(string value);
    public class ClassWithEvent
    {
        //event have to be encapsulated into a class or interface
        public event EventDelegate OnValueChanged;

        //same result
        //private event EventDelegate _onValueChanged;
        //public event EventDelegate OnValueChanged
        //{
        //    add { lock (this) { _onValueChanged += value; } }
        //    remove { lock (this) { _onValueChanged -= value; } }
        //}

        //event with custom subscription logic
        private event EventDelegate _onValueChanged2;
        public event EventDelegate OnValueChanged2
        {
            add
            {
                lock (this)
                {
                    Debug.WriteLine("Subscribed");
                    _onValueChanged2 += value;
                }
            }
            remove
            {
                lock (this)
                {
                    Debug.WriteLine("Unsubscribed");
                    _onValueChanged2 -= value;
                }
            }
        }

        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                HandleEvent("Value changed. New value: " + value);
            }
        }

        private void HandleEvent(string value)
        {
            OnValueChanged?.Invoke(value);
            //same result:
            //if (onClick != null)
            //    onClick(value);
        }

        public class Subscriber
        {
            public void M() //usage
            {
                var classWithEvent = new ClassWithEvent();
                //subscribe
                classWithEvent.OnValueChanged += SomeAction;

                classWithEvent.Name = "Vasya";
                //result 
                // Value changed: New value: Vasya

                //multicasting
                //anonymous method
                classWithEvent.OnValueChanged += (value) => { Console.WriteLine("Caller id: " + classWithEvent.Id); };
                //same result:
                //classWithEvent.onValueChanged += value =>  Console.WriteLine("Caller id: " + classWithEvent.Id); 

                classWithEvent.Id = 120;
                classWithEvent.Name = "Petya";
                //result 
                // Value changed: New value: Petya
                // Caller Id: 120

                //unsubscribe
                classWithEvent.OnValueChanged -= SomeAction;

                classWithEvent.Id = 100;
                classWithEvent.Name = "Sasha";
                //result
                // Caller id: 100
            }

            //a method that can be handled with a delegate EventDelegate
            private void SomeAction(string parameter)
            {
                Console.WriteLine(parameter);
            }
        }


        public delegate int IntFunction(int value);
        public class AnonymoutMethod
        {
            public void M() //usage
            {
                //anonymous method
                IntFunction myIncrement = delegate (int x)
                {
                    return x + 1;
                };

                //same result:
                IntFunction myIncrement1 = (int x) =>
                {
                    return x + 1;
                };

                //same result
                IntFunction myIncrement2 = x => x + 1;

                //same result
                IntFunction myIncrement3 = new IntFunction(x => x + 1);

                var a = myIncrement(123);
                //a = 124
            }
        }

        public class FuncExample
        {
            static int Sum(int x, int y)
            {
                return x + y;
            }

            public void M()
            {
                Func<int, int, int> add = Sum;

                int result = add(10, 10);

                Func<int, int, int, string> add2 = (x, y, z) => (x + y + z).ToString();
                //Func<int, int, int, string> add2 += (x, y, z) => (x + y + z).ToString(); //multicasting is not available

                string result2 = add2(1, 2, 3);
            }
        }

        public class ActionExample
        {
            //return type is void
            static void MyConsoleWrite(int value1, int value2)
            {
                Console.WriteLine($"Value1 is {value1} and value2 is { value2 }");
            }

            public void M()//usage
            {
                Action<int, int> myConsoleWrite = MyConsoleWrite;

                myConsoleWrite(1, 2);
            }
        }

        public class PredicateExample
        {
            //return type is bool, one parameter
            static bool IsZero(int value1)
            {
                return value1 == 0;
            }

            public void M()//usage
            {
                Predicate<int> isZero = IsZero;

                bool result = isZero(0);
                bool result2 = isZero(1);
            }
        }
    }

}
