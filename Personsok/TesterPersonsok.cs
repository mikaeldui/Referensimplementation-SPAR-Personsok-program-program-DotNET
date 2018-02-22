using NUnit.Framework;
using System.IO;
using ReferensimplementationPersonsok;
using ReferensimplementationPersonsok.SparServiceReference;

namespace Test
{
    [TestFixture]
    public class TesterPersonsok
    {
        private SPARPersonsokningClient Client;
        private IdentifieringsInformationTYPE IdentifierinsInformation;

        [SetUp]
        public void SetUp()
        {
            Client = DemonstrationPersonsok.CreateSPARPersonsokningClient(
                "https://kt-ext-ws.statenspersonadressregister.se/spar-webservice/SPARPersonsokningService/20160213/",
                "kt-ext-ws.statenspersonadressregister.se",
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Certifikat\\Kommun_A.p12"),
                "8017644482212111",
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Certifikat\\Verisign.pem"));

            IdentifierinsInformation = DemonstrationPersonsok.CreateIdentifieringsInformation(
                500243,
                500243,
                "Testsökning C#");
        }

        [Test]
        public void SokningGiltigtPersonId()
        {
            SPARPersonsokningSvar svar = Client.SPARPersonsokning(DemonstrationPersonsok.CreatePersonIdFraga(IdentifierinsInformation, "197910312391"));
            Assert.Null(svar.OverstigerMaxAntalSvarsposter);
            Assert.Null(svar.Undantag);
            Assert.AreEqual(1, svar.PersonsokningSvarsPost.Length);
            Assert.AreEqual("Jerry Felipe", svar.PersonsokningSvarsPost[0].Persondetaljer[0].Fornamn);
            Assert.AreEqual("Efternamn3663", svar.PersonsokningSvarsPost[0].Persondetaljer[0].Efternamn);
        }

        [Test]
        public void SokningFelaktigtPersonId()
        {
            SPARPersonsokningSvar svar = Client.SPARPersonsokning(DemonstrationPersonsok.CreatePersonIdFraga(IdentifierinsInformation, "000000000000"));
            Assert.Null(svar.OverstigerMaxAntalSvarsposter);
            Assert.AreEqual(2, svar.Undantag.Length);
            Assert.Null(svar.PersonsokningSvarsPost);
        }

        [Test]
        public void SokningFonetisk()
        {
            SPARPersonsokningSvar svar = Client.SPARPersonsokning(DemonstrationPersonsok.CreateFonetisktNamnFraga(IdentifierinsInformation, "mikael"));
            Assert.Null(svar.OverstigerMaxAntalSvarsposter);
            Assert.Null(svar.Undantag);
            Assert.Positive(svar.PersonsokningSvarsPost.Length);
        }

        [Test]
        public void SokningFonetiskNollTraffar()
        {
            SPARPersonsokningSvar svar = Client.SPARPersonsokning(DemonstrationPersonsok.CreateFonetisktNamnFraga(IdentifierinsInformation, "dethärnamnetfinnsinteispar"));
            Assert.Null(svar.OverstigerMaxAntalSvarsposter);
            Assert.Null(svar.Undantag);
            Assert.Null(svar.PersonsokningSvarsPost);
        }

        [Test]
        public void SokningFonetiskForMangaTraffar()
        {
            SPARPersonsokningSvar svar = Client.SPARPersonsokning(DemonstrationPersonsok.CreateFonetisktNamnFraga(IdentifierinsInformation, "an*"));
            Assert.Null(svar.Undantag);
            Assert.Null(svar.PersonsokningSvarsPost);
            Assert.NotNull(svar.OverstigerMaxAntalSvarsposter);
            Assert.Greater(svar.OverstigerMaxAntalSvarsposter.AntalPoster, 100);
        }
    }
}
