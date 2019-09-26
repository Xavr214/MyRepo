namespace Examples.Generic
{
    public class ListItem<T> where T: struct
    {
        public T Value { get; set; }
        public ListItem<T> Next { get; set; }
        public ListItem(T value)
        {
            Value = value;
        }
    }
}
