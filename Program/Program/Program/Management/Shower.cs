using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Shower
    {
        public Shower()
        {
        }

        public static void Cechy(Character ch)
        {
            if (ch.Sila == 120) Console.WriteLine("Jestes " + ch.SilaStr[0] + ".");
            else Console.WriteLine("Jestes " + ch.SilaStr[0] + " i brakuje ci " + ch.SilaStr[1] + " by wyzej ocenic swoja sile.");

            if (ch.Zrecznosc == 120) Console.WriteLine("Jestes " + ch.ZrecznoscStr[0] + ".");
            else Console.WriteLine("Jestes " + ch.ZrecznoscStr[0] + " i brakuje ci " + ch.ZrecznoscStr[1] + " by wyzej ocenic swoja zrecznosc.");

            if (ch.Wytrzymalosc == 120) Console.WriteLine("Jestes " + ch.WytrzymaloscStr[0] + ".");
            else Console.WriteLine("Jestes " + ch.WytrzymaloscStr[0] + " i brakuje ci " + ch.WytrzymaloscStr[1] + " by wyzej ocenic swoja wytrzymalosc.");

            if (ch.Intelekt == 120) Console.WriteLine("Jestes " + ch.IntelektStr[0] + ".");
            else Console.WriteLine("Jestes " + ch.IntelektStr[0] + " i brakuje ci " + ch.IntelektStr[1] + " by wyzej ocenic swoj intelekt.");

            if (ch.Odwaga == 120) Console.WriteLine("Jestes " + ch.OdwagaStr[0] + ".");
            else Console.WriteLine("Jestes " + ch.OdwagaStr[0] + " i brakuje ci " + ch.OdwagaStr[1] + " by wyzej ocenic swoja odwage.");
        }

        /// <summary>
        /// pokazuje "Jestes Sierya, short" albo w 3. osobie. Nic
        /// </summary>
        /// <param name="p"> postac </param>
        /// <param name="tomyself"> true jesli to siebie oglada</param>
        public static void ShowCharacter(Character ch, bool tomyself)
        {
            if (ch is NPC)
            {
                NPC n = ch as NPC;

                Console.Write("Masz przed soba ");
                Coloring.Cyan(SFuns.Up(n.Odm.Biernik) + ". ");
                Console.WriteLine(Splice("Jest to " + n.Short + " " + n.Gender + " (" + n.Race + ")."));
            }
            else if (ch is Player)
            {
                Player p = ch as Player;
                if (p != null)
                {
                    if (tomyself)
                    {
                        Console.Write("Jestes ");

                        Coloring.Cyan(p.Odm.Mianownik + ", ");
                        Console.WriteLine(p.Short + " " + p.Gender + " (" + p.Race + ").");
                    }
                    else
                    {
                        Console.Write("Masz przed soba ");
                        Coloring.Cyan(p.Odm.Biernik + ". ");
                        Console.WriteLine(Splice("Jest to " + p.Short + " " + p.Gender + " (" + p.Race + ")."));
                    }
                }
                else
                {
                    Coloring.Red("[INFO] ");
                    Console.WriteLine("Postac nie istnieje.");
                }
            }
        }

        /// <summary>
        /// Pokazuje opis itema
        /// </summary>
        /// <param name="item">Item ktory ma przeczytac</param>
        /// <param name="ocen">true dla "ocen", a nie obejrzyj</param>
        public static void ShowItem(Item item, bool ocen)
        {
            if (item != null)
            {
                if (!ocen)
                {
                    if (item is Armor)
                    {
                        Armor ar = item as Armor;
                        Console.WriteLine("Ogladasz uwaznie " + ar.Odm.Biernik + ".");
                        Console.WriteLine(Splice(ar.Long));
                    }
                    else if (item is Cloth)
                    {
                        Cloth cl = item as Cloth;
                        Console.WriteLine("Ogladasz uwaznie " + cl.Odm.Biernik + ".");
                        Console.WriteLine(Splice(cl.Long));
                    }
                    else if (item is Itemy)
                    {
                        Itemy it = item as Itemy;
                        Console.WriteLine("Ogladasz uwaznie " + it.Odm.Biernik + ".");
                        Console.WriteLine(Splice(it.Long));
                    }
                    else if (item is Weapon)
                    {
                        Weapon weap = item as Weapon;
                        Console.WriteLine("Ogladasz uwaznie " + weap.Odm.Biernik + ".");
                        Console.WriteLine(Splice(weap.Long));
                    }
                }
                else if (ocen)
                {
                }
            }
        }

        /// <summary>
        /// Pokazuje lokacje, jej longa lub shorta i wyjscia
        /// </summary>
        /// <param name="loc"> lokacja do pokazania </param>
        /// <param name="longL">true dla longa, inaczej shorta</param>
        public static void ShowLocation(Location loc, bool longL)
        {
            //opis lokacji
            if (loc != null)
            {
                if (longL)
                    Console.WriteLine(Splice(loc.Long));
                else
                    Console.WriteLine(Splice(loc.Short));

                //wyjscia z lokacji
                List<string> exits = new List<string>();
                for (int i = 0; i < loc.Exits.Count; i++)
                {
                    exits.Add(loc.Exits[i][0].Split(',')[0]);
                }
                exits = SFuns.LongExits(exits);

                if (exits.Count == 0)
                    Console.WriteLine("");
                else if (exits.Count == 1)
                    Coloring.Green(Splice("Widzisz tutaj " + exits.Count + " wyjscie: " + exits[0] + ".\n"));
                else if (exits.Count == 2)
                {
                    Coloring.Green(Splice("Widzisz tutaj " + exits.Count + " wyjscia: " + exits[0] + " oraz " + exits[1] + ".\n"));
                }
                else
                {
                    Coloring.Green(Splice("Widzisz tutaj " + exits.Count + " wyjsc: "));
                    for (int i = 0; i < exits.Count - 2; i++)
                        Coloring.Green(exits[i] + ", ");
                    Coloring.Green(exits[exits.Count - 2]);
                    Coloring.Green(" oraz " + exits[exits.Count - 1] + ".\n");
                }
            }
            else
            {
                Coloring.Red("[INFO]");
                Console.Write("Blad, lokacja nie istnieje.");
            }

            //NPCe
            //   loc.NPCs = new List<NPC>();
            if (loc.NPCs.Count > 1)
            {
                for (int i = 0; i < loc.NPCs.Count - 1; i++)
                {
                    Coloring.Yellow(SFuns.Up(loc.NPCs[i].Name) + ", ");
                }
                Coloring.Yellow(SFuns.Up(loc.NPCs[loc.NPCs.Count - 1].Name) + ".\n");
            }
            else if (loc.NPCs.Count == 1)
            {
                Coloring.Yellow(SFuns.Up(loc.NPCs[0].Name) + ".\n");
            }
        }

        /// <summary>
        /// Dziel tekst do 80 znakow bez dzielenia wyrazow.
        /// </summary>
        /// <param name="text">tekst do podzielenia</param>
        /// <returns>ten sam text, ale z enterami</returns>
        public static string Splice(string text)
        {
            var charCount = 0;
            var lines = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / 80)
                            .Select(g => string.Join(" ", g));

            return String.Join("\n", lines.ToArray());
        }
    }
}