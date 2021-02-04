namespace DotNetCenter.Core.Entities.UnitTest.BaseEntity
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    public class BaseEntityTest
    {
        #region CopyValue
        #region TheTargetObjectRead/WriteProperties*MustEqualTo*SourceObjectAfterCopyValue
        [Fact]
        public void TheTargetObjectReadWritePropsMustEqualToSourceObjectAfterCopyValue()
        {
            var sourceObject = new EPerson(1, 11, "111");
            var targetObject = new EPerson(2, 22, "222");
            sourceObject.CopyValuesTo(ref targetObject);

            Assert.Equal(sourceObject.Name, targetObject.Name);
            Assert.Equal(sourceObject.Age, targetObject.Age);
            Assert.NotEqual(sourceObject.Id, targetObject.Id);
        }
        #endregion
        #endregion

        private const string Name = "Alice";
        private const byte Age = 64;

        #region Equals with Covering GetEqualityComponents
        #region SameEntities*MustBeEquals*WithEqualsMethod
        [Fact]
        public void SameEntitiesMustBeEqualsWithEqualsMethod()
        {
            var builder = new EPersonBuilder();
            var firstPerson = builder.GetPerson(1, Name, Age);
            var secondPerson = builder.GetPerson(2, Name, Age);
            Assert.True(firstPerson.Equals(secondPerson));
        }
        #endregion
        #region DifferentEntities*MustBeNotEquals*WithEqualsMethod
        [Fact]
        public void DifferentEntitiesMustBeNotEqualsWithEqualsMethod()
        {
            var builder = new EPersonBuilder();
            var firstPerson = builder.GetPerson(1, Name, Age);
            var secondPerson = builder.GetPerson(2, Name + " Bob. ", Age + 23);
            Assert.False(firstPerson.Equals(secondPerson));
        }
        #endregion
        #endregion

        #region Operators
        #region == Operator
        #region SameEntitiesMustBeEqualWithObjectEqualityOperator
        [Fact]
        public void SameEntitiesMustBeEqualWithObjectEqualityOperator()
        {
            var builder = new EPersonBuilder();
            var firstPerson = builder.GetPerson(1, Name, Age);
            var secondPerson = builder.GetPerson(2, Name, Age);
            Assert.True(firstPerson == secondPerson);
        }
        #endregion
        #region DifferentEntitiesMustNotEqualWithObjectEqualityOperator
        [Fact]
        public void DifferentEntitiesMustNotEqualWithObjectEqualityOperator()
        {
            var builder = new EPersonBuilder();
            var firstPerson = builder.GetPerson(1, Name, Age);
            var secondPerson = builder.GetPerson(2, Name + " Bob. ", Age + 23);
            Assert.False(firstPerson == secondPerson);
        }
        #endregion
        #endregion
        #region != Operator
        #region SameEntitiesComparisonMustBeTrueWithObjectNotEqualityOperator
        [Fact]
        public void SameEntitiesComparisonMustBeFalseWithObjectNotEqualityOperator()
        {
            var builder = new EPersonBuilder();
            var firstPerson = builder.GetPerson(1, Name, Age);
            var secondPerson = builder.GetPerson(2, Name, Age);
            Assert.False(firstPerson != secondPerson);
        }
        #endregion
        #region DifferentEntitiesComparisonMustBeTrueWithObjectNotEqualityOperator
        [Fact]
        public void DifferentEntitiesComparisonMustBeTrueWithObjectNotEqualityOperator()
        {
            var builder = new EPersonBuilder();
            var firstPerson = builder.GetPerson(1, Name, Age);
            var secondPerson = builder.GetPerson(2, Name + " Bob. ", Age + 23);
            Assert.True(firstPerson != secondPerson);
        }
        #endregion
        #endregion
        #endregion

        #region TestCase
        internal class EPerson : BaseEntity<EPerson, int>
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public EPerson CopyValuesTo(ref EPerson other) 
                => base.CopyValues(ref other);
            public EPerson(int key, int age, string name)
                : base(key)
            {
                Age = age;
                Name = name;
            }
            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Name;
                yield return Age;
            }
            protected override int GetHashCodeCore() 
                => HashCode.Combine(Name, Age);
        }
        #endregion
    }
}
