using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NetDLL;

namespace Server
{
    class ServerManager
    {
        static ServerManager instance;
        private TcpListener server;
        private Thread waitingForUsers;
        private List<HandleClient> clients;
        private PacketCurrentNames currentUserNames;

        public ServerManager()
        {
            instance = this;
            currentUserNames = new PacketCurrentNames();
            server = new TcpListener(new IPEndPoint(IPAddress.Loopback, 15567));
            clients = new List<HandleClient>();
            waitingForUsers = new Thread(x => {
                while(true){
                    TcpClient client = server.AcceptTcpClient();
                    if (client != null && clients.Count != 10)
                    {
                        Console.WriteLine(" >> User connected");
                        HandleClient handle = new HandleClient(client);
                        clients.Add(handle);
                        handle.Write(new PacketConnected());
                        handle.ID = Guid.NewGuid();
                        handle.Write(new PacketSendID(handle.ID.ToString()));
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
            Console.WriteLine(" >> Server started");
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
                else if (packet is PacketNameRequest)
                {
                    Console.WriteLine(" >> Name check requested");
                    PacketNameRequest _packet = (PacketNameRequest)packet;
                    if (IsNameExisting(_packet.Name))
                    {
                        Console.WriteLine(" >> Username accepted");
                        client.Write(new PacketSendNameExists(true));
                        currentUserNames.AddUser(client.Name);
                        clients.ForEach(x =>
                        {
                            Console.WriteLine(" >> Current Users sent");
                            x.Write(currentUserNames);
                        });
                    }
                    else
                    {
                        client.Name = _packet.Name;
                        client.Write(new PacketSendNameExists(false));
                    }
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
            foreach (HandleClient h in clients)
            {
                if (h.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
