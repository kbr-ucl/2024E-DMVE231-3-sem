using System.Net.Sockets;
using System.Text;

namespace DineroMailfakeMiddelware;

public class EmailSender
{
    public void SendEmail(string toAddress, string message)
    {
        var smtpServer = "localhost";
        var smtpPort = 2525;

        using (var client = new TcpClient(smtpServer, smtpPort))
        using (var networkStream = client.GetStream())
        using (var writer = new StreamWriter(networkStream, Encoding.ASCII))
        using (var reader = new StreamReader(networkStream, Encoding.ASCII))
        {
            // Read server response
            var response = reader.ReadLine();
            Console.WriteLine("Server: " + response);

            // Send HELO command
            writer.WriteLine("HELO localhost");
            writer.Flush();
            response = reader.ReadLine();
            Console.WriteLine("Server: " + response);

            // Send MAIL FROM command
            writer.WriteLine("MAIL FROM:<your_email@example.com>");
            writer.Flush();
            response = reader.ReadLine();
            Console.WriteLine("Server: " + response);

            // Send RCPT TO command
            writer.WriteLine($"RCPT TO:<{toAddress}>");
            writer.Flush();
            response = reader.ReadLine();
            Console.WriteLine("Server: " + response);

            // Send DATA command
            writer.WriteLine("DATA");
            writer.Flush();
            response = reader.ReadLine();
            Console.WriteLine("Server: " + response);

            // Send email headers and body
            writer.WriteLine("Subject: Contact Information");
            writer.WriteLine("From: your_email@example.com");
            writer.WriteLine($"To: {toAddress}");
            writer.WriteLine();
            writer.WriteLine(message);
            writer.WriteLine(".");
            writer.Flush();
            response = reader.ReadLine();
            Console.WriteLine("Server: " + response);

            // Send QUIT command
            writer.WriteLine("QUIT");
            writer.Flush();
            response = reader.ReadLine();
            Console.WriteLine("Server: " + response);
        }
    }
}