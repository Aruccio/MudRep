using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Commands
{
    public class PlayerCommands
    {
        Player p;
        public PlayerCommands(Player p)
        {
            this.p = p;
        }
        /// <summary>
        /// drukuje ekwipunek gracza
        /// </summary>
        public void I()
        {
            Shower.ShowCharacter(p, true);
            Console.WriteLine("Masz przy sobie: ");
            for(int i=0; i<p.EqWeap.Count-1;i++)
            {
                Console.Write("+ "+p.EqWeap[i].OdmianaPoj[3]+",");
            }
            Console.Write("+ "+p.EqWeap[p.EqWeap.Count-1].OdmianaPoj[3]+".\n");

        }

        /// <summary>
        /// oglada wskazany cel
        /// </summary>
        /// <param name="kogo">kogo, co</param>
        public void Ob(string kogo)
        {
            if (kogo[0] == ' ') kogo = kogo.Substring(1).ToLower();
            //tymczasowe obiekty potrzebne przy szukaniu co ogladamy
            Object obj = new Object();
            NPC n = new NPC();
            Player pl = new Player();
            Itemy it = new Itemy();
            Weapon weap = new Weapon();
            Armor arm = new Armor();

            List<Object> objs = new List<Object>();
            objs.Add(p); //dla obejrzenia siebie

            //dla obejrzenia postaci na lokacji
            for (int i = 0; i < p.CurrentLoc.Characters.Count; i++)
            {
                objs.Add(p.CurrentLoc.Characters[i]);
            }
            //dla obejrzenia ekwipunku-broni gracza
            for (int i = 0; i < p.EqWeap.Count; i++)
            {
                objs.Add(p.EqWeap[i]);
            }

            //sprawdzanie dopelniacza -> szukamy celu ogladania
            for (int i = 0; i < objs.Count; i++)
            {
                if (objs[i] is NPC)
                {
                    n = objs[i] as NPC;
                    if (kogo == n.OdmianaPoj[3])
                    {
                        Shower.ShowCharacter(n, false);
                        break;
                    }
                }
                else if (objs[i] is Player)
                {
                    pl = objs[i] as Player;
                    if (kogo == "siebie")
                    {
                        Shower.ShowCharacter(p, true);
                        break;
                    }
                    else if (kogo == pl.OdmianaPoj[3])
                    {
                        Shower.ShowCharacter(pl, false);
                        break;
                    }
                }
                else if (objs[i] is Weapon)
                {
                    weap = objs[i] as Weapon;
                    string third = weap.OdmianaPoj[3].Split(' ')[2];
                    if (kogo == weap.OdmianaPoj[3] || kogo == third)
                    {
                        Shower.ShowItem(weap, false);
                        break;
                    }
                }
            }



        }

        /// <summary>
        /// Mowisz: Tresc
        /// </summary>
        /// <param name="tresc">co mowi</param>
        public void Powiedz(string tresc)
        {
            tresc = tresc.Substring(1).ToLower();
            Console.WriteLine("Mowisz: " + SFuns.Up(tresc));
        }

        /// <summary>
        /// pokazuje obecna lokacje gracza
        /// </summary>
        public void Sp()
        {
            Shower.ShowLocation(p.CurrentLoc, true);
        }

        /// <summary>
        /// Rozpoczyna walke z celem
        /// </summary>
        /// <param name="kogo">cel</param>
        public void Zabij(string kogo)
        {
            kogo = kogo.Replace(" ", "").ToLower();
            for(int i=0; i<p.CurrentLoc.Characters.Count; i++)
            {
                if(p.CurrentLoc.Characters[i] is Player)
                {
                    Player cel = p.CurrentLoc.Characters[i] as Player;
                    if (cel.OdmianaPoj[3] == kogo)
                    {
                        Console.WriteLine("Atakujesz " + SFuns.Up(cel.OdmianaPoj[3]) + ".");
                        p.Infight = true;
                        cel.Infight = true;
                        ManagerFights mf = new ManagerFights(p, cel);
                        break;
                    }
                }
                else if (p.CurrentLoc.Characters[i] is NPC)
                {
                    NPC cel = p.CurrentLoc.Characters[i] as NPC;
                    if (cel.OdmianaPoj[3] == kogo)
                    {
                        Console.WriteLine("Atakujesz " + SFuns.Up(cel.OdmianaPoj[3]) + ".");
                        p.Infight = true;
                        cel.Infight = true;
                        ManagerFights mf = new ManagerFights(p, cel);
                        break;
                    }
                }
            }

        }
    }
}
