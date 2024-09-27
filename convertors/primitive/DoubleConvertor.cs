using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.convertors.primitive
{
    public static class DoubleConvertor
    {
        /// <summary>
        /// Gets 8 bytes of a double value.
        /// </summary>
        /// <param name="value">double value</param>
        /// <returns>bytes of the value</returns>
        public unsafe static byte[] GetBytes(double value)
        {
            long bits = *(long*)&value;
            byte[] bytes = new byte[8];
            bytes[7] = (byte)(bits >> 56);
            bytes[6] = (byte)(bits >> 48);
            bytes[5] = (byte)(bits >> 40);
            bytes[4] = (byte)(bits >> 32);
            bytes[3] = (byte)(bits >> 24);
            bytes[2] = (byte)(bits >> 16);
            bytes[1] = (byte)(bits >> 8);
            bytes[0] = (byte)(bits);
            return bytes;
        }
    }
}
