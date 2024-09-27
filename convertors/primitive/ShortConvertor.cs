using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.convertors.primitive
{
    public static class ShortConvertor
    {
        /// <summary>
        /// Gets bytes of a short
        /// </summary>
        /// <param name="value">short value</param>
        /// <returns>byte of the value</returns>
        public static byte[] GetBytes(short value)
        {
            byte[] bytes = new byte[2];
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)value;
            return bytes;
        }

        /// <summary>
        /// Gets bytes of a ushort
        /// </summary>
        /// <param name="value">ushort value</param>
        /// <returns>byte of the value</returns>
        public static byte[] GetBytes(ushort value)
        {
            byte[] bytes = new byte[2];
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)value;
            return bytes;
        }
    }
}
