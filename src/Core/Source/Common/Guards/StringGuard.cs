namespace DotNetCenter.Core.Guards
{
    using System;
    /// <summary>
    /// Common String Guards
    /// </summary>
    public static class StringGuard
    {
        #region ForNullOrEmpty
        /// <summary>
        /// Guard For Null Or Empty value
        /// </summary>
        /// <param name="value">The Guarded Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForNullOrEmpty(string? value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }
        #endregion
        #region ForNullOrWhiteSpace
        /// <summary>
        /// Guard For Null Or White-Space value
        /// </summary>
        /// <param name="value">The Guarded Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForNullOrWhiteSpace(string? value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(paramName);
        }
        #endregion
    }
}
