namespace DotNetCenter.Core.UnitTest.Common.Guards
{
    using DotNetCenter.Core.Common.Guards;
    using DotNetCenter.Core.Guards;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ObjectGuardTest
    {

        #region ForNullReference
        #region GuardForNullReference*MustThrow*NullReferenceExceptionWhenTheObjectIsNull
        [Fact]
        public void GuardForNullReferenceMustThrowNullReferenceExceptionWhenTheObjectIsNull()
        {
            EEntity? @object = null;
            Type expected = GetNullReferenceExceptionType();
            Assert.Throws(expected, GuardObjectNullReference(@object));
        }
        #endregion
        #region GuardForNullReference*MustNotThrow*NullReferenceExceptionWhenTheObjectIsNotNull
        [Fact]
        public void GuardForNullReferenceMustNotThrowNullReferenceExceptionWhenTheObjectIsNotNull()
        {
            var @object = new EEntity();
            var exception = Record.Exception(GuardObjectNullReference(@object));
            Assert.Null(exception);
        }
        #endregion
        #endregion

        private static Action GuardObjectNullReference(EEntity? @object)
            => new Action(() =>
            {
                ObjectGuard.ForNullReference(@object, nameof(@object));
            });
        private static Type GetNullReferenceExceptionType()
            => new NullReferenceException().GetType();

        #region TestCase
        public class EEntity
        { }
        #endregion
    }
}
