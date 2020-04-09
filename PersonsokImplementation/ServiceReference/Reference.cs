using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Xml.Serialization;

//------------------------------------------------------------------------------
// Majoriteten av kod i denna fil har autogenererats med verktyg,
// men en del ändringar har gjorts i efterhand.
//
// Om ni väljer att generera egna proxyfiler och proxyklasser så är
// det rekommenderat att ni går igenom koden här nedan.
//
// Verktyg för autogenerering: WCF via svcutil.exe.
// Notera att WCF inte längre stöds i .NET Core.
//------------------------------------------------------------------------------
namespace ServiceReference
{
    [ServiceContractAttribute(Namespace="http://statenspersonadressregister.se/personsok/2019.1", ConfigurationName="PersonsokService")]
    public interface PersonsokService
    {
        [OperationContractAttribute(Action="http://skatteverket.se/spar/personsok/2019.1/PersonsokService/Personsok", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        PersonSokResponse PersonSok(PersonSokRequest request);
        
        [OperationContractAttribute(Action="http://skatteverket.se/spar/personsok/2019.1/PersonsokService/Personsok", ReplyAction="*")]
        Task<PersonSokResponse> PersonSokAsync(PersonSokRequest request);
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/identifieringsinformation-1.0")]
    public partial class IdentifieringsInformationTYPE
    {
        private int kundNrLeveransMottagareField;
        
        private int kundNrSlutkundField;
        
        private string orgNrSlutkundField;
        
        private long uppdragsIdField;
        
        private string slutAnvandarIdField;
        
        private SlutAnvandarUtokadBehorighetTYPE[] slutAnvandarUtokadBehorighetField;
        
        private DateTime tidsstampelField;
        
        [XmlElementAttribute(Order=0)]
        public int KundNrLeveransMottagare
        {
            get
            {
                return this.kundNrLeveransMottagareField;
            }
            set
            {
                this.kundNrLeveransMottagareField = value;
            }
        }
        
        [XmlElementAttribute(Order=1)]
        public int KundNrSlutkund
        {
            get
            {
                return this.kundNrSlutkundField;
            }
            set
            {
                this.kundNrSlutkundField = value;
            }
        }
        
        [XmlElementAttribute(Order=2)]
        public string OrgNrSlutkund
        {
            get
            {
                return this.orgNrSlutkundField;
            }
            set
            {
                this.orgNrSlutkundField = value;
            }
        }
        
        [XmlElementAttribute(Order=3)]
        public long UppdragsId
        {
            get
            {
                return this.uppdragsIdField;
            }
            set
            {
                this.uppdragsIdField = value;
            }
        }
        
        [XmlElementAttribute(Order=4)]
        public string SlutAnvandarId
        {
            get
            {
                return this.slutAnvandarIdField;
            }
            set
            {
                this.slutAnvandarIdField = value;
            }
        }
        
        [XmlElementAttribute("SlutAnvandarUtokadBehorighet", Order=5)]
        public SlutAnvandarUtokadBehorighetTYPE[] SlutAnvandarUtokadBehorighet
        {
            get
            {
                return this.slutAnvandarUtokadBehorighetField;
            }
            set
            {
                this.slutAnvandarUtokadBehorighetField = value;
            }
        }
        
        [XmlElementAttribute(Order=6)]
        public DateTime Tidsstampel
        {
            get
            {
                return this.tidsstampelField;
            }
            set
            {
                this.tidsstampelField = value;
            }
        }
    }
    
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/identifieringsinformation-1.0")]
    public enum SlutAnvandarUtokadBehorighetTYPE
    {
        Relationer,
        
        Medborgarskap,
        
        Taxering,
        
        Sekretess,
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsvar-1.0")]
    public partial class OverstigerMaxAntalSvarsposterTYPE
    {
        private int antalPosterField;
        
        private int maxAntalSvarsPosterField;
        
        [XmlElementAttribute(Order=0)]
        public int AntalPoster
        {
            get
            {
                return this.antalPosterField;
            }
            set
            {
                this.antalPosterField = value;
            }
        }
        
        [XmlElementAttribute(Order=1)]
        public int MaxAntalSvarsPoster
        {
            get
            {
                return this.maxAntalSvarsPosterField;
            }
            set
            {
                this.maxAntalSvarsPosterField = value;
            }
        }
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsvar-1.0")]
    public partial class UndantagTYPE
    {
        private string kodField;
        
        private string beskrivningField;
        
        [XmlElementAttribute(Order=0)]
        public string Kod
        {
            get
            {
                return this.kodField;
            }
            set
            {
                this.kodField = value;
            }
        }
        
        [XmlElementAttribute(Order=1)]
        public string Beskrivning
        {
            get
            {
                return this.beskrivningField;
            }
            set
            {
                this.beskrivningField = value;
            }
        }
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/fastighetstaxering-1.1")]
    public partial class FastighetDelTYPE
    {
        private string taxeringsidentitetField;
        
        private string fastighetBeteckningField;
        
        private string andelstalTaljareField;
        
        private string andelstalNamnareField;
        
        [XmlElementAttribute(Order=0)]
        public string Taxeringsidentitet
        {
            get
            {
                return this.taxeringsidentitetField;
            }
            set
            {
                this.taxeringsidentitetField = value;
            }
        }
        
        [XmlElementAttribute(Order=1)]
        public string FastighetBeteckning
        {
            get
            {
                return this.fastighetBeteckningField;
            }
            set
            {
                this.fastighetBeteckningField = value;
            }
        }
        
        [XmlElementAttribute(DataType="integer", Order=2)]
        public string AndelstalTaljare
        {
            get
            {
                return this.andelstalTaljareField;
            }
            set
            {
                this.andelstalTaljareField = value;
            }
        }
        
        [XmlElementAttribute(DataType="integer", Order=3)]
        public string AndelstalNamnare
        {
            get
            {
                return this.andelstalNamnareField;
            }
            set
            {
                this.andelstalNamnareField = value;
            }
        }
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/fastighetstaxering-1.1")]
    public partial class FastighetTYPE
    {
        private string taxeringsenhetsnummerField;
        
        private string lanKodField;
        
        private string kommunKodField;
        
        private string fastighetKodField;
        
        private string taxeringsarField;
        
        private string taxeringsvardeField;
        
        private FastighetDelTYPE[] fastighetDelField;
        
        [XmlElementAttribute(Order=0)]
        public string Taxeringsenhetsnummer
        {
            get
            {
                return this.taxeringsenhetsnummerField;
            }
            set
            {
                this.taxeringsenhetsnummerField = value;
            }
        }
        
        [XmlElementAttribute(Order=1)]
        public string LanKod
        {
            get
            {
                return this.lanKodField;
            }
            set
            {
                this.lanKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=2)]
        public string KommunKod
        {
            get
            {
                return this.kommunKodField;
            }
            set
            {
                this.kommunKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=3)]
        public string FastighetKod
        {
            get
            {
                return this.fastighetKodField;
            }
            set
            {
                this.fastighetKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=4)]
        public string Taxeringsar
        {
            get
            {
                return this.taxeringsarField;
            }
            set
            {
                this.taxeringsarField = value;
            }
        }
        
        [XmlElementAttribute(Order=5)]
        public string Taxeringsvarde
        {
            get
            {
                return this.taxeringsvardeField;
            }
            set
            {
                this.taxeringsvardeField = value;
            }
        }
        
        [XmlElementAttribute("FastighetDel", Order=6)]
        public FastighetDelTYPE[] FastighetDel
        {
            get
            {
                return this.fastighetDelField;
            }
            set
            {
                this.fastighetDelField = value;
            }
        }
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/relation-1.1")]
    public partial class RelationTYPE
    {
        private DateTime datumFromField;
        
        private DateTime datumTillField;
        
        private RelationstypTYPE relationstypField;
        
        private PersonIdTYPE1 personIdField;
        
        private string fornamnField;
        
        private string mellannamnField;
        
        private string efternamnField;
        
        private DateTime fodelsetidField;
        
        private bool fodelsetidFieldSpecified;
        
        private string avregistreringsorsakKodField;
        
        private string avlidendatumField;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=0)]
        public DateTime DatumFrom
        {
            get
            {
                return this.datumFromField;
            }
            set
            {
                this.datumFromField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=1)]
        public DateTime DatumTill
        {
            get
            {
                return this.datumTillField;
            }
            set
            {
                this.datumTillField = value;
            }
        }
        
        [XmlElementAttribute(Order=2)]
        public RelationstypTYPE Relationstyp
        {
            get
            {
                return this.relationstypField;
            }
            set
            {
                this.relationstypField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/person-1.1", Order=3)]
        public PersonIdTYPE1 PersonId
        {
            get
            {
                return this.personIdField;
            }
            set
            {
                this.personIdField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", Order=4)]
        public string Fornamn
        {
            get
            {
                return this.fornamnField;
            }
            set
            {
                this.fornamnField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", Order=5)]
        public string Mellannamn
        {
            get
            {
                return this.mellannamnField;
            }
            set
            {
                this.mellannamnField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", Order=6)]
        public string Efternamn
        {
            get
            {
                return this.efternamnField;
            }
            set
            {
                this.efternamnField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", DataType="date", Order=7)]
        public DateTime Fodelsetid
        {
            get
            {
                return this.fodelsetidField;
            }
            set
            {
                this.fodelsetidField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool FodelsetidSpecified
        {
            get
            {
                return this.fodelsetidFieldSpecified;
            }
            set
            {
                this.fodelsetidFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", Order=8)]
        public string AvregistreringsorsakKod
        {
            get
            {
                return this.avregistreringsorsakKodField;
            }
            set
            {
                this.avregistreringsorsakKodField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", Order=9)]
        public string Avlidendatum
        {
            get
            {
                return this.avlidendatumField;
            }
            set
            {
                this.avlidendatumField = value;
            }
        }
    }
    
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/relation-1.1")]
    public enum RelationstypTYPE
    {
        V,
        M,
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(TypeName="PersonIdTYPE", Namespace="http://statenspersonadressregister.se/schema/komponent/person/person-1.1")]
    public partial class PersonIdTYPE1
    {
        private string fysiskPersonIdField;
        
        [XmlElementAttribute(Order=0)]
        public string FysiskPersonId
        {
            get
            {
                return this.fysiskPersonIdField;
            }
            set
            {
                this.fysiskPersonIdField = value;
            }
        }
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/utlandsadress-1.0")]
    public partial class UtlandsadressTYPE
    {
        private DateTime datumFromField;
        
        private DateTime datumTillField;
        
        private string careOfField;
        
        private string utdelningsadress1Field;
        
        private string utdelningsadress2Field;
        
        private string utdelningsadress3Field;
        
        private string landField;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=0)]
        public DateTime DatumFrom
        {
            get
            {
                return this.datumFromField;
            }
            set
            {
                this.datumFromField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=1)]
        public DateTime DatumTill
        {
            get
            {
                return this.datumTillField;
            }
            set
            {
                this.datumTillField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=2)]
        public string CareOf
        {
            get
            {
                return this.careOfField;
            }
            set
            {
                this.careOfField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=3)]
        public string Utdelningsadress1
        {
            get
            {
                return this.utdelningsadress1Field;
            }
            set
            {
                this.utdelningsadress1Field = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=4)]
        public string Utdelningsadress2
        {
            get
            {
                return this.utdelningsadress2Field;
            }
            set
            {
                this.utdelningsadress2Field = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=5)]
        public string Utdelningsadress3
        {
            get
            {
                return this.utdelningsadress3Field;
            }
            set
            {
                this.utdelningsadress3Field = value;
            }
        }
        
        [XmlElementAttribute(Order=6)]
        public string Land
        {
            get
            {
                return this.landField;
            }
            set
            {
                this.landField = value;
            }
        }
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/sarskildpostadress-1.0")]
    public partial class SarskildPostadressTYPE
    {
        private DateTime datumFromField;
        
        private DateTime datumTillField;
        
        private string careOfField;
        
        private string utdelningsadress1Field;
        
        private string utdelningsadress2Field;
        
        private string postNrField;
        
        private string postortField;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=0)]
        public DateTime DatumFrom
        {
            get
            {
                return this.datumFromField;
            }
            set
            {
                this.datumFromField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=1)]
        public DateTime DatumTill
        {
            get
            {
                return this.datumTillField;
            }
            set
            {
                this.datumTillField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=2)]
        public string CareOf
        {
            get
            {
                return this.careOfField;
            }
            set
            {
                this.careOfField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=3)]
        public string Utdelningsadress1
        {
            get
            {
                return this.utdelningsadress1Field;
            }
            set
            {
                this.utdelningsadress1Field = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=4)]
        public string Utdelningsadress2
        {
            get
            {
                return this.utdelningsadress2Field;
            }
            set
            {
                this.utdelningsadress2Field = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=5)]
        public string PostNr
        {
            get
            {
                return this.postNrField;
            }
            set
            {
                this.postNrField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=6)]
        public string Postort
        {
            get
            {
                return this.postortField;
            }
            set
            {
                this.postortField = value;
            }
        }
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/folkbokforingsadress-1.0")]
    public partial class FolkbokforingsadressTYPE
    {
        private DateTime datumFromField;
        
        private DateTime datumTillField;
        
        private string careOfField;
        
        private string utdelningsadress1Field;
        
        private string utdelningsadress2Field;
        
        private string postNrField;
        
        private string postortField;
        
        private string folkbokfordLanKodField;
        
        private string folkbokfordKommunKodField;
        
        private string folkbokfordForsamlingKodField;
        
        private DateTime folkbokforingsdatumField;
        
        private bool folkbokforingsdatumFieldSpecified;
        
        private string distriktKodField;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=0)]
        public DateTime DatumFrom
        {
            get
            {
                return this.datumFromField;
            }
            set
            {
                this.datumFromField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=1)]
        public DateTime DatumTill
        {
            get
            {
                return this.datumTillField;
            }
            set
            {
                this.datumTillField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=2)]
        public string CareOf
        {
            get
            {
                return this.careOfField;
            }
            set
            {
                this.careOfField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=3)]
        public string Utdelningsadress1
        {
            get
            {
                return this.utdelningsadress1Field;
            }
            set
            {
                this.utdelningsadress1Field = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=4)]
        public string Utdelningsadress2
        {
            get
            {
                return this.utdelningsadress2Field;
            }
            set
            {
                this.utdelningsadress2Field = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=5)]
        public string PostNr
        {
            get
            {
                return this.postNrField;
            }
            set
            {
                this.postNrField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/deladeadresselement-1.0", Order=6)]
        public string Postort
        {
            get
            {
                return this.postortField;
            }
            set
            {
                this.postortField = value;
            }
        }
        
        [XmlElementAttribute(Order=7)]
        public string FolkbokfordLanKod
        {
            get
            {
                return this.folkbokfordLanKodField;
            }
            set
            {
                this.folkbokfordLanKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=8)]
        public string FolkbokfordKommunKod
        {
            get
            {
                return this.folkbokfordKommunKodField;
            }
            set
            {
                this.folkbokfordKommunKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=9)]
        public string FolkbokfordForsamlingKod
        {
            get
            {
                return this.folkbokfordForsamlingKodField;
            }
            set
            {
                this.folkbokfordForsamlingKodField = value;
            }
        }
        
        [XmlElementAttribute(DataType="date", Order=10)]
        public DateTime Folkbokforingsdatum
        {
            get
            {
                return this.folkbokforingsdatumField;
            }
            set
            {
                this.folkbokforingsdatumField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool FolkbokforingsdatumSpecified
        {
            get
            {
                return this.folkbokforingsdatumFieldSpecified;
            }
            set
            {
                this.folkbokforingsdatumFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Order=11)]
        public string DistriktKod
        {
            get
            {
                return this.distriktKodField;
            }
            set
            {
                this.distriktKodField = value;
            }
        }
    }
    
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1")]
    public partial class PersondetaljerTYPE
    {
        private DateTime datumFromField;
        
        private DateTime datumTillField;
        
        private string aviseringsnamnField;
        
        private string fornamnField;
        
        private int tilltalsnamnField;
        
        private bool tilltalsnamnFieldSpecified;
        
        private string mellannamnField;
        
        private string efternamnField;
        
        private SekretessmarkeringMedAttributTYPE sekretessmarkeringField;
        
        private SkyddadFolkbokforingTYPE skyddadFolkbokforingField;
        
        private bool skyddadFolkbokforingFieldSpecified;
        
        private string avregistreringsorsakKodField;
        
        private string avlidendatumField;
        
        private string antraffadDodDatumField;
        
        private string hanvisningsPersonNrByttFranField;
        
        private string hanvisningsPersonNrByttTillField;
        
        private DateTime fodelsetidField;
        
        private bool fodelsetidFieldSpecified;
        
        private string fodelselanKodField;
        
        private string fodelseforsamlingField;
        
        private KonTYPE1 konField;
        
        private bool konFieldSpecified;
        
        private SvenskMedborgareTYPE svenskMedborgareField;
        
        private bool svenskMedborgareFieldSpecified;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=0)]
        public DateTime DatumFrom
        {
            get
            {
                return this.datumFromField;
            }
            set
            {
                this.datumFromField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/datum-1.0", DataType="date", Order=1)]
        public DateTime DatumTill
        {
            get
            {
                return this.datumTillField;
            }
            set
            {
                this.datumTillField = value;
            }
        }
        
        [XmlElementAttribute(Order=2)]
        public string Aviseringsnamn
        {
            get
            {
                return this.aviseringsnamnField;
            }
            set
            {
                this.aviseringsnamnField = value;
            }
        }
        
        [XmlElementAttribute(Order=3)]
        public string Fornamn
        {
            get
            {
                return this.fornamnField;
            }
            set
            {
                this.fornamnField = value;
            }
        }
        
        [XmlElementAttribute(Order=4)]
        public int Tilltalsnamn
        {
            get
            {
                return this.tilltalsnamnField;
            }
            set
            {
                this.tilltalsnamnField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool TilltalsnamnSpecified
        {
            get
            {
                return this.tilltalsnamnFieldSpecified;
            }
            set
            {
                this.tilltalsnamnFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Order=5)]
        public string Mellannamn
        {
            get
            {
                return this.mellannamnField;
            }
            set
            {
                this.mellannamnField = value;
            }
        }
        
        [XmlElementAttribute(Order=6)]
        public string Efternamn
        {
            get
            {
                return this.efternamnField;
            }
            set
            {
                this.efternamnField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0", Order=7)]
        public SekretessmarkeringMedAttributTYPE Sekretessmarkering
        {
            get
            {
                return this.sekretessmarkeringField;
            }
            set
            {
                this.sekretessmarkeringField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0", Order=8)]
        public SkyddadFolkbokforingTYPE SkyddadFolkbokforing
        {
            get
            {
                return this.skyddadFolkbokforingField;
            }
            set
            {
                this.skyddadFolkbokforingField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool SkyddadFolkbokforingSpecified
        {
            get
            {
                return this.skyddadFolkbokforingFieldSpecified;
            }
            set
            {
                this.skyddadFolkbokforingFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Order=9)]
        public string AvregistreringsorsakKod
        {
            get
            {
                return this.avregistreringsorsakKodField;
            }
            set
            {
                this.avregistreringsorsakKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=10)]
        public string Avlidendatum
        {
            get
            {
                return this.avlidendatumField;
            }
            set
            {
                this.avlidendatumField = value;
            }
        }
        
        [XmlElementAttribute(Order=11)]
        public string AntraffadDodDatum
        {
            get
            {
                return this.antraffadDodDatumField;
            }
            set
            {
                this.antraffadDodDatumField = value;
            }
        }
        
        [XmlElementAttribute(Order=12)]
        public string HanvisningsPersonNrByttFran
        {
            get
            {
                return this.hanvisningsPersonNrByttFranField;
            }
            set
            {
                this.hanvisningsPersonNrByttFranField = value;
            }
        }
        
        [XmlElementAttribute(Order=13)]
        public string HanvisningsPersonNrByttTill
        {
            get
            {
                return this.hanvisningsPersonNrByttTillField;
            }
            set
            {
                this.hanvisningsPersonNrByttTillField = value;
            }
        }
        
        [XmlElementAttribute(DataType="date", Order=14)]
        public DateTime Fodelsetid
        {
            get
            {
                return this.fodelsetidField;
            }
            set
            {
                this.fodelsetidField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool FodelsetidSpecified
        {
            get
            {
                return this.fodelsetidFieldSpecified;
            }
            set
            {
                this.fodelsetidFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Order=15)]
        public string FodelselanKod
        {
            get
            {
                return this.fodelselanKodField;
            }
            set
            {
                this.fodelselanKodField = value;
            }
        }
        
        [XmlElementAttribute(Order=16)]
        public string Fodelseforsamling
        {
            get
            {
                return this.fodelseforsamlingField;
            }
            set
            {
                this.fodelseforsamlingField = value;
            }
        }
        
        [XmlElementAttribute(Order=17)]
        public KonTYPE1 Kon
        {
            get
            {
                return this.konField;
            }
            set
            {
                this.konField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool KonSpecified
        {
            get
            {
                return this.konFieldSpecified;
            }
            set
            {
                this.konFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Order=18)]
        public SvenskMedborgareTYPE SvenskMedborgare
        {
            get
            {
                return this.svenskMedborgareField;
            }
            set
            {
                this.svenskMedborgareField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool SvenskMedborgareSpecified
        {
            get
            {
                return this.svenskMedborgareFieldSpecified;
            }
            set
            {
                this.svenskMedborgareFieldSpecified = value;
            }
        }
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0")]
    public partial class SekretessmarkeringMedAttributTYPE
    {
        private SekretessSattAvSPARTYPE sattAvSPARField;
        
        private bool sattAvSPARFieldSpecified;
        
        private SekretessmarkeringTYPE valueField;
        
        [XmlAttributeAttribute()]
        public SekretessSattAvSPARTYPE sattAvSPAR
        {
            get
            {
                return this.sattAvSPARField;
            }
            set
            {
                this.sattAvSPARField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool sattAvSPARSpecified
        {
            get
            {
                return this.sattAvSPARFieldSpecified;
            }
            set
            {
                this.sattAvSPARFieldSpecified = value;
            }
        }
        
        [XmlTextAttribute()]
        public SekretessmarkeringTYPE Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0")]
    public enum SekretessSattAvSPARTYPE
    {
        J,
    }

    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0")]
    public enum SekretessmarkeringTYPE
    {
        J,
        N,
    }

    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0")]
    public enum SkyddadFolkbokforingTYPE
    {
        J,
        N,
    }
    
    [XmlTypeAttribute(TypeName="KonTYPE", Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1")]
    public enum KonTYPE1
    {
        M,
        K,
    }

    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1")]
    public enum SvenskMedborgareTYPE
    {
        J,
        N,
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/aviseringspost-1.1")]
    public partial class AviseringsPostTYPE
    {
        private PersonIdTYPE1 personIdField;
        
        private SekretessmarkeringMedAttributTYPE sekretessmarkeringField;
        
        private DateTime sekretessAndringsdatumField;
        
        private bool sekretessAndringsdatumFieldSpecified;
        
        private SkyddadFolkbokforingTYPE skyddadFolkbokforingField;
        
        private DateTime skyddadFolkbokforingAndringsdatumField;
        
        private bool skyddadFolkbokforingAndringsdatumFieldSpecified;
        
        private DateTime senasteAndringSPARField;
        
        private bool senasteAndringSPARFieldSpecified;
        
        private string summeradInkomstField;
        
        private string inkomstArField;
        
        private PersondetaljerTYPE[] persondetaljerField;
        
        private FolkbokforingsadressTYPE[] folkbokforingsadressField;
        
        private SarskildPostadressTYPE[] sarskildPostadressField;
        
        private UtlandsadressTYPE[] utlandsadressField;
        
        private RelationTYPE[] relationField;
        
        private FastighetTYPE[] fastighetField;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/person-1.1", Order=0)]
        public PersonIdTYPE1 PersonId
        {
            get
            {
                return this.personIdField;
            }
            set
            {
                this.personIdField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0", Order=1)]
        public SekretessmarkeringMedAttributTYPE Sekretessmarkering
        {
            get
            {
                return this.sekretessmarkeringField;
            }
            set
            {
                this.sekretessmarkeringField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0", DataType="date", Order=2)]
        public DateTime SekretessAndringsdatum
        {
            get
            {
                return this.sekretessAndringsdatumField;
            }
            set
            {
                this.sekretessAndringsdatumField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool SekretessAndringsdatumSpecified
        {
            get
            {
                return this.sekretessAndringsdatumFieldSpecified;
            }
            set
            {
                this.sekretessAndringsdatumFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0", Order=3)]
        public SkyddadFolkbokforingTYPE SkyddadFolkbokforing
        {
            get
            {
                return this.skyddadFolkbokforingField;
            }
            set
            {
                this.skyddadFolkbokforingField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/skyddadepersonuppgifter-1.0", DataType="date", Order=4)]
        public DateTime SkyddadFolkbokforingAndringsdatum
        {
            get
            {
                return this.skyddadFolkbokforingAndringsdatumField;
            }
            set
            {
                this.skyddadFolkbokforingAndringsdatumField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool SkyddadFolkbokforingAndringsdatumSpecified
        {
            get
            {
                return this.skyddadFolkbokforingAndringsdatumFieldSpecified;
            }
            set
            {
                this.skyddadFolkbokforingAndringsdatumFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/person-1.1", DataType="date", Order=5)]
        public DateTime SenasteAndringSPAR
        {
            get
            {
                return this.senasteAndringSPARField;
            }
            set
            {
                this.senasteAndringSPARField = value;
            }
        }
        
        [XmlIgnoreAttribute()]
        public bool SenasteAndringSPARSpecified
        {
            get
            {
                return this.senasteAndringSPARFieldSpecified;
            }
            set
            {
                this.senasteAndringSPARFieldSpecified = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/inkomsttaxering-1.1", Order=6)]
        public string SummeradInkomst
        {
            get
            {
                return this.summeradInkomstField;
            }
            set
            {
                this.summeradInkomstField = value;
            }
        }
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/inkomsttaxering-1.1", Order=7)]
        public string InkomstAr
        {
            get
            {
                return this.inkomstArField;
            }
            set
            {
                this.inkomstArField = value;
            }
        }
        
        [XmlElementAttribute("Persondetaljer", Namespace="http://statenspersonadressregister.se/schema/komponent/person/persondetaljer-1.1", Order=8)]
        public PersondetaljerTYPE[] Persondetaljer
        {
            get
            {
                return this.persondetaljerField;
            }
            set
            {
                this.persondetaljerField = value;
            }
        }
        
        [XmlElementAttribute("Folkbokforingsadress", Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/folkbokforingsadress-1.0", Order=9)]
        public FolkbokforingsadressTYPE[] Folkbokforingsadress
        {
            get
            {
                return this.folkbokforingsadressField;
            }
            set
            {
                this.folkbokforingsadressField = value;
            }
        }
        
        [XmlElementAttribute("SarskildPostadress", Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/sarskildpostadress-1.0", Order=10)]
        public SarskildPostadressTYPE[] SarskildPostadress
        {
            get
            {
                return this.sarskildPostadressField;
            }
            set
            {
                this.sarskildPostadressField = value;
            }
        }
        
        [XmlElementAttribute("Utlandsadress", Namespace="http://statenspersonadressregister.se/schema/komponent/person/adress/utlandsadress-1.0", Order=11)]
        public UtlandsadressTYPE[] Utlandsadress
        {
            get
            {
                return this.utlandsadressField;
            }
            set
            {
                this.utlandsadressField = value;
            }
        }
        
        [XmlElementAttribute("Relation", Namespace="http://statenspersonadressregister.se/schema/komponent/person/relation-1.1", Order=12)]
        public RelationTYPE[] Relation
        {
            get
            {
                return this.relationField;
            }
            set
            {
                this.relationField = value;
            }
        }
        
        [XmlElementAttribute("Fastighet", Namespace="http://statenspersonadressregister.se/schema/komponent/person/fastighetstaxering-1.1", Order=13)]
        public FastighetTYPE[] Fastighet
        {
            get
            {
                return this.fastighetField;
            }
            set
            {
                this.fastighetField = value;
            }
        }
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1")]
    public partial class PersonIdTYPE
    {
        private string fysiskPersonIdField;
        
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/person/person-1.1", Order=0)]
        public string FysiskPersonId
        {
            get
            {
                return this.fysiskPersonIdField;
            }
            set
            {
                this.fysiskPersonIdField = value;
            }
        }
    }

    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0")]
    public partial class PersonsokningFragaTYPE
    {
        private object[] itemsField;
        
        private ItemsChoiceType[] itemsElementNameField;
        
        [XmlElementAttribute("DistriktKod", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("DistriktKodFrom", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("DistriktKodTom", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("Fodelsetid", typeof(DateTime), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", DataType="date", Order=0)]
        [XmlElementAttribute("FodelsetidFran", typeof(DateTime), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", DataType="date", Order=0)]
        [XmlElementAttribute("FodelsetidTill", typeof(DateTime), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", DataType="date", Order=0)]
        [XmlElementAttribute("FonetiskSokning", typeof(FonetiskSokningTYPE), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("FornamnSokArgument", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("ForsamlingKod", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("KommunKod", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("Kon", typeof(KonTYPE), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("LanKod", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("MellanEfternamnSokArgument", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("NamnSokArgument", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("PersonId", typeof(PersonIdTYPE), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("PostNr", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("PostNrFran", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("PostNrTill", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("PostortSokArgument", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlElementAttribute("UtdelningsadressSokArgument", typeof(string), Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1", Order=0)]
        [XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
        
        [XmlElementAttribute("ItemsElementName", Order=1)]
        [XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1")]
    public enum FonetiskSokningTYPE
    {
        J,
        N,
    }
    
    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1")]
    public enum KonTYPE
    {
        M,
        K,
    }

    [XmlTypeAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0", IncludeInSchema=false)]
    public enum ItemsChoiceType
    {
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:DistriktKod")]
        DistriktKod,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:DistriktKodFrom")]
        DistriktKodFrom,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:DistriktKodTom")]
        DistriktKodTom,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:Fodelsetid")]
        Fodelsetid,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:FodelsetidFran")]
        FodelsetidFran,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:FodelsetidTill")]
        FodelsetidTill,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:FonetiskSokning")]
        FonetiskSokning,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:FornamnSokArgument")]
        FornamnSokArgument,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:ForsamlingKod")]
        ForsamlingKod,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:KommunKod")]
        KommunKod,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:Kon")]
        Kon,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:LanKod")]
        LanKod,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:MellanEfternamnSokArgument")]
        MellanEfternamnSokArgument,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:NamnSokArgument")]
        NamnSokArgument,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:PersonId")]
        PersonId,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:PostNr")]
        PostNr,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:PostNrFran")]
        PostNrFran,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:PostNrTill")]
        PostNrTill,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:PostortSokArgument")]
        PostortSokArgument,
        
        [XmlEnumAttribute("http://statenspersonadressregister.se/schema/komponent/sok/sokargument-1.1:UtdelningsadressSokArgument")]
        UtdelningsadressSokArgument,
    }

    [DebuggerStepThroughAttribute()]
    [MessageContractAttribute(WrapperName="SPARPersonsokningFraga", WrapperNamespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsfraga-1.0", IsWrapped=true)]
    public partial class PersonSokRequest
    {
        [MessageBodyMemberAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/identifieringsinformation-1.0", Order=0)]
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/identifieringsinformation-1.0")]
        public IdentifieringsInformationTYPE IdentifieringsInformation;
        
        [MessageBodyMemberAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0", Order=1)]
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0")]
        public PersonsokningFragaTYPE PersonsokningFraga;
        
        public PersonSokRequest()
        {
        }
        
        public PersonSokRequest(IdentifieringsInformationTYPE IdentifieringsInformation, PersonsokningFragaTYPE PersonsokningFraga)
        {
            this.IdentifieringsInformation = IdentifieringsInformation;
            this.PersonsokningFraga = PersonsokningFraga;
        }
    }

    [DebuggerStepThroughAttribute()]
    [MessageContractAttribute(WrapperName="SPARPersonsokningSvar", WrapperNamespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsvar-1.0", IsWrapped=true)]
    public partial class PersonSokResponse
    {
        [MessageBodyMemberAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0", Order=0)]
        [XmlElementAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsokparametrar-1.0")]
        public PersonsokningFragaTYPE PersonsokningFraga;
        
        [MessageBodyMemberAttribute(Namespace="http://statenspersonadressregister.se/schema/komponent/sok/personsokningsvar-1.0", Order=1)]
        [XmlElementAttribute("OverstigerMaxAntalSvarsposter", typeof(OverstigerMaxAntalSvarsposterTYPE))]
        [XmlElementAttribute("PersonsokningSvarsPost", typeof(AviseringsPostTYPE))]
        [XmlElementAttribute("Undantag", typeof(UndantagTYPE))]
        public object[] Items;
        
        public PersonSokResponse()
        {
        }
        
        public PersonSokResponse(PersonsokningFragaTYPE PersonsokningFraga, object[] Items)
        {
            this.PersonsokningFraga = PersonsokningFraga;
            this.Items = Items;
        }
    }

    public interface PersonsokServiceChannel : PersonsokService, IClientChannel
    {
    }

    [DebuggerStepThroughAttribute()]
    public partial class PersonsokServiceClient : ClientBase<PersonsokService>, PersonsokService
    {
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(ServiceEndpoint serviceEndpoint, ClientCredentials clientCredentials);
        
        public PersonsokServiceClient() : 
                base(PersonsokServiceClient.GetDefaultBinding(), PersonsokServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.PersonsokServiceSOAP.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PersonsokServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(PersonsokServiceClient.GetBindingForEndpoint(endpointConfiguration), PersonsokServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PersonsokServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PersonsokServiceClient.GetBindingForEndpoint(endpointConfiguration), new EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PersonsokServiceClient(EndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress) : 
                base(PersonsokServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PersonsokServiceClient(Binding binding, EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        PersonSokResponse PersonsokService.PersonSok(PersonSokRequest request)
        {
            return base.Channel.PersonSok(request);
        }
        
        public PersonSokResponse PersonSok(PersonSokRequest request)
        {
            return base.Channel.PersonSok(request);
        }
        
        public Task<PersonSokResponse> PersonSokAsync(PersonSokRequest request)
        {
            return base.Channel.PersonSokAsync(request);
        }
        
        public virtual Task OpenAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new Action<IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new Action<IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }
        
        private static Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.PersonsokServiceSOAP))
            {
                BasicHttpBinding result = new BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.PersonsokServiceSOAP))
            {
                return new EndpointAddress("http://localhost/personsok");
            }
            throw new InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static Binding GetDefaultBinding()
        {
            return PersonsokServiceClient.GetBindingForEndpoint(EndpointConfiguration.PersonsokServiceSOAP);
        }
        
        private static EndpointAddress GetDefaultEndpointAddress()
        {
            return PersonsokServiceClient.GetEndpointAddress(EndpointConfiguration.PersonsokServiceSOAP);
        }
        
        public enum EndpointConfiguration
        {
            PersonsokServiceSOAP,
        }
    }
}