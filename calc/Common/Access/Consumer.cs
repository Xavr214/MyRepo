using Examples.Access;

namespace Common.Access
{
    /// <summary>
    /// somewhere another place in the project
    /// </summary>
    public class Consumer
    {
        //public namespace member is available in other class of the project
        SimplePublicClass a;

        //internal namespace member is available in other class of the project
        SimpleInternalClass b;

        //internal namespace member is available in other class of the project
        SimpleInternalClass2 b2;

        //public inner member is available in other class of the project
        CurrentClass.PublicInnerElement aaa;

        //internal inner member is available in other class of the project
        CurrentClass.InternalInnerElement bb;

        //private member is not available from other class of the project
        //CurrentClass.PrivateInnerElement cc;

        //private member is not available from other class of the project
        //CurrentClass.PrivateInnerElement2 cc2;

        //protected inner member is not available outside the inheritance branch
        //CurrentClass.ProtectedInnerElement dd;

        //private protected inner member is not available from other class of the assembly otherwise it was not inherited
        //CurrentClass.PrivateProtectedInnerElement ee;

        //protected internal member is available in all classes placed in the current assembly
        CurrentClass.ProtectedInternalInnerElement ff;
    }
}
