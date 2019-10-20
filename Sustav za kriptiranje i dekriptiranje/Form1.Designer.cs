namespace Sustav_za_kriptiranje_i_dekriptiranje
{
    partial class FrmStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirektorijRada = new System.Windows.Forms.TextBox();
            this.btnOdaberiDirektorij = new System.Windows.Forms.Button();
            this.btnGenerirajKljuceve = new System.Windows.Forms.Button();
            this.lblTajniKljuc = new System.Windows.Forms.Label();
            this.lblPrivatniKljuc = new System.Windows.Forms.Label();
            this.lblJavniKljuc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUlazniPodatak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOdabirUlazneDatoteke = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAesKriptiranje = new System.Windows.Forms.Button();
            this.btnAesDekriptiranje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odabir radnog direktorija:";
            // 
            // txtDirektorijRada
            // 
            this.txtDirektorijRada.Enabled = false;
            this.txtDirektorijRada.Location = new System.Drawing.Point(16, 34);
            this.txtDirektorijRada.Name = "txtDirektorijRada";
            this.txtDirektorijRada.Size = new System.Drawing.Size(234, 22);
            this.txtDirektorijRada.TabIndex = 1;
            // 
            // btnOdaberiDirektorij
            // 
            this.btnOdaberiDirektorij.Location = new System.Drawing.Point(16, 63);
            this.btnOdaberiDirektorij.Name = "btnOdaberiDirektorij";
            this.btnOdaberiDirektorij.Size = new System.Drawing.Size(235, 31);
            this.btnOdaberiDirektorij.TabIndex = 2;
            this.btnOdaberiDirektorij.Text = "Odaberi direktorij";
            this.btnOdaberiDirektorij.UseVisualStyleBackColor = true;
            this.btnOdaberiDirektorij.Click += new System.EventHandler(this.btnOdaberiDirektorij_Click);
            // 
            // btnGenerirajKljuceve
            // 
            this.btnGenerirajKljuceve.Enabled = false;
            this.btnGenerirajKljuceve.Location = new System.Drawing.Point(16, 100);
            this.btnGenerirajKljuceve.Name = "btnGenerirajKljuceve";
            this.btnGenerirajKljuceve.Size = new System.Drawing.Size(235, 30);
            this.btnGenerirajKljuceve.TabIndex = 3;
            this.btnGenerirajKljuceve.Text = "Generiraj ključeve";
            this.btnGenerirajKljuceve.UseVisualStyleBackColor = true;
            this.btnGenerirajKljuceve.Click += new System.EventHandler(this.btnGenerirajKljuceve_Click);
            // 
            // lblTajniKljuc
            // 
            this.lblTajniKljuc.AutoSize = true;
            this.lblTajniKljuc.Location = new System.Drawing.Point(270, 38);
            this.lblTajniKljuc.Name = "lblTajniKljuc";
            this.lblTajniKljuc.Size = new System.Drawing.Size(75, 17);
            this.lblTajniKljuc.TabIndex = 5;
            this.lblTajniKljuc.Text = "Tajni ključ:";
            // 
            // lblPrivatniKljuc
            // 
            this.lblPrivatniKljuc.AutoSize = true;
            this.lblPrivatniKljuc.Location = new System.Drawing.Point(270, 63);
            this.lblPrivatniKljuc.Name = "lblPrivatniKljuc";
            this.lblPrivatniKljuc.Size = new System.Drawing.Size(91, 17);
            this.lblPrivatniKljuc.TabIndex = 5;
            this.lblPrivatniKljuc.Text = "Privatni ključ:";
            // 
            // lblJavniKljuc
            // 
            this.lblJavniKljuc.AutoSize = true;
            this.lblJavniKljuc.Location = new System.Drawing.Point(270, 89);
            this.lblJavniKljuc.Name = "lblJavniKljuc";
            this.lblJavniKljuc.Size = new System.Drawing.Size(77, 17);
            this.lblJavniKljuc.TabIndex = 5;
            this.lblJavniKljuc.Text = "Javni ključ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ulazni podaci:";
            // 
            // txtUlazniPodatak
            // 
            this.txtUlazniPodatak.Location = new System.Drawing.Point(273, 134);
            this.txtUlazniPodatak.Multiline = true;
            this.txtUlazniPodatak.Name = "txtUlazniPodatak";
            this.txtUlazniPodatak.Size = new System.Drawing.Size(499, 88);
            this.txtUlazniPodatak.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Odabir ulazne datoteke:";
            // 
            // btnOdabirUlazneDatoteke
            // 
            this.btnOdabirUlazneDatoteke.Location = new System.Drawing.Point(436, 230);
            this.btnOdabirUlazneDatoteke.Name = "btnOdabirUlazneDatoteke";
            this.btnOdabirUlazneDatoteke.Size = new System.Drawing.Size(181, 26);
            this.btnOdabirUlazneDatoteke.TabIndex = 9;
            this.btnOdabirUlazneDatoteke.Text = "Odaberi ulaznu datoteku";
            this.btnOdabirUlazneDatoteke.UseVisualStyleBackColor = true;
            this.btnOdabirUlazneDatoteke.Click += new System.EventHandler(this.btnOdabirUlazneDatoteke_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Simetrično kriptiranje / dekriptiranje";
            // 
            // btnAesKriptiranje
            // 
            this.btnAesKriptiranje.Location = new System.Drawing.Point(273, 286);
            this.btnAesKriptiranje.Name = "btnAesKriptiranje";
            this.btnAesKriptiranje.Size = new System.Drawing.Size(75, 33);
            this.btnAesKriptiranje.TabIndex = 11;
            this.btnAesKriptiranje.Text = "Kriptiraj";
            this.btnAesKriptiranje.UseVisualStyleBackColor = true;
            this.btnAesKriptiranje.Click += new System.EventHandler(this.btnAesKriptiranje_Click);
            // 
            // btnAesDekriptiranje
            // 
            this.btnAesDekriptiranje.Location = new System.Drawing.Point(355, 286);
            this.btnAesDekriptiranje.Name = "btnAesDekriptiranje";
            this.btnAesDekriptiranje.Size = new System.Drawing.Size(88, 33);
            this.btnAesDekriptiranje.TabIndex = 11;
            this.btnAesDekriptiranje.Text = "Dekriptiraj";
            this.btnAesDekriptiranje.UseVisualStyleBackColor = true;
            this.btnAesDekriptiranje.Click += new System.EventHandler(this.btnAesDekriptiranje_Click);
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 331);
            this.Controls.Add(this.btnAesDekriptiranje);
            this.Controls.Add(this.btnAesKriptiranje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOdabirUlazneDatoteke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUlazniPodatak);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJavniKljuc);
            this.Controls.Add(this.lblPrivatniKljuc);
            this.Controls.Add(this.lblTajniKljuc);
            this.Controls.Add(this.btnGenerirajKljuceve);
            this.Controls.Add(this.btnOdaberiDirektorij);
            this.Controls.Add(this.txtDirektorijRada);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmStart";
            this.Text = "Kripto";
            this.Load += new System.EventHandler(this.FrmStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirektorijRada;
        private System.Windows.Forms.Button btnOdaberiDirektorij;
        private System.Windows.Forms.Button btnGenerirajKljuceve;
        private System.Windows.Forms.Label lblTajniKljuc;
        private System.Windows.Forms.Label lblPrivatniKljuc;
        private System.Windows.Forms.Label lblJavniKljuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUlazniPodatak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOdabirUlazneDatoteke;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAesKriptiranje;
        private System.Windows.Forms.Button btnAesDekriptiranje;
    }
}

