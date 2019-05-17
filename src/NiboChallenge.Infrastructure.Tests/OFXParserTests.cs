using System;
using System.IO;
using NiboChallenge.Infrastructure.Entities;
using Xunit;

namespace NiboChallenge.Infrastructure.Tests
{
    public class OFXParserTests
    {
        [Fact]
        public void ShouldImportOFXFile()
        {
            // Arrange
            var parser = new OFXDocumentParser();

            // Act
            OFX ofxFile = parser.Load(new StreamReader("./extrato1.ofx").ReadToEnd());

            // Assert
            Assert.NotNull(ofxFile);
            Assert.NotNull(ofxFile.BANKMSGSRSV1);
            Assert.NotNull(ofxFile.SIGNONMSGSRSV1);
        }
    }
}
