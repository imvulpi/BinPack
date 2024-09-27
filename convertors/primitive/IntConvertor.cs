using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.convertors.primitive
{
    public static class IntConvertor
    {
        /// <summary>
        /// Gets 4 bytes of a int value
        /// </summary>
        /// <param name="value">int value</param>
        /// <returns>bytes of the value</returns>
        public static byte[] GetBytes(int value)
        {
            byte[] bytes = new byte[4];
            bytes[3] = (byte)(value >> 24);
            bytes[2] = (byte)(value >> 16);
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)(value);
            return bytes;
        }

        /// <summary>
        /// Gets 4 bytes of a uint value
        /// </summary>
        /// <param name="value">uint value</param>
        /// <returns>bytes of the value</returns>
        public static byte[] GetBytes(uint value)
        {
            byte[] bytes = new byte[4];
            bytes[3] = (byte)(value >> 24);
            bytes[2] = (byte)(value >> 16);
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)(value);
            return bytes;
        }
    }
}
