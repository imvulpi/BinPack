using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.commons
{
    /// <summary>
    /// Helper class for processing, writing and other actions involved with bytes.
    /// </summary>
    public static class ByteHelper
    {
        /// <summary>
        /// Iterates over all bytes and writes them 1 by 1 in a provided stream
        /// </summary>
        /// <param name="stream">Bytes will be written here</param>
        /// <param name="bytes">The bytes to be written</param>
        public static void WriteByteArray(MemoryStream stream, byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                stream.WriteByte(b);
            }
        }

        /// <summary>
        /// Explicitly casts sbyte to byte and writes it.
        /// </summary>
        /// <param name="stream">Sbyte will be written here</param>
        /// <param name="value">Sbyte value</param>
        public static void WriteSbyte(MemoryStream stream, sbyte value)
        {
            stream.WriteByte((byte)value);
        }

        /// <summary>
        /// Gets a byte from sbyte. (Explicit cast)
        /// </summary>
        /// <param name="value">Sbyte value</param>
        /// <returns>byte from sbyte</returns>
        public static byte GetBytes(sbyte value)
        {
            return (byte)value;
        }
    }
}
