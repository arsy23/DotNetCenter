namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    /// Abstract Base class for Auditable Entity
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity itself as parameter</typeparam>
    /// <typeparam name="TKey">Entity key type</typeparam>
    /// <typeparam name="TKeyUser">Modifier Key-Type</typeparam>
    public abstract class BaseAuditableEntity<TEntity, TKey, TKeyUser> 
        : BaseEntity<TEntity, TKey>,
        AuditableEntity<TKey, TKeyUser>
        where TEntity : BaseEntity<TEntity, TKey>
        where TKey : struct, IEquatable<TKey>
        where TKeyUser : struct, IEquatable<TKeyUser>
    {
        #region Constructors
        /// <summary>
        /// Default constructor with the Entity identity (ID) and the Creator identity (ID) initialization
        /// </summary>
        /// <param name="id">Entity Identity (ID)</param>
        /// <param name="creatorId">Creator identity (ID)</param>
        public BaseAuditableEntity(TKey id, TKeyUser creatorId)
           : base(id)
           => _creatorId = creatorId;
        #endregion

        #region Properties
        /// <summary>
        /// The DateTime that Entity it was Created
        /// </summary>
        public TKeyUser CreatedBy => _creatorId;
        private TKeyUser _creatorId;

        /// <summary>
        /// Initial Date-Time that Entity it was Created
        ///</summary>
        public DateTime CreatedDateTime => _createdDateTime;
        private DateTime _createdDateTime;

        /// <summary>
        /// Last Modifier identity (ID)
        /// </summary>
        public TKeyUser ModifiedBy => _lastModifiedBy;
        private TKeyUser _lastModifiedBy;

        /// <summary>
        /// Last Date-Time that Entity it was modified
        /// </summary>
        public DateTime? ModifiedDateTime => _lastModifiedDateTime;
        private DateTime? _lastModifiedDateTime;
        #endregion

        #region Methods

        /// <summary>
        /// Register Modified State Information
        /// </summary>
        /// <param name="modifierId">Modifier Identity (ID)</param>
        /// <param name="modifiedDateTime">Modified DateTime</param>
        public void RegisterModifiedInformation(TKeyUser modifierId, DateTime modifiedDateTime)
        {
            _lastModifiedBy = modifierId;
            _lastModifiedDateTime = modifiedDateTime;
        }
        #endregion
    }
}
