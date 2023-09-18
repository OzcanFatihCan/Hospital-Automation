namespace HastaneYönetim
{
    partial class DoktorBilgiDüzenleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoktorBilgiDüzenleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDoktorSifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDoktorSoyad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnBilgiGuncelle = new System.Windows.Forms.Button();
            this.TxtDoktorAd = new System.Windows.Forms.TextBox();
            this.MskDoktorTc = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbDoktorBrans = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Belong Sans ExtraBold", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 47);
            this.label1.TabIndex = 50;
            this.label1.Text = "Hasta Bilgi Güncelle";
            // 
            // TxtDoktorSifre
            // 
            this.TxtDoktorSifre.Location = new System.Drawing.Point(195, 221);
            this.TxtDoktorSifre.Name = "TxtDoktorSifre";
            this.TxtDoktorSifre.PasswordChar = '*';
            this.TxtDoktorSifre.Size = new System.Drawing.Size(188, 31);
            this.TxtDoktorSifre.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(131, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 45;
            this.label6.Text = "Şifre:";
            // 
            // TxtDoktorSoyad
            // 
            this.TxtDoktorSoyad.Location = new System.Drawing.Point(195, 145);
            this.TxtDoktorSoyad.Name = "TxtDoktorSoyad";
            this.TxtDoktorSoyad.Size = new System.Drawing.Size(188, 31);
            this.TxtDoktorSoyad.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(49, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 42;
            this.label4.Text = "Doktor Soyadı:";
            // 
            // BtnBilgiGuncelle
            // 
            this.BtnBilgiGuncelle.BackColor = System.Drawing.Color.Purple;
            this.BtnBilgiGuncelle.ForeColor = System.Drawing.Color.White;
            this.BtnBilgiGuncelle.Location = new System.Drawing.Point(253, 261);
            this.BtnBilgiGuncelle.Name = "BtnBilgiGuncelle";
            this.BtnBilgiGuncelle.Size = new System.Drawing.Size(130, 40);
            this.BtnBilgiGuncelle.TabIndex = 41;
            this.BtnBilgiGuncelle.Text = "Güncelle";
            this.BtnBilgiGuncelle.UseVisualStyleBackColor = false;
            // 
            // TxtDoktorAd
            // 
            this.TxtDoktorAd.Location = new System.Drawing.Point(195, 108);
            this.TxtDoktorAd.Name = "TxtDoktorAd";
            this.TxtDoktorAd.Size = new System.Drawing.Size(188, 31);
            this.TxtDoktorAd.TabIndex = 40;
            // 
            // MskDoktorTc
            // 
            this.MskDoktorTc.Location = new System.Drawing.Point(195, 71);
            this.MskDoktorTc.Mask = "00000000000";
            this.MskDoktorTc.Name = "MskDoktorTc";
            this.MskDoktorTc.Size = new System.Drawing.Size(188, 31);
            this.MskDoktorTc.TabIndex = 39;
            this.MskDoktorTc.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(80, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Doktor Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(62, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "TC Kimlik No:";
            // 
            // CmbDoktorBrans
            // 
            this.CmbDoktorBrans.FormattingEnabled = true;
            this.CmbDoktorBrans.Location = new System.Drawing.Point(195, 183);
            this.CmbDoktorBrans.Name = "CmbDoktorBrans";
            this.CmbDoktorBrans.Size = new System.Drawing.Size(188, 31);
            this.CmbDoktorBrans.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(117, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "Branşı:";
            // 
            // DoktorBilgiDüzenleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(434, 341);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbDoktorBrans);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDoktorSifre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDoktorSoyad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnBilgiGuncelle);
            this.Controls.Add(this.TxtDoktorAd);
            this.Controls.Add(this.MskDoktorTc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "DoktorBilgiDüzenleForm";
            this.Text = "Bilgileri Düzenle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDoktorSifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDoktorSoyad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnBilgiGuncelle;
        private System.Windows.Forms.TextBox TxtDoktorAd;
        private System.Windows.Forms.MaskedTextBox MskDoktorTc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDoktorBrans;
        private System.Windows.Forms.Label label5;
    }
}