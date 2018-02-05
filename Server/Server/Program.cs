using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server: " + IPAddress.Loopback.ToString();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            new ServerManager();
        }
    }
}
