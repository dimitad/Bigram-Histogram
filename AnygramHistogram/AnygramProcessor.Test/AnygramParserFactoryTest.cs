using System;
using AnygramProcessor.Interfaces;
using NUnit.Framework;

namespace AnygramProcessor.Test
{
    [TestFixture]
    public class AnygramParserFactoryTest
    {
        private IAnygramParserFactory _factory;

        [TestFixtureSetUp]
        public void FixtureInit()
        {
            _factory = new AnygramParserFactory();
        }

        [Test]
        public void Create_WhenGivenAnygramType_InstantiatesAnygramParser()
        {
            //Act
            var bigramParser = _factory.Create(AnygramType.Bigram);

            //Assert
            Assert.IsNotNull(bigramParser);
            Assert.IsTrue(bigramParser.GetType() == typeof(AnygramParser));
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void Create_WhenGivenUnigramType_ThrowsApplicationException()
        {
            //Act
            var parser = _factory.Create(AnygramType.Unigram);

            //Assert
            Assert.Null(parser);
        }
    }
}