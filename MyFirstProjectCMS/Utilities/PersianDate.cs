using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyProjectCMS.Utilities
{
    public static class PersianDate
    {
        public static string ConvertToShamsi(this DateTime value)
        {
            PersianCalendar persiancal = new PersianCalendar();
            return persiancal.GetYear(value) + "/" + persiancal.GetMonth(value).ToString("00") + "/" +
                   persiancal.GetDayOfMonth(value).ToString("00");
        }
    }
}