using System.Text;

namespace mnd.Logic
{
    public static class StringExtensions
    {

        public static string ToNetsisCollation(this string str)
        {
            return Encoding.GetEncoding(1252).GetString(Encoding.GetEncoding(1254).GetBytes(str));

        }

        public static string FromNetsisCollation(this string str)
        {
            if (str == null) return "";
            return Encoding.GetEncoding(1254).GetString(Encoding.GetEncoding(1252).GetBytes(str));
        }
    }
}
