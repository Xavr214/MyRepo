namespace Examples.Generic
{
    public class Usage
    {
        public void M()//usage
        {
            var myList = new LinkedList<int>(); //list of int elements without root element
            myList.Add(1); //okay
            //myList.Add("2"); //not okay, because T type for myList is int

            //var myList2 = new LinkedList(); //not okay because <T> is not specified

            var myList3 = new LinkedList<decimal>(new ListItem<decimal>(2)); //list of decimals that contain a root element with 2 inside
            //var myList4 = new LinkedList<decimal>(new ListItem<int>(3)); //not okay because List and ListItem T types have to be the same

        }
    }
}
