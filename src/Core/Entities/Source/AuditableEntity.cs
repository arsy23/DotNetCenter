namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    ///  Auditable Entity Interface
    /// </summary>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    public interface AuditableEntity<TKey, TKeyCreator> 
        where TKey :  IEquatable<TKey>
        where TKeyCreator :  IEquatable<TKeyCreator>
    {
        #region Properties
        /// <summary>
        /// Entity Identity (ID)
        /// </summary>
        public TKey Id { get;}
        /// <summary>
        /// Entity Creator Identity (ID)
        /// </summary>
        public TKeyCreator CreatedBy { get; set; }
        /// <summary>
        /// Entity Created Utc DateTime
        /// </summary>
        public DateTime CreatedUtc { get; set; }
        /// <summary>
        /// Entity Last Modifier identity (ID)
        /// </summary>
        public TKeyCreator LastModifiedBy { get; set; }
        /// <summary>
        /// Entity Last Modified Utc DateTime
        /// </summary>
        public DateTime? LastModifiedUtc { get; set; }
        #endregion
    }
}