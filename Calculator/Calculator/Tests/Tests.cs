using System;
using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    class Tests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(FormatException))]
        public void MalformedInput()
        {
            new Calculator().Calculate("2 ++ 2");
        }

        [TestCase("2+2", "4", Result = true)]
        [TestCase("2+2+2", "6", Result = true)]
        public bool TestSum(string input, string result)
        {
            return result == new Calculator().Calculate(input);
        }

        [TestCase("2+2*2", "6", Result = true)]
        [TestCase("(2+2)*2", "8", Result = true)]
        [TestCase("(2+2)*(2+3/3)", "12", Result = true)]
        public bool TestPriority(string input, string result)
        {
            return result == new Calculator().Calculate(input);
        }

        [Test]
        public void TestDivideRound()
        {
            Assert.AreEqual("1", new Calculator().Calculate("3/2"));
            Assert.AreEqual("0", new Calculator().Calculate("2/3"));
        }
    }
}
