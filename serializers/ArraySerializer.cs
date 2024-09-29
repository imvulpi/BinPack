using BinPack.commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinPack.serializers
{
    public static class ArraySerializer
    {
        /// <summary>
        /// Serializes an object of Array type
        /// </summary>
        /// <param name="stream">Stream where bytes should be written to.</param>
        /// <param name="objType">Type of the object</param>
        /// <param name="obj">Object to be serialized</param>
        public static void SerializeArray(MemoryStream stream, Type objType, object obj)
        {
            if (obj == null || objType.IsArray == false) return;
            Type? elementType = objType.GetElementType();
            int dimensionsAmount = objType.GetArrayRank();
            if (elementType != null)
            {
                int[] dimensionLengths = CollectArraysLengthDimensions(objType, obj).ToArray();
                Array array = Array.CreateInstance(elementType, dimensionLengths);
                ProcessArray(stream, array, (Array)obj, 0, dimensionLengths);
            }
        }
        
        public static void ProcessArray(MemoryStream stream, Array array, Array objArray, int dimension, int[] dimensionLengths)
        {
            ProcessArrayRecursive(stream, array, objArray, dimension, dimensionLengths, new int[dimensionLengths.Length]);
        }

        public static void ProcessArrayRecursive(MemoryStream stream, Array array, Array objArray, int dimension, int[] dimensionLengths, int[] indices)
        {
            if (dimension == array.Rank)
            {
                object? value = objArray.GetValue(indices);
                StructureHelper.WriteArrayValue(stream, BinPackSerializer.Serialize(value));
                return;
            }

            stream.WriteByte(StructureHelper.ARRAY_START);

            for (int i = 0; i < dimensionLengths[dimension]; i++)
            {
                indices[dimension] = i;
                ProcessArrayRecursive(stream, array, objArray, dimension + 1, dimensionLengths, indices);
                if (i < dimensionLengths[dimension]-1)
                {
                    stream.WriteByte(StructureHelper.VALUE_NEXT);
                }
            }

            stream.WriteByte(StructureHelper.ARRAY_END);
        }

        private static List<int> CollectArraysLengthDimensions(Type objType, object obj)
        {
            List<int> dimensionsLengths = new List<int>();
            int dimensionsAmount = objType.GetArrayRank();
            Array objArray = (Array)obj;
            for (int i = 0; i < dimensionsAmount; i++)
            {
                dimensionsLengths.Add(objArray.GetLength(i));
            }
            return dimensionsLengths;
        }

        private static string DisplayBytes(byte[] bytes, bool spaceBytes = true)
        {
            string stringBytes = "";
            foreach(byte b in bytes)
            {
                BitArray bitArray = new BitArray(b);
                foreach(bool i in bitArray)
                {
                    if (i)
                    {
                        stringBytes += "1";
                    }
                    else
                    {
                        stringBytes += "0";
                    }
                }

                if (spaceBytes)
                {
                    stringBytes = " ";
                }
            }
            return stringBytes;
        }
    }
}
