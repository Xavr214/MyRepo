namespace Examples.Inheritance
{
    public class A
    {
        public int AProp { get; set; }
        public A(int a)
        {
            AProp = a;
        }

        public int M()
        {
            return 1;
        }
    }

    public class B : A
    {
        public int BProp { get; set; }
        public int CProp { get; set; }

        public B(int a, int b) : base(a)
        {
            BProp = b;
        }

        public B(int a, int b, int c) : this(a, b)
        {
            CProp = c;
        }

        public new int M()
        {
            var temp =  base.M();
            return temp + 1;
        }
    }

}
