using System.IdentityModel.Selectors;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PersonsokImplementation
{
    /// <summary>
    /// Validerar att korrekt certifikat använts för att signera SPAR:s certifikat 
    /// och att SPAR:s certifikat innehåller rätt domännamn
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
            chain.ChainPolicy.ExtraStore.Add(SignerandeCertifikat);
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

            bool certifikatGiltigt = chain.Build(certifikat);
            if (!certifikatGiltigt)
            {
                throw new CryptographicException("Certifikat ej giltigt");
            }

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
                throw new CryptographicException("Var ej signerat av korrekt CA");
            }

            bool korrektDomannamn = false;
            if (chain.ChainElements.Count > 0)
            {
                var extensions = chain.ChainElements[0].Certificate.Extensions;
                for (var i = 0; i < extensions.Count && !korrektDomannamn; i++)
                {
                    if (extensions[i].Oid.Value == "2.5.29.17")
                    {
                        AsnEncodedData asndata = new AsnEncodedData(extensions[i].Oid, extensions[i].RawData);
                        string subjectAlternativeNames = asndata.Format(false);
                        if (subjectAlternativeNames.Contains(Domannamn))
                        {
                            korrektDomannamn = true;
                        }
                    }
                }
            }

            if (!korrektDomannamn)
            {
                throw new CryptographicException("Subject Alternative Name innehåller ej " + Domannamn);
            }
        }
    }
}