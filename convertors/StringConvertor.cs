using BinPack.convertors.primitive;

namespace BinPack.convertors
{
    public static class StringConvertor
    {
        /// <summary>
        /// Gets bytes of a string in UTF-16 format (C# standard for strings) (UTF-16 makes a character 2 bytes)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string str) 
        {
            byte[] stringBytes = new byte[str.Length*2];

            int arrayIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                byte[] bytes = CharConvertor.GetBytes(c);

                stringBytes[arrayIndex] = bytes[0];
                stringBytes[arrayIndex + 1] = bytes[1];
                arrayIndex += 2;
            }
            return stringBytes;
        }
    }
}
