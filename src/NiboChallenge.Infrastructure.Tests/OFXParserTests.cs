using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            // Act
            IEnumerable<OFXDocument> ofxFiles = OFXDocumentParser.Load(new StreamReader("./extrato1.ofx").ReadToEnd());

            // Assert
            Assert.NotNull(ofxFiles);
            Assert.NotEmpty(ofxFiles);

            OFXDocument ofxFile = ofxFiles.First();
            Assert.NotNull(ofxFile.Bank);
            Assert.NotNull(ofxFile.SIGNON);
        }
    }
}
