using NUnit.Framework;
using Project.Calculator.Core;

namespace Project.Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(2,3,5,TestName = "Add_PositiveNumbers")]
        [TestCase(-5, -10, -15, TestName = "Add_NegativeNumbers")]
        [TestCase(10.5, 2.5, 13.0, TestName = "Add_DecimalNumbers")]
        [TestCase(100, 0, 100, TestName = "Add_WithZero")]
        public void Should_GiveRightAnswer_When_AddDifferentInputs(double a, double b, double expectedResult)
        {
            // Arrange
            var calculator = new Project.Calculator.Core.Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), $"Failed. Inputs were {a} and {b}.");
        }

        [TestCase(10, 3, 7, TestName = "Substract_PositiveNumbers")]
        [TestCase(5, 10, -5, TestName = "Substract_ResultMustNegative")]
        [TestCase(-5, -5, 0, TestName = "Substract_NegativeNumbers")]
        [TestCase(10.5, 2.5, 8.0, TestName = "Substract_DecimalNumbers")]
        [TestCase(100, 0, 100, TestName = "Substract_WithZero")]
        public void Should_GiveRightAnswer_When_SubstractDifferentInputs(double a, double b, double expectedResult)
        {
            // Arrange
            var calculator = new Project.Calculator.Core.Calculator();

            // Act
            var result = calculator.Substract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), $"Failed. Inputs were {a} and {b}.");
        }

        [TestCase(5, 4, 20, TestName = "Multiply_PositiveNumbers")]
        [TestCase(10, 0, 0, TestName = "Multiply_ByZero")]
        [TestCase(-5, -4, 20, TestName = "Multiply_WithNegative")]
        [TestCase(2.5, 2, 5, TestName = "Multiply_DecimalNumbers")]
        [TestCase(2, -4, -8, TestName = "Multiply_ResultMustNegative")]
        public void Should_GiveRightAnswer_When_MultiplyTwoNumbers(double a, double b, double expectedResult)
        {
            // Arrange
            var calculator = new Project.Calculator.Core.Calculator();

            // Act
            var result = calculator.Multiply(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), $"Failed. Inputs were {a} and {b}.");
        }

        [TestCase(10, 2, 5, TestName = "Divide_PositiveNumbers")]
        [TestCase(10, 4, 2.5, TestName = "Divide_ResultMustDecimal")]
        [TestCase(-10, -2, 5, TestName = "Divide_NegativeNumbers")]
        [TestCase(0, 5, 0, TestName = "Divide_EqualsZero")]
        public void Should_GiveRightAnswer_When_DivideTwoNumbers(double a, double b, double expectedResult)
        {
            // Arrange
            var calculator = new Project.Calculator.Core.Calculator();

            // Act
            var result = calculator.Divide(a, b);

            // Arrange
            Assert.That(result, Is.EqualTo(expectedResult), $"Failed. Inputs were {a} and {b}.");
        }

        [Test]
        public void Should_ThrowException_When_DivideWithZero()
        {
            // Arrange
            var calculator = new Project.Calculator.Core.Calculator();

            // Act and Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}