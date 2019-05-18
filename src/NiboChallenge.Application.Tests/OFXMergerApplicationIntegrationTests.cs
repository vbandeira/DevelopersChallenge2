using System;
using System.IO;
using NiboChallenge.DomainServices;
using Xunit;

namespace NiboChallenge.Application.Tests
{
    public class OFXMergerApplicationIntegrationTests
    {
        OFXMergerApplication application;
        OFXMerger ofxMerger;

        public OFXMergerApplicationIntegrationTests()
        {
            ofxMerger = new OFXMerger();
            application = new OFXMergerApplication(ofxMerger);
        }

        [Fact]
        public void ShouldProcessFiles()
        {
            // Arrange
            string file1 = File.ReadAllText("./Data/dummyData1.ofx");
            string file2 = File.ReadAllText("./Data/dummyData2.ofx");

            // Act
            // Assert
            application.ImportFiles(file1, file2);
        }
    }
}
