using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCenter.Core.Common.Guards
{
    /// <summary>
    /// Common Numeric-Type Guards
    /// </summary>
    public static class NumericGuard
    {
        #region ForLessEqualZero
        /// <summary>
        /// Guard For Less-Equal Zero byte value
        /// </summary>
        /// <param name="value">The Guarded Byte Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForLessEqualZero(byte value, string paramName)
            => throwArgumentOutOfRangeExceptionForLessEqualZero(value, paramName);
        /// <summary>
        /// Guard For Less-Equal Zero short value
        /// </summary>
        /// <param name="value">The Guarded Short Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForLessEqualZero(short value, string paramName)
            => throwArgumentOutOfRangeExceptionForLessEqualZero(value, paramName);
        /// <summary>
        /// Guard For Less-Equal Zero integer value
        /// </summary>
        /// <param name="value">The Guarded Integer Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForLessEqualZero(int value, string paramName) 
            => throwArgumentOutOfRangeExceptionForLessEqualZero(value, paramName);
        /// <summary>
        /// Guard For Less-Equal Zero long value
        /// </summary>
        /// <param name="value">The Guarded Long Value</param>
        /// <param name="paramName">The Value parameter name</param>
        public static void ForLessEqualZero(long value, string paramName)
            => throwArgumentOutOfRangeExceptionForLessEqualZero(value, paramName);
        private static void throwArgumentOutOfRangeExceptionForLessEqualZero(long value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName);
        }
        #endregion
    }
}
