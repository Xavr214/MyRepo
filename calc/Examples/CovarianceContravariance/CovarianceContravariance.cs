namespace Examples.CovarianceContravariance
{
    public class Small
    {
    }
    public class Big : Small
    {

    }
    public class Bigger : Big
    {

    }

    public delegate Small covarDelSmallBig(Big mc); 
    public delegate Big covarDelBigSmall(Small mc);

    /// <summary>
    /// Covariance with types.
    /// Covariance enables you to pass a derived type where a base type is expected.
    /// </summary>
    public class CovarianceTypes
    {
        Small small1 = new Small();
        Small small2 = new Big();
        Small small3 = new Bigger();
        //Big big1 = new Small(); //not applicable because of derived type expected
        Big big2 = new Big();
        Big big3 = new Bigger();
        //Bigger bigger1 = new Small(); //not applicable because of derived type expected
        //Bigger bigger2 = new Big(); //not applicable because of derived type expected
        Bigger bigger3 = new Bigger();
    }

    /// <summary>
    /// Covariance with delegates.
    /// Covariance enables you to pass a derived type where a base type is expected.
    /// </summary>
    public class CovarianceDelegates
    {
        static Big Method1(Big bg)
        {
            //some code
            return new Big();
        }
        static Small Method2(Big bg)
        {
            //some code
            return new Small();
        }
        static Big Method3(Small sm)
        {
            //some code;
            return new Big();
        }

        static void M() //usage
        {
            covarDelSmallBig del1 = Method1;

            Small sm1 = del1(new Big());

            del1 = Method2;
            sm1 = del1(new Big());


            covarDelBigSmall del2 = Method3;
            Big bg1 = del2(new Small());
            //del2 = Method2; //not applicable because of derived type expected
            //del2 = Method1; //not applicable because of derived type expected

            sm1 = del2(new Big());
        }
    }

    /// <summary>
    /// Contravaariance with parameters.
    /// Cotravariance allows a method with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class.
    /// </summary>
    public class ContravarianceParameters
    {
        static Big Method1(Big bg)
        {
            //some code
            return new Big();
        }
        static Small Method2(Big bg)
        {
            //some code
            return new Small();
        }

        static Small Method3(Small sml)
        {
            //some code
            return new Small();
        }
        static void Main(string[] args)
        {
            covarDelSmallBig del = Method1;
            del += Method2;
            //Method3 has a parameter of Small class whereas delegate expects a parameter of Big class.
            //You still can use Method3 with the delegate
            del += Method3;

            Small sm = del(new Big());
        }
    }
}
