namespace DotNetCenter.Core.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class CuidGeneratorTest
    {
        #region NewCuid

        #region GeneratedCuidWithDefaultMechanismMustNotNullOrEmpty
        [Fact]
        public void GeneratedCuidWithDefaultMechanismMustNotNullOrEmpty()
            => Assert.False(string.IsNullOrEmpty(CuidGenerator.NewCuid()));
        #endregion

        #region GeneratedCuidWithDefaultMechanismMustNotNullOrWhiteSpace
        [Fact]
        public void GeneratedCuidWithDefaultMechanismMustNotNullOrWhiteSpace()
            => Assert.False(string.IsNullOrWhiteSpace(CuidGenerator.NewCuid()));
        #endregion

        #region NewCuidWithDefaultMechanismMustReturnCuidWith11CharLength
        [Fact]
        public void NewCuidWithDefaultMechanismMustReturnCuidWith11CharLength()
            => Assert.Equal(11, CuidGenerator.NewCuid().Length);
        #endregion

        #region NewCuidWithTestCaseCuidCharLengthMustEqualToTestCaseCuidCharLength
        [Fact]
        public void NewCuidWithTestCaseCuidCharLengthMustEqualToTestCaseCuidCharLength()
        {
            byte testCaseCuidLength = 18;
            Assert.Equal(testCaseCuidLength, CuidGenerator.NewCuid(testCaseCuidLength).Length);
        }
        #endregion

        #endregion
    }
}
