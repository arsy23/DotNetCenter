using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCenter.Core.Entities
{
    /// <summary>
    /// Interface for Creatable Entity
    /// </summary>
    /// <typeparam name="TKeyCreator">The Entity Creator Key-Type</typeparam>
    public interface CreatableEntity<TKeyCreator>
    {
        /// <summary>
        /// Entity Creator identity (ID)
        /// </summary>
        public TKeyCreator CreatedBy { get; }

        /// <summary>
        /// Initial Date-Time that Entity it was Created
        ///</summary>
        public DateTime CreatedDateTime { get; }
    }
}
