# Opgave: Systemintegration fra Dinero til Fake Mailserver

## Opgavebeskrivelse
Du skal udvikle en middleware-applikation, der indlæser en kommasepareret fil (CSV) med kontakter, der er eksporteret fra Dinero. Middleware-applikationen skal derefter sende disse kontaktoplysninger til de respektive kontakter via e-mail ved hjælp af en fake mailserver, som er hostet i en Docker-container ved hjælp af FakeSMTP.

## Kravspecifikation
1. **Eksport af kontakter fra Dinero**:
   - Opret en konto ved Dinero
   - Opret mindst to kontakter i Dinero
   - Eksporter kontakterne til 

2. **Middelware (C# program)**:
   1. Indlæsning af CSV-fil:
      - CSV-filen indeholder f.eks. kolonnerne: `E-mail`, `Kontaktname`, `Total salg`, `Total køb`.
      - Middleware-applikationen skal kunne læse og parse denne fil korrekt.

   2. Afsendelse af e-mails:
      - Middleware-applikationen skal oprette en forbindelse til en fake mailserver.
      - E-mails skal sendes til de adresser, der er angivet i CSV-filen, med de tilhørende kontaktoplysninger.

3. **Fake Mailserver i Docker**:
   - Opsæt en fake mailserver ved hjælp af Docker og FakeSMTP.
   - Sørg for, at mailserveren kan modtage e-mails fra middleware-applikationen.
   - Se dokumentation her https://nilhcem.com/FakeSMTP/

## Teknologier og Værktøjer
- **Programmeringssprog**: C#
- **Biblioteker**: `System.IO` til CSV-indlæsning.
- **Docker**: Til opsætning af den fake mailserver ved hjælp af FakeSMTP.
- **Netværkskommunikation**: `TcpClient` til afsendelse af e-mails.

## Trin-for-trin Guide
1. **Opsætning af Projekt**:
   - Opret et nyt C#-projekt og installer nødvendige biblioteker.
   - Opret en Dockerfile til FakeSMTP mailserveren.

2. **Indlæsning af CSV-fil**:
   - Implementer funktionalitet til at læse og parse CSV-filen ved hjælp af `File.ReadLines`.
   - Validér dataene for at sikre, at e-mailadresserne er gyldige.

3. **Afsendelse af E-mails**:
   - Implementer funktionalitet til at sende e-mails ved hjælp af `TcpClient` og SMTP-protokollen.
   - Test afsendelse til FakeSMTP mailserveren.

4. **Opsætning af Fake Mailserver**:
   - Opret en Docker-container med FakeSMTP.
   - Konfigurer mailserveren til at modtage e-mails fra middleware-applikationen.

5. **Test og Validering**:
   - Test hele workflowet fra indlæsning af CSV-fil til afsendelse af e-mails.
   - Sørg for, at alle e-mails modtages korrekt af FakeSMTP mailserveren.

## Eksempel på CSV-fil
```csv
Kontaktnavn;Medlemsnummer;Adresse;Postnummer;By;Landekode;CVR-nummer;EAN-nummer;Telefon;E-mail;Att. person;Hjemmeside;Betalings metode;Betalingsfrist i dage;Total salg;Total køb;Kontakttype
UCL Erhvervsakademi & Professionshøjskole S/I;;Niels Bohrs Allé 1;5230;Odense M;DK;30859480;;63183000;ucl@ucl.dk;;;Netto;8;0;0;Company
```

