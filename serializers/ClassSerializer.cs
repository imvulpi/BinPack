using BinPack.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.serializers
{
    public static class ClassSerializer
    {
        /// <summary>
        /// Serializes the provided object in an internal implementations. Writes it in the stream.
        /// </summary>
        /// <param name="stream">Stream where the object should be written</param>
        /// <param name="objType">Type of the object to be serialized</param>
        /// <param name="obj">Object to be serialized</param>
        public static void Serialize(MemoryStream stream, Type objType, object obj)
        {
            ProcessRecursive(stream, objType, obj);
        }

        /// <summary>
        /// Internal implementation for class serialization, writes the object in a provided stream.<br></br>
        /// Skips indexers, passes serialization to a main serializator (recursive) or writes null if object is null.
        /// </summary>
        /// <param name="stream">Stream where the object should be written</param>
        /// <param name="objType">Type of the object to be serialized</param>
        /// <param name="obj">Object to be serialized</param>
        private static void ProcessRecursive(MemoryStream stream, Type objType, object obj)
        {
            PropertyInfo[] properties = ObjectHelper.GetProperties(obj);
            PropertyInfo[] privateProperties = ObjectHelper.GetAttributeMarkedProperties(obj, typeof(BinPackAttribute));

            ProcessProperties(stream, privateProperties, objType, obj);
            ProcessProperties(stream, properties, objType, obj);

            FieldInfo[] fields = ObjectHelper.GetFields(obj);
            FieldInfo[] privateFields = ObjectHelper.GetAttributeMarkedFields(obj, typeof(BinPackAttribute));

            ProcessFields(stream, fields, objType, obj);
            ProcessFields(stream, privateFields, objType, obj);
        }

        /// <summary>
        /// Processes properties, serializes them and writes in a stream
        /// </summary>
        private static void ProcessProperties(MemoryStream stream, PropertyInfo[] properties, Type objType, object obj) {
            bool writeValueNext = false;
            foreach (PropertyInfo property in properties)
            {
                // Skips the indexers
                if (property.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                if (writeValueNext)
                {
                    stream.WriteByte(StructureHelper.VALUE_NEXT);
                }

                StructureHelper.WriteKey(stream, property.Name);
                object? propertyValue = property.GetValue(obj);
                if (propertyValue == null)
                {
                    stream.WriteByte(StructureHelper.VALUE_START);
                    StructureHelper.WriteValue(stream, null);
                    stream.WriteByte(StructureHelper.NULL);
                }
                else
                {
                    stream.WriteByte(StructureHelper.VALUE_START);
                    StructureHelper.WriteValue(stream, BinPackSerializer.Serialize(propertyValue));
                }
                writeValueNext = true;
            }
        }

        /// <summary>
        /// Processes fields, serializes them and writes in a stream
        /// </summary>
        private static void ProcessFields(MemoryStream stream, FieldInfo[] properties, Type objType, object obj)
        {
            bool writeValueNext = false;
            foreach (FieldInfo property in properties)
            {
                if (writeValueNext)
                {
                    stream.WriteByte(StructureHelper.VALUE_NEXT);
                }

                StructureHelper.WriteKey(stream, property.Name);
                object? propertyValue = property.GetValue(obj);
                if (propertyValue == null)
                {   
                    StructureHelper.WriteValue(stream, null);
                    stream.WriteByte(StructureHelper.NULL);
                }
                else
                {
                    ByteHelper.WriteByteArray(stream, BinPackSerializer.Serialize(propertyValue));
                }
                writeValueNext = true;
            }
        }
    }
}
