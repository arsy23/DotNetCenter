namespace DotNetCenter.Core.UnitTest.Common.Guards
{
    using DotNetCenter.Core.Guards;
    using System;
    using Xunit;

    public class StringGuardTest
    {

        #region ForNullOrEmpty
        #region GuardForNullOrEmpty*MustThorw*ArgumentNullExceptionWhenTheStringIsEmpty
        [Fact]
        public void GuardForNullOrEmptyMustThorwArgumentNullExceptionWhenTheStringIsEmpty()
        {
            var @string = string.Empty;
            Type expected = GetArgumentNullExceptionType();
            Assert.Throws(expected, () =>
            StringGuard.ForNullOrEmpty(@string, nameof(@string)));
        }
        #endregion
        #region GuardForNullOrEmpty*MustThorw*ArgumentNullExceptionWhenTheStringIsNull
        [Fact]
        public void GuardForNullOrEmptyMustThorwArgumentNullExceptionWhenTheStringIsNull()
        {
            string? @string = null;
            Type expected = GetArgumentNullExceptionType();
            Assert.Throws(expected, () =>
            StringGuard.ForNullOrEmpty(@string, nameof(@string)));
        }
        #endregion
        #region GuardForNullOrEmpty*MustNotThorw*ArgumentNullExceptionWhenTheStringHasValue
        [Fact]
        public void GuardForNullOrEmptyMustNotThorwArgumentNullExceptionWhenTheStringHasValue()
        {
            var @string = "Is not null.";
            var exception = Record.Exception(()
                => StringGuard.ForNullOrEmpty(@string, nameof(@string)));
            Assert.Null(exception);
        }
        #endregion
        #endregion
        #region ForNullOrWhiteSpace
        #region GuardForNullOrEmpty*MustThorw*ArgumentNullExceptionWhenTheStringIsAWhiteSpace
        [Fact]
        public void GuardForNullOrWhiteSpaceMustThorwArgumentNullExceptionWhenTheStringIsAWhiteSpace()
        {
            var @string = " ";
            Type expected = GetArgumentNullExceptionType();
            Assert.Throws(expected, () =>
            StringGuard.ForNullOrWhiteSpace(@string, nameof(@string)));
        }
        #endregion
        #region GuardForNullOrEmpty*MustThorw*ArgumentNullExceptionWhenTheStringIsWhiteSpaces
        [Fact]
        public void GuardForNullOrWhiteSpaceMustThorwArgumentNullExceptionWhenTheStringIsWhiteSpaces()
        {
            var @string = "            ";
            Type expected = GetArgumentNullExceptionType();
            Assert.Throws(expected, () =>
            StringGuard.ForNullOrWhiteSpace(@string, nameof(@string)));
        }
        #endregion
        #region GuardForNullOrWhiteSpace*MustThorw*ArgumentNullExceptionWhenTheStringIsNull
        [Fact]
        public void GuardForNullOrWhiteSpaceMustThorwArgumentNullExceptionWhenTheStringIsNull()
        {
            string? @string = null;
            Type expected = GetArgumentNullExceptionType();
            Assert.Throws(expected, () =>
            StringGuard.ForNullOrWhiteSpace(@string, nameof(@string)));
        }
        #endregion
        #region GuardForNullOrWhiteSpace*MustNotThorw*ArgumentNullExceptionWhenTheStringHasValue
        [Fact]
        public void GuardForNullOrWhiteSpaceMustNotThorwArgumentNullExceptionWhenTheStringHasValue()
        {
            var @string = "Is not null.";
            var exception = Record.Exception(()
                => StringGuard.ForNullOrWhiteSpace(@string, nameof(@string)));
            Assert.Null(exception);
        }
        #endregion
        #endregion

        private static Type GetArgumentNullExceptionType()
            => new ArgumentNullException().GetType();

        #region TestCase
        public class EEntity
        { }
        #endregion
    }
}
