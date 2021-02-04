using Xunit;

namespace DotNetCenter.Core.Entities.UnitTest.BaseEntity
{
    public class BaseEntityTest
    {
        #region CopyValue
        #region TheTargetObjectRead/WriteProperties*MustEqualTo*SourceObjectAfterCopyValue
        [Fact]
        public void TheTargetObjectReadWritePropsMustEqualToSourceObjectAfterCopyValue()
        {
            var sourceObject = new EPerson(1, 11, "111");
            EPerson targetObject = new EPerson(2, 22, "222");
            sourceObject.CopyValues(ref targetObject);

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
            public EPerson(int key, int age, string name)
                : base(key)
            {
                Age = age;
                Name = name;
            }
        }
        #endregion
    }
}
