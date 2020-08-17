using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var shower = new Shower();

            string name = "Sierya";
            int id = 1;

            Player p = Manager.ReadPlayer(name);

            Location loc = Manager.ReadLocation(id);
            MethodInfo invoked = shower.GetType().GetMethod("ShowPlayer");
            Console.WriteLine();

            
            object magicValue = invoked.Invoke(shower, new object[] {p });

            Shower.ShowLocation(loc, true);

            string command = "";
            while(command!="zakoncz")
            {
                Manager.ReadCommand(p, p.CurrentLoc);
            }


            Console.ReadKey();

        }



       
    }
}
