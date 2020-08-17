using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


namespace Program
{
    static class Manager
    {
        
        static string pathPlayers = @"../../../../../../Players";
        static string pathLocations = @"../../../../../../Locations";
        static string pathCommandsPlayer = @"../../../../../../Commands/player";
        static string pathThings = @"../../../../../../Things";



        public static void ReadCommand(Player p, Location loc)
        {

            Console.Write(">> ");
            string command = Console.ReadLine();

            command = SFuns.ConvertCommandByDir(command);

            List<string[]> dirs = SFuns.ExitsMerge(loc.Exits);


            for (int i = 0; i < dirs.Count; i++)
            {

                if (command == dirs[i][0])
                {

                    //     Console.WriteLine("[INFO] Ruch na: " + command);
                    Location newLoc = MovePlayer(p, loc, command);
                    Shower.ShowLocation(newLoc, true);
                    return;
                }
            }

            //komendy
            var shower = new Shower();

            List<string> commands = ReadCommandsFile();

            for(int i=1; i<commands.Count; i++)
            {
                if(commands[i]==command)
                {
                    using (StreamReader sr = new StreamReader(pathCommandsPlayer + "/" + command + ".txt"))
                    {
                        string cm;
                        while((cm=sr.ReadLine())!=null)
                        {
                            MethodInfo invoked = shower.GetType().GetMethod(cm);
                            object magicValue = invoked.Invoke(shower, new object[] { p });
                        }
                    }
                    return;
                }
            }



            //emocje




        }

        public static Player ReadPlayer(string name)
        {
            Player p = new Player();
            if (File.Exists(pathPlayers + "/" + name + ".txt"))
            {

                StreamReader sr = new StreamReader(pathPlayers + "/" + name + ".txt");

                using (sr)
                {
                    //imie
                    p.Name = sr.ReadLine();

                    //short
                    string shortn = sr.ReadLine();
                    if (!shortn.Contains(" ")) return null;
                    p.ShortN = shortn;

                    //plec
                    string gender = sr.ReadLine();
                    if (gender != "kobieta" && gender != "mezczyzna") return null;
                    p.Gender = gender;

                    //rasa
                    string race = sr.ReadLine();
                    p.Race = race;

                    //odmiana przez przypadki. Pamietac o kolejnosci!
                    string[] odmiana = new string[7];
                    p.OdmianaPoj = new string[6];
                    string odmianaStr = sr.ReadLine();
                    if(odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        p.OdmianaPoj[0] = name; //mianownik
                        p.OdmianaPoj[1] = odmiana[2]; //dopelniacz
                        p.OdmianaPoj[2] = odmiana[3]; //celownik
                        p.OdmianaPoj[3] = odmiana[4]; //biernik
                        p.OdmianaPoj[4] = odmiana[5]; //narzednik
                        p.OdmianaPoj[5] = odmiana[6]; //miejscownik

                    }
                    else { Console.WriteLine("BŁĄD ODMIANY."); }
                    string curLoc, startLoc;
                    if ((startLoc = sr.ReadLine()) != null)
                    {
                        startLoc = startLoc.Substring(8);
                        p.StartLoc = ReadLocation(Convert.ToInt32(startLoc));
                    }

                    if ((curLoc = sr.ReadLine()) != null)
                    {
                        curLoc = curLoc.Substring(11);
                        p.CurrentLoc = ReadLocation(Convert.ToInt32(curLoc));
                    }

                    string eq = sr.ReadLine();
                    p.Eq = new List<Thing>();
                    if(eq[0] =='i')
                    {
                        string[] s1 = eq.Split(' ');
                        string[] s2 = s1[1].Split(',');
                        for (int i = 0; i < s2.Length; i++)
                        {
                            p.Eq.Add(ReadThing(s2[i])) ;
                        }
                            
                    }
                }
            }
            else
            {

                return null;
            }
            return p;
        }

        public static void WritePlayer(Player p)
        {
            StreamWriter sw = new StreamWriter(pathPlayers + "/" + p.Name + ".txt");

            using (sw)
            {
                sw.WriteLine(p.Name);
                sw.WriteLine(p.ShortN);
                sw.WriteLine(p.Gender);
                sw.WriteLine(p.Race);
                sw.Write("odmiana");
                for(int i =0; i<p.OdmianaPoj.Length; i++)
                {
                    sw.Write("," + p.OdmianaPoj[i]);
                }

                sw.Write(p.StartLoc);
                sw.Write(p.CurrentLoc);

                sw.Write("i ");
                for (int i = 0; i < p.Eq.Count - 1; i++)
                    sw.Write(p.Eq[i].Name + ",");
                sw.WriteLine(p.Eq[p.Eq.Count - 1].Name);
            }
        }

        public static Location ReadLocation(int id)
        {
            Location loc = new Location();
            if (File.Exists(pathLocations + "/" + id + ".txt"))
            {
                StreamReader sr = new StreamReader(pathLocations + "/" + id + ".txt");

                using (sr)
                {
                    if (id != Convert.ToInt32(sr.ReadLine())) return null;
                    loc.Id = id;
                    loc.ShortN = sr.ReadLine();
                    loc.LongN = sr.ReadLine();
                    loc.Exits = new List<string[]>();
                    loc.Things = new List<string[]>();
                    string line;

                    while ((line=sr.ReadLine()) != null && line.Contains("exit"))
                    {
                        string[] splited = line.Split('=');
                        loc.Exits.Add(new string[] { splited[1], splited[2] });
                    }

                    while ((line = sr.ReadLine()) != null && line.Contains("thing"))
                    {
                        string[] splited = line.Split('=');
                        loc.Things.Add(new string[] { splited[1], splited[2], splited[3] });
                    }
                }


            }
            else
            {
                return null;
            }


                return loc;
        }

       

        public static Location MovePlayer(Player p, Location current, string command)
        {

            int id = 0;
            for(int i=0; i<current.Exits.Count; i++)
            {
             
                if(current.Exits[i][0].Substring(0,1)==command)
                {
                    id = Convert.ToInt32(current.Exits[i][1]);
                    break;
                }
            }
            Location newLocation = ReadLocation(id);
            p.CurrentLoc = newLocation;
            Console.WriteLine("Idziesz na " + command+".");
           // Console.WriteLine("[INFO] Przemieszczono " + p.OdmianaPoj[3]+" na "+command+" od "+current.Id+" Lokacja nr "+id+".");

            return newLocation;
        }


        public static List<string> ReadCommandsFile()
        {
            List<string> commands = new List<string>();
            List<string> TempCommands = new List<string>();
            using (StreamReader sr = new StreamReader(pathCommandsPlayer + "/listComms.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                    TempCommands.Add(s);
            }

            for (int i = 0; i < TempCommands.Count; i++)
            {
                string str = TempCommands[i].Split('=')[0];
                commands.Add(str);
            }



            return commands;

        }

        public static Thing ReadThing(string name)//imie z myslnikami
        {

            string truename = name.Replace('-', ' ');
            Thing thing = new Thing(truename);
            if (File.Exists(pathPlayers + " / " + name + ".txt"))
            {

                StreamReader sr = new StreamReader(pathThings + "/" + name + ".txt");

                using (sr)
                {
                    if (sr.ReadLine() == truename)
                        thing.Name = truename;
                    else
                        Coloring.Red("[INFO] ");
                        Console.WriteLine("Blad przedmiotu (nieprawdziwa nazwa)");

                    thing.LongN = sr.ReadLine();
                }
            }

            return thing;
        }
    }
}
