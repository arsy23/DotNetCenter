namespace DotNetCenter.Core.Entities.UnitTest
{
    public class MoneyValueObjectBuilder
    {
        public MoneyValueObject GetMoney(long amount)
                => new MoneyValueObject(amount);
    }
}
