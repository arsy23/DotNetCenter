namespace DotNetCenter.Core.Entities
{
    using System;
    /// <summary>
    ///  Auditable Entity Interface
    /// </summary>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    /// <typeparam name="TKeyCreator">The Entity Creator Key-Type</typeparam>
    /// <typeparam name="TKeyModifier">The Entity Modifier Key-Type</typeparam>
    public interface AuditableEntity<TKey, TKeyCreator, TKeyModifier> 
        : Entity<TKey>, ModifiableEntity<TKeyModifier>, CreatableEntity<TKeyCreator>
        where TKey :  IEquatable<TKey>
        where TKeyCreator :  IEquatable<TKeyCreator>
    {
        #region Properties
        #endregion
    }
}