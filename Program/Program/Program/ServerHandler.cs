using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ.Sockets;
using NetMQ;
using System.Threading;

namespace Program
{
    internal static class ServerHandler
    {
        public static void ToAll(RequestSocket client, Character ch, string text)
        {
            client.SendFrame(Encoding.ASCII.GetBytes(text));
        }

        public static void ForServer()
        {
        }
    }
}