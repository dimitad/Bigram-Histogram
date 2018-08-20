using System.Collections.Generic;

namespace AnygramProcessor.Interfaces
{
    /// <summary>
    /// This interface defines the methods that an "N"gram parser must support.
    /// </summary>
    public interface IAnyGramParser
    {
        /// <summary>
        /// This methods parses a collection of words and generates the specific "N"grams as a collection.
        /// </summary>
        /// <param name="input">The content of the input file.</param>
        /// <returns>A collecction of "N"grams where N is dependent on the specific parser instance.</returns>
        IList<Anygram> Parse(string input);

        /// <summary>
        /// This method generates a histogram and returns it as a formatted list.
        /// </summary>
        /// <param name="anygrams">The collecction of "N"grams.</param>
        /// <returns>A formatted collection of the anygram and its corresponding count.</returns>
        IList<string> GetHistogram(IEnumerable<Anygram> anygrams);

        /// <summary>
        /// This method parses the generated list of "N"grams and counts them.
        /// </summary>
        /// <param name="anygrams">The collecction of "N"grams.</param>
        /// <returns>A dictionary collection of the "N"gram as key and the corresponding count.</returns>
        Dictionary<Anygram, int> GenerateHistogram(IEnumerable<Anygram> anygrams);
    }
}