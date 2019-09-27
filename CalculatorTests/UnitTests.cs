using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTests
    {
        private Services.Calculator _calculator = new Services.Calculator();

        #region Sum()

        [TestMethod]
        public void SingleNumberTest()
        {
            var input = "20";
            var expectedOutput = 20;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void TwoNumbersCommaTest()
        {
            var input = "80,45";
            var expectedOutput = 125;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void TwoNumbersLineBreakTest()
        {
            var input = "80\n45";
            var expectedOutput = 125;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void InvalidNumberTest()
        {
            var input = "20,INVALID";
            var expectedOutput = 20;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void MultiDelimiterTest()
        {
            var input = "20,62\n18";
            var expectedOutput = 100;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void CustomSingleCharDelimiterTest()
        {
            var input = "//;\n2;5";
            var expectedOutput = 7;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void CustomMultiCharDelimiterTest()
        {
            var input = "//[***]\n11***22***33";
            var expectedOutput = 66;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void MultipleCustomDelimitersTest()
        {
            var input = "//[*][!!][r9r]\n11r9r22*33!!44";
            var expectedOutput = 110;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void NegativeTest()
        {
            var input = "40,-2,-50,AAA";

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsFalse(output.Success, "Expected to fail since a negative number was provided");
            Console.WriteLine(output.Message);
        }

        [TestMethod]
        public void NegativeTestAllowed()
        {
            var tempCalculator = new Services.Calculator(1000, false, "\n");

            var input = "40,-2,-50,AAA";
            var expectedOutput = -12;

            var output = tempCalculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void OverrideDelimiterTest()
        {
            var tempCalculator = new Services.Calculator(1000, true, "APPLE");

            var input = "8APPLE16";
            var expectedOutput = 24;

            var output = tempCalculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        [TestMethod]
        public void OverrideUpperBoundTest()
        {
            var tempCalculator = new Services.Calculator(10000, true, "\n");

            var input = "9999,111,22222";
            var expectedOutput = 10110;

            var output = tempCalculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        #endregion

        #region Difference()

        [TestMethod]
        public void DifferenceTest()
        {
            var input = "80,45";
            var expectedOutput = 35;

            var output = _calculator.Difference(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        #endregion

        #region Product()

        [TestMethod]
        public void ProductTest()
        {
            var input = "80,45";
            var expectedOutput = 3600;

            var output = _calculator.Product(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        #endregion

        #region Quotient()

        [TestMethod]
        public void QuotientTest()
        {
            var input = "90,15";
            var expectedOutput = 6;

            var output = _calculator.Quotient(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        #endregion
    }
}
