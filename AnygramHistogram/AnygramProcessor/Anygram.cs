using System.Collections.Generic;
using System.Linq;

namespace AnygramProcessor
{
    /// <summary>
    /// This class represents the words contained in a "N"gram of any length as a sequence.
    /// </summary>
    public class Anygram
    {
        private readonly IEnumerable<string> _words;

        /// <summary>
        /// The list of words that make up the class.
        /// </summary>
        public IEnumerable<string> Words
        {
            get { return _words; }
        }

        /// <summary>
        /// Initializes a new instance ot the any gram.
        /// </summary>
        /// <param name="words">The collection of words that make up the anygram.</param>
        public Anygram(IEnumerable<string> words)
        {
            _words = words;
        }

        /// <summary>
        /// Overrides the default implementation of Equals to support using this class as a dictionary key.
        /// </summary>
        /// <param name="obj">The other Anygram class being compared.</param>
        /// <returns>True if the 2 classes are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            var other = obj as Anygram;
            return other != null && other.Words.SequenceEqual(Words);
        }

        /// <summary>
        /// Overrides the default implementation of GetHashCode to support using this class as a dictionary key.
        /// </summary>
        /// <returns>Hash for the class.</returns>
        public override int GetHashCode()
        {
            return string.Join("|", Words.Select(w => w)).GetHashCode();
        }
    }
}
