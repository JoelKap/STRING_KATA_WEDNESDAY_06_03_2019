using System;
using System.Collections.Generic;
using System.Linq;

namespace STRING_KATA_WEDNESDAY_06_03_2019
{
    public class StringCalculator
    {
        public int Add(string inputValue)
        {
            if (inputValue == string.Empty) return 0;

            var numbers = SplitNumbers(inputValue);
            NoNegativeNumbers(numbers);
            numbers = numbers.Where(number => number <= 1000);
            return numbers.Sum(v => Convert.ToInt32(v));
        }

        private void NoNegativeNumbers(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0);
            if (negativeNumbers.Any())
            {
                var message = string.Format("Negative numbers are not allowed: {0}", String.Join(",", negativeNumbers));
                throw new NegativeNotSupported(message);
            }
        }

        private static IEnumerable<int> SplitNumbers(string inputValue)
        {
            var delimeters = new List<string> { ",", "\n" };
            if (inputValue.StartsWith("//"))
            {
                string[] customDelimeters = ExtractCustomDelimeter(inputValue);
                delimeters.AddRange(customDelimeters);
                inputValue = inputValue.Substring(inputValue.IndexOf("\n") + 1);
            }
            return inputValue.Split(delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToInt32(n));
        }

        private static string[] ExtractCustomDelimeter(string inputValue)
        {
            string delimeter = ExtractDelimeters(inputValue);
            var customDelimeters = delimeter.Split(new[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
            return customDelimeters;
        }

        private static string ExtractDelimeters(string inputValue)
        {
            var delimeter = inputValue.Substring(0, inputValue.IndexOf("\n"));
            delimeter = delimeter.Substring("//".Length);
            delimeter = delimeter.TrimStart('[').TrimEnd(']');
            return delimeter;
        }
    }
}
