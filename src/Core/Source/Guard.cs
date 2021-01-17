namespace DotNetCenter.Core
{
    using System;
    public class Guard
    {
        public static void ForLessEqualZero(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName);
        }
        public static void ForNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }
        public static void ForNullReference(object @object, string paramName = "")
        {
            if (@object is null)
                throw new NullReferenceException(paramName);
        }
    }
}
