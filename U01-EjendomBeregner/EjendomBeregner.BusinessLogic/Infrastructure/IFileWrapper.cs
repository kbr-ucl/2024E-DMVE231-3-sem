namespace EjendomBeregner.BusinessLogic.Infrastructure;

/// <summary>
///     Wrapper omkring File.ReadAllLines
/// </summary>
public interface IFileWrapper
{
    string[] ReadAllLines(string path);
}