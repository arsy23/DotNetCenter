namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    /// Base class for Auditable Entity
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity itself as parameter</typeparam>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    /// <typeparam name="TKeyCreator">The Entity Creator Key-Type</typeparam>
    /// <typeparam name="TKeyModifier">The Entity Modifier Key-Type</typeparam>
    public class BaseAuditableEntity<TEntity, TKey, TKeyCreator, TKeyModifier> 
        : BaseEntity<TEntity, TKey>,
        AuditableEntity<TKey, TKeyCreator, TKeyModifier>
        where TEntity : BaseEntity<TEntity, TKey>
        where TKey : struct, IEquatable<TKey>
        where TKeyCreator : struct, IEquatable<TKeyCreator>
        where TKeyModifier : struct, IEquatable<TKeyCreator>
    {
        #region Constructors
        /// <summary>
        /// Default constructor with the Entity identity (ID) and the Creator identity (ID) initialization
        /// </summary>
        /// <param name="id">The Entity identity</param>
        /// <param name="creatorId">The Entity creator identity (ID)</param>
        public BaseAuditableEntity(TKey id, TKeyCreator creatorId)
           : base(id)
           => _creatorId = creatorId;
        #endregion
        #region Properties
        /// <summary>
        /// The DateTime that Entity it was Created
        /// </summary>
        public TKeyCreator CreatedBy => _creatorId;
        private readonly TKeyCreator _creatorId;

        /// <summary>
        /// Initial Date-Time that Entity it was Created
        ///</summary>
        public DateTime CreatedDateTime => _createdDateTime;
        private readonly DateTime _createdDateTime;

        /// <summary>
        /// Entity Last Modifier identity (ID)
        /// </summary>
        public TKeyModifier LastModifiedBy => _lastModifiedBy;
        private TKeyModifier _lastModifiedBy;

        /// <summary>
        /// The Last Date-Time that Entity it was modified
        /// </summary>
        public DateTime? LastModifiedDateTime => _lastModifiedDateTime;
        private DateTime? _lastModifiedDateTime;
        #endregion
        #region Methods
        /// <summary>
        /// Modify Auditing Information
        /// </summary>
        /// <param name="modifierId">The Modifier Id</param>
        /// <param name="lastModifiedDate">The ModifiedDateTime</param>
        public virtual void Modify(TKeyModifier modifierId, DateTime lastModifiedDate)
        {
            _lastModifiedBy = modifierId;
            _lastModifiedDateTime = lastModifiedDate;
        }
        #endregion
    }
}
