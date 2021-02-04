namespace DotNetCenter.Core.UnitTest
{
    using Xunit;

    public class CuidGeneratorTest
    {
        #region NewCuid
        #region GeneratedCuidWithDefaultMechanism*MustNotNullOrEmpty*
        [Fact]
        public void GeneratedCuidWithDefaultMechanismMustNotNullOrEmpty()
            => Assert.False(string.IsNullOrEmpty(CuidGenerator.NewCuid()));
        #endregion
        #region GeneratedCuidWithDefaultMechanism*MustNotNullOrWhiteSpace*
        [Fact]
        public void GeneratedCuidWithDefaultMechanismMustNotNullOrWhiteSpace()
            => Assert.False(string.IsNullOrWhiteSpace(CuidGenerator.NewCuid()));
        #endregion
        #region NewCuidWithDefaultMechanism*MustReturnCuidWith11CharLength*
        [Fact]
        public void NewCuidWithDefaultMechanismMustReturnCuidWith11CharLength()
            => Assert.Equal(11, CuidGenerator.NewCuid().Length);
        #endregion
        #region NewCuidWithTestCaseCuidCharLength*MustEqualToTestCaseCuidCharLength*
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
