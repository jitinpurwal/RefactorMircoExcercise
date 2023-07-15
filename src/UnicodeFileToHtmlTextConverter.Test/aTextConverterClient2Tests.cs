using NUnit.Framework;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
    [TestFixture]
    public class aTextConverterClient2Tests
    {
        [Test]
        public void Constructor_ConvertsFileToHtml()
        {
            // Arrange
                     
            // Act
            aTextConverterClient2 client = new aTextConverterClient2();

            // Assert
            Assert.NotNull(client);
        }
    }
}


