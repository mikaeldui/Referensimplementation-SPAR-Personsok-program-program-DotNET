using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ReferensimplementationPersonsok
{
    /// <summary>
    /// Validerar att korrekt certifikat använts för att signera SPAR:s certifikat och att SPAR:s certifikat innehåller rätt domännamn
    /// </summary>
    public class SPARCertificateValidator : X509CertificateValidator
    {
        private X509Certificate2 SignerandeCertifikat;
        private string Domannamn;

        public SPARCertificateValidator(X509Certificate2 signerandeCertifikat, string domannamn)
        {
            SignerandeCertifikat = signerandeCertifikat;
            Domannamn = domannamn;
        }

        public override void Validate(X509Certificate2 certifikat)
        {
            X509Chain chain = new X509Chain(false);
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

            bool certifikatGiltigt = chain.Build(certifikat);
            if (!certifikatGiltigt)
            {
                throw new SecurityTokenValidationException("Certifikat ej giltigt");
            }

            // Gå igenom certifikatkejdan och verifiera att rätt certifikat använts för att signera SPAR
            bool korrectSignerare = false;
            for (var i = 1; i < chain.ChainElements.Count && !korrectSignerare; i++)
            {
                if (chain.ChainElements[i].Certificate.Thumbprint == SignerandeCertifikat.Thumbprint)
                {
                    korrectSignerare = true;
                }
            }

            if (!korrectSignerare)
            {
                throw new SecurityTokenValidationException("Var ej signerat av korrekt CA");
            }

            // Gå igenom certifikatet och se till att Subject Alternative Name i certifikatet innehåller rätt domännamn
            bool korrektDomannamn = false;
            if (chain.ChainElements.Count > 0)
            {
                var extensions = chain.ChainElements[0].Certificate.Extensions;
                for (var i = 0; i < extensions.Count && !korrektDomannamn; i++)
                {
                    // Extension 2.5.29.17 är Subject Alternative Name, dom alternativa/ytterligare domännamnen som ett certifikat är giltigt för
                    if (extensions[i].Oid.Value == "2.5.29.17")
                    {
                        AsnEncodedData asndata = new AsnEncodedData(extensions[i].Oid, extensions[i].RawData);
                        string subjectAlternativeNames = asndata.Format(false);
                        if (subjectAlternativeNames.Contains("=" + Domannamn + ","))
                        {
                            korrektDomannamn = true;
                        }
                    }
                }
            }

            if (!korrektDomannamn)
            {
                throw new SecurityTokenValidationException("Subject Alternative Name innehåller ej " + Domannamn);
            }
        }
    }
}
