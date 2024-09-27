using BinPack.commons;
using BinPack.convertors.primitive;

namespace BinPack.serializers
{
    /// <summary>
    /// Supports serialization of primitive types<br></br>
    /// The primitive types are Bool, Byte, SByte, Int16(short), UInt16(ushort), Int32(int), UInt32(uint), Int64(long), UInt64(ulong), IntPtr, UIntPtr, Char, Double(double), and Single(float).
    /// </summary>
    public static class PrimitiveSerializer
    {
        /// <summary>
        /// Serializes primitive types from object and object type. Writes it in the provided stream
        /// </summary>
        /// <param name="stream">Stream where to write serialized bytes</param>
        /// <param name="objType">Type of the object to be serialized</param>
        /// <param name="obj">Object to be serialized</param>
        /// <exception cref="NotSupportedException">Throws an error if type is not supported</exception>
        public static void Serialize(MemoryStream stream, Type objType, object obj)
        {
            if (objType == typeof(bool))
            {
                bool boolObj = (bool)obj;
                if (boolObj)
                {
                    stream.WriteByte(1);
                }
                else
                {
                    stream.WriteByte(0);
                }
            }
            else if (objType == typeof(byte))
            {
                stream.WriteByte((byte)obj);
            }
            else if (objType == typeof(sbyte))
            {
                StructureHelper.WriteValue(stream, new byte[ByteHelper.GetBytes((sbyte)obj)]); // Could be optimizied
            }
            else if (objType == typeof(short))
            {
                StructureHelper.WriteValue(stream, ShortConvertor.GetBytes((short)obj));
            }
            else if (objType == typeof(ushort))
            {
                StructureHelper.WriteValue(stream, ShortConvertor.GetBytes((ushort)obj));
            }
            else if (objType == typeof(int))
            {
                StructureHelper.WriteValue(stream, IntConvertor.GetBytes((int)obj));
            }
            else if (objType == typeof(uint))
            {
                StructureHelper.WriteValue(stream, IntConvertor.GetBytes((uint)obj));
            }
            else if (objType == typeof(long))
            {
                StructureHelper.WriteValue(stream, LongConvertor.GetBytes((long)obj));
            }
            else if (objType == typeof(ulong))
            {
                StructureHelper.WriteValue(stream, LongConvertor.GetBytes((ulong)obj));
            }
            else if (objType == typeof(float))
            {
                StructureHelper.WriteValue(stream, FloatConvertor.GetBytes((float)obj));
            }
            else if (objType == typeof(double))
            {
                StructureHelper.WriteValue(stream, DoubleConvertor.GetBytes((double)obj));
            }
            else if (objType == typeof(char))
            {
                StructureHelper.WriteValue(stream, CharConvertor.GetBytes((char)obj));
            } 
            else if(objType == typeof(IntPtr))
            {
                StructureHelper.WriteValue(stream, IntPtrConvertor.GetBytes((IntPtr)obj));
            }
            else if(objType == typeof(UIntPtr))
            {
                StructureHelper.WriteValue(stream, IntPtrConvertor.GetBytes((UIntPtr)obj));
            }
            else
            {
                throw new NotSupportedException($"Type {objType} is not supported for serialization.");
            }
        }
    }
}
