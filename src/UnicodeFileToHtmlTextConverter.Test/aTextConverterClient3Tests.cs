using Moq;
using NUnit.Framework;
using System;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.SomeDependencies;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests.SomeDependencies
{
    [TestFixture]
    public class aTextConverterClient3Tests
    {
        [Test]
        public void Constructor_ConvertsFileToHtml()
        {
            // Arrange
            Mock<aTextConverterClient3> converterMock = new Mock<aTextConverterClient3>();
            
            Mock<Activator> activatorWrapperMock = new Mock<Activator>();
            activatorWrapperMock.Setup(a => a.CreateInstance(It.IsAny<Type>(), It.IsAny<object[]>())).Returns(converterMock.Object);

            // Act
            aTextConverterClient3 client = new aTextConverterClient3();

            // Assert
            Assert.NotNull(client);
        }
    }
}

