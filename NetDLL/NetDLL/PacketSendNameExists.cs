using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDLL
{
    [Serializable]
    public class PacketSendNameExists : Packet
    {
        public bool Exists { get; private set; }

        public PacketSendNameExists(bool exists)
        {
            Exists = exists;
        }
    }
}
