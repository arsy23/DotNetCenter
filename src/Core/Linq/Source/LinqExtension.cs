namespace DotNetCenter.Core.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public static class LinqExtension
    {
        public static void CopyValues<T>(this T source, T target)
        {
            var type = typeof(T);
            var properties = type.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);
            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
                action(item);
            return enumeration;
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
