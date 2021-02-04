namespace DotNetCenter.Core.Entities.UnitTest
{
    using Xunit;

    public class BaseValueObjectTest
    {
        private const int Amount = 23000;

        #region Equals with Covering GetEqualityComponents
        #region SameValueObjects*MustBeEquals*WithEqualsMethod
        [Fact]
        public void SameValueObjectsMustBeEqualsWithEqualsMethod()
        {
            var builder = new MoneyValueObjectBuilder();
            var firstMoneyResource = builder.GetMoney(Amount);
            var secondMoneyResource = builder.GetMoney(Amount);
            Assert.True(firstMoneyResource.Equals(secondMoneyResource));
        }
        #endregion
        #region DifferentValueObjects*MustBeNotEquals*WithEqualsMethod
        [Fact]
        public void DifferentValueObjectsMustBeNotEqualsWithEqualsMethod()
        {
            var builder = new MoneyValueObjectBuilder();
            var firstMoneyResource = builder.GetMoney(Amount);
            var secondMoneyResource = builder.GetMoney(Amount + 32000);
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
            var builder = new MoneyValueObjectBuilder();
            var firstMoneyResource = builder.GetMoney(Amount);
            var secondMoneyResource = builder.GetMoney(Amount);
            Assert.True(firstMoneyResource == secondMoneyResource);
        }
        #endregion
        #region DifferentValueObjectsMustNotEqualWithObjectEqualityOperator
        [Fact]
        public void DifferentValueObjectsMustNotEqualWithObjectEqualityOperator()
        {
            var builder = new MoneyValueObjectBuilder();
            var firstMoneyResource = builder.GetMoney(Amount);
            var secondMoneyResource = builder.GetMoney(Amount + 32000);
            Assert.False(firstMoneyResource == secondMoneyResource);
        }
        #endregion
        #endregion
        #region != Operator
        #region SameValueObjectsComparisonMustBeTrueWithObjectNotEqualityOperator
        [Fact]
        public void SameValueObjectsComparisonMustBeFalseWithObjectNotEqualityOperator()
        {
            var builder = new MoneyValueObjectBuilder();
            var firstMoneyResource = builder.GetMoney(Amount);
            var secondMoneyResource = builder.GetMoney(Amount);
            Assert.False(firstMoneyResource != secondMoneyResource);
        }
        #endregion
        #region DifferentValueObjectsComparisonMustBeTrueWithObjectNotEqualityOperator
        [Fact]
        public void DifferentValueObjectsComparisonMustBeTrueWithObjectNotEqualityOperator()
        {
            var builder = new MoneyValueObjectBuilder();
            var firstMoneyResource = builder.GetMoney(Amount);
            var secondMoneyResource = builder.GetMoney(Amount + 32000);
            Assert.True(firstMoneyResource != secondMoneyResource);
        }
        #endregion
        #endregion
        #endregion
    }
}
