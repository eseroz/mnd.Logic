using Newtonsoft.Json;

namespace mnd.Logic.Helper
{
    public class PandapObjectHelper
    {
        public void GetAppCommandList()
        {
        }

        public static T CopyObject<T>(T _obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(_obj));
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src);
        }
    }
}