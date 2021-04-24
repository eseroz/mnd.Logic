using System;

namespace mnd.Logic.Helper
{
    public class Utils
    {
        public static string AyAdiBul_Haftadan(int yil, int hafta)
        {
            var day = hafta * 7 - 7 + 1;
            var t = new DateTime(yil, 1, 1).AddDays(day - 1).Date.ToShortDateString().Split('.')[1];

            return t;
        }
    }
}