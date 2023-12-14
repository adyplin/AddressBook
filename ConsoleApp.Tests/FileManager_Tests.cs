using ConsoleApp.Services;

namespace ConsoleApp.Tests;

public class FileManager_Tests
{
    [Fact]
    public void SaveToFileShould_ReturnTrue_IfTheFilePathExists()
    {
        // Arrange

        IFileManager fileManager = new FileManager(@"C:\Projects-Education\testing.json");
        string content = "Test content";

        // Act

        bool result = fileManager.SaveContentToFile(content);

        // Assert

        Assert.True(result);
    }
    
    [Fact]
    public void SaveToFileShould_ReturnFalse_IfTheFilePathDoNotExist()
    {
        // Arrange

        IFileManager fileManager = new FileManager(@$"C:\{Guid.NewGuid()}testing.json");
        string content = "Test content";

        // Act

        bool result = fileManager.SaveContentToFile(content);

        // Assert

        Assert.False(result);
    }

}
