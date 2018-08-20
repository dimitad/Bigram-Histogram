using System.Collections.Generic;
using AnygramProcessor.Interfaces;
using NUnit.Framework;

namespace AnygramProcessor.Test
{
    [TestFixture]
    public class BigramParserTest
    {
        private const string SingleWordInput = "Test";
        private const string PunctuatationInput = ". , ; : ! ?";

        private const string TwoWordsInput = "The quick";
        private const string MultipleWordsInput = "The quick brown fox and the quick blue hare";
        private const string MultipleWordsWithPunctuationInput = "The, quick. brown! \"fox\" and, the! quic'k? blu-e hare?";
        private const string MultipleSpacesBetweenWordsInput = "        The  quick    brown     fox          and the   quick blue      hare    ";
        private const string MultipleLineWordsInput = 
                                                        @"The quick 
                                                        brown fox 
                                                        and 


                                                        the

                                                        quick 



                                                        blue 
                                                        hare";
        private static readonly Anygram Bigram1 = new Anygram(new List<string>() { "the", "quick" });
        private static readonly Anygram Bigram2 = new Anygram(new List<string>() { "quick", "brown" });
        private static readonly Anygram Bigram3 = new Anygram(new List<string>() { "brown", "fox" });
        private static readonly Anygram Bigram4 = new Anygram(new List<string>() { "fox", "and" });
        private static readonly Anygram Bigram5 = new Anygram(new List<string>() { "and", "the" });
        private static readonly Anygram Bigram6 = new Anygram(new List<string>() { "the", "quick" });
        private static readonly Anygram Bigram7 = new Anygram(new List<string>() { "quick", "blue" });
        private static readonly Anygram Bigram8 = new Anygram(new List<string>() { "blue", "hare" });

        private const string OneLetterWordsInput = "I am a robot";
        private static readonly Anygram OneLetterBigram1 = new Anygram(new List<string>() { "i", "am" });
        private static readonly Anygram OneLetterBigram2 = new Anygram(new List<string>() { "am", "a" });
        private static readonly Anygram OneLetterBigram3 = new Anygram(new List<string>() { "a", "robot" });

        private const string VariableCaseWordsInput = "tEsT OnE TwO ThREe FoUR fiVE TeSt oNe tWo tHreE fOur FIve";
        private static readonly Anygram VariableCaseBigram1 = new Anygram(new List<string>() { "test", "one" });
        private static readonly Anygram VariableCaseBigram2 = new Anygram(new List<string>() { "one", "two" });
        private static readonly Anygram VariableCaseBigram3 = new Anygram(new List<string>() { "two", "three" });
        private static readonly Anygram VariableCaseBigram4 = new Anygram(new List<string>() { "three", "four" });
        private static readonly Anygram VariableCaseBigram5 = new Anygram(new List<string>() { "four", "five" });
        private static readonly Anygram VariableCaseBigram6 = new Anygram(new List<string>() { "five", "test" });

        private const string NumericalInput = "1 2 3 4 5 6";
        private static readonly Anygram NumericalBigram1 = new Anygram(new List<string>() { "1", "2" });
        private static readonly Anygram NumericalBigram2 = new Anygram(new List<string>() { "2", "3" });
        private static readonly Anygram NumericalBigram3 = new Anygram(new List<string>() { "3", "4" });
        private static readonly Anygram NumericalBigram4 = new Anygram(new List<string>() { "4", "5" });
        private static readonly Anygram NumericalBigram5 = new Anygram(new List<string>() { "5", "6" });

        private const string RepeatingWordInput = "test test test test test test test test test test";
        private static readonly Anygram RepeatingWordBigram = new Anygram(new List<string>() { "test", "test" });

        private readonly IAnyGramParser _bigramParser = new AnygramParser(2);

        [Test]
        public void ParseBigram_WithEmptyString_ReturnsEmptyCollection()
        {
            //Act
            var result = _bigramParser.Parse(string.Empty);

            //Assert
            Assert.IsNotNull(result);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ParseBigram_WithSingleWord_ReturnsEmptyCollection()
        {
            //Act
            var result = _bigramParser.Parse(SingleWordInput);

            //Assert
            Assert.IsNotNull(result);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ParseBigram_WithPunctuation_ReturnsEmptyCollection()
        {
            //Act
            var result = _bigramParser.Parse(PunctuatationInput);

            //Assert
            Assert.IsNotNull(result);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ParseBigram_WithWhiteSpace_ReturnsEmptyCollection()
        {
            //Act
            var result = _bigramParser.Parse("         ");

            //Assert
            Assert.IsNotNull(result);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ParseBigram_WithTwoWords_ReturnsSingleBigram()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                Bigram1
            };

            //Act
            var result = _bigramParser.Parse(TwoWordsInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void ParseBigram_WithMultipleWords_ReturnsCorrectBigrams()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                Bigram1,
                Bigram2,
                Bigram3,
                Bigram4,
                Bigram5,
                Bigram6,
                Bigram7,
                Bigram8
            };

            //Act
            var result = _bigramParser.Parse(MultipleWordsInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void ParseBigram_WithOneLetterWords_ReturnsCorrectBigrams()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                OneLetterBigram1,
                OneLetterBigram2,
                OneLetterBigram3
            };

            //Act
            var result = _bigramParser.Parse(OneLetterWordsInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void ParseBigram_WithDigitsOnly_ReturnsCorrectBigrams()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                NumericalBigram1,
                NumericalBigram2,
                NumericalBigram3,
                NumericalBigram4,
                NumericalBigram5
            };

            //Act
            var result = _bigramParser.Parse(NumericalInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void ParseBigram_WithMultipleSpacesBetweenWords_RemovesExtraSpaces()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                Bigram1,
                Bigram2,
                Bigram3,
                Bigram4,
                Bigram5,
                Bigram6,
                Bigram7,
                Bigram8
            };

            //Act
            var result = _bigramParser.Parse(MultipleSpacesBetweenWordsInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void ParseBigram_WithPunctuation_RemovesAllPunctuation()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                Bigram1,
                Bigram2,
                Bigram3,
                Bigram4,
                Bigram5,
                Bigram6,
                Bigram7,
                Bigram8
            };

            //Act
            var result = _bigramParser.Parse(MultipleWordsWithPunctuationInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void ParseBigram_WithNewLinesBetweenWords_ReturnsCorrectBigrams()
        {
            //Arrange
            var expectedBigrams = new List<Anygram>
            {
                Bigram1,
                Bigram2,
                Bigram3,
                Bigram4,
                Bigram5,
                Bigram6,
                Bigram7,
                Bigram8
            };

            //Act
            var result = _bigramParser.Parse(MultipleLineWordsInput);

            //Assert
            CollectionAssert.AreEqual(expectedBigrams, result);
        }

        [Test]
        public void GenerateHistogram_WhenInputTextHasDifferentCase_ReturnsCorrectCounts()
        {
            //Arrange
            var expectedBigramCounts = new Dictionary<Anygram, int>()
            {
                {VariableCaseBigram1, 2},
                {VariableCaseBigram2, 2},
                {VariableCaseBigram3, 2},
                {VariableCaseBigram4, 2},
                {VariableCaseBigram5, 2},
                {VariableCaseBigram6, 1}
            };
            var bigrams = _bigramParser.Parse(VariableCaseWordsInput);

            //Act
            var resultBigramCounts = _bigramParser.GenerateHistogram(bigrams);

            //Assert
            CollectionAssert.AreEquivalent(expectedBigramCounts, resultBigramCounts);
        }

        [Test]
        public void GenerateHistogram_WithMultipleBigrams_ReturnsCorrectCounts()
        {
            //Arrange
            var expectedBigramCounts = new Dictionary<Anygram, int>()
            {
                {Bigram1, 2},
                {Bigram2, 1},
                {Bigram3, 1},
                {Bigram4, 1},
                {Bigram5, 1},
                {Bigram7, 1},
                {Bigram8, 1}
            };

            var bigrams = _bigramParser.Parse(MultipleWordsInput);

            //Act
            var resultBigramCounts = _bigramParser.GenerateHistogram(bigrams);

            //Assert
            CollectionAssert.AreEquivalent(expectedBigramCounts, resultBigramCounts);
        }

        [Test]
        public void GenerateHistogram_WhenTextContainsPunctuation_ReturnsCorrectCounts()
        {
            //Arrange
            var expectedBigramCounts = new Dictionary<Anygram, int>()
            {
                {Bigram1, 2},
                {Bigram2, 1},
                {Bigram3, 1},
                {Bigram4, 1},
                {Bigram5, 1},
                {Bigram7, 1},
                {Bigram8, 1}
            };

            var bigrams = _bigramParser.Parse(MultipleWordsWithPunctuationInput);

            //Act
            var resultBigramCounts = _bigramParser.GenerateHistogram(bigrams);

            //Assert
            CollectionAssert.AreEquivalent(expectedBigramCounts, resultBigramCounts);
        }

        [Test]
        public void GenerateHistogram_WithRepeatingWords_ReturnsCorrectCounts()
        {
            //Arrange
            var expectedBigramCounts = new Dictionary<Anygram, int>()
            {
                {RepeatingWordBigram, 9}
            };

            var bigrams = _bigramParser.Parse(RepeatingWordInput);

            //Act
            var resultBigramCounts = _bigramParser.GenerateHistogram(bigrams);

            //Assert
            CollectionAssert.AreEquivalent(expectedBigramCounts, resultBigramCounts);
        }

        [Test]
        public void GetHistogram_WhenSingleBigram_ReturnsList()
        {
            //Arrange
            var expectedBigramCounts = new List<string>
            {
                "the quick: 1"
            };

            var bigrams = _bigramParser.Parse(TwoWordsInput);

            //Act
            var result = _bigramParser.GetHistogram(bigrams);

            //Assert
            CollectionAssert.AreEqual(expectedBigramCounts, result);
        }

        [Test]
        public void GetHistogram_WhenMultipleBigrams_ReturnsList()
        {
            //Arrange
            var expectedBigramCounts = new List<string>
            {
                "the quick: 2", "quick brown: 1", "brown fox: 1", "fox and: 1", "and the: 1", "quick blue: 1", "blue hare: 1"
            };

            var bigrams = _bigramParser.Parse(MultipleWordsInput);

            //Act
            var result = _bigramParser.GetHistogram(bigrams);

            //Assert
            CollectionAssert.AreEqual(expectedBigramCounts, result);
        }

        [Test]
        public void GetHistogram_WhenNumericalBigrams_ReturnsList()
        {
            //Arrange
            var expectedBigramCounts = new List<string>
            {
                "1 2: 1", "2 3: 1", "3 4: 1", "4 5: 1", "5 6: 1"
            };

            var bigrams = _bigramParser.Parse(NumericalInput);

            //Act
            var result = _bigramParser.GetHistogram(bigrams);

            //Assert
            CollectionAssert.AreEqual(expectedBigramCounts, result);
        }
    }
}
