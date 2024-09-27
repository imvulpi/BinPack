using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack
{
    /// <summary>
    /// Attribute used for marking fields or properties to be serialized or deserialized.<br></br>
    /// Private properties or fields with this attribute will get processed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class BinPackAttribute : Attribute
    {
    }
}
