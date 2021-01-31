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
            _id = id;
            _creatorId = creatorId;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Entity Identity (ID)
        /// </summary>
        public TKey Id => _id;
        private readonly TKey _id;

        /// <summary>
        /// The UTC-DateTime that Entity it was Created
        /// </summary>
        public TKeyCreator CreatedBy => _creatorId;
        private readonly TKeyCreator _creatorId;

        /// <summary>
        /// Initial UTC Date-Time that Entity it was Created
        ///</summary>
        public DateTime CreatedUtc => _createdUtc;
        private readonly DateTime _createdUtc;

        /// <summary>
        /// Entity Last Modifier identity (ID)
        /// </summary>
        public TKeyCreator LastModifiedBy => _lastModifiedBy;
        private readonly DateTime? _lastModifiedUtc;

        /// <summary>
        /// The Last UTC Date-Time that Entity it was modified
        /// </summary>
        public DateTime? LastModifiedUtc => _lastModifiedUtc;
        private readonly TKeyCreator _lastModifiedBy;
        #endregion
        #region Fields
        /// <summary>
        /// The Name of Identity (ID) Property
        /// </summary>
        public const string ID = nameof(Id);
        #endregion
        #region Methods
        public abstract void Set
        #endregion
    }
}
