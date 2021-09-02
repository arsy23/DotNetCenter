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
           => CreatedBy = creatorId;
        #endregion

        #region Properties
        /// <summary>
        /// The DateTime that Entity it was Created
        /// </summary>
        public TKeyUser CreatedBy { get; set; }

        /// <summary>
        /// Initial Date-Time that Entity it was Created
        ///</summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Last Modifier identity (ID)
        /// </summary>
        public TKeyUser? ModifiedBy { get; set; }

        /// <summary>
        /// Last Date-Time that Entity it was modified
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Register Modified State Information
        /// </summary>
        /// <param name="modifierId">Modifier Identity (ID)</param>
        /// <param name="modifiedDateTime">Modified DateTime</param>
        public void RegisterModifiedInformation(TKeyUser modifierId, DateTime modifiedDateTime)
        {
            ModifiedBy = modifierId;
            ModifiedDateTime = modifiedDateTime;
        }
        #endregion


    }
}
