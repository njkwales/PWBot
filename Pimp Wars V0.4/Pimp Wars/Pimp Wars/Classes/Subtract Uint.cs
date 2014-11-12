using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pimp_Wars
{
    class Subtract_Uint
    {
        public ulong Subtract(ulong one, ulong two)   
        {
            checked
            {
                try
                {
                    ulong three = one - two;
                    return three;
                }
                catch
                {
                    return 0;
                }               
            }

        }

    }
}
