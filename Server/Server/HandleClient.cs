using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class HandleClient
    {
        public TcpClient Handle { get; private set; }
        public StreamReader In { get; private set; }
        public StreamWriter Out { get; private set; }
        public string Name { get; private set; }
        public Thread Thread { get; private set; }

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

        private void Close()
        {
            Thread.Abort();
            In.Close();
            Out.Close();
        }
    }
}
