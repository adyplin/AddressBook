using System.Diagnostics;
namespace ConsoleApp.Services;

public interface IFileManager

{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}

public class FileManager(string filePath) : IFileManager
{
    private readonly string _filePath = filePath;


    public bool SaveContentToFile(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath)) 
            {
                sw.WriteLine(content);
            }
                return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

        /// Sparar innehåll och returnerar true ifall den lyckas spara en kontakt annars returnera false
    }


    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

        /// Om filen existerar så kommer innehållet att läsas ut annars går den till catch delen
    }
}
