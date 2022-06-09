using FluentAssertions;
using NUnit.Framework;

namespace EasyCodes.UnitTests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void GetCode_WhenGivenNoValues_ShouldReturnCodeWithSixCharacters()
        {
            var result = Generator.GetCode();

            result.Length.Should().Be(6);
        }
        
        [Test]
        public void GetCode_WhenGivenNoValues_ShouldReturnLettersAndNumbersOnly()
        {
            var result = Generator.GetCode(10000);
            
            result.Should().NotContainAny("~", "@", "#", "%", "^", "&", "*");
            
            result.Should().ContainAll("A", "C", "D", "F", "G", "H", "J", "K", "L", "P", "Q", "R", "T", "U", "V", "W", "X", "Y", "Z");
            result.Should().ContainAll("2", "4", "6", "7", "9");
        }        
        
        [Test]
        public void GetCode_WhenGivenLettersOnly_ShouldReturnLettersAndNumbersOnly()
        {
            var result = Generator.GetCode(10000, CharacterSets.LettersOnly);
            
            result.Should().NotContainAny("~", "@", "#", "%", "^", "&", "*");
            result.Should().NotContainAny("2", "4", "6", "7", "9");

            result.Should().ContainAll("A", "C", "D", "F", "G", "H", "J", "K", "L", "P", "Q", "R", "T", "U", "V", "W", "X", "Y", "Z");
        }
        
        [Test]
        public void GetCode_WhenGivenLettersNumbersAndSymbols_ShouldReturnLettersNumbersAndSymbols()
        {
            var result = Generator.GetCode(10000, CharacterSets.LettersNumbersAndSymbols);
            
            result.Should().ContainAll("~", "@", "#", "%", "^", "&", "*");
            result.Should().ContainAll("2", "4", "6", "7", "9");
            result.Should().ContainAll("A", "C", "D", "F", "G", "H", "J", "K", "L", "P", "Q", "R", "T", "U", "V", "W", "X", "Y", "Z");
        }
        
        [Test]
        public void GetCode_WhenGivenLength_ShouldReturnCodeOfLength()
        {
            var result = Generator.GetCode(100);

            result.Length.Should().Be(100);
        }
        
        [Test]
        public void GetCode_WhenGivenLengthOne_ShouldReturnCodeOfLengthOne()
        {
            var result = Generator.GetCode(1);

            result.Length.Should().Be(1);
        }
    }
}