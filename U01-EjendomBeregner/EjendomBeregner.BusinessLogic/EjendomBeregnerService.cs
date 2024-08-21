using EjendomBeregner.BusinessLogic.Infrastructure;

namespace EjendomBeregner.BusinessLogic;

/// <summary>
///     Application service der beregner ejendommens kvadratmeter.
/// </summary>
public class EjendomBeregnerService
{
    private readonly ILejemaalRepository _lejemaalRepository;

    public EjendomBeregnerService(ILejemaalRepository lejemaalRepository)
    {
        _lejemaalRepository = lejemaalRepository;
    }

    /// <summary>
    ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
    /// </summary>
    /// <returns>Ejendommens kvadratmeter</returns>
    public double BeregnKvadratmeter()
    {
        var lejemaals = _lejemaalRepository.HentLejemaal();
        double kvadratmeter = 0;
        foreach (var lejemaal in lejemaals) kvadratmeter += lejemaal.Kvadratmeter;
        return kvadratmeter;
    }
}