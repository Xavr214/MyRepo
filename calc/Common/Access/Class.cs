namespace Examples.Access
{
    //some classes we want to check for accessibility from another places

    /// <summary>
    /// public namespace members are available from anywhere
    /// </summary>
    public class SimplePublicClass
    {

    }

    /// <summary>
    /// internal namespace members are available only from within the assembly
    /// </summary>
    internal class SimpleInternalClass
    {

    }

    //default access modifier is internal
    /// <summary>
    /// same behaviour as internal
    /// </summary>
    class SimpleInternalClass2
    {

    }

    //not possible to write namespace members with access level modifier lower than internal 
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

    public class CurrentClass
    {
        public void M()
        {
            //public namespace element is available in other class of the project
            SimplePublicClass a;

            //internal namespace element is available in other class of the project
            SimpleInternalClass b;

            //internal namespace member is available in other class of the project
            SimpleInternalClass2 b2;

            //public inner member is available within the current class
            PublicInnerElement aaa;

            //internal inner member is available within the current class
            InternalInnerElement bb;

            //private member is available within the current class
            PrivateInnerElement cc;

            //private member is available within the current class
            PrivateInnerElement2 cc2;

            //protected member is available within the current class
            ProtectedInnerElement dd;

            //private protected member is available within the current class
            PrivateProtectedInnerElement ee;

            //protected internal member is available within the current class
            ProtectedInternalInnerElement ff;
        }

        //inner classes can be replaced by fields/properties/etc.
        //eg: public string Name {get;set;} , private protected int age;

        /// <summary>
        /// public inner element is available from anywhere
        /// </summary>
        public class PublicInnerElement
        { }

        /// <summary>
        /// internal inner element is available from within the project(assembly)
        /// </summary>
        internal class InternalInnerElement
        {

        }

        /// <summary>
        /// private member is available only within the current class
        /// </summary>
        private class PrivateInnerElement
        {

        }

        //default access modifier for inner elements is private
        /// <summary>
        /// private member is available only within the current class
        /// </summary>
        class PrivateInnerElement2
        {

        }

        /// <summary>
        /// protected member is available only within the current class and in all inherited classes
        /// </summary>
        protected class ProtectedInnerElement
        {

        }

        /// <summary>
        /// private protected members are available only inside current class and inherited classes placed in the current project
        /// </summary>
        private protected class PrivateProtectedInnerElement
        {

        }

        /// <summary>
        /// protected internal mempers are available anywhere inside the current assembly or in inherited classes of other assemblies
        /// </summary>
        protected internal class ProtectedInternalInnerElement
        {

        }
    }

    /// <summary>
    /// Somewhere in this assembly(project). Another class is inherited from current.
    /// </summary>
    public class CurrentClassChild : CurrentClass
    {
        public void MM()
        {
            //public namespace member is available in other class
            SimplePublicClass a;

            //internal namespace member is available in other class of the project
            SimpleInternalClass b;

            //internal namespace member is available in other class of the project
            SimpleInternalClass2 b2;

            //public inner member is available in other class
            PublicInnerElement aaa;

            //internal inner member is available within the current class
            InternalInnerElement bb;

            //private inner element is not available in inherited class
            //PrivateInnerElement cc;

            //private inner element is not available in inherited class
            //PrivateInnerElement2 cc2;

            //protected member is available in inherited class
            ProtectedInnerElement dd;

            ///private protected member is available in inherited classes placed in the current assembly
            ProtectedInnerElement ee;

            //protected internal member is available in inherited classes placed in the current assembly
            ProtectedInternalInnerElement ff;
        }
    }
}

