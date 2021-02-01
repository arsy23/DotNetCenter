namespace DotNetCenter.Core.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

    /// <summary>
    /// Base class for Value-Objects
    /// </summary>
    /// <typeparam name="TValueObject">Type of the Value-Object itself as parameter</typeparam>
    public abstract class BaseValueObject<TValueObject> where TValueObject : BaseValueObject<TValueObject>
    {
        #region GetEqualityComponents
        /// <summary>
        /// Get Equality Components
        /// </summary>
        /// <returns>yield return class components. eg. properties, method results and ...</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();
        #endregion
        #region GetHashCodeCore
        /// <summary>
        /// Abastract class for implement custom functionality to provide Hash-Code  
        /// </summary>
        /// <returns>Hash-Code</returns>
        protected abstract int GetHashCodeCore();
        #endregion
        #region Equals
        /// <summary>
        /// Determine wheter the specified object is equal to the current object; otherwize,false
        /// Support custom equality base on the BaseValueObject Abstract Methods implementations
        /// How to using this method case-studies, Available in test cases 
        /// </summary>
        /// <param name="obj">The Target Object</param>
        /// <returns>true if the specified object is equal to the current object; otherwize,false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)  return false;
            if (GetType() != obj.GetType())  return false;

            var valueObject = (TValueObject)obj;

            return GetEqualityComponents()
                .SequenceEqual(valueObject.GetEqualityComponents());
        }
        #endregion
        #region GetHashCode
        /// <summary>
        /// Provide Hash-Code for the this object
        /// </summary>
        /// <returns>Hash-Code</returns>
        public override int GetHashCode()
         => GetHashCodeCore();
        #endregion
        #region Operators
        #region ==
        /// <summary>
        /// Equality Opreator
        /// </summary>
        /// <param name="firstObj">f</param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public static bool operator ==(BaseValueObject<TValueObject> firstObj, BaseValueObject<TValueObject> secondObj)
            => firstObj is null && secondObj is null
            ? true : firstObj is null
            || secondObj is null
            ? false : firstObj.Equals(secondObj);
        #endregion
        #region !=
        /// <summary>
        /// Not Equality Oprator
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public static bool operator !=(BaseValueObject<TValueObject> firstObject, BaseValueObject<TValueObject> secondObj)
            => !(firstObject == secondObj);
        #endregion
        #endregion
    }
}
