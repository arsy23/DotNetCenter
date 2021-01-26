namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    ///  Auditable Entity Interface
    /// </summary>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    public interface AuditableEntity<TKey> 
        where TKey :  IEquatable<TKey>
    {
        #region Properties
        /// <summary>
        /// Entity Identity (ID) 
        /// </summary>
        public TKey Id { get;}
        /// <summary>
        /// Entity Creator
        /// </summary>
        public TKey CreatedBy { get; set; }
        /// <summary>
        /// Entity Created Utc DateTime
        /// </summary>
        public DateTime CreatedUtc { get; set; }
        /// <summary>
        /// Entity Last Modifier
        /// </summary>
        public TKey LastModifiedBy { get; set; }
        /// <summary>
        /// Entity Last Modified Utc DateTime
        /// </summary>
        public DateTime? LastModifiedUtc { get; set; }
        #endregion
    }
}