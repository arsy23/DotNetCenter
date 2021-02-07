namespace DotNetCenter.DateTime.Persian
{
    using System;
    /// <summary>
    /// Provide D
    /// </summary>
    public static class DateTimeConversions
    {
        /// <summary>s
        /// تبدیل تاریخ از میلادی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ میلادی</param>
        /// <returns> یکشنبه 5 شهریور 1396 ساعت 15:16:29 </returns>
        public static string ToPersianDateTimeString(this DateTime datetime) => new PersianDateTime(datetime).ToString("dddd d MMMM yyyy ساعت HH:mm:ss");

        /// تبدیل تاریخ از میلادی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ به میلادی</param>
        /// <returns> یکشنبه 2 شهریور 1396 </returns>
        public static string ToPersianDateString(this DateTime datetime) => new PersianDateTime(datetime).ToString("dddd d MMMM yyyy");

        /// <summary>
        /// تبدیل تاریخ از میلادی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ میلادی</param>
        /// <returns> 1396/06/12 15:16:29 </returns>
        public static PersianDateTime ToPersianDateTime(this DateTime datetime) => new PersianDateTime(datetime);

        /// <summary>
        /// تبدیل تاریخ میلادی به میلادی
        /// </summary>
        /// <param name="datetime">تاریخ میلادی</param>
        /// <returns> Sunday 3 September 2017 03:16:29 PM </returns>
        public static string ToDateTimeString(this DateTime datetime) => datetime.ToString("dddd d MMMM yyyy hh:mm:ss tt");

        /// <summary>
        /// تبدیل تاریخ میلادی به میلادی
        /// </summary>
        /// <param name="datetime">تاریخ میلادی</param>
        /// <returns> 2017/09/3 15:16:29 </returns>
        public static string ToDigitalDateTimeString(this DateTime datetime) => datetime.ToString("yyyy/MM/d H:mm:ss");

        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ میلادی</param>
        /// <returns> 1396/06/12 15:16:29 </returns>
        public static string ToPersianDigitalDateTimeString(this DateTime datetime) => new PersianDateTime(datetime).ToString("yyyy/MM/d H:mm:ss");

        /// <summary>
        /// تبدیل تاریخ شمسی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ شمسی</param>
        /// <returns> یکشنبه 12 شهریور 1396 </returns>
        public static string ToPersianDateString(this PersianDateTime datetime) => datetime.ToString("dddd d MMMM yyyy");

        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="datetime">تاریخ شمسی</param>
        /// <returns> 9/3/2017 3:16:29 PM </returns>
        public static DateTime ToDateTime(this PersianDateTime datetime) => datetime.ToDateTime();

        /// <summary>
        /// تبدیل تاریخ شمسی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ شمسی</param>
        /// <returns> 1396/06/12 15:16:29 </returns>
        public static string ToPersianDigitalDateTimeString(this PersianDateTime datetime) => datetime.ToString("yyyy/MM/d H:mm:ss");

        /// <summary>
        /// تبدیل تاریخ شمسی به شمسی
        /// </summary>
        /// <param name="datetime">تاریخ شمسی</param>
        /// <returns>1396/06/12</returns>
        public static string ToPersianDigitalDateString(this PersianDateTime datetime) => datetime.ToString("yyyy/MM/d");

        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="datetime">تاریخ شمسی</param>
        /// <returns>Sunday 3 September 2017 </returns>
        public static string ToDateString(this PersianDateTime datetime) => datetime.ToDateTime().ToString("dddd d MMMM yyyy");

        public static int ToInteger(this TimeSpan time)
            => int.Parse($"{ time.Hours }{ time.Minutes.ToString().PadLeft(2, '0') }{ time.Seconds.ToString().PadLeft(2, '0') }");
    
        public static short ToShort(this TimeSpan time) => short.Parse($"{ time.Hours}{ time.Minutes.ToString().PadLeft(2, '0') }");

        public static string ToHHMM(this TimeSpan time) => time.ToString("hh\\:mm");

        public static string ToHHMMSS(this TimeSpan time) => time.ToString("hh\\:mm\\:ss");
    }
}