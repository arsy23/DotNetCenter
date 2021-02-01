using DotNetCenter.Core.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCenter.Core.Common.Guards
{
    /// <summary>
    /// Access all the DotNetCenter Common Guards
    /// </summary>
    public class FullGuard
    {
        /// <summary>
        /// Initialize Common Guards
        /// </summary>
        public FullGuard()
        {
            _stringGuard = new StringGuard();
            _objectGuard = new ObjectGuard();
        }
        /// <summary>
        /// Common String Guards
        /// </summary>
        public StringGuard StringGuard => _stringGuard;
        private readonly StringGuard _stringGuard;

        /// <summary>
        /// Common Object Guards
        /// </summary>
        public ObjectGuard ObjectGuard => _objectGuard;
        private readonly ObjectGuard _objectGuard;
    }
}
