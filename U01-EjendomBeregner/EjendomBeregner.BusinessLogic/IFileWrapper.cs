namespace EjendomBeregner.BusinessLogic;

/// <summary>
///     Wrapper omkring File.ReadAllLines
/// </summary>
public interface IFileWrapper
{
    string[] ReadAllLines(string path);
}

public class FileWrapper : IFileWrapper
{
    public string[] ReadAllLines(string path)
    {
        return File.ReadAllLines(path);
    }
}