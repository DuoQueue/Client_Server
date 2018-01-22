using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class ServerManager
    {
        private TcpListener server;
        private IPAddress address;
        private IPEndPoint endPoint;
        private Thread waitingForUsers, receivePackets;
        private List<TcpClient> clients;

        public ServerManager()
        {
            address = IPAddress.Loopback;
            endPoint = new IPEndPoint(address, 15567);
            server = new TcpListener(endPoint);
            clients = new List<TcpClient>();
            waitingForUsers = new Thread(x => {
                while(true){
                    TcpClient client = server.AcceptTcpClient();
                    if (client != null && clients.Count != 10)
                    {
                        clients.Add(client);
                    }
                }
            });
            receivePackets = new Thread(x =>
            {
                while (true)
                {
                    
                }
            });
            Start();
            waitingForUsers.Abort();
        }

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine(" >> Server gestartet");
            server.Start();
            waitingForUsers.Start();
            Console.ReadKey();
        }
    }
}
