using BinPack.convertors;
using System.Security.AccessControl;

namespace BinPack.commons
{
    /// <summary>
    /// Helper class for keeping the BinPack format structure, contains helpful methods to maintain the structure.
    /// </summary>
    public static class StructureHelper
    {
        // MARKERS:
        /// <summary>Value of: 0x0</summary>
        public const byte NULL = 0b00000000; // 0x0
        /// <summary>Value of: "</summary>
        public const byte START_END = 0b00100010; // "
        /// <summary>Value of: \</summary>
        public const byte ESCAPE = 0b01011100; // \
        /// <summary>Value of: :</summary>
        public const byte VALUE_START = 0b00111010; // :
        /// <summary>Value of: ,</summary>
        public const byte VALUE_NEXT = 0b00101100; // ,
        /// <summary>Value of: {</summary>
        public const byte OBJECT_START = 0b01111011; // {
        /// <summary>Value of: }</summary>
        public const byte OBJECT_END = 0b01111101; // }
        /// <summary>Value of: [</summary>
        public const byte ARRAY_START = 0b01011011; // [
        /// <summary>Value of: ]</summary>
        public const byte ARRAY_END = 0b01011101; // ]

        // Interpreted:
        /// <summary><</summary>
        public const byte VALUE_DATA_START = 0b00111100; // <
        /// <summary>></summary>
        public const byte VALUE_DATA_END = 0b00111110; // >

        /// <summary>
        /// Writes a key in stream from provided entry name
        /// </summary>
        /// <param name="stream">Stream where the key should be written</param>
        /// <param name="entry">Key name</param>
        public static void WriteKey(MemoryStream stream, string entry)
        {
            byte[] stringBytes = StringConvertor.GetBytes(entry);
            stream.WriteByte(START_END);
            for (int i = 0; i < stringBytes.Length; i++)
            {
                if (stringBytes[i] == START_END)
                {
                    if (i <= 0 || (i > 0 && stringBytes[i-1] != ESCAPE))
                    {
                        stream.WriteByte(ESCAPE); // might break if needs to be 2 bytes (short)
                    }
                }
                stream.WriteByte(stringBytes[i]);
            }
            stream.WriteByte(START_END);
        }

        /// <summary>
        /// Writes a marker of value in provided stream
        /// </summary>
        /// <param name="stream">Stream the marker should be written to.</param>
        public static void WriteValueMarker(MemoryStream stream)
        {
            stream.WriteByte(VALUE_START);
        }

        /// <summary>
        /// Writes a value in a correct structure<br></br>NOTE: This doesn't check for illegal characters.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        public static void WriteValue(MemoryStream stream, byte[]? value)
        {
            if (value == null)
            {
                stream.WriteByte(NULL);
                return;
            }
            ByteHelper.WriteByteArray(stream, value);
        }

        public static void WriteArrayValue(MemoryStream stream, byte[]? value)
        {
            stream.WriteByte(VALUE_DATA_START);
            if (value == null)
            {
                stream.WriteByte(NULL);
                stream.WriteByte(VALUE_DATA_END);
                return;
            }
            ByteHelper.WriteByteArray(stream, value);
            stream.WriteByte(VALUE_DATA_END);
        }

        /// <summary>
        /// Creates a list of bytes and escapes illegal characters, returns list in a new array.<br></br>
        /// NOTE: This is slow, and might need to be optimized later on.
        /// </summary>
        /// <param name="bytes">Bytes that should be checked</param>
        /// <returns>Escaped bytes</returns>
        public static byte[] EscapeIllegal(byte[] bytes)
        {
            List<byte> escapedArray = new List<byte>();
            byte? previousByte = null;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == START_END)
                {
                    if ((previousByte != null && previousByte != ESCAPE) || previousByte == null)
                    {
                        escapedArray.Add(ESCAPE);
                    }
                }
                escapedArray.Add(bytes[i]);
                previousByte = bytes[i];
            }
            return escapedArray.ToArray();
        }
    }
}
