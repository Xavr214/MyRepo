using System.Collections.Generic;

namespace EnumerableTanki
{
    public class Program
    {
        static void Main(string[] args)
        {
            var t34List = new List<Tank>();
            var panteraList = new List<Tank>();

            for (int i = 0; i < 3; i++)
            {
                t34List.Add(new Tank("t34 - " + i));
                panteraList.Add(new Tank("pantera - " + i));
            }

            var armyT34 = new Army(t34List, new TankEnumerator(t34List));
            var armyPantera = new Army(panteraList, new TankEnumerator2(panteraList));

            foreach (var tankT34 in armyT34)
            {
                foreach (var tankPantera in armyPantera)
                {
                    Tank.Fight(tankT34, tankPantera);
                }
            }
        }
    }
}
