using NUnit.Framework;
using System;

namespace UnitTestingLab
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void InchesToCentimeters_ValidInput_ReturnsCorrectResult()
        {
            var (result, error) = Calculator.InchesToCentimeters(10);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(result, Is.EqualTo(25.4).Within(0.001));
        }

        [Test]
        public void InchesToCentimeters_ZeroInput_ReturnsZero()
        {
            var (result, error) = Calculator.InchesToCentimeters(0);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void InchesToCentimeters_NegativeInput_ReturnsError()
        {
            var (result, error) = Calculator.InchesToCentimeters(-5);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_INVALID_INPUT));
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void IsEven_EvenNumber_ReturnsTrue()
        {
            var (isEven, error) = Calculator.IsEven(4);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(isEven, Is.True);
        }

        [Test]
        public void IsEven_OddNumber_ReturnsFalse()
        {
            var (isEven, error) = Calculator.IsEven(7);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(isEven, Is.False);
        }

        [Test]
        public void IsEven_Zero_ReturnsTrue()
        {
            var (isEven, error) = Calculator.IsEven(0);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(isEven, Is.True);
        }

        [Test]
        public void FindMax_ValidArray_ReturnsMaximum()
        {
            int[] arr = { 3, 7, 2, 9, 1 };
            var (max, error) = Calculator.FindMax(arr);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(max, Is.EqualTo(9));
        }

        [Test]
        public void FindMax_NegativeNumbers_WorksCorrectly()
        {
            int[] arr = { -5, -1, -10 };
            var (max, error) = Calculator.FindMax(arr);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(max, Is.EqualTo(-1));
        }

        [Test]
        public void FindMax_NullArray_ReturnsError()
        {
            var (max, error) = Calculator.FindMax(null);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NULL_ARRAY));
        }

        [Test]
        public void FindMax_EmptyArray_ReturnsError()
        {
            var (max, error) = Calculator.FindMax(new int[0]);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_EMPTY_ARRAY));
        }

        [Test]
        public void Modulo_ValidDivision_ReturnsRemainder()
        {
            var (remainder, error) = Calculator.Modulo(17, 5);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(remainder, Is.EqualTo(2));
        }

        [Test]
        public void Modulo_DivisibleNumbers_ReturnsZero()
        {
            var (remainder, error) = Calculator.Modulo(20, 4);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(remainder, Is.EqualTo(0));
        }

        [Test]
        public void Modulo_DivisionByZero_ReturnsError()
        {
            var (remainder, error) = Calculator.Modulo(10, 0);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_DIVISION_BY_ZERO));
        }

        [Test]
        public void CalculateBankInterest_LessThan100_Adds5Percent()
        {
            var (total, error) = Calculator.CalculateBankInterest(50);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(total, Is.EqualTo(52.5).Within(0.001)); // 50 * 1.05
        }

        [Test]
        public void CalculateBankInterest_Boundary100_Adds7Percent()
        {
            var (total, error) = Calculator.CalculateBankInterest(100);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(total, Is.EqualTo(107).Within(0.001)); // 100 * 1.07
        }

        [Test]
        public void CalculateBankInterest_Between100And200_Adds7Percent()
        {
            var (total, error) = Calculator.CalculateBankInterest(150);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(total, Is.EqualTo(160.5).Within(0.001)); // 150 * 1.07
        }

        [Test]
        public void CalculateBankInterest_Boundary200_Adds7Percent()
        {
            var (total, error) = Calculator.CalculateBankInterest(200);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(total, Is.EqualTo(214).Within(0.001)); // 200 * 1.07
        }

        [Test]
        public void CalculateBankInterest_GreaterThan200_Adds10Percent()
        {
            var (total, error) = Calculator.CalculateBankInterest(300);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(total, Is.EqualTo(330).Within(0.001)); // 300 * 1.10
        }

        [Test]
        public void CalculateBankInterest_ZeroDeposit_ReturnsZero()
        {
            var (total, error) = Calculator.CalculateBankInterest(0);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_NONE));
            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void CalculateBankInterest_NegativeDeposit_ReturnsError()
        {
            var (total, error) = Calculator.CalculateBankInterest(-100);
            Assert.That(error, Is.EqualTo(Calculator.ERROR_INVALID_INPUT));
        }
    }
}
