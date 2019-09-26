using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTests
    {
        private Services.Calculator _calculator = new Services.Calculator();

        [TestMethod]
        public void SingleNumberTest()
        {
            var input = "20";
            var expectedOutput = 20;

            var output = _calculator.Sum(input);

            Assert.IsNotNull(output, "Output object should not be null");
            Assert.IsTrue(output.Success, output.Message);
            Assert.AreEqual(expectedOutput, output.Value, "Incorrect Output");
        }
    }
}
