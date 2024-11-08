namespace DineroMailfakeMiddelware;

public class CsvDineroReader
{
    public static List<DineroContact> ReadCsv(string filePath)
    {
        var first = true;
        var contacts = new List<DineroContact>();
        foreach (var line in File.ReadLines(filePath))
        {
            if(first)
            {
                first = false;
                continue;
            }

            var values = line.Split(';');
            if (values.Length == 17)
                contacts.Add(
                    new DineroContact
                    {
                        Kontaktnavn = values[0],
                        Medlemsnummer = values[1],
                        Adresse = values[2],
                        Postnummer = values[3],
                        By = values[4],
                        Landekode = values[5],
                        CVRnummer = values[6],
                        EANnummer = values[7],
                        Telefon = values[8],
                        Email = values[9],
                        AttPerson = values[10],
                        Hjemmeside = values[11],
                        BetalingsMetode = values[12],
                        BetalingsfristIDage = values[13],
                        TotalSalg = values[14],
                        TotalKøb = values[15],
                        Kontakttype = values[16]
                    });
        }

        return contacts;
    }
}