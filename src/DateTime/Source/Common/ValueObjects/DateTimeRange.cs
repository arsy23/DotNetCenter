namespace DotNetCenter.DateTime.Common
{
    using System;
    using System.Collections.Generic;
    using DotNetCenter.Core.Entities;
    using DotNetCenter.DateTime.Persian;

    public class DateTimeRange : BaseValueObject<DateTimeRange>
    {
        public CompoundDateTimeService Start { get; set; }
        public CompoundDateTimeService End { get; set; }

        public DateTimeRange(CompoundDateTimeService start, CompoundDateTimeService end)
        {
            DateTimeGuard.ForPrecedesDate(start.DateTime, end.DateTime, "start");
            Start = start;
            End = end;
        }

        public DateTimeRange(CompoundDateTimeService start, TimeSpan duration) : this(start, start.Add(duration))
        { }

        protected DateTimeRange()
        { }

        public int DurationInMinutesForUtc()
            => (End.DateTime - Start.DateTime).Minutes;
        public int DurationInMinutesForPersian()
            =>(End.PersianDateTime - Start.PersianDateTime).Minutes;
        
        public DateTimeRange NewEnd(CompoundDateTimeService newEnd)
            => new DateTimeRange(this.Start, newEnd);

        public DateTimeRange NewDuration(TimeSpan newDuration)
            => new DateTimeRange(this.Start, newDuration);

        public DateTimeRange NewStart(CompoundDateTimeService newStart)
            => new DateTimeRange(newStart, this.End);

        public static DateTimeRange CreateOneDayRange(CompoundDateTimeService day)
            => new DateTimeRange(day, new CompoundDateTimeService(day.DateTime.AddDays(1)));

        public static DateTimeRange CreateOneWeekRange(CompoundDateTimeService startDay)
            => new DateTimeRange(startDay, new CompoundDateTimeService(startDay.DateTime.AddDays(7)));
        public bool OverlapsForUtc(DateTimeRange dateTimeRange)
            => Start.DateTime < dateTimeRange.End.DateTime && 
               End.DateTime > dateTimeRange.Start.DateTime;
        public bool OverlapsForPersian(DateTimeRange dateTimeRange)
            => Start.PersianDateTime < dateTimeRange.End.PersianDateTime &&
               End.PersianDateTime > dateTimeRange.Start.PersianDateTime;

        public override string ToString() 
            => Start.DateTime.ToShortTimeString() + "-" + End.DateTime.ToShortTimeString();
        public string ToPersianString()
            => Start.PersianDateTime.ToString(PersianDateTimeFormat.ShortDateShortTime) + "-" + End.PersianDateTime.ToString(PersianDateTimeFormat.ShortDateShortTime);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start.DateTime;
            yield return End.DateTime;
        }

        protected override int GetHashCodeCore()
            => HashCode.Combine(Start, End);
    }
}
