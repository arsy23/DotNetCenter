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
        /// Concate strings and execute action foreach concatination
        /// </summary>
        /// <param name="enumeration">The string collection you need to concat to each others</param>
        /// <param name="action">The Action you need to excute before each concationation. Each strings passed to action as parameter to the action</param>
        /// <returns>Concated string</returns>
        public static string ForEachConcat(this IEnumerable<string> enumeration, Func<string,string> action)
        {
            var stringBuilder = new StringBuilder();
            foreach (var @string in enumeration)
            {
                if (string.IsNullOrEmpty(@string))
                    continue;

                var result = action.Invoke(@string);
                
                if (result == null)
                    continue;
                
                stringBuilder.Append($"/{result}");
            }
            return stringBuilder.ToString();
        }
    }
}
