namespace EjendomBeregner.BusinessLogic.Infrastructure;

public class FileWrapper : IFileWrapper
{
    public string[] ReadAllLines(string path)
    {
        return File.ReadAllLines(path);
    }
}