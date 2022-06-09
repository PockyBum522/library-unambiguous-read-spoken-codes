using FluentAssertions;
using NUnit.Framework;

namespace EasyCodes.UnitTests
{
    [TestFixture]
    public class SplitCodeTests
    {
        private string TestCodeOne => "X";
        private string TestCodeTwo => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        [Test]
        public void SplitCode_WhenGivenNoValues_ShouldReturnCodeSplitEveryFourCharacters()
        {
            var result = Generator.SplitCode(TestCodeTwo);

            result.Should().Be("ABCD EFGH IJKL MNOP QRST UVWX YZ");
        }
        
        [Test]
        public void SplitCode_WhenGivenDash_ShouldSplitWithDash()
        {
            var result = Generator.SplitCode(TestCodeTwo,3,"-");

            result.Should().Be("ABC-DEF-GHI-JKL-MNO-PQR-STU-VWX-YZ");
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

            result.Should().Be("ABCDE-=-FGHIJ-=-KLMNO-=-PQRST-=-UVWXY-=-Z");
        }
    }
}