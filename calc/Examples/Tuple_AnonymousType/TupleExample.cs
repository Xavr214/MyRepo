using System;

namespace Examples.Tuple_AnonymousType
{
    public class TupleExample
    {
        public void M()
        {
            var tuple1 = new Tuple<int, string, A>(123, "123", new A(432));
            var id = tuple1.Item1;
            var name = tuple1.Item2;
            var itemA = tuple1.Item3;

            var tuple2 = Method1();
            
            var tuple3 = (Id:22, Name:"from method2", ItemA : new A(22));
            id = tuple3.Id;
            name = tuple3.Item2; // = tuple3.Name;
            itemA = tuple3.Item3;// = tuple3.ItemA;

            var tuple4 = Method2();

            tuple1 = tuple2;
            //tuple1 = tuple3; //недопустимо, так как запись (int, string, A) предусматривает создание анонимного типа (см. ниже)
            //tuple1.Item1 = 123; // недопустимо, так как элементы tuple - readonly

            //anonymous
            var student1 = new { Id = 1, Name = "Vasya"};
            var student2 = new { Name = "Petya", Id = 2 };
            var student3 = new { Id = 3, Name = "Sasha" };

            id = student1.Id;
            name = student1.Name;

            //student1.Id = 123; // недопустимо, так как элементы анонимного типа - readonly
            //student1 = student2; // недопустимо, так как типы будут созданы разные
            student1 = student3;
        }

        private Tuple<int, string, A> Method1()
        {
            return new Tuple<int, string, A>(11, "from method1", new A(11));
        }

        private (int, string, A) Method2()
        {
            return (22, "from method2", new A(22));
        }


        private class A
        {
            private int Number { get; set; }
            public A(int number)
            {
                Number = number;
            }
        }
    }
}
