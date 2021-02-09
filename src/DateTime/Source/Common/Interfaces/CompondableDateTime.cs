namespace DotNetCenter.DateTime.Common
{
    using DotNetCenter.DateTime.Persian;
    using System;
    public interface CompoundableDateTime
    {
        public PersianDateTime PersianDateTime { get; }
        public DateTime DateTime { get; }
    }
}