namespace DotNetCenter.Core.Entities
{
    using System;
    using System.Linq;

    /// <summary>
    /// Abstract Base class for Entity
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity itself as parameter</typeparam>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    public abstract class BaseEntity<TEntity, TKey> : Entity<TKey>
        where TEntity : BaseEntity<TEntity, TKey>
        where TKey : struct, IEquatable<TKey>
    {
        #region Constructors
        /// <summary>
        /// Default constructor with the Entity identity (ID)
        /// </summary>
        /// <param name="id">The Entity identity</param>
        public BaseEntity(TKey id)
            => _id = id;
        #endregion
        #region Properties
        /// <summary>
        /// Entity Identity (ID)
        /// </summary>
        public TKey Id => _id;
        private readonly TKey _id;
        #endregion
        #region Fields
        /// <summary>
        /// The Name of Identity (ID) Property
        /// </summary>
        public const string ID = nameof(Id);
        #endregion
        #region Methods
        /// <summary>
        /// Copy The Value of type Entity<TKey> form this object to target object
        /// </summary>
        /// <param name="target">The Target object recived value from this object presented as reference parameter</param>
        public ref TEntity CopyValues(ref TEntity target)
        {
            var properties = GetType()
                .GetProperties()
                .Where(prop => prop.CanRead && prop.CanWrite);
            foreach (var prop in properties)
                GetTarget(ref target, prop);

            ref TEntity GetTarget(ref TEntity target, System.Reflection.PropertyInfo prop)
            {
                var value = prop.GetValue(this, null);
                if (value != null)
                    prop.SetValue(target, value, null);
                return ref target;
            }
            return ref target;
        }
        #endregion
    }
}
