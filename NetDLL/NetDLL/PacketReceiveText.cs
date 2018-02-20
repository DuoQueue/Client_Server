using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDLL
{
    [Serializable]
    public class PacketReceiveText : Packet
    {
        public PacketSendText PacketReceived { get; private set; }
        public string Receiver { get; private set; }

        public PacketReceiveText(string name, PacketSendText packet)
        {
            PacketReceived = packet;
            Receiver = name;
        }
    }
}
