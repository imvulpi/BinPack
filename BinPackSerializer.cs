using BinPack.commons;
using BinPack.convertors;
using BinPack.serializers;
using System.Collections;

namespace BinPack
{
    /// <summary>
    /// Serializes or Deserializes objects in the BinPack format.
    /// </summary>
    public static class BinPackSerializer
    {
        /// <summary>
        /// Serializes an object using the internal implementations<br></br>Creates a new memory stream and returns it in an byte array.
        /// </summary>
        /// <param name="obj">Object to be serialized</param>
        /// <returns>Serialized bytes</returns>
        public static byte[] Serialize(object obj)
        {
            MemoryStream stream = new();
            SerializeInternal(stream, obj);
            byte[] data = stream.ToArray();
            stream.Dispose();
            return data;
        }

        /// <summary>
        /// Internal serialization, uses different types of serializators including class serializator and primitive serializator.<br></br>
        /// Implemented types:
        /// Primitive types, 
        /// String, 
        /// Classes with implemented types, 
        /// <br></br>
        /// Not implemented (TO-BE): Arrays (excluding byte[]), Dictionaries, More complicated data structures
        /// </summary>
        /// <param name="stream">Stream bytes should be written to</param>
        /// <param name="obj">Object to be serialized</param>
        private static void SerializeInternal(MemoryStream stream, object obj)
        {
            if (obj == null)
            {
                stream.WriteByte(StructureHelper.NULL);
                return;
            }

            Type objType = obj.GetType();
            if (objType.IsPrimitive)
            {
                PrimitiveSerializer.Serialize(stream, objType, obj);
                return;
            }
            else if (objType.IsClass && !objType.IsArray && objType != typeof(string))
            {
                stream.WriteByte(StructureHelper.OBJECT_START);
                ClassSerializer.Serialize(stream, objType, obj);
                stream.WriteByte(StructureHelper.OBJECT_END);
            }else if (objType.IsArray)
            {
                ArraySerializer.SerializeArray(stream, objType, obj);
            }
            else if (objType == typeof(string)) // Special
            {
                StructureHelper.WriteValue(stream, StringConvertor.GetBytes((string)obj));
            }
        }
    }
}
