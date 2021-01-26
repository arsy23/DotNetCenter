namespace DotNetCenter.Core.Entities.UnitTest
{
    using System.Collections.Generic;
    public class MoneyValueObject : BaseValueObject<MoneyValueObject>
    {
        public MoneyValueObject(long amount) 
            => _amount = amount;

        public long Amount => _amount;
        private readonly long _amount;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }

        protected override int GetHashCodeCore() 
            => System.HashCode.Combine(Amount);
    }
}
