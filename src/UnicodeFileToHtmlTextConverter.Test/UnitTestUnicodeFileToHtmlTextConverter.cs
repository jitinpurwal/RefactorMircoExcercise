using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;


namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterRefactoredTests
    {
        [Test]
        public void ConvertToHtml_WithFileReaderAndHtmlEncoder_ReturnsHtmlString()
        {
            // Arrange
            string[] lines = new string[] { "Line 1", "Line 2", "Line 3" };
            string expectedHtml = "Line 1<br />Line 2<br />Line 3";

            Mock<IFileReader> fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(f => f.ReadAllLines(It.IsAny<string>())).Returns(lines);

            Mock<IHtmlEncoder> htmlEncoderMock = new Mock<IHtmlEncoder>();
            htmlEncoderMock.Setup(h => h.HtmlEncode(It.IsAny<string>(), It.IsAny<bool>())).Returns((string s) => s);

            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter("Files/testfile.txt");

            // Act
            string result = converter.ConvertToHtml();

            // Assert
            Assert.AreEqual(expectedHtml, result);           
        }

        [Test]
        public void ConvertToHtml_WhenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            // Arrange
            var nonExistentFilePath = "Files/nonexistenttestfile.txt";


            // Create an instance of the UnicodeFileToHtmlTextConverter with the mock dependencies
            var converter = new UnicodeFileToHtmlTextConverter(nonExistentFilePath);

            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => converter.ConvertToHtml());
        }
    }
}
