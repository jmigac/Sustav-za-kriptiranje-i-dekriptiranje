using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeKriptiranjem
{
    public class AES
    {
        private static Aes aesOperator;
        private static string tajniKljuc;


        public static string KreirajTajniKljuc()
        {
            aesOperator = Aes.Create();
            aesOperator.BlockSize = 128;
            aesOperator.KeySize = 256;
            aesOperator.Mode = CipherMode.CBC;
            aesOperator.Padding = PaddingMode.PKCS7;
            aesOperator.GenerateKey();
            aesOperator.GenerateIV();
            tajniKljuc = Convert.ToBase64String(aesOperator.Key);
            return tajniKljuc;
        }
        public static string DohvatiTajniKljuc()
        {
            return tajniKljuc;
        }
        public static void PostaviTajniKljuc(string kljuc)
        {
            if (kljuc.Length > 0)
            {
                tajniKljuc = kljuc;
            }
        }

        public static byte[] KriptirajSadrzaj(string tekst)
        {
            byte[] kriptiraniSadrzaj;
            ICryptoTransform objKriptiranja = aesOperator.CreateEncryptor(aesOperator.Key, aesOperator.IV);
            using(MemoryStream memorijskoStrujanje = new MemoryStream())
            {
                using(CryptoStream strujanjeKriptiranja = new CryptoStream(memorijskoStrujanje, objKriptiranja, CryptoStreamMode.Write))
                {
                    using(StreamWriter pisacStrujanja = new StreamWriter(strujanjeKriptiranja))
                    {
                        pisacStrujanja.Write(tekst);
                    }
                    kriptiraniSadrzaj = memorijskoStrujanje.ToArray();
                }
            }
            return kriptiraniSadrzaj;
        }
    }
}
