using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Program
{
    /// <summary>
    /// wszystkie male wkurzajace funkcje
    /// </summary>
    static class SFuns
    {
        public static List<string[]> ExitsMerge(List<string[]> exs)
        {
            List<string[]> exits = new List<string[]>();

            for (int i = 0; i < exs.Count; i++)
            {
                string[] exis = exs[i][0].Split(',');

                exits.Add(new string[] { exis[0], exs[i][1] });
           //     Console.WriteLine("[INFO] Idac na " + exis[0] + " dotrzemy do " + exs[i][1]);

            }

            return exits;
        }

        public static string ConvertCommandByDir(string command)
        {
            command = command.ToLower();
            switch (command)
            {
                case "poludnie": command = "s"; break;
                case "polnoc": command = "n"; break;
                case "zachod": command = "w"; break;
                case "wschod": command = "e"; break;
                case "polnocny-wschod": command = "ne"; break;
                case "polnocny-zachod": command = "nw"; break;
                case "poludniowy-wschod": command = "se"; break;
                case "poludniowy-zachod": command = "sw"; break;
                case "polnocny wschod": command = "ne"; break;
                case "polnocny zachod": command = "nw"; break;
                case "poludniowy wschod": command = "se"; break;
                case "poludniowy zachod": command = "sw"; break;
                case "dol": command = "d"; break;
                case "gora": command = "u"; break;
                default: break;
            }


            return command;
        }

        public static List<string> LongExits(List<string> exits)
        {
            List<string> longs = exits;

            for(int i=0; i<exits.Count; i++)
            {
                switch(exits[i])
                {
                    case "s": longs[i] = "poludnie"; break;
                    case "n": longs[i] = "polnoc"; break;
                    case "w": longs[i] = "zachod"; break;
                    case "e": longs[i] = "wschod"; break;
                    case "ne": longs[i] = "polnocny-wschod"; break;
                    case "nw": longs[i] = "polnocny-zachod"; break;
                    case "se": longs[i] = "poludniowy-wschod"; break;
                    case "sw": longs[i] = "poludniowy-zachod"; break;
                    case "d": longs[i] = "dol"; break;
                    case "u": longs[i] = "gora"; break;
                    default: break;
                }

            }

            return longs;
        }

        public static string NumberToString(int x)
        {
            string s = "";
            switch(x)
            {
                case 1: s = "jeden"; break;
                case 2: s = "dwa";break;
                case 3: s = "trzy";break;
                case 4: s = "cztery";break;
                case 5: s = "piec";break;
                case 6: s = "szesc";break;
                case 7: s = "siedem";break;
                case 8: s = "osiem";break;
                case 9:s = "dziewiec";break;
                
            }

            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeName"> rodzaj klasy</param>
        /// <param name="methodName"> nazwa wywolywanej funkcji</param>
        /// <param name="stringParam">parametr funkcji</param>
        /// <returns></returns>
        public static string InvokeWithString  (string typeName, string methodName, string stringParam)
            {
                // Get the Type for the class
                Type calledType = Type.GetType(typeName);

                // Invoke the method itself. The string returned by the method winds up in s.
                // Note that stringParam is passed via the last parameter of InvokeMember,
                // as an array of Objects.
                String s = (String)calledType.InvokeMember(
                                methodName,
                                BindingFlags.InvokeMethod | BindingFlags.Public |
                                    BindingFlags.Static,
                                null,
                                null,
                                new string[] { stringParam });

                // Return the string that was returned by the called method.
                return s;
            }
        
    }
}
