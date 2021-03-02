namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    ///  Auditable Entity Interface
    /// </summary>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    /// <typeparam name="TKeyUser">The IdentityUser Entity Key-Type</typeparam>
    public interface AuditableEntity<TKey, TKeyUser> 
        : Entity<TKey>, ModifiableEntity<TKeyUser>, CreatableEntity<TKeyUser>
        where TKey :  IEquatable<TKey>
        where TKeyUser :  IEquatable<TKeyUser>
    {
        #region Properties
        #endregion
    }
}