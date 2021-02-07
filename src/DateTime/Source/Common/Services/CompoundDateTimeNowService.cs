namespace DotNetCenter.DateTime.Common
{
    using DotNetCenter.DateTime.Persian;
    using System;

    public class CompoundDateTimeNowService : CompoundableDateTimeNow
    {
        public PersianDateTime PersianNow => PersianDateTime.Now;
        public DateTime DateTimeNow => DateTime.UtcNow;
    }
}
