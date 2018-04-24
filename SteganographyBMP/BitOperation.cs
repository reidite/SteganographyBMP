using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyBMP
{
    class BitWise
    {
        public static byte Extract(byte B, int pos)
        {
            return (byte)((B & (1 << pos)) >> pos);
        } 

        public static void Replace(ref byte B,int pos, byte value)
        {
            B = (byte)(value == 1 ? B | (1 << pos) : B & ~(1 << pos));
        }
    }
}
