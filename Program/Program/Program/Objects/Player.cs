using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    /// <summary>
    /// Klasa gracza
    /// </summary>
    public class Player:Character
    {
        public Player()
        {

        }


        public Player(string name, string shortN)
        {
            Name = name;
            Short = shortN;
        }

        public string Long { get; set; }

        public string Gender { get; set; }

        public string Race { get; set; }

        public Location StartLoc { get; set; }

        public Location CurrentLoc { get; set; }

        public List<Weapon> EqWeap { get; set; }

        public Weapon WeaponInHand { get; set; }

    }
}
