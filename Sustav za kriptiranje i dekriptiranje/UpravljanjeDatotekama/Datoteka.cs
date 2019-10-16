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
                File.Create(putanjaTajniKljuc).Close();
                File.Create(putanjaPrivatniKljuc).Close();
                File.Create(putanjaJavniKljuc).Close();
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
        private static void ZapisiUDatoteku(string putanja, string sadrzaj)
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
    }
}
