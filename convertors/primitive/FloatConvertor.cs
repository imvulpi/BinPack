using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.convertors.primitive
{
    public static class FloatConvertor
    {
        /// <summary>
        /// Gets 4 bytes of a float value
        /// </summary>
        /// <param name="value">float value</param>
        /// <returns>bytes of the value</returns>
        public unsafe static byte[] GetBytes(float value) {
            int bits = *(int*)&value;
            byte[] bytes = new byte[4];
            bytes[3] = (byte)(bits >> 24);
            bytes[2] = (byte)(bits >> 16);
            bytes[1] = (byte)(bits >> 8);
            bytes[0] = (byte)bits;
            return bytes;
        }
    }
}
