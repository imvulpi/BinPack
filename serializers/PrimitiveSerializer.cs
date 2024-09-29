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
        private readonly static Type boolType = typeof(bool);
        private readonly static Type byteType = typeof(byte);
        private readonly static Type sbyteType = typeof(sbyte);
        private readonly static Type shortType = typeof(short);
        private readonly static Type ushortType = typeof(ushort);
        private readonly static Type intType = typeof(int);
        private readonly static Type uintType = typeof(uint);
        private readonly static Type longType = typeof(long);
        private readonly static Type ulongType = typeof(ulong);
        private readonly static Type doubleType = typeof(double);
        private readonly static Type floatType = typeof(float);
        private readonly static Type charType = typeof(sbyte);
        private readonly static Type intPtrType = typeof(IntPtr);
        private readonly static Type uintPtrType = typeof(UIntPtr);

        /// <summary>
        /// Serializes primitive types from object and object type. Writes it in the provided stream
        /// </summary>
        /// <param name="stream">Stream where to write serialized bytes</param>
        /// <param name="objType">Type of the object to be serialized</param>
        /// <param name="obj">Object to be serialized</param>
        /// <exception cref="NotSupportedException">Throws an error if type is not supported</exception>
        public static void Serialize(MemoryStream stream, Type objType, object obj)
        {
            if (objType == boolType)
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
            else if (objType == byteType)
            {
                stream.WriteByte((byte)obj);
            }
            else if (objType == sbyteType)
            {
                StructureHelper.WriteValue(stream, new byte[ByteHelper.GetBytes((sbyte)obj)]); // Could be optimizied
            }
            else if (objType == shortType)
            {
                StructureHelper.WriteValue(stream, ShortConvertor.GetBytes((short)obj));
            }
            else if (objType == ushortType)
            {
                StructureHelper.WriteValue(stream, ShortConvertor.GetBytes((ushort)obj));
            }
            else if (objType == intType)
            {
                StructureHelper.WriteValue(stream, IntConvertor.GetBytes((int)obj));
            }
            else if (objType == uintType)
            {
                StructureHelper.WriteValue(stream, IntConvertor.GetBytes((uint)obj));
            }
            else if (objType == longType)
            {
                StructureHelper.WriteValue(stream, LongConvertor.GetBytes((long)obj));
            }
            else if (objType == ulongType)
            {
                StructureHelper.WriteValue(stream, LongConvertor.GetBytes((ulong)obj));
            }
            else if (objType == floatType)
            {
                StructureHelper.WriteValue(stream, FloatConvertor.GetBytes((float)obj));
            }
            else if (objType == doubleType)
            {
                StructureHelper.WriteValue(stream, DoubleConvertor.GetBytes((double)obj));
            }
            else if (objType == charType)
            {
                StructureHelper.WriteValue(stream, CharConvertor.GetBytes((char)obj));
            }
            else if (objType == intPtrType)
            {
                StructureHelper.WriteValue(stream, IntPtrConvertor.GetBytes((IntPtr)obj));
            }
            else if (objType == uintPtrType)
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
