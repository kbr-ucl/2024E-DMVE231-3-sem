using EjendomBeregner.BusinessLogic.Domain;

namespace EjendomBeregner.BusinessLogic.Infrastructure;

/// <summary>
///     Repository interface for lejemål
/// </summary>
public interface ILejemaalRepository
{
    /// <summary>
    ///     Indlæser ejendommens lejelmål.
    /// </summary>
    /// <returns>Liste af ejendommens lejemål</returns>
    IEnumerable<Lejemaal> HentLejemaal();
}