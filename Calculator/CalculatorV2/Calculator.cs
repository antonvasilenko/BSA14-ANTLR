using System;
using System.Globalization;

namespace CalculatorV2
{
    public class Calculator
    {
        private string _input;

        public bool Debug { get; private set; }

        public Calculator(bool debug = false)
        {
            Debug = debug;
        }

        public string Calculate(string inputString)
        {
            _input = inputString;
            return "unknown";
        }
    }
}