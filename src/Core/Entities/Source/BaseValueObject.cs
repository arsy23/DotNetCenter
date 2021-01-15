namespace DotNetCenter.Core.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
    public abstract class BaseValueObject<T> where T : BaseValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();
        protected abstract int GetHashCodeCore();
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            var valueObject = (T)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }
        public override int GetHashCode()
         => GetHashCodeCore();
        public static bool operator ==(BaseValueObject<T> firstObj, BaseValueObject<T> secondObj)
            => firstObj is null && secondObj is null 
            ? true : firstObj is null 
            || secondObj is null 
            ? false : firstObj.Equals(secondObj);

        public static bool operator !=(BaseValueObject<T> firstObject, BaseValueObject<T> secondObj)
            => !(firstObject == secondObj);
    }
}
