namespace DotNetCenter.Core.Guards
{
    using System;
    /// <summary>
    /// Common Object Guards
    /// </summary>
    public class ObjectGuard
    {
        /// <summary>
        /// Guard For Object Null Reference
        /// </summary>
        /// <param name="object">The Guarded object</param>
        /// <param name="paramName">The object parameter name</param>
        public static void ForNullReference(object @object, string paramName)
        {
            if (@object is null)
                throw new NullReferenceException(paramName);
        }
    }
}
