namespace EjendomBeregner.BusinessLogic;

/// <summary>
///     Domain model for lejemål
/// </summary>
public class Lejemaal
{
    public int Lejlighednummer { get; set; }
    public double Kvadratmeter { get; set; }
    public double Rum { get; set; }
}