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
                btnGenerirajKljuceve.Enabled = true;
                btnUcitajDatoteke.Enabled = true;
                btnOdaberiDirektorij.Enabled = false;
            }
        }

        private void btnGenerirajKljuceve_Click(object sender, EventArgs e)
        {
            Datoteka.KreirajDatoteke();
        }
    }
}
