using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NetDLL;
using System.IO;
using System.Reflection;

namespace Server
{
    class ServerManager
    {
        static ServerManager instance;
        private TcpListener server;
        private IPAddress address;
        private IPEndPoint endPoint;
        private Thread waitingForUsers;
        private List<HandleClient> clients;
        private Dictionary<PacketSendText, string> lastMessages;

        public ServerManager()
        {
            List<IPAddress> addresses = new List<IPAddress>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            File.Create(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data.txt");
            foreach (var ip in host.AddressList)
            {
                addresses.Add(ip);
            }
            address = addresses.Last();
            instance = this;
            endPoint = new IPEndPoint(address, 15567);
            server = new TcpListener(endPoint);
            lastMessages = new Dictionary<PacketSendText, string>();
            clients = new List<HandleClient>();
            waitingForUsers = new Thread(x => {
                while(true){
                    TcpClient client = server.AcceptTcpClient();
                    if (client != null && clients.Count != 10)
                    {
                        clients.Add(new HandleClient(client));
                        Console.WriteLine(" >> Client verbunden");
                    }
                    else if(client != null)
                    {
                        client.Close();
                        Console.WriteLine(" >> Client abgelehnt");
                    }
                }
            });
            waitingForUsers.IsBackground = true;
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

        public void OnDisconnect(HandleClient handle)
        {
            clients.Remove(handle);
        }

        public static ServerManager Instance()
        {
            return instance;
        }

        public void HandleInput(HandleClient client, string text)
        {
            Byte[] bytes = ASCIIEncoding.ASCII.GetBytes(text);
            Packet packet = Packet.ToPacket(bytes);
            if (packet != null)
            {
                if (packet is PacketSendUniText)
                {
                    Console.WriteLine(" >> Input received");
                    PacketSendUniText sendUniText = (PacketSendUniText)packet;
                    HandleClient receiver = GetClient(sendUniText.Receiver);
                    if (receiver != null)
                    {
                        PacketSendText sendText = new PacketSendText(client.Name, sendUniText.Text);
                        lastMessages.Add(sendText, sendUniText.Receiver);
                        File.WriteAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\data.txt", sendText.Text + "|" + sendText.Sender + "|" + sendUniText.Receiver);
                        client.Write(sendText);
                        receiver.Write(sendText);
                    }
                }
                else if (packet is PacketDisconnect)
                {
                    Console.WriteLine(" >> User disconnected");
                    client.Close();
                    OnDisconnect(client);
                }
                else if (packet is PacketSendNameExists)
                {
                    Console.WriteLine(" >> Name check requested");
                    PacketNameRequest _packet = (PacketNameRequest)packet;
                    if (IsNameExisting(_packet.Name))
                    {
                        client.Write(new PacketSendNameExists(true));
                    }
                    else
                    {
                        client.Name = _packet.Name;
                        client.Write(new PacketSendNameExists(false));
                    }
                }
                else if (packet is PacketReceiveText)
                {
                    PacketReceiveText receivedText = (PacketReceiveText)packet;
                    lastMessages.Remove(receivedText.PacketReceived);
                }
            }
        }

        public HandleClient GetClient(string name)
        {
            try
            {
                return clients.Find(x => x.Name.ToLower() == name.ToLower());
            }
            catch
            {
                return null;
            }
        }

        private bool IsNameExisting(string name)
        {
            try
            {
                HandleClient client = clients.Find(x => x.Name.ToLower() == name.ToLower());
                return client != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
