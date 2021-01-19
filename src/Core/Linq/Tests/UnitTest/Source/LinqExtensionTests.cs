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

        [Fact]
        public void ConcatinatedStringsMustEqualToExpectedStringWithoutExtraSpaceAtEnd()
        {
            var string1 = "This";
            var string2 = "Successful";
            var string3 = "Concaination";
            var string4 = "Strings";
            var string5 = "!";
            var @strings = new string[5] {
                string1, string2, string3, string4, string5
            };

            var concatinatedStrings = @strings
                .CustomConcatination(new Func<string, string>((@string) => {
                    var st = @string + ' ';
                    return st;  
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

            Assert.NotEqual(
                concatinatedStrings, 
                @stringsBuilder.ToString().TrimEnd());
        }

        [Fact]
        public void ConcatinatedStringsMustNotEqualToStringWithExtraSpaceAtEnd()
        {
            var extraSpace = ' ';

            var string1 = "This";
            var string2 = "Successful";
            var string3 = "Concaination";
            var string4 = "Strings";
            var string5 = "!";
            var @strings = new string[5] {
                string1, string2, string3, string4, string5
            };

            var concatinatedStrings = @strings
                .CustomConcatination(new Func<string, string>((@string) => {
                    @string += extraSpace;
                    return @string;
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

            Assert.Equal(concatinatedStrings,
                @stringsBuilder.ToString());
        }
    }
}
