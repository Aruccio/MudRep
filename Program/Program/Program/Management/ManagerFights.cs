using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Management;
using Program.Commands;
using System.Threading;

namespace Program
{
    public class ManagerFights
    {
        private Character player, cel;
        private PlayerCommands pc;

        public ManagerFights(Character player, Character cel)
        {
            this.player = player;
            this.cel = cel;
            PlayerCommands pc = new PlayerCommands(player as Player);
            Fight(); //cala walka
        }

        public void Fight()
        {
            string command = "";
            LastingTour();
            while (command == "dalej" || command == "walcz" || command == "walcz dalej" || command == "" && player.HP > 0 && cel.HP > 0)
            {
                Console.WriteLine();
                Manager.ReadCommand(player as Player, (player as Player).CurrentLoc, pc);
                LastingTour();
            }
        }

        public void LastingTour()
        {
            //tura podzielona na 11 czesci)
            for (int i = 1; i <= 11; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.15));
                if (player.WeaponInHand.Speed == 0) Coloring.Red("\nDRAMATYCZNY BLAD!!!");
                else if (Convert.ToDouble(i % player.WeaponInHand.Speed) == 0.0) //jesli czesc dzieli sie przez predkosc broni
                {
                    //atak
                    Attack(player, cel);
                    if (player.HP <= 0) { Coloring.Red(SFuns.Up(cel.Name) + " zabil cie. Umierasz.\n"); break; }
                    else if (cel.HP <= 0) { Coloring.DarkCyan(SFuns.Up(cel.Name) + " umiera.\n"); break; }
                }
                Thread.Sleep(TimeSpan.FromSeconds(0.15));
                if (cel.WeaponInHand.Speed == 0) Coloring.Red("\nDRAMATYCZNY BLAD!!!");
                else if (Convert.ToDouble(i % cel.WeaponInHand.Speed) == 0.0) //jesli czesc dzieli sie przez predkosc broni
                {
                    //atak
                    Attack(cel, player);
                    if (player.HP <= 0) { Coloring.Red(SFuns.Up(cel.Name) + " zabil cie. Umierasz.\n"); break; }
                    else if (cel.HP <= 0) { Coloring.DarkCyan(SFuns.Up(cel.Name) + " umiera.\n"); break; }
                }
            }
            Console.WriteLine("Kondycja wszystkich:");
            player.HP = player.HP < 0 ? 0 : player.HP;
            cel.HP = cel.HP <= 0 ? 0 : cel.HP;
            Console.WriteLine("- " + SFuns.Up(player.Name) + ": " + player.HP + ".");
            Console.WriteLine("- " + SFuns.Up(cel.Name) + ": " + cel.HP + ".");
        }

        public void Attack(Character p, Character c)
        {
            double atak = Maths.PoliczAtak(p);
            Console.WriteLine(SFuns.Up(p.Name) + " wykonuje atak bronia: " + p.WeaponInHand.Name + " zadajac " + atak + " obrazen.");
            c.HP -= Math.Round(atak, 2);
        }
    }
}

//public ManagerFights(params Character[] characters)
//{
//    chars = characters.ToList();
//    npcs = new List<NPC>();
//    players = new List<Player>();
//    for (int i = 0; i < chars.Count; i++)
//    {
//        if (chars[i] is Player) players.Add(chars[i] as Player);
//        else if (chars[i] is NPC) npcs.Add(chars[i] as NPC);
//    }

//    Fight(); //cala walka
//}

//public void LastingTour()
//{
//    //tura podzielona na 11 czesci)
//    for (int i = 1; i <= 11; i++)
//    {
//        foreach (var p in players)
//        {
//            if (p.WeaponInHand.Speed == 0) Coloring.Red("\nDRAMATYCZNY BLAD!!!");
//            else if (Convert.ToDouble(i % p.WeaponInHand.Speed) == 0.0) //jesli czesc dzieli sie przez predkosc broni
//            {
//                //atak
//                Console.WriteLine("[" + i + "] " + SFuns.Up(p.Name) + " wykonuje atak bronia: " + p.WeaponInHand.Name);
//                Attack(p);
//            }
//        }
//        foreach (var n in npcs)
//        {
//            if (n.WeaponInHand.Speed == 0) Coloring.Red("\nDRAMATYCZNY BLAD!!!");
//            else if (Convert.ToDouble(i % n.WeaponInHand.Speed) == 0.0) //jesli czesc dzieli sie przez predkosc broni
//            {
//                //atak
//                Console.WriteLine("[" + i + "] " + SFuns.Up(n.Name) + " wykonuje atak bronia: " + n.WeaponInHand.Name);
//                Attack(n);
//            }
//        }
//    }
//}