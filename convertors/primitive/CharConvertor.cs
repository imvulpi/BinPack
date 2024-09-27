namespace BinPack.convertors.primitive
{
    public static class CharConvertor
    {
        /// <summary>
        /// Gets 2 bytes of a char in UTF-16 format (C# standard for char)
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public unsafe static byte[] GetBytes(char character)
        {
            short charbits = *(short*)&character;
            return ShortConvertor.GetBytes(charbits);
        }
    }
}
