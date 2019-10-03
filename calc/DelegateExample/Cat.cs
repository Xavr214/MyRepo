namespace DelegateExample
{
    public class Cat
    {
        public delegate void OnChangeDelegate
            (string oldValue, string newValue);

        public event OnChangeDelegate OnNameChanged;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                    OnNameChanged?.Invoke(_name, value);

                _name = value;
            }
        }
    }
}
