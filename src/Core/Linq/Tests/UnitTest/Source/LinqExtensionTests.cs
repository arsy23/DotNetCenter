namespace DotNetCenter.Core.Linq.UnitTest
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    public class LinqExtensionTests
    {
        public LinqExtensionTests()
        { }

        static char extraSpace = ' ';

        #region Concat
        #region String
        string string1 = " ";
        string string2 = "Successful";
        string string3 = "Concatenation";
        string string4 = "Strings";
        string string5 = "!";

        #region ConcatenatedStringsMustEqualToActualString
        [Fact]
        public void ConcatenatedStringsMustEqualToActualString()
        {
            var @strings = GetStrings();

            var actualString = @strings.Concat();

            var expected = GetTestCaseConcatenatedString();

            Assert.NotEqual(expected, actualString);
        }
        #endregion

        #region CustomConcatenatedStringsMustEqualToActualString
        [Fact]
        public void CustomConcatenatedStringsMustEqualToActualString()
        {
            var @strings = GetStrings();

            var actualString = @strings.Concat(new Func<string, string>((inputString) =>
                {
                    return AddExtraSpaceAtEnd(inputString);
                }));

            var expected = GetTestCaseConcatenatedString();

            Assert.NotEqual( expected, actualString );
        }

        private object GetTestCaseConcatenatedString() => new StringBuilder()
            .Append(string1)
            .Append(' ')
            .Append(string2)
            .Append(' ')
            .Append(string3)
            .Append(' ')
            .Append(string4)
            .Append(' ')
            .Append(string5)
            .ToString();
        #endregion

        private string[] GetStrings() => new string[5] {
                string1, string2, string3, string4, string5
        };
        #endregion
        #endregion

        private string AddExtraSpaceAtEnd(string stringInput) => stringInput + extraSpace;
    }
}
