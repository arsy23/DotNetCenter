namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    /// Base class for Auditable Entity
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
        #endregion
        #region Properties
        /// <summary>
        /// The Entity identity (ID)
        /// </summary>
        public TKey Id { get; private set; }
        /// <summary>
        /// The Creator Identity (ID)
        /// </summary>
        public TKeyCreator CreatedBy { get; set; }
        /// <summary>
        /// The UTC-DateTime that Entity it was Created
        /// /// </summary>
        public DateTime CreatedUtc { get; set; }
        /// <summary>
        /// The UTC-DateTime that Entity it was Created
        /// </summary>
        public TKeyCreator LastModifiedBy { get; set; }
        /// <summary>
        /// The LastModified-DateTime by The Entity
        /// </summary>
        public DateTime? LastModifiedUtc { get; set; }
        #endregion
        #region Fields
        /// <summary>
        /// The Name of Identity (ID) Property
        /// </summary>
        public const string ID = nameof(Id);
        #endregion
    }
}
