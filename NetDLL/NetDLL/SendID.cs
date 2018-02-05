using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDLL
{
    [Serializable]
    public class SendID : Packet
    {
        public string ID { get; private set; }

        public SendID(string id)
        {
            ID = id;
        }
    }
}
