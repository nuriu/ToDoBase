using System.Linq;

namespace ToDoBase.Core.Extensions
{
    public static class StringExtensions
    {
        public static string DefaultIfEmpty(this string input, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }

        public static bool ShouldNotContainDigits(this string input)
        {
            return !input.Any(char.IsDigit);
        }

        public static bool ShouldContainDigits(this string input)
        {
            return input.Any(char.IsDigit);
        }
    }
}
