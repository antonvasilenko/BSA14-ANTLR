using System;
using NUnit.Framework;

namespace Calculator.Tests
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

        [TestCase("2+2", Result = "4")]
        [TestCase("2+2+2", Result = "6")]
        public string TestSum(string input)
        {
            return new Calculator().Calculate(input);
        }

        [TestCase("2+2*2", Result = "6")]
        [TestCase("(2+2)*2", Result = "8")]
        [TestCase("(2+2)*(2+3/3)", Result = "12")]
        public string TestPriority(string input)
        {
            return new Calculator().Calculate(input);
        }

        [Test]
        public void TestDivideRound()
        {
            Assert.AreEqual("1", new Calculator().Calculate("3/2"));
            Assert.AreEqual("0", new Calculator().Calculate("2/3"));
        }

        [TestCase("2 + -2", Result = "0")]
        [TestCase("-2 - -1*(3*-4)", Result = "-14")]
        public string TestNegativeNumbers(string input)
        {
            return new Calculator().Calculate(input);
        }
    }
}
