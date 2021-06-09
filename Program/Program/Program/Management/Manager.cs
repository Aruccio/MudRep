using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Program.Commands;
using Program.Management;
using Program.Objects;

namespace Program
{
    internal class Manager
    {
        public Manager()
        {
        }

        private static string pathPlayers = @"../../../../../../Players";
        private static string pathLocations = @"../../../../../../Locations";
        private static string pathWeapons = @"../../../../../../Items/Weapons";
        private static string pathCloths = @"../../../../../../Items/Cloths";
        private static string pathArmors = @"../../../../../../Items/Armors";
        private static string pathItemy = @"../../../../../../Items/Itemy";
        private static string pathNPC = @"../../../../../../NPC";
        private static string pathContainers = @"../../../../../../Items/Containers";

        /// <summary>
        /// Zmienia polozenie gracza zgodnie z komenda. Tylko mechanicznie. Nic graczowi nie pokazuje.
        /// </summary>
        /// <param name="p">Gracz</param>
        /// <param name="current">obecna lokacja</param>
        /// <param name="command">komenda ktora wskazuje nowa lokacje</param>
        /// <returns></returns>
        public static Location MovePlayer(Player p, Location current, string command)
        {
            int id = 0;
            for (int i = 0; i < current.Exits.Count; i++)
            {
                if (current.Exits[i][0].Substring(0, 1) == command)
                {
                    id = Convert.ToInt32(current.Exits[i][1]);
                    break;
                }
            }
            Location newLocation = ReadLocation(id);
            p.CurrentLoc = newLocation;
            p.CurrentLoc.Characters.Add(p);
            Console.WriteLine("Idziesz na " + command + ".");

            return newLocation;
        }

        /// <summary>
        /// czyta komende wprowadzana w konsoli(w funkcji to jest string command) i kolejno:
        ///updatuje dostepne wyjscia z lokacji
        ///sprawdza czy komenda to dostepne wyjscie z lokacji
        /// </summary>
        /// <param name="p"> gracz ktory dal komende</param>
        /// <param name="loc">lokacja na ktorej sie znajduje ten gracz</param>
        public static void ReadCommand(Player p, Location loc, PlayerCommands pc)
        {
            Console.Write(">> ");
            string command = Console.ReadLine();

            command = SFuns.ConvertCommandByDirection(command);

            List<string[]> dirs = SFuns.ExitsMerge(loc.Exits);

            //sprawdzenie kierunkow na lokacji oraz czy gracz wpisal kierunek
            for (int i = 0; i < dirs.Count; i++)
            {
                if (command == dirs[i][0])
                {
                    Location newLoc = MovePlayer(p, loc, command);
                    WriteLocation(loc);
                    Shower.ShowLocation(newLoc, true);
                    break;
                }
            }

            //komendy inne niz kierunki
            var shower = new Shower();

            string[] comTab = command.Split(' ');
            string firstcom = comTab.First();
            string restcom = "";
            if (comTab.Length > 1)
                for (int i = 1; i < comTab.Length; i++)
                    restcom += " " + comTab[i];

            string apostrof = ((char)39).ToString();

            switch (firstcom)
            {
                case "cechy":
                    pc.Cechy();
                    break;

                case "i":
                    pc.I();
                    break;

                case "ob":
                    pc.Ob(restcom);
                    break;

                case "obejrzyj":
                    pc.Ob(restcom);
                    break;

                case "powiedz":
                    pc.Powiedz(restcom);
                    break;

                case "sp":
                    pc.Sp();
                    break;

                case "spojrz":
                    pc.Sp();
                    break;

                case "zabij":
                    pc.Zabij(restcom);
                    break;

                case "zerknij":
                    pc.Zerknij();
                    break;

                case "zakoncz":
                    Save(p, loc);
                    break;

                case "": break;
                default:
                    Console.WriteLine("Slucham?");
                    break;
            }
            //emocje

            //    return toSend;
        }

        /// <summary>
        /// tworzy obiekt Container z pliku folderu Pojemniki
        /// </summary>
        /// <param name="name">nazwa pliku, z myslnikami</param>
        /// <returns></returns>
        public static Container ReadContainer(string name)
        {
            Container c = new Container();
            if (File.Exists(pathContainers + "/" + name + ".txt"))
            {
                StreamReader sr = new StreamReader(pathContainers + "/" + name + ".txt");

                using (sr)
                {
                    //nazwa bez myslnikow
                    c.Name = sr.ReadLine().Replace('-', ' ');

                    //long
                    c.Long = sr.ReadLine();

                    //odmiana przez przypadki. Pamietac o kolejnosci!
                    string[] odmiana = new string[7];
                    string odmianaStr = sr.ReadLine();
                    if (odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        c.Odm.Mianownik = name.Replace('-', ' ');
                        c.Odm.Dopelniacz = odmiana[2];
                        c.Odm.Celownik = odmiana[3];
                        c.Odm.Biernik = odmiana[4];
                        c.Odm.Narzednik = odmiana[5];
                        c.Odm.Miejscownik = odmiana[6];
                    }
                    else { Console.WriteLine("BŁĄD ODMIANY BRONI (pojedyncza)."); }

                    odmianaStr = sr.ReadLine();
                    if (odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        c.Odm.MMianownik = odmiana[1];
                        c.Odm.MDopelniacz = odmiana[2];
                        c.Odm.MCelownik = odmiana[3];
                        c.Odm.MBiernik = odmiana[4];
                        c.Odm.MNarzednik = odmiana[5];
                        c.Odm.MMiejscownik = odmiana[6];
                    }
                    else { Console.WriteLine("BŁĄD ODMIANY BRONI (mnoga)."); }
                    c.Closed = false;

                    string[] zawartoscp = sr.ReadLine().Split(',');
                    string[] zawartoscw = sr.ReadLine().Split(',');
                    string[] zawartosca = sr.ReadLine().Split(',');
                    string[] zawartoscc = sr.ReadLine().Split(',');
                    string[] zawartosci = sr.ReadLine().Split(',');
                    for (int i = 1; i < zawartoscp.Length; i++) c.Zawartosc.Add(ReadContainer(zawartoscp[i]));
                    for (int i = 1; i < zawartoscw.Length; i++) c.Zawartosc.Add(ReadWeapon(zawartoscw[i]));
                    //  for (int i = 1; i < zawartosca.Length; i++) c.Zawartosc.Add(ReadArmor(zawartoscp[i]) as Item);
                    //  for (int i = 1; i < zawartoscc.Length; i++) c.Zawartosc.Add(ReadCloth(zawartoscp[i]) as Item);
                    //  for (int i = 1; i < zawartosci.Length; i++) c.Zawartosc.Add(ReadItemy(zawartoscp[i]) as Item);
                }
            }

            return c;
        }

        /// <summary>
        /// wczytuje lokacje jako obiekt z pliku o id lokacji
        ///zwrocic uwage na puste linie pokazane w templatce lokacji
        /// </summary>
        /// <param name="id">numer lokacji</param>
        /// <returns>lokacje jako obiekt</returns>
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
                    loc.Short = sr.ReadLine();
                    loc.Long = sr.ReadLine();
                    loc.Exits = new List<string[]>();
                    loc.Things = new List<string[]>();
                    string line;

                    //wyjscia z lokacji
                    while ((line = sr.ReadLine()) != null && line.Contains("exit"))
                    {
                        string[] splited = line.Split('=');
                        loc.Exits.Add(new string[] { splited[1], splited[2] });
                    }

                    //rzeczy na lokacji
                    //while ((line = sr.ReadLine()) != null && line.Contains("thing"))
                    //{
                    //    string[] splited = line.Split('=');
                    //    loc.Things.Add(new string[] { splited[1], splited[2], splited[3] });
                    //}

                    //npce na lokacji
                    loc.NPCs = new List<NPC>();
                    loc.Characters = new List<Character>();
                    while ((line = sr.ReadLine()) != null && line.Contains("npc") && line != "")
                    {
                        string[] splited = line.Split('=');
                        NPC npc = ReadNPC(splited[1]);
                        loc.NPCs.Add(npc);
                        loc.Characters.Add(npc);
                    }
                }
            }
            else
            {
                return null;
            }

            return loc;
        }

        /// <summary>
        /// wczytuje NPCa
        /// </summary>
        /// <param name="name">imie NPCa</param>
        /// <returns>zwraca obiekt NPCa</returns>
        public static NPC ReadNPC(string name)
        {
            NPC p = new NPC();
            if (File.Exists(pathNPC + "/" + name + ".txt"))
            {
                StreamReader sr = new StreamReader(pathNPC + "/" + name + ".txt");

                using (sr)
                {
                    //imie
                    p.Name = sr.ReadLine();

                    //short
                    string shortn = sr.ReadLine();
                    if (!shortn.Contains(" ")) return null;
                    p.Short = shortn;

                    //plec
                    string gender = sr.ReadLine();
                    if (gender != "kobieta" && gender != "mezczyzna") return null;
                    p.Gender = gender;

                    //rasa
                    string race = sr.ReadLine();
                    p.Race = race;

                    //odmiana przez przypadki. Pamietac o kolejnosci!
                    string[] odmiana = new string[7];
                    string odmianaStr = sr.ReadLine();
                    if (odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        p.Odm.Mianownik = name;
                        p.Odm.Dopelniacz = odmiana[2];
                        p.Odm.Celownik = odmiana[3];
                        p.Odm.Biernik = odmiana[4];
                        p.Odm.Narzednik = odmiana[5];
                        p.Odm.Miejscownik = odmiana[6];
                    }
                    else { Console.WriteLine("BŁĄD ODMIANY."); }
                    //string curLoc;
                    //if ((curLoc = sr.ReadLine()) != null)
                    //{
                    //    curLoc = curLoc.Substring(11);
                    //    p.CurrentLoc = ReadLocation(Convert.ToInt32(curLoc));
                    //}
                    string[] cechy = sr.ReadLine().Split(',');
                    p.Sila = Convert.ToInt32(cechy[1]);
                    p.Zrecznosc = Convert.ToInt32(cechy[2]);
                    p.Wytrzymalosc = Convert.ToInt32(cechy[3]);
                    p.Intelekt = Convert.ToInt32(cechy[4]);
                    p.Odwaga = Convert.ToInt32(cechy[5]);
                    p.DoCech();

                    string[] eq = sr.ReadLine().Split(',');

                    p.EqWeap = new List<Weapon>();
                    for (int i = 1; i < eq.Length; i++)
                    {
                        p.EqWeap.Add(ReadWeapon(eq[i]));
                    }
                    p.WeaponInHand = p.EqWeap[0];
                }

                Maths.PoliczHP(p);
            }
            else
            {
                return null;
            }
            return p;
        }

        /// <summary>
        /// wczytuje gracza
        /// </summary>
        /// <param name="name">imie gracza</param>
        /// <returns>zwraca obiekt gracza</returns>
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
                    p.Short = shortn;

                    //plec
                    string gender = sr.ReadLine();
                    if (gender != "kobieta" && gender != "mezczyzna") return null;
                    p.Gender = gender;

                    //rasa
                    string race = sr.ReadLine();
                    p.Race = race;

                    //odmiana przez przypadki. Pamietac o kolejnosci!
                    string[] odmiana = new string[7];
                    string odmianaStr = sr.ReadLine();
                    if (odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        p.Odm.Mianownik = name;
                        p.Odm.Dopelniacz = odmiana[2];
                        p.Odm.Celownik = odmiana[3];
                        p.Odm.Biernik = odmiana[4];
                        p.Odm.Narzednik = odmiana[5];
                        p.Odm.Miejscownik = odmiana[6];
                    }
                    else { Console.WriteLine("BŁĄD ODMIANY."); }

                    //lokacja obecna/startowa
                    string curLoc, startLoc;
                    if ((startLoc = sr.ReadLine()) != null)
                    {
                        startLoc = startLoc.Substring(9);
                        p.StartLoc = ReadLocation(Convert.ToInt32(startLoc));
                    }

                    if ((curLoc = sr.ReadLine()) != null)
                    {
                        curLoc = curLoc.Substring(11);
                        p.CurrentLoc = ReadLocation(Convert.ToInt32(curLoc));
                    }

                    //cechy
                    string[] cechy = sr.ReadLine().Split(',');
                    p.Sila = Convert.ToInt32(cechy[1]);
                    p.Zrecznosc = Convert.ToInt32(cechy[2]);
                    p.Wytrzymalosc = Convert.ToInt32(cechy[3]);
                    p.Intelekt = Convert.ToInt32(cechy[4]);
                    p.Odwaga = Convert.ToInt32(cechy[5]);
                    p.DoCech();

                    //pojemniki
                    string[] eqp = sr.ReadLine().Split(',');
                    p.EqContainers = new List<Container>();
                    for (int i = 1; i < eqp.Length; i++)
                    {
                        p.EqContainers.Add(ReadContainer(eqp[i]));
                    }

                    //bronie
                    string[] eqw = sr.ReadLine().Split(',');
                    p.EqWeap = new List<Weapon>();
                    for (int i = 1; i < eqw.Length; i++)
                    {
                        p.EqWeap.Add(ReadWeapon(eqw[i]));
                    }

                    p.WeaponInHand = p.EqWeap[0];
                }
                Maths.PoliczHP(p);
            }
            else
            {
                Coloring.Red("Nie znaleziono takiego gracza.");
                return null;
            }
            return p;
        }

        /// <summary>
        /// tworzy obiekt Weapon
        /// </summary>
        /// <param name="name">nazwa pliku, z myslnikami</param>
        /// <returns>zwraca obiekt Weapon</returns>
        public static Weapon ReadWeapon(string name)
        {
            Weapon w = new Weapon();
            if (File.Exists(pathWeapons + "/" + name + ".txt"))
            {
                StreamReader sr = new StreamReader(pathWeapons + "/" + name + ".txt");

                using (sr)
                {
                    //nazwa bez myslnikow
                    w.Name = sr.ReadLine().Replace('-', ' ');

                    //long
                    w.Long = sr.ReadLine();

                    string temp = sr.ReadLine();
                    if (temp == "twohand")
                        w.Hand = 2;
                    else if (temp == "onehand")
                        w.Hand = 1;
                    else w.Hand = 0;

                    //odmiana przez przypadki. Pamietac o kolejnosci!
                    string[] odmiana = new string[7];
                    string odmianaStr = sr.ReadLine();
                    if (odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        w.Odm.Mianownik = name.Replace('-', ' ');
                        w.Odm.Dopelniacz = odmiana[2];
                        w.Odm.Celownik = odmiana[3];
                        w.Odm.Biernik = odmiana[4];
                        w.Odm.Narzednik = odmiana[5];
                        w.Odm.Miejscownik = odmiana[6];
                    }
                    else { Console.WriteLine("BŁĄD ODMIANY BRONI (pojedyncza)."); }

                    odmianaStr = sr.ReadLine();
                    if (odmianaStr.Contains("odmiana"))
                    {
                        odmiana = odmianaStr.Split(',');
                        w.Odm.MMianownik = odmiana[1];
                        w.Odm.MDopelniacz = odmiana[2];
                        w.Odm.MCelownik = odmiana[3];
                        w.Odm.MBiernik = odmiana[4];
                        w.Odm.MNarzednik = odmiana[5];
                        w.Odm.MMiejscownik = odmiana[6];
                    }
                    else { Console.WriteLine("BŁĄD ODMIANY BRONI (mnoga)."); }

                    string speedstr = sr.ReadLine().Split(',')[1];
                    w.Speed = Convert.ToInt32(speedstr);
                    string damagestr = sr.ReadLine().Split(',')[1];
                    w.Damage = Convert.ToInt32(damagestr);
                }
            }

            return w;
        }

        public static void Save(Player p, Location loc)
        {
            WritePlayer(p);
            Coloring.Red("ZAKONCZONO.\n Program zostanie wylaczony.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void WriteLocation(Location loc)
        {
            StreamWriter sw = new StreamWriter(pathLocations + "/" + loc.Id + ".txt");

            using (sw)
            {
                sw.WriteLine(loc.Id);
                sw.WriteLine(loc.Short);
                for (int i = 0; i < loc.Exits.Count; i++)
                {
                    sw.WriteLine("exits=" + loc.Exits[i][0] + "=" + loc.Exits[i][1]);
                }

                sw.WriteLine();

                for (int i = 0; i < loc.NPCs.Count; i++)
                {
                    sw.WriteLine("npc=" + loc.NPCs[i].Name);
                }
            }
        }

        /// <summary>
        /// zapisuje obiekt gracza do pliku o podanej sciezce
        /// </summary>
        /// <param name="p">gracz jako obiekt</param>
        public static void WritePlayer(Player p)
        {
            StreamWriter sw = new StreamWriter(pathPlayers + "/" + p.Name + ".txt");

            using (sw)
            {
                sw.WriteLine(p.Name);
                sw.WriteLine(p.Short);
                sw.WriteLine(p.Gender);
                sw.WriteLine(p.Race);
                sw.Write("odmiana,");
                sw.WriteLine(p.Odm.Mianownik + "," + p.Odm.Dopelniacz + "," + p.Odm.Celownik + "," + p.Odm.Biernik + "," + p.Odm.Narzednik + "," + p.Odm.Miejscownik);
                sw.WriteLine("startloc," + p.StartLoc.Id);
                sw.WriteLine("currentloc," + p.CurrentLoc.Id);
                sw.WriteLine("cechy," + p.Sila + "," + p.Zrecznosc + "," + p.Wytrzymalosc + "," + p.Intelekt + "," + p.Odwaga);
                sw.Write("ip,");
                if (p.EqContainers.Count > 0)
                {
                    for (int i = 0; i < p.EqContainers.Count - 1; i++) sw.Write(p.EqContainers[i] + ",");
                    sw.Write(p.EqContainers[p.EqContainers.Count - 1].Name.Replace(' ', '-'));
                }
                sw.Write("iw,");
                if (p.EqWeap.Count > 0)
                {
                    for (int i = 0; i < p.EqWeap.Count - 1; i++) sw.Write(p.EqWeap[i] + ",");
                    sw.Write(p.EqWeap[p.EqWeap.Count - 1].Name.Replace(' ', '-'));
                }
            }
        }
    }
}