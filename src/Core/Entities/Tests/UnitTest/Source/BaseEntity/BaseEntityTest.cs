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
