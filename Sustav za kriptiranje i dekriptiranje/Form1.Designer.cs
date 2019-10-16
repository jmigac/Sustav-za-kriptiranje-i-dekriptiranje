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
            this.btnUcitajDatoteke = new System.Windows.Forms.Button();
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
            // btnUcitajDatoteke
            // 
            this.btnUcitajDatoteke.Enabled = false;
            this.btnUcitajDatoteke.Location = new System.Drawing.Point(16, 136);
            this.btnUcitajDatoteke.Name = "btnUcitajDatoteke";
            this.btnUcitajDatoteke.Size = new System.Drawing.Size(234, 30);
            this.btnUcitajDatoteke.TabIndex = 4;
            this.btnUcitajDatoteke.Text = "Učitaj datoteke";
            this.btnUcitajDatoteke.UseVisualStyleBackColor = true;
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 176);
            this.Controls.Add(this.btnUcitajDatoteke);
            this.Controls.Add(this.btnGenerirajKljuceve);
            this.Controls.Add(this.btnOdaberiDirektorij);
            this.Controls.Add(this.txtDirektorijRada);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmStart";
            this.Text = "Kripto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirektorijRada;
        private System.Windows.Forms.Button btnOdaberiDirektorij;
        private System.Windows.Forms.Button btnGenerirajKljuceve;
        private System.Windows.Forms.Button btnUcitajDatoteke;
    }
}

