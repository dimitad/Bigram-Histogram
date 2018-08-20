namespace AnygramProcessor.Interfaces
{
    /// <summary>
    /// This interface defines the methods a parser factory must support.
    /// </summary>
    public interface IAnygramParserFactory
    {
        /// <summary>
        /// Factory method to get a parser instance depending on the number of words in the "N"gram.
        /// </summary>
        /// <param name="type">Look up type that corresponds to the size of the "N"gram.</param>
        /// <returns>An instance of an "N"gram parser.</returns>
        IAnyGramParser Create(AnygramType type);
    }
}
