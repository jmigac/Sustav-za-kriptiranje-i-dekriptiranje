using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeDatotekama;

namespace Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeKriptiranjem
{
    public class RSA
    {
        private static string privatniKljuc { get; set; }
        private static string javniKljuc { get; set; }
        private static RSACryptoServiceProvider rsaOperator;
        private static RSAParameters rsaParametri;

        public static string[] GenerirajKljuceve()
        {
            string[] generiraniKljucevi = new string[2];
            rsaOperator = new RSACryptoServiceProvider(2048);
            rsaParametri = rsaOperator.ExportParameters(true);
            privatniKljuc = Convert.ToBase64String(rsaParametri.D);
            javniKljuc = Convert.ToBase64String(rsaParametri.Modulus);
            generiraniKljucevi[0] = privatniKljuc;
            generiraniKljucevi[1] = javniKljuc;
            return generiraniKljucevi;
        }
        public static string DohvatiPrivatniKljuc()
        {
            return privatniKljuc;
        }
        public static string DohvatiJavniKljuc()
        {
            return javniKljuc;
        }
        public static void PostaviPrivatniKljuc(string kljuc)
        {
            if (kljuc.Length > 0)
            {
                privatniKljuc = kljuc;
            }
        }
        public static void PostaviJavniKljuc(string kljuc)
        {
            if (kljuc.Length > 0)
            {
                javniKljuc = kljuc;
            }
        }

        public static string Kriptiraj(byte[] sadrzajKriptiranja)
        {
            byte[] kriptiraniSadrzaj = rsaOperator.Encrypt(sadrzajKriptiranja, false);
            return Convert.ToBase64String(kriptiraniSadrzaj);
        }
        public static string Dekriptiraj(byte[] tekst)
        {
            byte[] dekriptiranTekst = rsaOperator.Decrypt(tekst, false);
            return Encoding.UTF8.GetString(dekriptiranTekst);
        }
    }
}
