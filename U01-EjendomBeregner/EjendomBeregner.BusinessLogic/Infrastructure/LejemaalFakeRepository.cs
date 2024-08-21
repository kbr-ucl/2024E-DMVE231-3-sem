using EjendomBeregner.BusinessLogic.Domain;

namespace EjendomBeregner.BusinessLogic.Infrastructure;

/// <summary>
///     Implementation af ILejemaalRepository der indlæser fake.
/// </summary>
public class LejemaalFakeRepository : ILejemaalRepository
{
    /// <summary>
    ///     Danner et fake lejemål repository.
    /// </summary>
    /// <returns>Ejendommens lejemål</returns>
    public IEnumerable<Lejemaal> HentLejemaal()
    {
        return new List<Lejemaal>(new[]
        {
            new Lejemaal { Lejlighednummer = 1, Kvadratmeter = 100, Rum = 4 },
            new Lejemaal { Lejlighednummer = 2, Kvadratmeter = 80.4, Rum = 3 },
            new Lejemaal { Lejlighednummer = 3, Kvadratmeter = 60, Rum = 2.5 }
        });
    }
}