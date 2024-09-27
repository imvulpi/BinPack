using System.Reflection;

namespace BinPack.commons
{
    /// <summary>
    /// Helper class for retrieving information or doing actions with an object.
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Gets all public properties of an object
        /// </summary>
        /// <param name="obj">Object from which properties will be retrieved</param>
        /// <returns>Public properties of an object</returns>
        /// <exception cref="Exception">Throws exception if object is null</exception>
        public static PropertyInfo[] GetProperties(object obj)
        {
            if (obj == null)
            {
                throw new Exception("Can't retrieve properties of null");
            }
            PropertyInfo[] properties = obj.GetType().GetProperties();
            return properties;
        }

        /// <summary>
        /// Gets all PropertyInfos marked with a provided attribute in a provided object
        /// </summary>
        /// <param name="obj">Object from which properties will be retrieved</param>
        /// <param name="attributeType">The attribute type members are marked with</param>
        /// <returns>PropertyInfos marked with provided attribute</returns>
        /// <exception cref="Exception">Throws exception if object is null</exception>
        public static PropertyInfo[] GetAttributeMarkedProperties(object obj, Type attributeType)
        {
            if (obj == null)
            {
                throw new Exception("Can't retrieve properties of null");
            }
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return properties.Where(property => property.GetCustomAttributes(attributeType, false).Any()).ToArray();
        }

        /// <summary>
        /// Gets all public fields of an object
        /// </summary>
        /// <param name="obj">Object from which fields will be retrieved</param>
        /// <returns>Public fields of an object</returns>
        /// <exception cref="Exception">Throws exception if object is null</exception>
        public static FieldInfo[] GetFields(object obj)
        {
            if (obj == null)
            {
                throw new Exception("Can't retrieve properties of null");
            }
            FieldInfo[] fields = obj.GetType().GetFields();
            return fields;
        }

        /// <summary>
        /// Gets all FieldInfos marked with a provided attribute in a provided object
        /// </summary>
        /// <param name="obj">Object from which fields will be retrieved</param>
        /// <param name="attributeType">The attribute type fields are marked with</param>
        /// <returns>FieldInfos marked with provided attribute</returns>
        /// <exception cref="Exception">Throws exception if object is null</exception>
        public static FieldInfo[] GetAttributeMarkedFields(object obj, Type attributeType)
        {
            if (obj == null)
            {
                throw new Exception("Can't retrieve fields of null");
            }
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return fields.Where(field => field.GetCustomAttributes(attributeType, false).Any()).ToArray();
        }

        /// <summary>
        /// Gets all MemberInfos marked with a provided attribute in a provided object
        /// </summary>
        /// <param name="obj">Object from which members will be retrieved</param>
        /// <param name="attributeType">The attribute type members are marked with</param>
        /// <returns>MemberInfos marked with provided attribute</returns>
        /// <exception cref="Exception">Throws exception if object is null</exception>
        public static MemberInfo[] GetAttributeMarkedMembers(object obj, Type attributeType)
        {
            if (obj == null)
            {
                throw new Exception("Can't retrieve members of null");
            }
            Type type = obj.GetType();
            MemberInfo[] members = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return members.Where(member => member.GetCustomAttributes(attributeType, false).Any()).ToArray();
        }
    }
}
