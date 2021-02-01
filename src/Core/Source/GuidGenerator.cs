namespace DotNetCenter.Core
{
    using System;
    using System.Linq;
    using System.Text;
    /// <summary>
    /// Generates CUID (Custom Unique Identifier (ID))
    /// </summary>
    public static class CuidGenerator
    {
        /// <summary>
        /// Generate Cuid with default length
        /// </summary>
        /// <returns>The Defaults mechanism provide 11 char cuid in string format</returns>
        public static string NewCuid()
        {
            return NewCuid(11);
        }
        /// <summary>
        /// Generate Cuid with custom length in string format
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string NewCuid(byte length)
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
