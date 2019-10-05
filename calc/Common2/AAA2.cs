using Examples.Access;

namespace Common2
{
    /// <summary>
    /// somewhere another place in another project
    /// </summary>
    public class AAA2 : CurrentClass
    {
        public void MMM()
        {
            //public inner members are availble out of the assembly
            SimplePublicClass a;

            //internal members are not availble out of the assembly(project)
            //SimpleInternalClass b;

            //internal members are not availble out of the assembly(project)
            //SimpleInternalClass2 b2;

            //public inner members are availble out of the assembly
            PublicInnerElement aaa;

            //internal inner elements are not available out of the assembly
            //InternalInnerElement bb;

            //private member is not available from other class of another project even inherited 
            //PrivateInnerElement cc;

            //private member is not available from other class of another project even inherited 
            //PrivateInnerElement2 cc2;

            //protected element is availble in inherited class even declared in another project
            ProtectedInnerElement dd;

            //private protected member is not available in inherited class of another project
            //PrivateProtectedInnerElement ee;

            //protected internal member is available in inherited class of another project
            ProtectedInternalInnerElement ff;
        }
    }

    public class AAA3
    {
        public void MMM()
        {
            //public namespace members are availble out of the assembly
            SimplePublicClass a;

            //internal members are not availble out of the assembly(project)
            //SimpleInternalClass b;

            //internal members are not availble out of the assembly(project)
            //SimpleInternalClass2 b2;

            //public inner members are availble out of the assembly
            CurrentClass.PublicInnerElement aaa;

            //internal inner elements are not available out of the assembly
            //CurrentClass.InternalInnerElement bb;

            //private member is not available from other class of another project
            //CurrentClass.PrivateInnerElement cc;

            //private member is not available from other class of another project
            //CurrentClass.PrivateInnerElement2 cc2;

            //protected element is availble in another project otherwise it is used in inherited type
            //CurrentClass.ProtectedInnerElement dd;

            //private protected member is not available in some class of another project
            //CurrentClass.PrivateProtectedInnerElement ee;

            //protected internal member is not available in some class of another project
            //CurrentClass.ProtectedInternalInnerElement ff;
        }
    }
}
