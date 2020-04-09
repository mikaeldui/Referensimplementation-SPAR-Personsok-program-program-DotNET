using System;
using System.Xml;
using System.Xml.Schema;

namespace PersonsokImplementation
{
    /// <summary>
    /// En validatorklass för att validera personnummer, samt för att validera om ett requestmeddelande
    /// följer reglerna angivet i XML-schemat för SPAR Personsök 
    /// </summary>
    public static class PersonsokValidator 
    {
        private static PersonsokLogger Logger = PersonsokLogger.CreatePersonsokLogger();

        /// <summary>
        /// Kontrollerar ifall det angivna personnumret är giltigt.
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsPersonIdValid(string personId)
        {
            if(personId.Length != 12)
                throw new ArgumentException("PersonId måste vara 12 siffror");
            if(!long.TryParse(personId, out long result))
                throw new ArgumentException("PersonId får endast bestå utav siffror");
            
            int year = int.Parse(personId.Substring(0, 4));
            int month = int.Parse(personId.Substring(4, 2));
            int day = int.Parse(personId.Substring(6, 2));

            if(year < 1800 || year > 3000)
                throw new ArgumentOutOfRangeException("PersonId måste bestå utav ett korrekt årtal");
            if(month < 1 || month > 12)
                throw new ArgumentOutOfRangeException("PersonId måste bestå utav ett korrekt månadstal");
            if(month < 1 || month > 31 )
                throw new ArgumentOutOfRangeException("PersonId måste bestå utav ett korrekt dagstal");

            return IsPersonIdChecksumValid(personId.Substring(2));
        }

        /// <summary>
        /// Kontrollerar ifall det angivna personnumret har giltiga kontrollsiffror.
        /// </summary>
        /// <returns>bool</returns>
        private static bool IsPersonIdChecksumValid(string personId)
        {
            int lastDigit = int.Parse(personId.Substring(personId.Length - 1, 1));
            int tal = 0;
            int vikt = 0;
            int sum = 0;

            for (int i = personId.Length - 2; i >= 0; i--) 
            {
                vikt = vikt == 2 ? 1 : 2;
                tal = int.Parse(personId[i].ToString()) * vikt;
                sum += (tal / 10) + (tal % 10);
            }

            sum = 10 - (sum % 10);
            sum = sum == 10 ? 0 : sum;

            return lastDigit == sum;
        }

        /// <summary>
        /// Validerar requestmeddelandet mot xml-schemat.
        /// </summary>
        /// <returns>bool</returns>
        public static bool ValidateXml(XmlReader message)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add("http://statenspersonadressregister.se/schema/komponent/sok/personsokningsfraga-1.0", "http://xmls.statenspersonadressregister.se/se/spar/deladeKomponenter/sok/PersonsokningFraga-1.0.xsd");
                settings.Schemas.Add("http://statenspersonadressregister.se/schema/komponent/sok/identifieringsinformation-1.0", "http://xmls.statenspersonadressregister.se/se/spar/deladeKomponenter/sok/IdentifieringsInformation-1.0.xsd");
                settings.Schemas.Add("http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0", "http://xmls.statenspersonadressregister.se/se/spar/deladeKomponenter/sok/PersonsokningSokparametrar-1.0.xsd");
                settings.Schemas.Add("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", "http://xmls.statenspersonadressregister.se/se/spar/deladeKomponenter/sok/Sokargument-1.1.xsd");
                settings.Schemas.Add("http://statenspersonadressregister.se/schema/komponent/datum-1.0", "http://xmls.statenspersonadressregister.se/se/spar/deladeKomponenter/generellt/Datum-1.0.xsd");
                settings.Schemas.Add("http://statenspersonadressregister.se/schema/komponent/person/person-1.1", "http://xmls.statenspersonadressregister.se/se/spar/deladeKomponenter/person/Person-1.1.xsd");

                XmlReader reader = XmlReader.Create(message, settings).ReadSubtree();
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
                document.Validate(eventHandler);
            }
            catch(XmlSchemaValidationException ex) 
            {
                Logger.LogError("Fel vid valideringen av request: " + ex.Message);
                return false;
            }
            catch(XmlSchemaException ex)
            {
                Logger.LogError("Fel vid validaeringen av request: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError("Oförväntad fel vid valideringen av request: " + ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loggar felmeddelanden vid uppkomst av valideringsfel med requestmeddelandet.
        /// </summary>
        /// <returns></returns>
        public static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Logger.LogError(e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Logger.LogWarning(e.Message);
                    break;
            }
        }
    }
}