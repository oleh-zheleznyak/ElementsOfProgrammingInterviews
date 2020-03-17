using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter09_Stacks
{
    public class ReversePolishNotationCalculator
    {
        private readonly char delimiter;

        public ReversePolishNotationCalculator(char delimiter)
        {
            this.delimiter = delimiter;
        }

        public int Calculate(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException(nameof(input));

            var tokens = input.Split(delimiter);

            return Calculate(tokens);
        }

        private int Calculate(string[] tokens)
        {
            var intermediateResults = new Stack<int>();

            (int first, int second) TakeTwo() => (intermediateResults.Pop(), intermediateResults.Pop());

            foreach (var token in tokens)
            {
                var result = ProcessToken(token, TakeTwo);
                intermediateResults.Push(result);
            }
            return intermediateResults.Peek();
        }

        private int ProcessToken(string token, Func<(int, int)> operandSource)
        {
            if (int.TryParse(token, out var number))
                return number;
            else
            {
                var (first, second) = operandSource();
                var result = ApplyOperand(token, second, first);
                return result;
            }
        }

        private int ApplyOperand(string operand, int first, int second) =>
            operand switch
            {
                "+" => first + second,
                "*" => first * second,
                "-" => first - second,
                "/" => first / second,
                _ => throw new ArgumentException("Token not supported")
            };
    }
}
