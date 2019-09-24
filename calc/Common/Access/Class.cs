namespace Examples.Access
{
    public class A
    {

    }

    internal class B
    {

    }

    class B2
    {

    }

    //private class C
    //{

    //}

    //protected class D
    //{

    //}

    //private protected class E
    //{

    //}

    //protected internal class F
    //{

    //}

    public class AA
    {
        public void M()
        {
            A a;
            B b;
            B2 b2;
            AAA aaa;
            BB bb;
            CC cc;
            CC2 cc2;
            DD dd;
            EE ee;
            FF ff;
        }

        public class AAA
        { }

        internal class BB
        {

        }

        private class CC
        {

        }

        class CC2
        {

        }

        protected class DD
        {

        }

        private protected class EE
        {

        }

        protected internal class FF
        {

        }
    }

    public class AChild : AA
    {
        public void MM()
        {
            A a;
            B b;
            B2 b2;
            AAA aaa;
            BB bb;
            //CC cc;
            //CC2 cc2;
            DD dd;
            EE ee;
            FF ff;
        }
    }
}

