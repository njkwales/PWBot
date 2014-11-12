using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pimp_Wars
{
    class Ready
    {
        public bool wp2done { get; set; }
        public bool wp3done { get; set; }
        public bool wp4done { get; set; }
        public bool wp5done { get; set; }
        public bool wp6done { get; set; }
        public bool wp7done { get; set; }
        public bool wp8done { get; set; }

        public bool ReadyCheck()
        {
            if (wp2done == true & wp3done == true & wp4done == true & wp5done == true & wp6done == true & wp7done == true & wp8done == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
