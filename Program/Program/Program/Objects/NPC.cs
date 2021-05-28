using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class NPC :Character
    {
        string name, shortN, longN;
        string gender, race;
        string[] odmianaPoj, odmianaMn;
        Weapon weap;
        List<Weapon> eqweap;
        //     List<Armor> eqarmor;
        //    List<Cloth> eqcloth; 
        public NPC()
        {

        }


        public NPC(string name, string shortN)
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

        public string[] OdmianaPoj
        {
            get { return odmianaPoj; }
            set { odmianaPoj = value; }
        }

        public string[] OdmianaMn
        {
            get { return odmianaMn;  }
            set { odmianaMn = value; }
        }

        public List<Weapon> EqWeap
        {
            get { return eqweap; }
            set { eqweap = value; }
        }

        public Weapon WeaponInHand
        {
            get { return weap; }
            set { weap = value; }
        }
    }
}
