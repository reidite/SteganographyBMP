using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SteganographyBMP
{
    class LSB
    {
        public static void Encode(FileStream inStream, byte[] message, FileStream outStream)
        {
            int byteRead;
            byte byteWrite;
            int i = 0;
            int j = 0;
            while ((byteRead = inStream.ReadByte()) != -1)
            {
                byteWrite = (byte)byteRead;

                if (i< message.Length)
                {
                    byte bit = BitWise.Extract(message[i], j++);
                    BitWise.Replace(ref byteWrite, 0, bit);
                    if(j==8) { j = 0; i++; }
                }
                outStream.WriteByte(byteWrite);
            }

            if (i < message.Length)
                throw new Exception("The message is too big!");
        }
        public static byte[] Decode(FileStream inStream, int length)
        {
            int byteIndex = 0;
            int bitIndex = 0;
            byte[] arrResult = new byte[length];
            int byteRead;
            while ((byteRead = inStream.ReadByte()) != -1)
            {
                byte bit = BitWise.Extract((byte)byteRead, 0);
                BitWise.Replace(ref arrResult[byteIndex], bitIndex++, bit);
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
                if (byteIndex == length) break;
            }
            return arrResult;
        }
    }
}
