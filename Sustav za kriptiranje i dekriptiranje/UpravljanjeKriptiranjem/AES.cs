using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
    }
}
