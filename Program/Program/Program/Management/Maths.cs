using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Management
{
    public static class Maths
    {
        public static void PoliczHP(Character ch)
        {
            ch.HP = 15 * ch.Wytrzymalosc / 3;
        }

        public static double PoliczAtak(Character ch)
        {
            Random r = new Random();
            double rng = r.Next(10, 50);
            double at = Math.Round((ch.WeaponInHand.Damage * ch.Sila * 1.3 / rng), 2);
            return at;
        }
    }
}