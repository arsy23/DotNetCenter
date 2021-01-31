namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    ///  Auditable Entity Interface
    /// </summary>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    /// <typeparam name="TKeyCreator">The Entity creator key type</typeparam>
    public interface AuditableEntity<TKey, TKeyCreator> 
        where TKey :  IEquatable<TKey>
        where TKeyCreator :  IEquatable<TKeyCreator>
    {
        #region Properties
        /// <summary>
        /// Entity Identity (ID)
        /// </summary>
        public TKey Id { get; }

        /// <summary>
        /// The UTC-DateTime that Entity it was Created
        /// </summary>
        public TKeyCreator CreatedBy { get; }

        /// <summary>
        /// Initial UTC Date-Time that Entity it was Created
        ///</summary>
        public DateTime CreatedUtc { get; }

        /// <summary>
        /// Entity Last Modifier identity (ID)
        /// </summary>
        public TKeyCreator LastModifiedBy { get; }

        /// <summary>
        /// The Last UTC Date-Time that Entity it was modified
        /// </summary>
        public DateTime? LastModifiedUtc { get; }
        #endregion
    }
}