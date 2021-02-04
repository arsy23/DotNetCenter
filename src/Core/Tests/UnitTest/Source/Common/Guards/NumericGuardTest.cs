namespace DotNetCenter.Core.UnitTest.Common.Guards
{
    using DotNetCenter.Core.Common.Guards;
    using System;
    using Xunit;
    public class NumericGuardTest
    {

        #region ForLessEqualZero
        #region GuardForLessEqualZero*MustNotThrow*ArgumentOutOfRangeExceptionWhenTheNumberGreaterThanZero
        [Fact]
        public void GuardForLessEqualZeroMustNotThrowArgumentOutOfRangeExceptionWhenTheNumberGreaterThanZero()
        {
            byte number = 1;
            var exception = Record.Exception(() => NumericGuard.ForLessEqualZero(number, nameof(number)));
            Assert.Null(exception);
        }
        #endregion
        #region GuardForLessEqualZero*MustThrow*ArgumentOutOfRangeExceptionWhenTheNumberLessThanZero
        [Fact]
        public void GuardForLessEqualZeroMustThrowArgumentOutOfRangeExceptionWhenTheNumberLessThanZero()
        {
            short number = -1;
            Type expected = GetArgumentOutOfRangeExceptionType();
            Assert.Throws(expected, () => NumericGuard.ForLessEqualZero(number, nameof(number)));
        }
        #endregion
        #region GuardForLessEqualZero*MustThrow*ArgumentOutOfRangeExceptionWhenTheNumberEqualZero
        [Fact]
        public void GuardForLessEqualZeroMustThrowArgumentOutOfRangeExceptionWhenTheNumberEqualZero()
        {
            short number = 0;
            Type expected = GetArgumentOutOfRangeExceptionType();
            Assert.Throws(expected, () => NumericGuard.ForLessEqualZero(number, nameof(number)));

        }
        #endregion
        private static Type GetArgumentOutOfRangeExceptionType()
            => new ArgumentOutOfRangeException().GetType();
        #endregion

        #region TestCase
        public class EEntity
        { }
        #endregion
    }
}
