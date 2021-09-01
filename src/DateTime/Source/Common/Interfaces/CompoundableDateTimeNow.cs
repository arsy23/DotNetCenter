namespace DotNetCenter.DateTime.Common
{
    using DotNetCenter.DateTime.Persian;
    using System;
    public interface CompoundableDateTimeNow
    {
#if NETSTANDARD2_0
        public PersianDateTime PersianNow {get;}
        public DateTime DateTimeNow { get; }
#else
        public virtual PersianDateTime PersianNow => PersianDateTime.Now;
        public virtual DateTime DateTimeNow => DateTime.Now;
#endif
    }
}
