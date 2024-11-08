// See https://aka.ms/new-console-template for more information

using DineroMailfakeMiddelware;

Console.WriteLine("Dinero mailsender middelware starting");
// Load Dinero contacts
var contacts = CsvDineroReader.ReadCsv("contacts.csv");

// Send email to each contact
foreach (var contact in contacts)
{
    // Build email message
    var mail = new Mail(contact);
    var emailSender = new EmailSender();
    emailSender.SendEmail(mail.Email, mail.GetMessage());
}

Console.WriteLine("Dinero mailsender middelware done - press any key to exit");
Console.ReadKey();