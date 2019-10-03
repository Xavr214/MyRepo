using System.Collections;
using System.Collections.Generic;

namespace EnumerableTanki
{
    public class TankEnumerator2 : IEnumerator<Tank>
    {
        private int tankIndex;
        private Tank[] tankArr;
        public TankEnumerator2(List<Tank> tanks)
        {
            tankArr = tanks.ToArray();
            tankIndex = tankArr.Length;
        }

        public Tank Current => tankArr[tankIndex];
        object IEnumerator.Current => tankArr[tankIndex];

        public bool MoveNext()
        {
            tankIndex--;
            return tankIndex >= 0;
        }

        public void Reset()
        {
            tankIndex = tankArr.Length;
        }

        public void Dispose()
        { }
    }
}
