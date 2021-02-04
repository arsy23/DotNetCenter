using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCenter.Core
{
    /// <summary>
    /// Abstract class for ay object in DotNetCenter framework
    /// </summary>
    public abstract class BaseObject : object
    {
        #region GetEqualityComponents
        /// <summary>
        /// Get Equality Components
        /// </summary>
        /// <returns>yield return class components. eg. properties, method results and ...</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();
        #endregion
        #region GetHashCodeCore
        /// <summary>
        /// Get Hash-Code of the inherited class components resulted by System.HashCode.Combine()
        /// </summary>
        /// <returns>Hash-Code</returns>
        protected abstract int GetHashCodeCore();
        #endregion
        #region GetHashCode
        /// <summary>
        /// Get Hash-Code for the this object
        /// </summary>
        /// <returns>Hash-Code</returns>
        public override int GetHashCode()
         => GetHashCodeCore();
        #endregion
    }
}
