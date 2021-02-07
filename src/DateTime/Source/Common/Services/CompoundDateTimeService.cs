namespace DotNetCenter.DateTime.Common
{
    using DotNetCenter.Core.Entities;
    using System;
    using System.Collections.Generic;
    using DotNetCenter.DateTime.Persian;

    public class CompoundDateTimeService 
        : BaseValueObject<CompoundDateTimeService>, CompoundableDateTime
    {
        /// <summary>
        /// Present DateTime in persian and commmon format
        /// </summary>
        /// <param name="datetime"></param>
        public CompoundDateTimeService(DateTime datetime)
            => DateTime = datetime;

        /// <summary>
        /// Represent DateTime Now
        /// </summary>
        public CompoundDateTimeService() 
            => DateTime = DateTime.UtcNow;

        public PersianDateTime PersianDateTime
            => new PersianDateTime(DateTime);

        public DateTime DateTime { get;  private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateTime;
        }

        public static explicit operator CompoundDateTimeService(DateTime dateTime)
            => new CompoundDateTimeService(dateTime);

        internal CompoundDateTimeService Add(TimeSpan duration)
            => new CompoundDateTimeService()
            {
                DateTime = DateTime.Add(duration)
            };

        protected override int GetHashCodeCore()
            => HashCode.Combine(DateTime, PersianDateTime);
    }

}
