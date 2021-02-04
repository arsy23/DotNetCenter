namespace DotNetCenter.Core.Linq.UnitTest
{
    using System;
    using System.Linq;
    using System.Text;
    using Xunit;
    public class LinqExtensionTests
    {
        static char extraSpace = ' ';

        #region Concat
        #region String
        string string1 = " ";
        string string2 = "Successful";
        string string3 = "Concatenation";
        string string4 = "Strings";
        string string5 = "!";

        #region ConcatenatedStrings*MustEqual*ToActualString
        [Fact]
        public void ConcatenatedStringsMustEqualToActualString()
        {
            var @strings = GetStrings();

            var actualString = @strings.Concat();

            var expected = GetTestCaseConcatenatedString();

            Assert.NotEqual(expected, actualString);
        }
        #endregion
        #region CustomConcatenatedStrings*MustEqual*ToActualString
        [Fact]
        public void CustomConcatenatedStringsMustEqualToActualString()
        {
            var @strings = GetStrings();

            var actualString = @strings.Concat(new Func<string, string>((inputString) =>
                {
                    return AddExtraSpaceAtEnd(inputString);
                }));

            var expected = GetTestCaseConcatenatedString();

            Assert.NotEqual(expected, actualString);
        }
        #endregion

        private object GetTestCaseConcatenatedString() => new StringBuilder()
            .Append(string1)
            .Append(extraSpace)
            .Append(string2)
            .Append(extraSpace)
            .Append(string3)
            .Append(extraSpace)
            .Append(string4)
            .Append(extraSpace)
            .Append(string5)
            .ToString();
        private string[] GetStrings() => new string[5] {
                string1, string2, string3, string4, string5
        };
        private string AddExtraSpaceAtEnd(string stringInput)
            => stringInput + extraSpace;

        #endregion
        #endregion
    }
}
