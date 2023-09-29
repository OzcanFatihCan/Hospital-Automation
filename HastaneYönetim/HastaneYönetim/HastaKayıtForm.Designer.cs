namespace HastaneYönetim
{
    partial class HastaKayıtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HastaKayıtForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnKayitOl = new System.Windows.Forms.Button();
            this.TxtHastaAd = new System.Windows.Forms.TextBox();
            this.MskHastaTc = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtHastaSoyad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtHastaSifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MskHastaTel = new System.Windows.Forms.MaskedTextBox();
            this.CmbCinsiyet = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Belong Sans ExtraBold", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(101, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 47);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hasta Kayıt ";
            // 
            // BtnKayitOl
            // 
            this.BtnKayitOl.BackColor = System.Drawing.Color.Purple;
            this.BtnKayitOl.ForeColor = System.Drawing.Color.White;
            this.BtnKayitOl.Location = new System.Drawing.Point(253, 295);
            this.BtnKayitOl.Name = "BtnKayitOl";
            this.BtnKayitOl.Size = new System.Drawing.Size(130, 40);
            this.BtnKayitOl.TabIndex = 12;
            this.BtnKayitOl.Text = "Kayıt Ol";
            this.BtnKayitOl.UseVisualStyleBackColor = false;
            this.BtnKayitOl.Click += new System.EventHandler(this.BtnKayitOl_Click);
            // 
            // TxtHastaAd
            // 
            this.TxtHastaAd.Location = new System.Drawing.Point(193, 60);
            this.TxtHastaAd.Name = "TxtHastaAd";
            this.TxtHastaAd.Size = new System.Drawing.Size(188, 31);
            this.TxtHastaAd.TabIndex = 1;
            // 
            // MskHastaTc
            // 
            this.MskHastaTc.Location = new System.Drawing.Point(193, 136);
            this.MskHastaTc.Mask = "00000000000";
            this.MskHastaTc.Name = "MskHastaTc";
            this.MskHastaTc.Size = new System.Drawing.Size(188, 31);
            this.MskHastaTc.TabIndex = 3;
            this.MskHastaTc.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(89, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hasta Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(60, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "TC Kimlik No:";
            // 
            // TxtHastaSoyad
            // 
            this.TxtHastaSoyad.Location = new System.Drawing.Point(193, 97);
            this.TxtHastaSoyad.Name = "TxtHastaSoyad";
            this.TxtHastaSoyad.Size = new System.Drawing.Size(188, 31);
            this.TxtHastaSoyad.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(58, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hasta Soyadı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(23, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Telefon Numarası:";
            // 
            // TxtHastaSifre
            // 
            this.TxtHastaSifre.Location = new System.Drawing.Point(195, 213);
            this.TxtHastaSifre.Name = "TxtHastaSifre";
            this.TxtHastaSifre.Size = new System.Drawing.Size(188, 31);
            this.TxtHastaSifre.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(131, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Şifre:";
            // 
            // MskHastaTel
            // 
            this.MskHastaTel.Location = new System.Drawing.Point(195, 176);
            this.MskHastaTel.Mask = "(999) 000-0000";
            this.MskHastaTel.Name = "MskHastaTel";
            this.MskHastaTel.Size = new System.Drawing.Size(188, 31);
            this.MskHastaTel.TabIndex = 4;
            // 
            // CmbCinsiyet
            // 
            this.CmbCinsiyet.FormattingEnabled = true;
            this.CmbCinsiyet.Items.AddRange(new object[] {
            "Kadın",
            "Erkek"});
            this.CmbCinsiyet.Location = new System.Drawing.Point(195, 252);
            this.CmbCinsiyet.Name = "CmbCinsiyet";
            this.CmbCinsiyet.Size = new System.Drawing.Size(188, 31);
            this.CmbCinsiyet.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(103, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Cinsiyet:";
            // 
            // HastaKayıtForm
            // 
            this.AcceptButton = this.BtnKayitOl;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbCinsiyet);
            this.Controls.Add(this.MskHastaTel);
            this.Controls.Add(this.TxtHastaSifre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtHastaSoyad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnKayitOl);
            this.Controls.Add(this.TxtHastaAd);
            this.Controls.Add(this.MskHastaTc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "HastaKayıtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasta Kayıt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnKayitOl;
        private System.Windows.Forms.TextBox TxtHastaAd;
        private System.Windows.Forms.MaskedTextBox MskHastaTc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtHastaSoyad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtHastaSifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox MskHastaTel;
        private System.Windows.Forms.ComboBox CmbCinsiyet;
        private System.Windows.Forms.Label label7;
    }
}