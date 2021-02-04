namespace DotNetCenter.Core.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    /// <summary>
    /// Extension for Microsoft DotNet Linq Technologies
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// Execute the Action Forech items in the Set and pass item to it
        /// </summary>
        /// <typeparam name="T">Type of Set and items</typeparam>
        /// <param name="set">Set of items</param>
        /// <param name="action">Action that recived each items in set</param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> set, Action<T> action)
        {
            foreach (var item in set)
                action(item);
            return set;
        }
        /// <summary>
        /// Make string concatenation
        /// </summary>
        /// <param name="enumeration">The string collection you need to concat</param>
        /// <returns>Concatenation result</returns>
        public static string Concat(this IEnumerable<string> enumeration)
        {
            var @stringBuilder = new StringBuilder();
            foreach (var @string in enumeration)
            {
                if (string.IsNullOrEmpty(@string))
                    continue;

                @stringBuilder.Append(@string);
            }
            return @stringBuilder.ToString();
        }
        /// <summary>
        /// Make string concatenation and take control on each string before concatenation 
        /// </summary>
        /// <param name="enumeration">The string collection you need to concat</param>
        /// <param name="action">The Action excute before each concatenation for custom concatenation. Each strings passed as parameter to the action</param>
        /// <returns>Concatenation result </returns>
        public static string Concat(this IEnumerable<string> enumeration, Func<string,string> action)
        {
            var @stringBuilder = new StringBuilder();
            foreach (var @string in enumeration)
            {
                if (string.IsNullOrEmpty(@string))
                    continue;

                var result = action.Invoke(@string);
                
                if (string.IsNullOrEmpty(result))
                    continue;

                @stringBuilder.Append(result);
            }
            return @stringBuilder.ToString();
        }
    }
}
