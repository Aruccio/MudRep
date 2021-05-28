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
        string name, shortN, longN;
        string gender, race;
        string[] odmiana;
        Location currentLoc, startLoc;
        Weapon weap;
        List<Weapon> eqweap;
   //     List<Armor> eqarmor;
    //    List<Cloth> eqcloth; 
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

        public string[] OdmianaPoj
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
        //public List<Armor> EqArmor
        //{
        //    get { return eqarmor; }
        //    set { eqarmor = value; }
        //}
        
        //public List<Cloth> EqCloth
        //{
        //    get { return eqcloth; }
        //    set { eqcloth = value; }
        //}
    }
}
