using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDLL
{
    [Serializable]
    public class PacketCurrentNames : Packet
    {
        public List<string> Names { get; private set; }

        public void AddUser(string name)
        {
            Names.Add(name);
        }

        public void RemoveUser(string name)
        {
            Names.Remove(name);
        }
    }
}
