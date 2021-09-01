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
        /// Register Modified State Informations
        /// </summary>
        /// <param name="modifierId"></param>
        /// <param name="modifiedDateTime"></param>
        public void RegisterModifiedInformation(TKeyModifier modifierId, DateTime modifiedDateTime);
        /// <summary>
        /// Entity Modifier identity (ID)
        /// </summary>
        public TKeyModifier ModifiedBy { get; }

        /// <summary>
        /// Last Date-Time that Entity it was modified
        /// </summary>
        public DateTime? ModifiedDateTime { get; }
    }
}
