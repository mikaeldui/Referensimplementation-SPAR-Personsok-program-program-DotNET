using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using log4net;
using log4net.Config;
using ReferensimplementationPersonsok.SparServiceReference;

namespace ReferensimplementationPersonsok
{
    public class DemonstrationPersonsok
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DemonstrationPersonsok));

        /// <summary>
        /// Demonstration av SPAR personsök program-program version 20160213
        /// </summary>
        static void Main(string[] args)
        {
            // Skapa grundkonfiguration för Log4net som loggar till console.
            BasicConfigurator.Configure();

            Log.Info("Demonstration SPAR Personsök program-program version 20160213");

            IdentifieringsInformationTYPE identifierinsInformation = CreateIdentifieringsInformation(
                500243,
                500243,
                "Testsökning C#");

            SPARPersonsokningClient client = CreateSPARPersonsokningClient(
                "https://kt-ext-ws.statenspersonadressregister.se/spar-webservice/SPARPersonsokningService/20160213/",
                "kt-ext-ws.statenspersonadressregister.se",
                "Certifikat\\Kommun_A.p12",
                "8017644482212111",
                "Certifikat\\DigiCert.pem");

            Log.Info("Personnummersök 197910312391");
            LogPersonsokningSvar(client.SPARPersonsokning(CreatePersonIdFraga(identifierinsInformation, "197910312391")));

            Log.Info("Personnummersök ogiltigt personnummer");
            LogPersonsokningSvar(client.SPARPersonsokning(CreatePersonIdFraga(identifierinsInformation, "000000000000")));

            Log.Info("Fonetisk namnsok");
            LogPersonsokningSvar(client.SPARPersonsokning(CreateFonetisktNamnFraga(identifierinsInformation, "mikael efter*")));

            Log.Info("Fonetisk namnsok, utan förvändad träff");
            LogPersonsokningSvar(client.SPARPersonsokning(CreateFonetisktNamnFraga(identifierinsInformation, "dethärnamnetfinnsinteispar")));

            Log.Info("Fonetisk namnsok, förväntar för många svar");
            LogPersonsokningSvar(client.SPARPersonsokning(CreateFonetisktNamnFraga(identifierinsInformation, "an*")));

            Console.Write("Tryck Enter to för att avsluta...");
            Console.ReadLine();
        }

        /// <summary>
        /// Skapar en klient som används för att prata med webbtjänsten SPAR personsök program-program
        /// </summary>
        /// <param name="url">Address till tjänsten</param>
        /// <param name="domannamn">Domännamn till tjänsten</param>
        /// <param name="klientCerfikatPath">Sökvägen till Steriacertifikat</param>
        /// <param name="klientCertifikatLosenord">Lösenord till Steriacertifikat</param>
        /// <param name="sparCertifikatSignerarePath">Sökvägen till certifikat som används för att signera SPAR:s certfikikat</param>
        /// <returns></returns>
        public static SPARPersonsokningClient CreateSPARPersonsokningClient(string url, string domannamn, string klientCerfikatPath, string klientCertifikatLosenord, string sparCertifikatSignerarePath)
        {
            SPARPersonsokningClient client = new SPARPersonsokningClient();
            client.Endpoint.Address = new EndpointAddress(url);

            // Sökväg till certifikat, samt lösenord till klientcertifikatet
            client.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2(klientCerfikatPath, klientCertifikatLosenord);

            // Verifiera att det är rätt ufärdare av SPAR:s certifikat och det är rätt common name på TLS-termineringspunkten
            X509Certificate2 signerandeCertifikat = new X509Certificate2(sparCertifikatSignerarePath);
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication();
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication.CustomCertificateValidator = new SPARCertificateValidator(signerandeCertifikat, domannamn);

            return client;
        }

        /// <summary>
        /// Skapa identifieringsinformation för att användas i frågor mot SPAR personsök program-program
        /// </summary>
        /// <param name="kundNrLeveransMottagare">Kundnummer för leveransmottagare</param>
        /// <param name="kundNrSlutkund">Kundnummer för slutkund</param>
        /// <param name="slutAnvandarId">Fritext för att lättare identifiera frågor</param>
        /// <returns>Identifieringsinformation</returns>
        public static IdentifieringsInformationTYPE CreateIdentifieringsInformation(int kundNrLeveransMottagare, int kundNrSlutkund, string slutAnvandarId)
        {
            return new IdentifieringsInformationTYPE
            {
                KundNrLeveransMottagare = kundNrLeveransMottagare,
                KundNrSlutkund = kundNrSlutkund,
                OrgNrSlutkund = "0000000000",
                SlutAnvandarId = slutAnvandarId,
                Tidsstampel = DateTime.Now,
                UppdragsIdSpecified = false
            };
        }

        /// <summary>
        /// Skapa en fråga från ett personId som är antigen ett personnummer eller samordningsnummer
        /// </summary>
        /// <param name="identifieringsInformation">Identifierar frågeställaren</param>
        /// <param name="personId">Personnummer eller samordningsnummer</param>
        /// <returns></returns>
        public static SPARPersonsokningFraga CreatePersonIdFraga(IdentifieringsInformationTYPE identifieringsInformation, string personId)
        {
            List<object> items = new List<object>();
            items.Add(new PersonIdTYPE { FysiskPersonId = personId });

            List<ItemsChoiceType> itemsChoiceTypes = new List<ItemsChoiceType>();
            itemsChoiceTypes.Add(ItemsChoiceType.PersonId);

            return new SPARPersonsokningFraga
            {
                IdentifieringsInformation = identifieringsInformation,
                PersonsokningFraga = new PersonsokningFragaTYPE
                {
                    Items = items.ToArray(),
                    ItemsElementName = itemsChoiceTypes.ToArray()
                }
            };
        }

        /// <summary>
        /// Skapa en fråga från ett namn, namnet kommer i SPAR hanteras fonetiserat
        /// </summary>
        /// <param name="identifieringsInformation">Identifierar frågeställaren</param>
        /// <param name="namn">Namn, fritext</param>
        /// <returns></returns>
        public static SPARPersonsokningFraga CreateFonetisktNamnFraga(IdentifieringsInformationTYPE identifieringsInformation, string namn)
        {
            List<object> items = new List<object>();
            items.Add(FonetiskSokningTYPE.J);
            items.Add(namn);

            List<ItemsChoiceType> itemsChoiceTypes = new List<ItemsChoiceType>();
            itemsChoiceTypes.Add(ItemsChoiceType.FonetiskSokning);
            itemsChoiceTypes.Add(ItemsChoiceType.NamnSokArgument);

            return new SPARPersonsokningFraga
            {
                IdentifieringsInformation = identifieringsInformation,
                PersonsokningFraga = new PersonsokningFragaTYPE
                {
                    Items = items.ToArray(),
                    ItemsElementName = itemsChoiceTypes.ToArray()
                }
            };
        }

        private static void LogPersonsokningSvar(SPARPersonsokningSvar svar)
        {
            StringBuilder sb = new StringBuilder();

            int svarsposter = svar.PersonsokningSvarsPost == null ? 0 : svar.PersonsokningSvarsPost.Length;
            int undantag = svar.Undantag == null ? 0 : svar.Undantag.Length;
            sb.AppendLine("Personsökningssvar, " + svarsposter + " sökträffar, " + undantag + " undantag.");

            LogOverstiger(sb, svar.OverstigerMaxAntalSvarsposter);
            LogUndantag(sb, svar.Undantag);
            LogAviseringsPoster(sb, svar.PersonsokningSvarsPost);

            Log.Debug(sb);
        }

        private static void LogOverstiger(StringBuilder sb, OverstigerMaxAntalSvarsposterTYPE overstiger)
        {
            if (overstiger != null)
            {
                sb.AppendLine("  Överstiger max antal träffar, " + overstiger.AntalPoster + " av max " + overstiger.MaxAntalSvarsPoster + ".");
            }
        }

        private static void LogUndantag(StringBuilder sb, UndantagTYPE[] svarUndantag)
        {
            if (svarUndantag != null)
            {
                foreach (UndantagTYPE undantag in svarUndantag)
                {
                    sb.AppendLine("  Undantag");
                    sb.AppendLine("    Kod: " + undantag.Kod);
                    sb.AppendLine("    Beskrivning: " + undantag.Beskrivning);
                }
            }
        }

        private static void LogAviseringsPoster(StringBuilder sb, AviseringsPostTYPE[] svarsposter)
        {
            if (svarsposter != null)
            {
                foreach (AviseringsPostTYPE svarspost in svarsposter)
                {
                    sb.AppendLine("  Aviseringspost");
                    sb.AppendLine("    PersonId: " + svarspost.PersonId.FysiskPersonId);
                    sb.AppendLine("    Sekretess: " + svarspost.Sekretessmarkering);

                    if (svarspost.SenasteAndringSPARSpecified)
                        sb.AppendLine("    Senast ändrad i SPAR: " + svarspost.SekretessAndringsdatum);
                    if (svarspost.SekretessAndringsdatumSpecified)
                        sb.AppendLine("    Sekretess ändrad: " + svarspost.SekretessAndringsdatum);
                    if (!String.IsNullOrEmpty(svarspost.Beskattningsar))
                        sb.AppendLine("    Beskattningsår: " + svarspost.Beskattningsar);
                    if (!String.IsNullOrEmpty(svarspost.SummeradInkomst))
                        sb.AppendLine("    Summerad inkomst: " + svarspost.SummeradInkomst);

                    LogFastigheter(sb, svarspost);
                    LogPersondetaljer(sb, svarspost);
                    LogRelationer(sb, svarspost);
                    LogFolkbokforingsadresser(sb, svarspost);
                    LogSarskildapostadresser(sb, svarspost);
                    LogUtlandsadresser(sb, svarspost);
                }
            }
        }


        private static void LogFastigheter(StringBuilder sb, AviseringsPostTYPE svarspost)
        {
            if (svarspost.Fastighet != null)
            {
                foreach (var fastighet in svarspost.Fastighet)
                {
                    sb.AppendLine("    Fastighet");
                    sb.AppendLine("      Fastighetskod: " + fastighet.FastighetsKod);

                    if (!String.IsNullOrEmpty(fastighet.FastighetKommunKod))
                        sb.AppendLine("      Kommunkod: " + fastighet.FastighetKommunKod);
                    if (!String.IsNullOrEmpty(fastighet.FastighetLanKod))
                        sb.AppendLine("      Länkod: " + fastighet.FastighetLanKod);
                    if (!String.IsNullOrEmpty(fastighet.Taxeringsar))
                        sb.AppendLine("      Taxeringsår: " + fastighet.Taxeringsar);
                    if (!String.IsNullOrEmpty(fastighet.Taxeringsvarde))
                        sb.AppendLine("      Taxeringsvärde: " + fastighet.Taxeringsvarde);
                    if (!String.IsNullOrEmpty(fastighet.AndelstalTaljare))
                        sb.AppendLine("      Andelstal täljare: " + fastighet.AndelstalTaljare);
                    if (!String.IsNullOrEmpty(fastighet.AndelstalNamnare))
                        sb.AppendLine("      Antelstal nämnare: " + fastighet.AndelstalNamnare);
                }
            }
        }

        private static void LogPersondetaljer(StringBuilder sb, AviseringsPostTYPE svarspost)
        {
            if (svarspost.Persondetaljer != null)
            {
                foreach (var detalj in svarspost.Persondetaljer)
                {
                    sb.AppendLine("    Persondetalj");
                    sb.AppendLine("      Datum from: " + detalj.DatumFrom);
                    sb.AppendLine("      Datum till: " + detalj.DatumTill);

                    if (!String.IsNullOrEmpty(detalj.Avregistreringsdatum))
                        sb.AppendLine("      Avregistreringsdatum: " + detalj.Avregistreringsdatum);
                    if (detalj.AvregistreringsorsakKodSpecified)
                        sb.AppendLine("      Avregisteringskod: " + detalj.AvregistreringsorsakKod);
                    if (!String.IsNullOrEmpty(detalj.Fornamn))
                        sb.AppendLine("      Förnamn: " + detalj.Fornamn);
                    if (!String.IsNullOrEmpty(detalj.Mellannamn))
                        sb.AppendLine("      Mellannamn: " + detalj.Mellannamn);
                    if (!String.IsNullOrEmpty(detalj.Efternamn))
                        sb.AppendLine("      Efternamn: " + detalj.Efternamn);
                    if (detalj.TilltalsnamnSpecified)
                        sb.AppendLine("      Tilltalsnamn: " + detalj.Tilltalsnamn);
                    if (!String.IsNullOrEmpty(detalj.FodelselanKod))
                        sb.AppendLine("      Födelselänkod: " + detalj.FodelselanKod);
                    if (!String.IsNullOrEmpty(detalj.Fodelseforsamling))
                        sb.AppendLine("      Födelselänkod: " + detalj.Fodelseforsamling);
                    if (detalj.FodelsetidSpecified)
                        sb.AppendLine("      Födelsetid: " + detalj.Fodelsetid);
                    if (!String.IsNullOrEmpty(detalj.HanvisningsPersonNrByttFran))
                        sb.AppendLine("      Hänvisning personnummer bytt från: " + detalj.HanvisningsPersonNrByttFran);
                    if (!String.IsNullOrEmpty(detalj.HanvisningsPersonNrByttTill))
                        sb.AppendLine("      Hänvisning personnummer bytt till: " + detalj.HanvisningsPersonNrByttTill);
                    if (detalj.SekretessmarkeringSpecified)
                        sb.AppendLine("      Sekretessmarkering: " + detalj.Sekretessmarkering);
                    if (detalj.KonSpecified)
                        sb.AppendLine("      Kön: " + detalj.Kon);
                }
            }
        }

        private static void LogRelationer(StringBuilder sb, AviseringsPostTYPE svarspost)
        {
            if (svarspost.Relation != null)
            {
                foreach (var relation in svarspost.Relation)
                {
                    sb.AppendLine("    Relation");
                    sb.AppendLine("      Datum from: " + relation.DatumFrom);
                    sb.AppendLine("      Datum till: " + relation.DatumTill);
                    sb.AppendLine("      Relationstyp: " + relation.Relationstyp);

                    if (relation.PersonId != null)
                        sb.AppendLine("     PersonId: " + relation.PersonId);
                    if (relation.Fodelsetid != null)
                        sb.AppendLine("      Födelsetid: " + relation.Fodelsetid);
                    if (!String.IsNullOrEmpty(relation.Avregistreringsdatum))
                        sb.AppendLine("      Avregistreringsdatum: " + relation.Avregistreringsdatum);
                    sb.AppendLine("      Avregistreringsdatum: " + relation.AvregistreringsorsakKod);
                    if (!String.IsNullOrEmpty(relation.Fornamn))
                        sb.AppendLine("      Förnamn: " + relation.Fornamn);
                    if (!String.IsNullOrEmpty(relation.Mellannamn))
                        sb.AppendLine("      Mellannamn: " + relation.Mellannamn);
                    if (!String.IsNullOrEmpty(relation.Efternamn))
                        sb.AppendLine("      Efternamn: " + relation.Efternamn);
                }
            }
        }

        private static void LogFolkbokforingsadresser(StringBuilder sb, AviseringsPostTYPE svarspost)
        {
            if (svarspost.Adresser != null && svarspost.Adresser.Folkbokforingsadress != null)
            {
                foreach (var fba in svarspost.Adresser.Folkbokforingsadress)
                {
                    sb.AppendLine("    Folkbokföringsadress");
                    sb.AppendLine("      Datum from: " + fba.DatumFrom);
                    sb.AppendLine("      Datum till: " + fba.DatumTill);

                    if (!String.IsNullOrEmpty(fba.CareOf))
                        sb.AppendLine("      c/o: " + fba.CareOf);
                    if (!String.IsNullOrEmpty(fba.Utdelningsadress1))
                        sb.AppendLine("      Utdelningsadress 1: " + fba.Utdelningsadress1);
                    if (!String.IsNullOrEmpty(fba.Utdelningsadress2))
                        sb.AppendLine("      Utdelningsadress 2: " + fba.Utdelningsadress2);
                    if (!String.IsNullOrEmpty(fba.PostNr))
                        sb.AppendLine("      Postnummer: " + fba.PostNr);
                    if (!String.IsNullOrEmpty(fba.Postort))
                        sb.AppendLine("      Postort: " + fba.Postort);
                    if (fba.FolkbokforingsdatumSpecified)
                        sb.AppendLine("      Folkbokföringsdatum: " + fba.Folkbokforingsdatum);
                    if (!String.IsNullOrEmpty(fba.FolkbokfordForsamlingKod))
                        sb.AppendLine("      Församlingskod: " + fba.FolkbokfordForsamlingKod);
                    if (!String.IsNullOrEmpty(fba.DistriktKod))
                        sb.AppendLine("      Distriktkod: " + fba.DistriktKod);
                    if (!String.IsNullOrEmpty(fba.FolkbokfordKommunKod))
                        sb.AppendLine("      Kommunkod: " + fba.FolkbokfordKommunKod);
                    if (!String.IsNullOrEmpty(fba.FolkbokfordLanKod))
                        sb.AppendLine("      Länkod: " + fba.FolkbokfordLanKod);
                }
            }
        }

        private static void LogSarskildapostadresser(StringBuilder sb, AviseringsPostTYPE svarspost)
        {
            if (svarspost.Adresser != null && svarspost.Adresser.SarskildPostadress != null)
            {
                foreach (var spa in svarspost.Adresser.SarskildPostadress)
                {
                    sb.AppendLine("    Särskild postadress");
                    sb.AppendLine("      Datum from: " + spa.DatumFrom);
                    sb.AppendLine("      Datum till: " + spa.DatumTill);

                    if (!String.IsNullOrEmpty(spa.CareOf))
                        sb.AppendLine("      c/o: " + spa.CareOf);
                    if (!String.IsNullOrEmpty(spa.Utdelningsadress1))
                        sb.AppendLine("      Utdelningsadress 1: " + spa.Utdelningsadress1);
                    if (!String.IsNullOrEmpty(spa.Utdelningsadress2))
                        sb.AppendLine("      Utdelningsadress 2: " + spa.Utdelningsadress2);
                    if (!String.IsNullOrEmpty(spa.PostNr))
                        sb.AppendLine("      Postnummer: " + spa.PostNr);
                    if (!String.IsNullOrEmpty(spa.Postort))
                        sb.AppendLine("      Postort: " + spa.Postort);
                }
            }
        }

        private static void LogUtlandsadresser(StringBuilder sb, AviseringsPostTYPE svarspost)
        {
            if (svarspost.Adresser != null && svarspost.Adresser.Utlandsadress != null)
            {
                foreach (var spa in svarspost.Adresser.Utlandsadress)
                {
                    sb.AppendLine("    Utlandsadress");
                    sb.AppendLine("      Datum from: " + spa.DatumFrom);
                    sb.AppendLine("      Datum till: " + spa.DatumTill);

                    if (!String.IsNullOrEmpty(spa.CareOf))
                        sb.AppendLine("      c/o: " + spa.CareOf);
                    if (!String.IsNullOrEmpty(spa.Utdelningsadress1))
                        sb.AppendLine("      Utdelningsadress 1: " + spa.Utdelningsadress1);
                    if (!String.IsNullOrEmpty(spa.Utdelningsadress2))
                        sb.AppendLine("      Utdelningsadress 2: " + spa.Utdelningsadress2);
                    if (!String.IsNullOrEmpty(spa.Utdelningsadress3))
                        sb.AppendLine("      Utdelningsadress 3: " + spa.Utdelningsadress3);
                    if (!String.IsNullOrEmpty(spa.Land))
                        sb.AppendLine("      Land: " + spa.Land);
                }
            }
        }
    }
}
