using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeDatotekama;
using Sustav_za_kriptiranje_i_dekriptiranje.UpravljanjeKriptiranjem;

namespace Sustav_za_kriptiranje_i_dekriptiranje

{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
            this.Height = 283;
            this.Width = 221;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        private void PostaviTekst(string tekst)
        {
            txtUlazniPodatak.Text = tekst;
        }
        private void OsvjeziLabele()
        {
            lblTajniKljuc.Text = "Tajni ključ: " + AES.DohvatiTajniKljuc();
            lblPrivatniKljuc.Text = "Privatni ključ: " + RSA.DohvatiPrivatniKljuc().Substring(0,50)+"...";
            lblJavniKljuc.Text = "Javni ključ: " + RSA.DohvatiJavniKljuc().Substring(0,50)+"...";
        }
        private void OsvjeziFormu()
        {
            txtDirektorijRada.Text = Datoteka.DohvatiRadniDirektorij();
        }
        private void btnOdaberiDirektorij_Click(object sender, EventArgs e)
        {
            try
            {
                Datoteka.OdaberiRadniDirektorij();
                OsvjeziFormu();
                if (Datoteka.ProvjeriPostojanostDatoteka())
                {
                    Datoteka.IzbrisiDatoteke();
                }
                this.btnGenerirajKljuceve.Enabled = true;
                this.btnOdaberiDirektorij.Enabled = false;
                
            }
            catch (Exception poruka)
            {

                MessageBox.Show(poruka.Message);
            }
        }

        private void btnGenerirajKljuceve_Click(object sender, EventArgs e)
        {
            Datoteka.KreirajDatoteke();
            OsvjeziLabele();
            this.Width = 798;
            this.Height = 450;
            this.btnIzracunajSazetak.Enabled = true;
            this.btnDigitalnoPotpisivanje.Enabled = true;
            this.btnGenerirajKljuceve.Enabled = false;
        }

        private void btnOdabirUlazneDatoteke_Click(object sender, EventArgs e)
        {
            string putanjaDatoteke = "";
            try
            {
                putanjaDatoteke = Datoteka.UcitajSadrzajKriptiranja();
                if(putanjaDatoteke.Length>0 && putanjaDatoteke != "")
                {
                    txtUlazniPodatak.Text = Datoteka.UcitajSadrzajDatoteke(putanjaDatoteke);
                    //txtUlazniPodatak.Enabled = false;
                }
            }
            catch (Exception poruka)
            {

                MessageBox.Show(poruka.Message);
            }
        }

        private void btnAesKriptiranje_Click(object sender, EventArgs e)
        {
            string putanjaDatoteke = Datoteka.KreirajAesKripitraniSadrzajDatoteku();
            byte[] kriptiranSadrzaj = AES.KriptirajSadrzaj(txtUlazniPodatak.Text);
            string sadrzaj = Convert.ToBase64String(kriptiranSadrzaj);
            Datoteka.ZapisiUDatoteku(putanjaDatoteke, sadrzaj);
            PostaviTekst(sadrzaj);
        }

        private void btnAesDekriptiranje_Click(object sender, EventArgs e)
        {
            string putanjaDatoteke = Datoteka.KreirajAesDekriptiraniSadrzajDatoteku();
            string putanjaKriptiranaDatoteka = Datoteka.DohvatiRadniDirektorij() + @"/kriptirani_sadrzaj.txt";
            string kriptiraniSadrzaj = Datoteka.UcitajSadrzajDatoteke(putanjaKriptiranaDatoteka);
            string dekriptiraniSadrzaj = AES.DekriptirajSadrzaj(kriptiraniSadrzaj);
            Datoteka.ZapisiUDatoteku(putanjaDatoteke, dekriptiraniSadrzaj);
            PostaviTekst(dekriptiraniSadrzaj);
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {

        }

        private void btnAsimetricnoKriptiranje_Click(object sender, EventArgs e)
        {
            string putanjaDatoteke = Datoteka.KreirajRsaDatotekuZaKriptiranje();
            byte[] sadrzajKriptiranja = Encoding.UTF8.GetBytes(txtUlazniPodatak.Text);
            string kriptiraniSadrzaj = RSA.Kriptiraj(sadrzajKriptiranja);
            Datoteka.ZapisiUDatoteku(putanjaDatoteke, kriptiraniSadrzaj);
            PostaviTekst(kriptiraniSadrzaj);
        }

        private void btnAsimetricnoDekriptiranje_Click(object sender, EventArgs e)
        {
            string putanjaDatoteke = Datoteka.KreirajRsaDatotekuZaDekriptiranje();
            string radniDirektorij = Datoteka.DohvatiRadniDirektorij();
            string putanja = radniDirektorij + @"/RSAkriptirani_sadrzaj.txt";
            string kriptiranSadrzaj = Datoteka.UcitajSadrzajDatoteke(putanja);
            byte[] tekst = Convert.FromBase64String(kriptiranSadrzaj);
            string dekriptiraniSadrzaj = RSA.Dekriptiraj(tekst);
            Datoteka.ZapisiUDatoteku(putanjaDatoteke, dekriptiraniSadrzaj);
            PostaviTekst(dekriptiraniSadrzaj);
        }

        private void btnIzracunajSazetak_Click(object sender, EventArgs e)
        {
            string putanjaDatoteke = "";
            byte[] sadrzajDatoteke;
            try
            {
                putanjaDatoteke = Datoteka.UcitajDatotekuDigitalnogPotpisivanje();
            }
            catch (Exception poruka)
            {

                MessageBox.Show(poruka.Message);
            }
            try
            {
                sadrzajDatoteke = Datoteka.UcitajOdredenuDatoteku(putanjaDatoteke);
                byte[] sazetakDatoteke = RSA.IzracunajSazetakDatoteke(sadrzajDatoteke);
                string putanjaSazetka = Datoteka.KreirajDatotekuSazetka();
                string izracunatSazetak = Convert.ToBase64String(sazetakDatoteke);
                Datoteka.ZapisiUDatoteku(putanjaSazetka, izracunatSazetak);
                txtUlazniPodatak.Text = izracunatSazetak;
            }
            catch (Exception poruka)
            {

                MessageBox.Show(poruka.Message);
            }

        }

        private void btnDigitalnoPotpisivanje_Click(object sender, EventArgs e)
        {
            string putanjaDatotekeDigitalnogPotpisa = Datoteka.KreirajDatotekuDigitalnogPotpisa();
            string datotekaPotpisivanja = "";
            OpenFileDialog ucitanaDatoteka = new OpenFileDialog();
            if(ucitanaDatoteka.ShowDialog() == DialogResult.OK)
            {
                datotekaPotpisivanja = ucitanaDatoteka.FileName;
            }
            byte[] sadrzajUcitaneDatoteke = Datoteka.UcitajOdredenuDatoteku(datotekaPotpisivanja);
            byte[] sadrzajDigitalnogPotpisa = RSA.DigitalnoPotpisi(sadrzajUcitaneDatoteke);
            string strSadrzajDigitalnogPotpisa = Convert.ToBase64String(sadrzajDigitalnogPotpisa);
            Datoteka.ZapisiUDatoteku(putanjaDatotekeDigitalnogPotpisa, strSadrzajDigitalnogPotpisa);
            txtUlazniPodatak.Text = strSadrzajDigitalnogPotpisa;
        }
    }
}
