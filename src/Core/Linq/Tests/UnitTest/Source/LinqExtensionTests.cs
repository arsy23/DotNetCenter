namespace DotNetCenter.Core.Linq.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class LinqExtensionTests
    {
        public LinqExtensionTests()
        { }

        static char extraSpace = ' ';

        [Fact]
        public void ConcatenatedStringsMustEqualToActualStringWithoutExtraSpaceAtEnd()
        {
            var string1 = " ";
            var string2 = "Successful";
            var string3 = "Concatenation";
            var string4 = "Strings";
            var string5 = "!";
            var @strings = new string[5] {
                string1, string2, string3, string4, string5
            };

            var actualString = @strings
                .CustomConcatenation(new Func<string, string>((inputString) =>
                {
                    inputString = AddExtraSpaceAtEnd(inputString);
                    return inputString;
                }));

            var @stringsBuilder = new StringBuilder();
            @stringsBuilder.Append(string1);
            @stringsBuilder.Append(' ');
            @stringsBuilder.Append(string2);
            @stringsBuilder.Append(' ');
            @stringsBuilder.Append(string3);
            @stringsBuilder.Append(' ');
            @stringsBuilder.Append(string4);
            @stringsBuilder.Append(' ');
            @stringsBuilder.Append(string5);

            //expected 'without' extra space
            var expected = RemoveExtraSpaceAtEnd(stringsBuilder);

            Assert.NotEqual(
                expected,
                actualString
                );

            static string RemoveExtraSpaceAtEnd(StringBuilder stringsBuilder)
                => @stringsBuilder.ToString().TrimEnd();
        }

        [Fact]
        public void ConcatenatedStringsMustEqualToActualStringWithEndExtraSpaceAtEnd()
        {
            var string1 = " ";
            var string2 = "Successful";
            var string3 = "Concatenation";
            var string4 = "Strings";
            var string5 = "!";
            var @strings = new string[5] {
                string1, string2, string3, string4, string5
            };

            var actualString = strings
                .CustomConcatenation(new Func<string, string>((inputString) =>
                {
                    inputString = AddExtraSpaceAtEnd(inputString);
                    return inputString;
                }));

            var @stringsBuilder = new StringBuilder();
            @stringsBuilder
            .Append(string1)
            .Append(extraSpace)
            .Append(string2)
            .Append(extraSpace)
            .Append(string3)
            .Append(extraSpace)
            .Append(string4)
            .Append(extraSpace)
            .Append(string5)
            .Append(extraSpace);

            //expected 'with' extra space
            var expected = @stringsBuilder.ToString();

            Assert.Equal(
                expected,
                actualString);
        }
        private static string AddExtraSpaceAtEnd(string stringInput)
        {
            return stringInput + extraSpace;
        }
    }
}
