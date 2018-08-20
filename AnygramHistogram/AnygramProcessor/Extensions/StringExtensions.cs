using System.Linq;

namespace AnygramProcessor.Extensions
{
    /// <summary>
    /// Static class that exposes any extension methods on the string type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method on the string type to remove any punctuation.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>The input string with all punctuation removed.</returns>
        public static string RemovePunctuation(this string input)
        {
            return new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
        }
    }
}
