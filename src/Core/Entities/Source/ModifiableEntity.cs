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
        where TKeyModifier : struct
    {
        /// <summary>
        /// Entity Modifier identity (ID)
        /// </summary>
        public TKeyModifier? ModifiedBy { get; set; }

        /// <summary>
        /// Last Date-Time that Entity it was modified
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }
    }
}
