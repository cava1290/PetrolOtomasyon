namespace PetrolOtomasyon
{
    partial class SubeCalisaniForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnReddet = new System.Windows.Forms.Button();
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.lblGunSonuToplam = new System.Windows.Forms.Label();
            this.btnGunSonuHesapla = new System.Windows.Forms.Button();
            this.btnGunSonuKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(546, 184);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnOnayla
            // 
            this.btnOnayla.Location = new System.Drawing.Point(63, 236);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(80, 23);
            this.btnOnayla.TabIndex = 1;
            this.btnOnayla.Text = "Satışı Onayla";
            this.btnOnayla.UseVisualStyleBackColor = true;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // btnReddet
            // 
            this.btnReddet.Location = new System.Drawing.Point(190, 236);
            this.btnReddet.Name = "btnReddet";
            this.btnReddet.Size = new System.Drawing.Size(80, 23);
            this.btnReddet.TabIndex = 2;
            this.btnReddet.Text = "Satışı Reddet";
            this.btnReddet.UseVisualStyleBackColor = true;
            this.btnReddet.Click += new System.EventHandler(this.btnReddet_Click);
            // 
            // dgvSatislar
            // 
            this.dgvSatislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSatislar.Location = new System.Drawing.Point(733, 12);
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.Size = new System.Drawing.Size(549, 184);
            this.dgvSatislar.TabIndex = 3;
            this.dgvSatislar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSatislar_CellContentClick);
            // 
            // lblGunSonuToplam
            // 
            this.lblGunSonuToplam.AutoSize = true;
            this.lblGunSonuToplam.Location = new System.Drawing.Point(946, 245);
            this.lblGunSonuToplam.Name = "lblGunSonuToplam";
            this.lblGunSonuToplam.Size = new System.Drawing.Size(35, 13);
            this.lblGunSonuToplam.TabIndex = 4;
            this.lblGunSonuToplam.Text = "label1";
            // 
            // btnGunSonuHesapla
            // 
            this.btnGunSonuHesapla.Location = new System.Drawing.Point(788, 281);
            this.btnGunSonuHesapla.Name = "btnGunSonuHesapla";
            this.btnGunSonuHesapla.Size = new System.Drawing.Size(107, 23);
            this.btnGunSonuHesapla.TabIndex = 5;
            this.btnGunSonuHesapla.Text = "Gün Sonu Hesalpa";
            this.btnGunSonuHesapla.UseVisualStyleBackColor = true;
            this.btnGunSonuHesapla.Click += new System.EventHandler(this.btnGunSonuHesapla_Click);
            // 
            // btnGunSonuKaydet
            // 
            this.btnGunSonuKaydet.Location = new System.Drawing.Point(933, 281);
            this.btnGunSonuKaydet.Name = "btnGunSonuKaydet";
            this.btnGunSonuKaydet.Size = new System.Drawing.Size(107, 23);
            this.btnGunSonuKaydet.TabIndex = 6;
            this.btnGunSonuKaydet.Text = "Gün Sonu Kaydet";
            this.btnGunSonuKaydet.UseVisualStyleBackColor = true;
            this.btnGunSonuKaydet.Click += new System.EventHandler(this.btnGunSonuKaydet_Click);
            // 
            // SubeCalisaniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 469);
            this.Controls.Add(this.btnGunSonuKaydet);
            this.Controls.Add(this.btnGunSonuHesapla);
            this.Controls.Add(this.lblGunSonuToplam);
            this.Controls.Add(this.dgvSatislar);
            this.Controls.Add(this.btnReddet);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SubeCalisaniForm";
            this.Text = "SubeCalisanForm";
            this.Load += new System.EventHandler(this.SubeCalisaniForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.Button btnReddet;
        private System.Windows.Forms.DataGridView dgvSatislar;
        private System.Windows.Forms.Label lblGunSonuToplam;
        private System.Windows.Forms.Button btnGunSonuHesapla;
        private System.Windows.Forms.Button btnGunSonuKaydet;
    }
}