namespace DotNetCenter.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Interface for Modifiable Entity
    /// </summary>
    /// <typeparam name="TKeyModifier">The Entity Modifier Key-Type</typeparam>
    public interface ModifiableEntity<TKeyModifier>
    {
        /// <summary>
        /// Entity Modifier identity (ID)
        /// </summary>
        public TKeyModifier LastModifiedBy { get; }

        /// <summary>
        /// The Last Date-Time that Entity it was modified
        /// </summary>
        public DateTime? LastModifiedDateTime { get; }
    }
}
