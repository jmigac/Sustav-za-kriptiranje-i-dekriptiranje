using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeKriptiranjem;

namespace Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeDatotekama
{
    public class Datoteka
    {
        private static string radniDirektorij { get; set; }
        private static string putanjaTajniKljuc { get; set; }
        private static string putanjaPrivatniKljuc { get; set; }
        private static string putanjaJavniKljuc { get; set; }
        public static void OdaberiRadniDirektorij()
        {
            FolderBrowserDialog odabirDirektorij = new FolderBrowserDialog();
            if(odabirDirektorij.ShowDialog() == DialogResult.OK)
            {
                radniDirektorij = odabirDirektorij.SelectedPath;
                putanjaTajniKljuc = radniDirektorij + @"/tajni_kljuc.txt";
                putanjaPrivatniKljuc = radniDirektorij + @"/privatni_kljuc.txt";
                putanjaJavniKljuc = radniDirektorij + @"/javni_kljuc.txt";
            }
            else if (odabirDirektorij.SelectedPath.Length <=0 || radniDirektorij.Length <= 0)
            {
                throw new Exception("Niste odabali radni direktorij!");
            }
        }
        public static string DohvatiRadniDirektorij()
        {
            return radniDirektorij;
        }
        public static bool ProvjeriPostojanostDatoteka()
        {
            bool tajniKljuc = File.Exists(putanjaTajniKljuc);
            bool privatniKljuc = File.Exists(putanjaPrivatniKljuc);
            bool javniKljuc = File.Exists(putanjaJavniKljuc);
            if(tajniKljuc && privatniKljuc && javniKljuc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void KreirajDatoteke()
        {
            if (!ProvjeriPostojanostDatoteka())
            {
                if (!File.Exists(putanjaTajniKljuc))
                {
                    File.Create(putanjaTajniKljuc).Close();
                }
                if (!File.Exists(putanjaPrivatniKljuc))
                {
                    File.Create(putanjaPrivatniKljuc).Close();
                }
                if (!File.Exists(putanjaJavniKljuc))
                {
                    File.Create(putanjaJavniKljuc).Close();
                }
                string tajniKljuc, privatniKljuc, javniKljuc;
                string[] generiraniKljucevi = new string[2];
                generiraniKljucevi = RSA.GenerirajKljuceve();
                tajniKljuc = AES.KreirajTajniKljuc();
                privatniKljuc = generiraniKljucevi[0];
                javniKljuc = generiraniKljucevi[1];
                ZapisiUDatoteku(putanjaTajniKljuc, tajniKljuc);
                ZapisiUDatoteku(putanjaPrivatniKljuc, privatniKljuc);
                ZapisiUDatoteku(putanjaJavniKljuc, javniKljuc);
            }
        }
        public static void ZapisiUDatoteku(string putanja, string sadrzaj)
        {
            File.WriteAllText(putanja, sadrzaj);
        }
        public static string UcitajSadrzajDatoteke(string putanja)
        {
            if (File.Exists(putanja))
            {
                return File.ReadAllText(putanja);
            }
            else
            {
                throw new Exception("Datoteka ne postoji! Na lokaciji: "+putanja);
            }
        }
        public static void UcitajDatoteke()
        {
            string tajniKljuc, privatniKljuc, javniKljuc;
            try
            {
                tajniKljuc = UcitajSadrzajDatoteke(putanjaTajniKljuc);
                privatniKljuc = UcitajSadrzajDatoteke(putanjaPrivatniKljuc);
                javniKljuc = UcitajSadrzajDatoteke(putanjaJavniKljuc);
                PostaviKljuceve(tajniKljuc, privatniKljuc, javniKljuc);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private static void PostaviKljuceve(string tajniKljuc, string privatniKljuc,string javniKljuc)
        {
            AES.PostaviTajniKljuc(tajniKljuc);
            RSA.PostaviPrivatniKljuc(privatniKljuc);
            RSA.PostaviJavniKljuc(javniKljuc);
        }
        public static string UcitajSadrzajKriptiranja()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                string putanjaDatoteke = fileDialog.FileName;
                return putanjaDatoteke;
            }
            throw new Exception("Neispravna datoteka!");
        }
        public static string KreirajAesKripitraniSadrzajDatoteku()
        {
            string putanjaDatoteke = radniDirektorij + @"/kriptirani_sadrzaj.txt";
            if (!File.Exists(putanjaDatoteke))
            {
                File.Create(putanjaDatoteke).Close();
            }
            return putanjaDatoteke;
        }
        public static string KreirajAesDekriptiraniSadrzajDatoteku()
        {
            string putanjaDatoteke = radniDirektorij + @"/dekriptirani_sadrzaj.txt";
            if (!File.Exists(putanjaDatoteke))
            {
                File.Create(putanjaDatoteke).Close();
            }
            return putanjaDatoteke;
        }
        public static void IzbrisiDatoteke()
        {
            string tajniKljuc = radniDirektorij + @"/tajni_kljuc.txt";
            string privatniKljuc = radniDirektorij + @"/privatni_kljuc.txt";
            string javniKljuc = radniDirektorij + @"/javni_kljuc.txt";
            string kriptiraniSadrzajAes = radniDirektorij + @"/kriptirani_sadrzaj.txt";
            string dekriptiraniSadrzajAes = radniDirektorij + @"/dekriptirani_sadrzaj.txt";
            string kriptiraniSadrzajRsa = radniDirektorij + @"/RSAkriptirani_sadrzaj.txt";
            string dekriptiraniSadrzajRsa = radniDirektorij + @"/RSAdekriptirani_sadrzaj.txt";
            if (File.Exists(tajniKljuc))
            {
                File.Delete(tajniKljuc);
            }
            if (File.Exists(privatniKljuc))
            {
                File.Delete(privatniKljuc);
            }
            if (File.Exists(javniKljuc))
            {
                File.Delete(javniKljuc);
            }
            if (File.Exists(kriptiraniSadrzajAes))
            {
                File.Delete(kriptiraniSadrzajAes);
            }
            if (File.Exists(dekriptiraniSadrzajAes))
            {
                File.Delete(dekriptiraniSadrzajAes);
            }
            if (File.Exists(kriptiraniSadrzajRsa))
            {
                File.Delete(kriptiraniSadrzajRsa);
            }
            if (File.Exists(dekriptiraniSadrzajRsa))
            {
                File.Delete(dekriptiraniSadrzajRsa);
            }
        }
        public static string KreirajRsaDatotekuZaKriptiranje()
        {
            string putanjaDatoteke = radniDirektorij + @"/RSAkriptirani_sadrzaj.txt";
            if (!File.Exists(putanjaDatoteke))
            {
                File.Create(putanjaDatoteke).Close();
            }
            return putanjaDatoteke;
        }
        public static string KreirajRsaDatotekuZaDekriptiranje()
        {
            string putanjaDatoteke = radniDirektorij + @"\RSAdekriptirani_sadrzaj.txt";
            if (!File.Exists(putanjaDatoteke))
            {
                File.Create(putanjaDatoteke).Close();
            }
            return putanjaDatoteke;
        }
        public static byte[] UcitajOdredenuDatoteku(string putanja)
        {
            byte[] sadrzajDatoteke;
            if (File.Exists(putanja))
            {
                sadrzajDatoteke = Encoding.UTF8.GetBytes(File.ReadAllText(putanja));
            }
            else
            {
                throw new Exception("Dokument ne postoji!");
            }
            return sadrzajDatoteke;
        }
        public static string UcitajOdredenuDatotekuKaoString(string putanja)
        {
            string sadrzajDatoteke = "";
            if (File.Exists(putanja))
            {
                sadrzajDatoteke = File.ReadAllText(putanja);
            }
            else
            {
                throw new Exception("Datoteka ne postoji!");
            }
            return sadrzajDatoteke;
        }

        public static string UcitajDatotekuDigitalnogPotpisivanje()
        {
            string radniDirektorij = DohvatiRadniDirektorij();
            OpenFileDialog datoteka = new OpenFileDialog();
            if(datoteka.ShowDialog() == DialogResult.OK)
            {
                if (datoteka.FileName.Length <= 0)
                {
                    throw new Exception("Niste odabrali datoteku za digitalni potpis!");
                }
                else
                {
                    return datoteka.FileName;
                }
            }
            else
            {
                throw new Exception("Niste odbrali datoteku za digitalni potpis!");
            }
        }
        public static string KreirajDatotekuSazetka()
        {
            string putanjaDatoteke = "";
            string radniDirektorij = DohvatiRadniDirektorij();
            putanjaDatoteke = radniDirektorij + @"/sazetak.txt";
            if (File.Exists(putanjaDatoteke))
            {
                File.Delete(putanjaDatoteke);
                File.Create(putanjaDatoteke);
            }
            else
            {
                File.Create(putanjaDatoteke);
            }
            return putanjaDatoteke;
        }
    }
}
