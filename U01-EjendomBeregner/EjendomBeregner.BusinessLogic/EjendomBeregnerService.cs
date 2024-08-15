namespace EjendomBeregner.BusinessLogic
{
    public class EjendomBeregnerService
    {
        /// <summary>
        ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
        ///     Lejemål er i en kommasepareret tekstfil. Formatet af filen er:
        ///     "lejlighednummer", "kvadratmeter", "antal rum"
        ///     lejlighednummer: int
        ///     kvadratmeter: double
        ///     antal rum: double
        /// </summary>
        /// <param name="lejemaalDataFilename"></param>
        /// <returns></returns>
        public double BeregnKvadratmeter(string lejemaalDataFilename)
        {
            var lejemaalene = File.ReadAllLines(lejemaalDataFilename);
            var kvadratmeter = 0.0;


            foreach (var lejemaal in lejemaalene)
            {
                var lejemaalParts = lejemaal.Split(',');
                double lejemaalKvadratmeter;
                double.TryParse(RemoveQuotes(lejemaalParts[1]), out lejemaalKvadratmeter);
                kvadratmeter += lejemaalKvadratmeter;
            }

            return kvadratmeter;
        }

        private string RemoveQuotes(string lejemaalPart)
        {
            return lejemaalPart.Replace('"', ' ').Trim();
        }
    }
}
