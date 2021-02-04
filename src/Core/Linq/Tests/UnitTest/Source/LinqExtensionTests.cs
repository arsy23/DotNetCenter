namespace DotNetCenter.Core.Linq.UnitTest
{
    using System;
    using System.Linq;
    using System.Text;
    using Xunit;
    public class LinqExtensionTests
    {
        static readonly char extraSpace = ' ';

        #region ForEach<T>
        #region TheArrayNumbers*MustMultiplyByAction*
        [Fact]
        public void TheArrayNumbersMustMultiplyByAction()
        {
            var array = new[] { 1, 2, 3, 4, 5 };
            var actualResult = 1;
            var resultOfMultiply = 1;

            for (int i = 1; i <= 5; i++)
                actualResult *= i;

            array.ForEach((int number) =>
            {
                resultOfMultiply *= number;
            });
            Assert.Equal(resultOfMultiply, actualResult);
        }
        #endregion
        #endregion

        #region Concat
        #region String
        readonly string string1 = " ";
        readonly string string2 = "Successful";
        readonly string string3 = "Concatenation";
        readonly string string4 = "Strings";
        readonly string string5 = "!";

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
        private static string AddExtraSpaceAtEnd(string stringInput)
            => stringInput + extraSpace;

        #endregion
        #endregion
    }
}
