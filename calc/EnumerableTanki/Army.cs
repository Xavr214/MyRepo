using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableTanki
{
    public class Army : IEnumerable<Tank>
    {
        private List<Tank> _tankList;
        private IEnumerator<Tank> _enumerator;

        public Army(List<Tank> tankList, IEnumerator<Tank> enumerator)
        {
            _tankList = tankList;
            _enumerator = enumerator;
        }
        
        public IEnumerator<Tank> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
