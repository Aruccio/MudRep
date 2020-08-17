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

        public static void ShowPlayer(Player p)
        {

            if (p != null)
            {
                Console.Write("Masz przed soba ");
                Coloring.Cyan(p.OdmianaPoj[3]+". ");
                Console.WriteLine("Jest to " + p.ShortN + " " + p.Gender + ".");
            }
            else
            {
                Coloring.Red("[INFO] ");
                Console.WriteLine("Postac nie istnieje.");
            }
        }


        public static void ShowLocation(Location loc, bool longL) //jesli longL==true, pokazuje longa, inaczej shorta
        {
            if(loc!=null)
            {
                if (longL)
                    Console.WriteLine(loc.LongN);
                else
                    Console.WriteLine(loc.ShortN);

                List<string> exits = new List<string>();
                for (int i = 0; i < loc.Exits.Count; i++)
                {
                    exits.Add(loc.Exits[i][0].Split(',')[0]);
                    //   Console.WriteLine("[INFO] Mozna wyjsc: " + loc.Exits[i][0] + " do id: " + loc.Exits[i][1]);
                }
                exits = SFuns.LongExits(exits);

                if (exits.Count == 0)
                    Console.WriteLine("");
                else if (exits.Count == 1)
                    Coloring.Green("Widzisz tutaj " + exits.Count + " wyjscie: " + exits[0] + ".\n");
                else if (exits.Count == 2)
                {
                    Coloring.Green("Widzisz tutaj " + exits.Count + " wyjscia: " + exits[0] + " oraz " + exits[1] + ".\n");
                }
                else
                {
                    Coloring.Green("Widzisz tutaj " + exits.Count + " wyjsc: ");
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
        }

        public static void ShowEq(Player p)
        {
            Console.WriteLine("Masz przy sobie: ");
            for(int i=0; i<p.Eq.Count;i++)
            {
                Console.WriteLine("-> " + p.Eq[i].Name);
            }
            Console.WriteLine();
        }
    
    }
}
