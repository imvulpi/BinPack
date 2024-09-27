using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.convertors.primitive
{
    public static class LongConvertor
    {
        /// <summary>
        /// Gets 8 bytes of the long value
        /// </summary>
        /// <param name="value">long value</param>
        /// <returns>bytes of the value</returns>
        public static byte[] GetBytes(long value)
        {
            byte[] bytes = new byte[8];
            bytes[7] = (byte)(value >> 56);
            bytes[6] = (byte)(value >> 48);
            bytes[5] = (byte)(value >> 40);
            bytes[4] = (byte)(value >> 32);
            bytes[3] = (byte)(value >> 24);
            bytes[2] = (byte)(value >> 16);
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)(value);
            return bytes;
        }

        /// <summary>
        /// Gets 8 bytes of the ulong value
        /// </summary>
        /// <param name="value">ulong value</param>
        /// <returns>bytes of the value</returns>
        public static byte[] GetBytes(ulong value)
        {
            byte[] bytes = new byte[8];
            bytes[7] = (byte)(value >> 56);
            bytes[6] = (byte)(value >> 48);
            bytes[5] = (byte)(value >> 40);
            bytes[4] = (byte)(value >> 32);
            bytes[3] = (byte)(value >> 24);
            bytes[2] = (byte)(value >> 16);
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)(value);
            return bytes;
        }
    }
}
