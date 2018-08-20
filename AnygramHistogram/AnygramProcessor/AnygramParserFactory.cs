using System;
using System.Collections.Generic;
using AnygramProcessor.Interfaces;

namespace AnygramProcessor
{
    [Flags]
    public enum AnygramType
    {
        Unigram,
        Bigram
    }

    /// <summary>
    /// This is a factory class used to create any defined "N"gram parser instance based on the number of words in the "N"gram.
    /// </summary>
    public class AnygramParserFactory : IAnygramParserFactory
    {
        private readonly Dictionary<AnygramType, Type> _parsers = new Dictionary<AnygramType, Type>
        {
            {AnygramType.Bigram, typeof (AnygramParser)}
        };

        public IAnyGramParser Create(AnygramType type)
        {
            Type instanceType;
            _parsers.TryGetValue(type, out instanceType);

            if (instanceType == null)
            {
                 throw new ApplicationException();
            }

            return Activator.CreateInstance(instanceType, 2) as IAnyGramParser;
        }
           
    }
}
