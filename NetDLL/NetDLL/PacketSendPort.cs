using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDLL
{
    [Serializable]
    public class PacketSendPort : Packet
    {
        public int Port { get; private set; }

        public PacketSendPort(int port)
        {
            Port = port;
        }
    }
}
