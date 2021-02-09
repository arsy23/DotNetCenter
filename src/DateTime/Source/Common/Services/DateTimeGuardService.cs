namespace DotNetCenter.DateTime.Common
{
    using System;
    public static class DateTimeGuard
    {
        public static void ForPrecedesDate(DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
                throw new ArgumentOutOfRangeException(parameterName);
        }
        public static void ForPrecedesDate(CompoundDateTimeService value, CompoundDateTimeService dateToPrecede, string parameterName)
        {
            if (value.DateTime >= dateToPrecede.DateTime)
                throw new ArgumentOutOfRangeException(parameterName);

            if (value.PersianDateTime >= dateToPrecede.PersianDateTime)
                throw new ArgumentOutOfRangeException(parameterName);
        }
    }
}
