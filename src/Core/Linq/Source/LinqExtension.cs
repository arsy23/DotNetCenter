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
        public static string ForEachConcate(this IEnumerable<string> enumeration, Func<string,string> action)
        {
            var stringBuilder = new StringBuilder();
            foreach (var @string in enumeration)
            {
                var result = action.Invoke(@string);
                if (string.IsNullOrEmpty(@string)
                    || string.IsNullOrWhiteSpace(@string)
                    || string.IsNullOrEmpty(result)
                    || string.IsNullOrWhiteSpace(result))
                    break;
                stringBuilder.Append($"/{result}");
            }
            return stringBuilder.ToString();
        }
    }
}
