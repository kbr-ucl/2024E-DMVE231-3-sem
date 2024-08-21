using System.Globalization;
using EjendomBeregner.BusinessLogic.Domain;

namespace EjendomBeregner.BusinessLogic.Infrastructure;

/// <summary>
///     Implementation af ILejemaalRepository der indlæser lejemål fra en kommasepareret tekstfil.
/// </summary>
public class LejemaalFileRepository : ILejemaalRepository
{
    private readonly IFileWrapper _fileWrapper;
    private readonly string _lejemaalDataFilename;

    public LejemaalFileRepository(string lejemaalDataFilename, IFileWrapper fileWrapper)
    {
        _lejemaalDataFilename = lejemaalDataFilename;
        _fileWrapper = fileWrapper;
    }

    /// <summary>
    ///     Indlæser ejendommens lejelmål.
    ///     Lejemål er i en kommasepareret tekstfil. Formatet af filen er:
    ///     "lejlighednummer", "kvadratmeter", "antal rum"
    ///     lejlighednummer: int
    ///     kvadratmeter: double
    ///     antal rum: double
    ///     Data eksempel fra filen: "3", "20.5", "4.5"
    /// </summary>
    /// <returns>Ejendommens lejemål</returns>
    public IEnumerable<Lejemaal> HentLejemaal()
    {
        var lejemaalene = _fileWrapper.ReadAllLines(_lejemaalDataFilename);
        foreach (var lejemaal in lejemaalene)
        {
            var lejemaalParts = lejemaal.Split(',');
            int.TryParse(RemoveQuotes(lejemaalParts[0]), out var lejlighednummer);
            double.TryParse(RemoveQuotes(lejemaalParts[1]), CultureInfo.InvariantCulture, out var lejemaalKvadratmeter);
            double.TryParse(RemoveQuotes(lejemaalParts[2]), CultureInfo.InvariantCulture, out var rum);
            yield return new Lejemaal
            {
                Lejlighednummer = lejlighednummer,
                Kvadratmeter = lejemaalKvadratmeter,
                Rum = rum
            };
        }
    }

    private string RemoveQuotes(string lejemaalPart)
    {
        return lejemaalPart.Replace('"', ' ').Trim();
    }
}