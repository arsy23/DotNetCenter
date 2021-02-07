namespace DotNetCenter.DateTime.Common
{
    using DotNetCenter.DateTime.Persian;
    using System;
    public interface CompoundableDateTimeNow
    {
        public PersianDateTime PersianNow => PersianDateTime.Now;
        public DateTime DateTimeNow => DateTime.Now;
    }
}
