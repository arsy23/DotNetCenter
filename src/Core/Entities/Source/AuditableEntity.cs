namespace DotNetCenter.Core.Entities
{
    using System;
    public interface AuditableEntity<TAppKey> where TAppKey :  IEquatable<TAppKey>
    {
        #region Properties
        public TAppKey Id { get;}
        public TAppKey CreatedBy { get; set; }
        public DateTime CreatedUtc { get; set; }
        public TAppKey LastModifiedBy { get; set; }
        public DateTime? LastModifiedUtc { get; set; }
        #endregion
    }
}