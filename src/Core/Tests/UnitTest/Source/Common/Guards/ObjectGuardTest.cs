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
        public ObjectGuardTest() 
            => _guard = new ObjectGuard();


        private readonly ObjectGuard _guard;

        #region ForNullReference
        #region GuardForNullReferenceMustThrowNullReferenceExceptionWhenTheObjectIsNull
        [Fact]
        public void GuardForNullReferenceMustThrowNullReferenceExceptionWhenTheObjectIsNull()
        {
            EEntity @object = null;
            Type expected = GetNullReferenceExceptionType();
            Assert.Throws(expected, ForNullReferenceGuardObject(@object));
        }


        #endregion
        #region GuardForNullReferenceMustNotThrowNullReferenceExceptionWhenTheObjectIsNotNull
        [Fact]
        public void GuardForNullReferenceMustNotThrowNullReferenceExceptionWhenTheObjectIsNotNull()
        {
            var @object = new EEntity();
            var exception = Record.Exception(ForNullReferenceGuardObject(@object));
            Assert.Null(exception);
        }

        private static Type GetNullReferenceExceptionType() 
            => new NullReferenceException().GetType();
        #endregion
        #endregion

        private static Action ForNullReferenceGuardObject(EEntity @object) 
            => new Action(() =>
            {
                ObjectGuard.ForNullReference(@object, nameof(@object));
            });

        #region TestCase
        public class EEntity
        { }
        #endregion
    }
}
