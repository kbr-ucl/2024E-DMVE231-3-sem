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