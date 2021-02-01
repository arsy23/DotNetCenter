using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCenter.Core
{
    /// <summary>
    /// Determine Orign that value comes from
    /// </summary>
    public enum ValueComesFrom
    {
        /// <summary>
        /// The Value comes from Configurations
        /// </summary>
        Configurations = 0,
        /// <summary>
        /// The Value comes from Arguments
        /// </summary>
        Arguments = 1
    }
}
