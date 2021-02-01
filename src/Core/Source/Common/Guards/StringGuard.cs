namespace DotNetCenter.Core.Guards
{
    using System;
    /// <summary>
    /// Common String Guards
    /// </summary>
    public class StringGuard
    {
        /// <summary>
        /// Guard For Less-Equal Zero value
        /// </summary>
        /// <param name="value">The Guarded Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForLessEqualZero(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName);
        }
        /// <summary>
        /// Guard For Null Or Empty value
        /// </summary>
        /// <param name="value">The Guarded Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }
    }
}
