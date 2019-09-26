using System;

namespace Examples.Generic
{
    /// <summary>
    /// A list of T items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
        where T : struct, //type 'struct' means value type
                  IEquatable<T> //because i need .Equals() somewhere in the code
    {
        public ListItem<T> Root { get; private set; }
                
        public LinkedList()
        {

        }

        public LinkedList(ListItem<T> root)
        {
            Root = root;
        }
        
        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new ListItem<T>(value);
            }
            else
            {
                var last = Root;
                while (last.Next != null) //check if it is the end of a list
                {
                    last = last.Next; //go to next element
                }
                last.Next = new ListItem<T>(value);
            }
        }


        public bool Contains(T value)
        {
            if (Root == null)
                return false;

            var last = Root;
            while (last.Next != null) //check if it is the end of a list
            {
                if (last.Value.Equals(value))//if value is found
                    return true;
                last = last.Next; //go to next element
            }

            return false;
        }
    }
}
