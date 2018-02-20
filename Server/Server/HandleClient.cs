using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using NetDLL;

namespace Server
{
    class HandleClient
    {
        public TcpClient Handle { get; private set; }
        public StreamReader In { get; private set; }
        public StreamWriter Out { get; private set; }
        public string Name { get; set; }
        public Thread Thread { get; private set; }
        public Guid ID { get; set; }
        public int Port { get; private set; }

        public HandleClient(TcpClient handle)
        {
            Handle = handle;
            In = new StreamReader(handle.GetStream());
            Out = new StreamWriter(handle.GetStream());
            Thread = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        string s = null;
                        while ((s = In.ReadLine()) != null)
                        {
                            ServerManager.Instance().HandleInput(this, s);
                        }
                    }
                }
                catch
                {
                    ServerManager.Instance().OnDisconnect(this);
                    Close();
                }
            });
            Thread.IsBackground = true;
            Thread.Start();
        }

        public void ChangePort(int port)
        {
            Port = port;
            
        }

        public void Close()
        {
            Thread.Abort();
            In.Close();
            Out.Close();
        }

        public void Write(Packet packet)
        {
            string str = packet.ToString();
            Out.WriteLine(str);
            Out.Flush();
        }
    }
}
