using System;

namespace EnumerableTanki
{
    public class Tank
    {
        private static Random rnd = new Random();
        public bool IsDead { get; set; }

        public string Name { get; set; }

        public Tank(string name)
        {
            Name = name;
        }

        public static void Fight(Tank tank1, Tank tank2)
        {
            if (rnd.Next(100) > 50)
            {
                tank1.IsDead = true;
            }
            else
            {
                tank2.IsDead = true;
            }
        }
    }
}
