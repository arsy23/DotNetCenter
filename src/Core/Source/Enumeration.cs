namespace DotNetCenter.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    /// <summary>
    /// 
    /// </summary>
    public abstract class Enumeration 
        : BaseObject
        , IComparable
    {
        #region Constructors
        protected Enumeration()
        { }
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; }

        #region Methods
        /// <summary>
        /// Get Hash-Code for this object
        /// </summary>
        /// <returns>Hash-Code</returns>
        public override int GetHashCode()
            => Id.GetHashCode();
        #endregion

        #region StaticMethods
        #region public static IEnumerable<T> GetAll<T>() 
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetAll<T>() 
            where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;
                if (locatedValue != null)
                    yield return locatedValue;
            }
        }
        #endregion

        #region public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <returns></returns>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }
        #endregion

        #region public static T FromValue<T>(int value) where T : Enumeration, new()
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }
        #endregion

        #region public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName,
                                                "display name",
                                                item => item.Name == displayName);
            return matchingItem;
        }
        #endregion
        private static T Parse<T, K>(K value,
                                     string description,
                                     Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new InvalidOperationException(message);
            }
            return matchingItem;
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Determine wheter the specified object is equal to the current object; otherwize,false
        /// </summary>
        /// <param name="obj">The Target Object</param>
        /// <returns>true if the specified object is equal to the current object; otherwize,false</returns>
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
            if (otherValue == null)
                return false;
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);
            return typeMatches && valueMatches;
        }

        #endregion
               public int CompareTo(object other)
            => Id.CompareTo(((Enumeration)other).Id);
    }
}
