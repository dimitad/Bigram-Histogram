using NUnit.Framework;

namespace AnygramProcessor.Test
{
    [TestFixture]
    public class AnygramTest
    {
        private static readonly string[] Bigrams1 = { "test one", "one test", "test two", "two test" };
        private static readonly string[] Bigrams2 = { "test one", "one test", "test two", "two test" };
        private static readonly string[] Bigrams3 = { "test one", "test two", "one test", "two test" };

        [Test]
        public void Equals_WithSameBigrams_ReturnsTrue()
        {
            var bigram1 = new Anygram(Bigrams1);
            var bigram2 = new Anygram(Bigrams2);

            Assert.AreEqual(bigram1, bigram2);
        }

        [Test]
        public void Equals_WithDifferentBigrams_ReturnsFalse()
        {
            var bigram1 = new Anygram(Bigrams1);
            var bigram2 = new Anygram(Bigrams3);

            Assert.AreNotEqual(bigram1, bigram2);
        }

        [Test]
        public void HashCode_WithSameBigrams_ShouldMatch()
        {
            var bigram1 = new Anygram(Bigrams1);
            var bigram2 = new Anygram(Bigrams2);

            Assert.AreEqual(bigram1.GetHashCode(), bigram2.GetHashCode());
        }

        [Test]
        public void HashCode_WithDifferentBigrams_ShouldNotMatch()
        {
            var bigram1 = new Anygram(Bigrams1);
            var bigram2 = new Anygram(Bigrams3);

            Assert.AreNotEqual(bigram1.GetHashCode(), bigram2.GetHashCode());
        }
    }
}
