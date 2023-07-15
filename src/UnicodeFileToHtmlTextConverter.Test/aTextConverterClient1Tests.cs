using NUnit.Framework;
using System;
using System.IO;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies;

namespace TDDMicroExercises.Tests
{
    [TestFixture]
    public class aTextConverterClient1Tests
    {
        [Test]
        public void Constructor_ConvertsTextToHtml()
        {
            // Arrange

            // Act
            var client = new aTextConverterClient1();

            // Assert           
            Assert.NotNull(client);
        }
    }
}