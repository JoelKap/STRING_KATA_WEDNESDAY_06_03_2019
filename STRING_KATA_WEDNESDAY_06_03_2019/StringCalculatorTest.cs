using NUnit.Framework;

namespace STRING_KATA_WEDNESDAY_06_03_2019
{
    [TestFixture]
    public class StringCalculatorTest
    {

        [Test]
        public void Add_GivenAnEmptyString_ShouldReturnZero()
        {
            // Act
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("");
            // Assert
            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Add_GivenAStringWithASingleNumber_ShouldReturnThatNumber()
        {
            // Act
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("1");
            // Assert
            Assert.AreEqual(1, sum);
        }

        [Test]
        public void Add_GivenTwoCharacterNumber_ShouldReturnSum()
        {
            // Act 
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("1,2");
            // Assert
            Assert.AreEqual(3, sum);
        }

        [Test]
        public void Add_GivenManyCommaSeparatedNumbers_ShouldReturnSum()
        {
            // Act 
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("1,3,3");
            // Assert
            Assert.AreEqual(7, sum);
        }

        [Test]
        public void Add_GivenNewLineAsDelimeter_ShouldReturnSum()
        {
            // Act  
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("1\n2,3");
            // Assert
            Assert.AreEqual(6, sum);
        }

        [Test]
        public void Add_GivenNewLineAndCustomDelimeters_ShouldReturnSum()
        {
            // Act   
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("//;\n1;2");
            // Assert
            Assert.AreEqual(3, sum);
        }

        [Test]
        public void Add_GivenANegativeNumber_ShouldThrowException()
        {
            // Act   
            var calcultor = new StringCalculator();
            // Arrange
            var exception = Assert.Throws<NegativeNotSupported>(() => calcultor.Add("-1"));
            // Assert
            Assert.AreEqual(exception.Message, "Negative numbers are not allowed: -1");
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowException()
        {
            // Act   
            var calcultor = new StringCalculator();
            // Arrange
            var exception = Assert.Throws<NegativeNotSupported>(() => calcultor.Add("-1,-2,-3"));
            // Assert
            Assert.AreEqual(exception.Message, "Negative numbers are not allowed: -1,-2,-3");
        }

        [Test]
        public void Add_GivenNumberBiggerThen1000_ShouldIgnore()
        {
            // Act   
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("//;\n1;1001");
            // Assert
            Assert.AreEqual(1, sum);
        }

        [Test]
        public void Add_GivenNumberEqualOrLessentThen1000_ShouldReturnSum()
        {
            // Act   
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("//;\n1;1000,3");
            // Assert
            Assert.AreEqual(1004, sum);
        }

        [Test]
        public void Add_GivenDelimetersWithAnyLength_ShouldReturnSum()
        {
            // Act    
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("//[***]\n1***2***3");
            // Assert
            Assert.AreEqual(6, sum);
        }

        [Test]
        public void Add_GivenMutipleCustomDelimeters_ShouldReturnSum()
        {
            // Act    
            var calcultor = new StringCalculator();
            // Arrange
            var sum = calcultor.Add("//[***][&]\n1***7&");
            // Assert
            Assert.AreEqual(8, sum);
        }
    }
}
