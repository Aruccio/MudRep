using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Player : Object
    {
        string name, shortN, longN;
        string gender, race;
        string[] odmiana;
        Location currentLoc, startLoc;
        List<Thing> eq;
        public Player()
        {

        }


        public Player(string name, string shortN)
        {
            this.name = name;
            this.shortN = shortN;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ShortN
        {
            get { return shortN; }
            set { shortN = value; }
        }

        public string LongN
        {
            get { return longN; }
            set { longN = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Race
        {
            get { return race; }
            set { race = value; }
        }

        public new string[] OdmianaPoj
        {
            get { return odmiana; }
            set { odmiana = value; }
        }

        public Location StartLoc
        {
            get { return startLoc; }
            set { startLoc = value; }
        }

        public Location CurrentLoc
        {
            get { return currentLoc; }
            set { currentLoc = value; }
        }

        public List<Thing> Eq
        {
            get { return eq; }
            set { eq = value; }
        }
    }
}
