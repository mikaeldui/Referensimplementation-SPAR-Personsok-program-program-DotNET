# Referensimplementation SPAR Personsök program-program

Denna källkod är en referensimplementation av SPAR Personsök program-program version _20160213_.

Referensimplementationen är skriven för _.NET 4.5_ och använder _nuget_ för pakethantering.

Med hjälp av _Visual Studio_ och menyalternativet '_Add Service Reference..._' har det skapats en
tjänst från wsdl-filen som används för att anropa Personsökstjänsten.
Utöver det används _log4net_ för att hantera loggningen och _NUnit_ och _NUnit3TestAdapter_ för att hantera testning av koden.

För mer detaljer om verksamhetsbegrepp inom SPAR, och även andra tjänster inom SPAR se gränssnittsmanualen som är tillgänglig på
[SPARs hemsida](https://www.statenspersonadressregister.se).

## Användning
När projektet byggs hämtar _nuget_ externa beroenden så att koden kan kompilera.

_DemonstrationPersonsok_ innehåller en demonstration som gör fem olika sökningar mot kundtestmiljön och loggar utförligt ut resultatet.

_TesterPersonsok_ har fem tester som kör mot kundtestmiljön. Dessa verifierar att inget går fel. För att köra tester
i Visual Studio, se menyalternativet _Test_, _Run_.

### Kundtest
Vi rekommenderar att det klientcertifikat som är tänkt att användas i produktion även används vid tester mot kundtestmiljön,
detta för att i ett tidigt skede verifiera att certifikatet är korrekt.

### Klientcertifikat
För att använda eget klientcertifikat, byt ut sökväg och lösenord till certifikat i anropet
'_client.ClientCredentials.ClientCertificate.Certificate = ..._' i funktionen _CreateSPARPersonsokningClient_.

### Rootcertifikat
För att verifiera att det är rätt utställare av certifikat hos SPAR så används _X509Certificate2 signerandeCertifikat_
i funktionen _CreateSPARPersonsokningClient_. Den använder även en _CustomCertificateValidator_, _SPARCertificateValidator_
som gör extra verifiering av SPARs certifikat.

Vi rekommenderar att verifiering av rootcertifikatet görs även om en annan lösning används.

### Produktion
Om koden används för att integrera mot produktionsmiljön krävs ett giltigt klientcertifikat, det inkluderade
testcertifikatet fungerar endast i kundtestmiljön. Även indentifieringsinformation behöver vara giltig,
se _KundNrLeveransMottagare_, _KundNrSlutkund_ och _UppdragsId_. För mer information kontakta SPAR:s kundtjänst.

SPAR har bytt certifikatutfärdare vilket medför att anslutningar mot produktionsmiljön behöver använda
medföljande _DigiCert.pem_ istället för Verisign.pem som [rootcertifikat](Rootcertifikat) för att verifiera SPARs certifikat.
