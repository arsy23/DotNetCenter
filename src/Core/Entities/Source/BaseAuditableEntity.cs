namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    /// Base class for Auditable Entities
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity itself as parameter</typeparam>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    /// <typeparam name="TKeyCreator">The Entity creator key type</typeparam>
    public class BaseAuditableEntity<TEntity, TKey, TKeyCreator> : AuditableEntity<TKey, TKeyCreator>
        where TEntity : BaseAuditableEntity<TEntity, TKey, TKeyCreator>
        where TKey : struct, IEquatable<TKey>
        where TKeyCreator : struct, IEquatable<TKeyCreator>
    {
        #region Constructors
        /// <summary>
        /// Default constructor with the Entity identity (ID) and the Creator identity (ID) initialization
        /// </summary>
        /// <param name="id">The Entity identity</param>
        /// <param name="creatorId">The Entity creator identity (ID)</param>
        public BaseAuditableEntity(TKey id, TKeyCreator creatorId)
        {
            Id = id;
            CreatedBy = creatorId;
        }
        /// <summary>
        /// Default constructor with the Entity Identity (ID) initialization
        /// </summary>
        /// <param name="id">The Entity id</param>
        public BaseAuditableEntity(TKey id)
            => Id = id;
        #endregion
        #region Properties
        /// <summary>
        /// Entity identity (ID)
        /// </summary>
        public TKey Id { get; private set; }
        /// <summary>
        /// Entity Creator identity (ID)
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
        #region Fields
        /// <summary>
        /// The Entity identity (ID) property name
        /// </summary>
        public const string ID = nameof(Id);
        #endregion
    }
}
