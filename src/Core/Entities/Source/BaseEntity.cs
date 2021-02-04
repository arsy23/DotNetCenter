namespace DotNetCenter.Core.Entities
{
    using System;
    using System.Linq;

    /// <summary>
    /// Abstract Base class for Entity
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity itself as parameter</typeparam>
    /// <typeparam name="TKey">The Entity key type</typeparam>
    public abstract class BaseEntity<TEntity, TKey> 
        : BaseObject
        ,Entity<TKey>
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
        #region Operators
        #region ==
        /// <summary>
        /// Equality Opreator
        /// </summary>
        /// <param name="firstObj"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public static bool operator ==(BaseEntity<TEntity, TKey>? firstObj, BaseEntity<TEntity, TKey>? secondObj)
        {
            if (firstObj is null || secondObj is null)
                throw new(nameof(secondObj) + nameof(firstObj));

            return firstObj.Equals(secondObj);
        }
        #endregion
        #region !=
        /// <summary>
        /// Not Equality Oprator
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public static bool operator !=(BaseEntity<TEntity, TKey> firstObject, BaseEntity<TEntity, TKey> secondObj)
            => !(firstObject == secondObj);
        #endregion
        #endregion
        #region CopyValues
        /// <summary>
        /// Copy The Value of type Entity-Key- form this object to target object
        /// </summary>
        /// <param name="target">The Target object recived value from this object presented as reference parameter</param>
        /// <returns></returns>
        protected ref TEntity CopyValues(ref TEntity target)
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
        #endregion
    }
}
