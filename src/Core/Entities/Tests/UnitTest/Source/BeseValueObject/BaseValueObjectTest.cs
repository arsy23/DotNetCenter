using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCenter.Core.Entities.UnitTest
{
    public class BaseValueObjectTest
    {
        private const int Amount = 23000;

        #region GetEqualityComponents;
        #region SameValueObjectsMustBeEquals
        [Fact]
        public void SameValueObjectsMustBeEquals()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount);
            Assert.True(firstMoneyResource.Equals(secondMoneyResource));
        }
        #endregion
        #region SameValueObjectsMustNotEquals
        [Fact]
        public void DiffrentValueObjectsMustNotEquals()
        {
            var moneyuilder = new MoneyValueObjectBuilder();
            var firstMoneyResource = moneyuilder.GetMoney(Amount);
            var secondMoneyResource = moneyuilder.GetMoney(Amount + 32000);
            Assert.False(firstMoneyResource.Equals(secondMoneyResource));
        }
        #endregion
        #endregion
    }
}
