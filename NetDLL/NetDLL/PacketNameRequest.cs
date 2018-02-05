using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDLL
{
    [Serializable]
    public class PacketNameRequest : Packet
    {
        public string Name { get; private set; }

        public PacketNameRequest(string name)
        {
            Name = name;
        }
    }
}
