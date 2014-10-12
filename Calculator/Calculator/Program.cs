using System;

namespace Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var inputString = args[0];
            var result = new Calculator(true).Calculate(inputString);
            Console.WriteLine("{0} = {1}", args[0], result);
        }
    }
}
