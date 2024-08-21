namespace EjendomBeregner.BusinessLogic;


/// <summary>
///     Service interface for beregner service
/// </summary>
public interface IEjendomBeregnerService
{
    /// <summary>
    ///     Beregner ejendommens kvadratmeter.
    /// </summary>
    /// <returns>Ejendommens kvadratmeter</returns>
    double BeregnKvadratmeter();
}

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