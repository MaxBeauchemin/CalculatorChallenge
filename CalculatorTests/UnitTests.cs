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
            var input = "////[*][!!][r9r]\n11r9r22*33!!44";
            var expectedOutput = 110;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
            Console.WriteLine(output.Formula);
        }

        #endregion
    }
}
