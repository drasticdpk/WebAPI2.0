using System.IO;
using System.Web.Script.Serialization;

namespace Remit.API
{
    public class General
    {
        internal static string GetObjectDescription(object obj)
        {
            if (obj == null)
            {
                return "NULL";
            }
            if (obj is string || obj.GetType().IsValueType)
            {
                return obj.ToString();
            }
            if (obj is Stream)
            {
                return $"stream size={((Stream)obj).Length}";
            }

            try
            {
                return new JavaScriptSerializer().Serialize(obj);
            }
            catch
            {
                return "Object cannot be represented.";
            }
        }
    }
}