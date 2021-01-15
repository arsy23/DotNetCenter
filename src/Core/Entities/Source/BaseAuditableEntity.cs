namespace DotNetCenter.Core.Entities
{
    using System; 
    public class BaseAuditableEntity<TEntity, TAppKey> : AuditableEntity<TAppKey> 
        where TEntity : BaseAuditableEntity<TEntity, TAppKey>
        where TAppKey : IEquatable<TAppKey>
    {
        #region Constructors
        public BaseAuditableEntity()
        { }
        public BaseAuditableEntity(TAppKey id)
            => Id = id;
        #endregion
        #region Properties
        public TAppKey Id { get; private set; }
        public TAppKey CreatedBy { get; set; }
        public DateTime CreatedUtc { get; set; }
        public TAppKey LastModifiedBy { get; set; }
        public DateTime? LastModifiedUtc { get; set; }
        #endregion
        #region Fields
        public const string ID = nameof(Id);
        #endregion
    }
}
