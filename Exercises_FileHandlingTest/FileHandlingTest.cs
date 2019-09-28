using Xunit;
using Exercises_FileHandling;

namespace Exercises_FileHandlingTest
{
    public class FileHandlingTest
    {
        [Theory]
        [InlineData(@"..\..\..\Blank1.txt")]
        [InlineData(@"..\..\Blank3.txt")]
        [InlineData(@"..\Blank5.txt")]
        [InlineData(@"..\Blank7")]
        public void Test_MultiplePath_BlankFile(string value)
        {
            //Act
            bool actual = FileHandling.BlankFile(value);

            //Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData(@"..\..\..\Blank1.txt")]
        [InlineData(@"..\..\Blank3.txt")]
        [InlineData(@"..\Blank5.txt")]
        [InlineData(@"..\Blank7")]
        public void Test_MultiplePath_CreateSecondFile(string value)
        {
            //Act
            bool actual = FileHandling.CreateSecondFile(value);

            //Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData(@"..\..\..\Blank1.txt")]
        [InlineData(@"..\..\..\Blank2.txt")]
        [InlineData(@"..\..\Blank3.txt")]
        [InlineData(@"..\..\Blank4.txt")]
        [InlineData(@"..\Blank5.txt")]
        [InlineData(@"..\Blank6.txt")]
        [InlineData(@"..\Blank7")]
        [InlineData(@"..\Blank8")]
        public void Test_MultiplePath_DeleteFile(string value)
        {
            //Arrange
            bool expected = true;

            //Act
            bool actual = FileHandling.DeleteFile(value);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"..\..\..\myTest.txt", "Message")]
        public void Test_WriteToFile(string input, string message)
        {
            bool actual = FileHandling.WriteToFile(input, message);

            Assert.True(actual);
        }
    }
}
