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
            Datoteka.OdaberiRadniDirektorij();
            OsvjeziFormu();
            if (Datoteka.DohvatiRadniDirektorij().Length > 0)
            {
                if (Datoteka.ProvjeriPostojanostDatoteka())
                {
                    btnUcitajDatoteke.Enabled = true;
                    btnGenerirajKljuceve.Enabled = false;
                }
                else
                {
                    btnUcitajDatoteke.Enabled = false;
                    btnGenerirajKljuceve.Enabled = true;
                }
                btnOdaberiDirektorij.Enabled = false;
            }
        }

        private void btnGenerirajKljuceve_Click(object sender, EventArgs e)
        {
            Datoteka.KreirajDatoteke();
            OsvjeziLabele();
            this.Width = 680;
        }

        private void btnUcitajDatoteke_Click(object sender, EventArgs e)
        {
            Datoteka.UcitajDatoteke();
            OsvjeziLabele();
        }
    }
}
