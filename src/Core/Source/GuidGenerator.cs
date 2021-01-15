namespace DotNetCenter.Core
{
    using System;
    using System.Linq;
    using System.Text;

    public static class GuidGenerator
    {
        public static string NewGuid()
        {
            var builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList()
                .ForEach(e => builder.Append(e));
            return builder.ToString();
        }
        public static string NewGuid(byte length)
        {
            var builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(length)
                .ToList()
                .ForEach(e => builder.Append(e));
            return builder.ToString();
        }
    }
}
