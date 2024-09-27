using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.convertors.primitive
{
    public static class IntPtrConvertor
    {
        /// <summary>
        /// Gets bytes of the Pointer Address, 4 in 32bit, 8 in 64bit.
        /// </summary>
        /// <param name="ptr">Pointer</param>
        /// <returns>bytes of the address</returns>
        public static byte[] GetBytes(IntPtr ptr)
        {
            if(IntPtr.Size == 4)
            {
                int address = (int)ptr;
                return IntConvertor.GetBytes(address);
            }
            else
            {
                long address = (long)ptr;
                return LongConvertor.GetBytes(address);
            }
        }

        /// <summary>
        /// Gets bytes of the Pointer Address, 4 in 32bit, 8 in 64bit.
        /// </summary>
        /// <param name="ptr">Pointer</param>
        /// <returns>bytes of the address</returns>
        public static byte[] GetBytes(UIntPtr ptr)
        {
            if (UIntPtr.Size == 4)
            {
                int address = (int)ptr;
                return IntConvertor.GetBytes(address);
            }
            else
            {
                long address = (long)ptr;
                return LongConvertor.GetBytes(address);
            }
        }
    }
}
