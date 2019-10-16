using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
            }
        }
    }
}
