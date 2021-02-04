namespace DotNetCenter.Core.Entities.UnitTest
{
    using Xunit;

    public class BaseValueObjectTest
    {
        private const int Amount = 23000;

        #region Equals
        #region SameValueObjects*MustBeEquals*WithEqualsMethod
        [Fact]
        public void SameValueObjectsMustBeEqualsWithEqualsMethod()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount);
            Assert.True(firstMoneyResource.Equals(secondMoneyResource));
        }
        #endregion
        #region DiffrentValueObjects*MustBeNotEquals*WithEqualsMethod
        [Fact]
        public void DiffrentValueObjectsMustBeNotEqualsWithEqualsMethod()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount + 32000);
            Assert.False(firstMoneyResource.Equals(secondMoneyResource));
        }
        #endregion
        #endregion

        #region Operators
        #region == Operator
        #region SameValueObjectsMustBeEqualWithObjectEqualityOperator
        [Fact]
        public void SameValueObjectsMustBeEqualWithObjectEqualityOperator()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount);
            Assert.True(firstMoneyResource == secondMoneyResource);
        }
        #endregion
        #region DifferentValueObjectsMustNotEqualWithObjectEqualityOperator
        [Fact]
        public void DifferentValueObjectsMustNotEqualWithObjectEqualityOperator()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount + 32000);
            Assert.False(firstMoneyResource == secondMoneyResource);
        }
        #endregion
        #endregion
        #region != Operator
        #region SameValueObjectsComparisonMustBeTrueWithObjectNotEqualityOperator
        [Fact]
        public void SameValueObjectsComparisonMustBeFalseWithObjectNotEqualityOperator()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount);
            Assert.False(firstMoneyResource != secondMoneyResource);
        }
        #endregion
        #region DifferentValueObjectsComparisonMustBeTrueWithObjectNotEqualityOperator
        [Fact]
        public void DifferentValueObjectsComparisonMustBeTrueWithObjectNotEqualityOperator()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount + 32000);
            Assert.True(firstMoneyResource != secondMoneyResource);
        }
        #endregion
        #endregion
        #endregion
    }
}
