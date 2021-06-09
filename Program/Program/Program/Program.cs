using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Program.Commands;
using NetMQ.Sockets;
using NetMQ;
using System.Threading;

namespace Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shower = new Shower();

            string name = "Sierya";
            int id = 1;

            Player p = Manager.ReadPlayer(name);
            PlayerCommands pc = new PlayerCommands(p);
            NPC n = new NPC();

            /*
            //zostawiam to zeby pokazac wywolanie funkcji po stringu nazwy
            MethodInfo invoked = shower.GetType().GetMethod("ShowPlayer");
            Console.WriteLine();
            invoked.Invoke(shower, new object[] {p,true });
            */
            //      using (var client = new RequestSocket())
            //      {
            //          client.Connect("tcp://localhost:5555");
            string command = "";
            while (command != "zakoncz")
            {
                Manager.ReadCommand(p, p.CurrentLoc, pc);
                Console.WriteLine();
            }

            Manager.Save(p, p.CurrentLoc);

            //    }
        }
    }
}