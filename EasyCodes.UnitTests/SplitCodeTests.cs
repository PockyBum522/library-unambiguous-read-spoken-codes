using FluentAssertions;
using NUnit.Framework;

namespace EasyCodes.UnitTests
{
    [TestFixture]
    public class SplitCodeTests
    {
        private string TestCodeOne => "X";
        private string TestCodeTwo => "GXHYDHWTTQPYRY4QWQLCFKLH7G";
        
        [Test]
        public void SplitCode_WhenGivenNoValues_ShouldReturnCodeSplitEveryFourCharacters()
        {
            var result = Generator.SplitCode(TestCodeTwo);

            result.Should().Be("GXHY DHWT TQPY RY4Q WQLC FKLH 7G");
        }
        
        [Test]
        public void SplitCode_WhenGivenDash_ShouldSplitWithDash()
        {
            var result = Generator.SplitCode(TestCodeTwo,3,"-");

            result.Should().Be("GXH-YDH-WTT-QPY-RY4-QWQ-LCF-KLH-7G");
        }
        
        [Test]
        public void SplitCode_WhenGivenShortString_ShouldNotSplit()
        {
            var result = Generator.SplitCode(TestCodeOne, 5, "-=-");

            result.Should().Be("X");
        }

        [Test]
        public void SplitCode_WhenGivenLongerString_ShouldReturnCodeSplitWithLongerString()
        {
            var result = Generator.SplitCode(TestCodeTwo, 5, "-=-");

            result.Should().Be("GXHYD-=-HWTTQ-=-PYRY4-=-QWQLC-=-FKLH7-=-G");
        }
    }
}