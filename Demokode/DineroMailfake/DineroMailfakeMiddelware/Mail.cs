using System.Text;
using DineroMailfakeMiddelware;

public class Mail
{
    private readonly DineroContact _contact;

    public string Email => _contact.Email;

    public Mail(DineroContact contact)
    {
        _contact = contact;
    }

    public string GetMessage()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Kære {_contact.Kontaktnavn}");
        sb.AppendLine();
        sb.AppendLine("Hermed dine registrede kontaktoplysninger");
        sb.AppendLine();
        sb.AppendLine($"Medlemsnummer: {_contact.Medlemsnummer}");
        sb.AppendLine($"Adresse: {_contact.Adresse}");
        sb.AppendLine($"Postnummer: {_contact.Postnummer}");
        sb.AppendLine($"By: {_contact.By}");
        sb.AppendLine($"Landekode: {_contact.Landekode}");
        sb.AppendLine($"CVR-nummer: {_contact.CVRnummer}");
        sb.AppendLine($"EAN-nummer: {_contact.EANnummer}");
        sb.AppendLine($"Telefon: {_contact.Telefon}");
        sb.AppendLine($"E-mail: {_contact.Email}");
        sb.AppendLine($"Att. person: {_contact.AttPerson}");
        sb.AppendLine($"Hjemmeside: {_contact.Hjemmeside}");
        sb.AppendLine($"Betalings metode: {_contact.BetalingsMetode}");
        sb.AppendLine($"Betalingsfrist i dage: {_contact.BetalingsfristIDage}");
        sb.AppendLine($"Total salg: {_contact.TotalSalg}");
        sb.AppendLine($"Total køb: {_contact.TotalKøb}");
        sb.AppendLine($"Kontakttype: {_contact.Kontakttype}");
        sb.AppendLine();
        sb.AppendLine("Med venlig hilsen");
        sb.AppendLine("Dinero Middelware");
        return sb.ToString();
    }
}