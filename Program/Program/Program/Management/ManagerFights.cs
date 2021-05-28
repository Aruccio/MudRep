using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class ManagerFights
    {
        List<Character> chars;
        List<NPC> npcs;
        List<Player> players;

        public ManagerFights(params Character[] characters)
        {
            chars = characters.ToList();
            npcs = new List<NPC>();
            players = new List<Player>();
            for(int i=0; i<chars.Count; i++)
            {
                if (chars[i] is Player) players.Add(chars[i] as Player);
                else if (chars[i] is NPC) npcs.Add(chars[i] as NPC);
            }

            Fight(); //cala walka
        }

        public void Fight()
        {
            LastingTour();
        }
        public void LastingTour()
        {
            //aktualizacja walczacych
//            for (int i = 0; i < chars.Count; i++)
//                if (!chars[i].Infight) chars.Remove(chars[i]);

            //tura podzielona na 7 czesci)
            for(int i=1; i<=11;i++)
            {
                foreach(var p in players)
                {

                    if (p.WeaponInHand.Speed == 0) Coloring.Red("\nDRAMATYCZNY BLAD!!!");
                    else if (Convert.ToDouble(i % p.WeaponInHand.Speed) == 0.0) //jesli czesc dzieli sie przez predkosc broni
                    {
                        //atak
                        Console.WriteLine("["+i+"] "+ SFuns.Up(p.Name) + " wykonuje atak bronia: " + p.WeaponInHand.Name);
                    }
                }
                foreach(var n in npcs)
                {
                    if (n.WeaponInHand.Speed == 0) Coloring.Red("\nDRAMATYCZNY BLAD!!!");
                    else if (Convert.ToDouble(i % n.WeaponInHand.Speed) == 0.0) //jesli czesc dzieli sie przez predkosc broni
                    {
                        //atak
                        Console.WriteLine("[" + i + "] " + SFuns.Up(n.Name) + " wykonuje atak bronia: " + n.WeaponInHand.Name);
                    }
                }
            }

        }

    }
}
