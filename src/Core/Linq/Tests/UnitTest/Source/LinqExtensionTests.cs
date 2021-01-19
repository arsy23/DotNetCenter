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
        public void ForeachConcatMustConcateAllStrings()
        {
            var string1 = "This";
            var string2 = "Method";
            var string3 = "Concat";
            var string4 = "Strings";
            var string5 = "Successfuly";
            var @strings = new string[5] {
                string1, string2, string3, string4, string5
            };

            var concatinateddStrings = @strings.ForEachConcat(null);

            var @stringsBuilder = new StringBuilder();
            @stringsBuilder.Append(string1);
            @stringsBuilder.Append(string2);
            @stringsBuilder.Append(string3);
            @stringsBuilder.Append(string4);
            @stringsBuilder.Append(string5);

            Assert.Equal(concatinateddStrings, @stringsBuilder.ToString());
        }
    }
}
