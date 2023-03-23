namespace Barkod_Oku
{
    partial class AnaEkran
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaEkran));
            this.PURE_BARCODE = new System.Windows.Forms.CheckBox();
            this.İpUcu = new System.Windows.Forms.ToolTip(this.components);
            this.ASSUME_CODE_39_CHECK_DIGIT = new System.Windows.Forms.CheckBox();
            this.ASSUME_MSI_CHECK_DIGIT = new System.Windows.Forms.CheckBox();
            this.USE_CODE_39_EXTENDED_MODE = new System.Windows.Forms.CheckBox();
            this.RELAXED_CODE_39_EXTENDED_MODE = new System.Windows.Forms.CheckBox();
            this.TRY_HARDER_WITHOUT_ROTATION = new System.Windows.Forms.CheckBox();
            this.ASSUME_GS1 = new System.Windows.Forms.CheckBox();
            this.RETURN_CODABAR_START_END = new System.Windows.Forms.CheckBox();
            this.ALSO_INVERTED = new System.Windows.Forms.CheckBox();
            this.TRY_HARDER = new System.Windows.Forms.CheckBox();
            this.DumpBlackPoint = new System.Windows.Forms.CheckBox();
            this.Parametre_İzleme = new System.Windows.Forms.TextBox();
            this.Tür = new System.Windows.Forms.CheckedListBox();
            this.KarakterKodlama = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Multi = new System.Windows.Forms.CheckBox();
            this.AutoRotate = new System.Windows.Forms.CheckBox();
            this.Sığdır = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Girdi = new System.Windows.Forms.PictureBox();
            this.Çıktı = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Girdi)).BeginInit();
            this.SuspendLayout();
            // 
            // PURE_BARCODE
            // 
            this.PURE_BARCODE.AutoSize = true;
            this.PURE_BARCODE.Location = new System.Drawing.Point(9, 132);
            this.PURE_BARCODE.Name = "PURE_BARCODE";
            this.PURE_BARCODE.Size = new System.Drawing.Size(140, 20);
            this.PURE_BARCODE.TabIndex = 0;
            this.PURE_BARCODE.Text = "PURE_BARCODE";
            this.İpUcu.SetToolTip(this.PURE_BARCODE, "Image is a pure monochrome image of a barcode. Doesn\'t matter what it maps to;");
            this.PURE_BARCODE.UseVisualStyleBackColor = true;
            this.PURE_BARCODE.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // İpUcu
            // 
            this.İpUcu.AutomaticDelay = 100;
            this.İpUcu.AutoPopDelay = 10000;
            this.İpUcu.InitialDelay = 100;
            this.İpUcu.IsBalloon = true;
            this.İpUcu.ReshowDelay = 20;
            this.İpUcu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.İpUcu.ToolTipTitle = "Detaylar";
            this.İpUcu.UseAnimation = false;
            this.İpUcu.UseFading = false;
            // 
            // ASSUME_CODE_39_CHECK_DIGIT
            // 
            this.ASSUME_CODE_39_CHECK_DIGIT.AutoSize = true;
            this.ASSUME_CODE_39_CHECK_DIGIT.Location = new System.Drawing.Point(9, 158);
            this.ASSUME_CODE_39_CHECK_DIGIT.Name = "ASSUME_CODE_39_CHECK_DIGIT";
            this.ASSUME_CODE_39_CHECK_DIGIT.Size = new System.Drawing.Size(246, 20);
            this.ASSUME_CODE_39_CHECK_DIGIT.TabIndex = 0;
            this.ASSUME_CODE_39_CHECK_DIGIT.Text = "ASSUME_CODE_39_CHECK_DIGIT";
            this.İpUcu.SetToolTip(this.ASSUME_CODE_39_CHECK_DIGIT, "Assume Code 39 codes employ a check digit.");
            this.ASSUME_CODE_39_CHECK_DIGIT.UseVisualStyleBackColor = true;
            this.ASSUME_CODE_39_CHECK_DIGIT.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // ASSUME_MSI_CHECK_DIGIT
            // 
            this.ASSUME_MSI_CHECK_DIGIT.AutoSize = true;
            this.ASSUME_MSI_CHECK_DIGIT.Location = new System.Drawing.Point(9, 184);
            this.ASSUME_MSI_CHECK_DIGIT.Name = "ASSUME_MSI_CHECK_DIGIT";
            this.ASSUME_MSI_CHECK_DIGIT.Size = new System.Drawing.Size(210, 20);
            this.ASSUME_MSI_CHECK_DIGIT.TabIndex = 0;
            this.ASSUME_MSI_CHECK_DIGIT.Text = "ASSUME_MSI_CHECK_DIGIT";
            this.İpUcu.SetToolTip(this.ASSUME_MSI_CHECK_DIGIT, "Assume MSI codes employ a check digit.");
            this.ASSUME_MSI_CHECK_DIGIT.UseVisualStyleBackColor = true;
            this.ASSUME_MSI_CHECK_DIGIT.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // USE_CODE_39_EXTENDED_MODE
            // 
            this.USE_CODE_39_EXTENDED_MODE.AutoSize = true;
            this.USE_CODE_39_EXTENDED_MODE.Checked = true;
            this.USE_CODE_39_EXTENDED_MODE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.USE_CODE_39_EXTENDED_MODE.Location = new System.Drawing.Point(9, 210);
            this.USE_CODE_39_EXTENDED_MODE.Name = "USE_CODE_39_EXTENDED_MODE";
            this.USE_CODE_39_EXTENDED_MODE.Size = new System.Drawing.Size(251, 20);
            this.USE_CODE_39_EXTENDED_MODE.TabIndex = 0;
            this.USE_CODE_39_EXTENDED_MODE.Text = "USE_CODE_39_EXTENDED_MODE";
            this.İpUcu.SetToolTip(this.USE_CODE_39_EXTENDED_MODE, "if Code39 could be detected try to use extended mode for full ASCII character");
            this.USE_CODE_39_EXTENDED_MODE.UseVisualStyleBackColor = true;
            this.USE_CODE_39_EXTENDED_MODE.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // RELAXED_CODE_39_EXTENDED_MODE
            // 
            this.RELAXED_CODE_39_EXTENDED_MODE.AutoSize = true;
            this.RELAXED_CODE_39_EXTENDED_MODE.Checked = true;
            this.RELAXED_CODE_39_EXTENDED_MODE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RELAXED_CODE_39_EXTENDED_MODE.Location = new System.Drawing.Point(9, 236);
            this.RELAXED_CODE_39_EXTENDED_MODE.Name = "RELAXED_CODE_39_EXTENDED_MODE";
            this.RELAXED_CODE_39_EXTENDED_MODE.Size = new System.Drawing.Size(285, 20);
            this.RELAXED_CODE_39_EXTENDED_MODE.TabIndex = 0;
            this.RELAXED_CODE_39_EXTENDED_MODE.Text = "RELAXED_CODE_39_EXTENDED_MODE";
            this.İpUcu.SetToolTip(this.RELAXED_CODE_39_EXTENDED_MODE, "Don\'t fail if a Code39 is detected but can\'t be decoded in extended mode. Return\r" +
        "\nthe raw Code39 result instead.");
            this.RELAXED_CODE_39_EXTENDED_MODE.UseVisualStyleBackColor = true;
            this.RELAXED_CODE_39_EXTENDED_MODE.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // TRY_HARDER_WITHOUT_ROTATION
            // 
            this.TRY_HARDER_WITHOUT_ROTATION.AutoSize = true;
            this.TRY_HARDER_WITHOUT_ROTATION.Checked = true;
            this.TRY_HARDER_WITHOUT_ROTATION.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TRY_HARDER_WITHOUT_ROTATION.Location = new System.Drawing.Point(9, 262);
            this.TRY_HARDER_WITHOUT_ROTATION.Name = "TRY_HARDER_WITHOUT_ROTATION";
            this.TRY_HARDER_WITHOUT_ROTATION.Size = new System.Drawing.Size(270, 20);
            this.TRY_HARDER_WITHOUT_ROTATION.TabIndex = 0;
            this.TRY_HARDER_WITHOUT_ROTATION.Text = "TRY_HARDER_WITHOUT_ROTATION";
            this.İpUcu.SetToolTip(this.TRY_HARDER_WITHOUT_ROTATION, resources.GetString("TRY_HARDER_WITHOUT_ROTATION.ToolTip"));
            this.TRY_HARDER_WITHOUT_ROTATION.UseVisualStyleBackColor = true;
            this.TRY_HARDER_WITHOUT_ROTATION.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // ASSUME_GS1
            // 
            this.ASSUME_GS1.AutoSize = true;
            this.ASSUME_GS1.Location = new System.Drawing.Point(9, 288);
            this.ASSUME_GS1.Name = "ASSUME_GS1";
            this.ASSUME_GS1.Size = new System.Drawing.Size(119, 20);
            this.ASSUME_GS1.TabIndex = 0;
            this.ASSUME_GS1.Text = "ASSUME_GS1";
            this.İpUcu.SetToolTip(this.ASSUME_GS1, "Assume the barcode is being processed as a GS1 barcode, and modify behavior as\r\nn" +
        "eeded. For example this affects FNC1 handling for Code 128 (aka GS1-128). Doesn\'" +
        "t\r\nmatter what it maps to;");
            this.ASSUME_GS1.UseVisualStyleBackColor = true;
            this.ASSUME_GS1.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // RETURN_CODABAR_START_END
            // 
            this.RETURN_CODABAR_START_END.AutoSize = true;
            this.RETURN_CODABAR_START_END.Location = new System.Drawing.Point(9, 314);
            this.RETURN_CODABAR_START_END.Name = "RETURN_CODABAR_START_END";
            this.RETURN_CODABAR_START_END.Size = new System.Drawing.Size(249, 20);
            this.RETURN_CODABAR_START_END.TabIndex = 0;
            this.RETURN_CODABAR_START_END.Text = "RETURN_CODABAR_START_END";
            this.İpUcu.SetToolTip(this.RETURN_CODABAR_START_END, "If true, return the start and end digits in a Codabar barcode instead of strippin" +
        "g\r\nthem. They are alpha, whereas the rest are numeric. By default, they are stri" +
        "pped,\r\nbut this causes them to not be.");
            this.RETURN_CODABAR_START_END.UseVisualStyleBackColor = true;
            this.RETURN_CODABAR_START_END.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // ALSO_INVERTED
            // 
            this.ALSO_INVERTED.AutoSize = true;
            this.ALSO_INVERTED.Location = new System.Drawing.Point(9, 340);
            this.ALSO_INVERTED.Name = "ALSO_INVERTED";
            this.ALSO_INVERTED.Size = new System.Drawing.Size(140, 20);
            this.ALSO_INVERTED.TabIndex = 0;
            this.ALSO_INVERTED.Text = "ALSO_INVERTED";
            this.İpUcu.SetToolTip(this.ALSO_INVERTED, "If true, also tries to decode as inverted image. All configured decoders are\r\nsim" +
        "ply called a second time with an inverted image. Doesn\'t matter what it maps\r\nto" +
        ";");
            this.ALSO_INVERTED.UseVisualStyleBackColor = true;
            this.ALSO_INVERTED.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // TRY_HARDER
            // 
            this.TRY_HARDER.AutoSize = true;
            this.TRY_HARDER.Location = new System.Drawing.Point(9, 80);
            this.TRY_HARDER.Name = "TRY_HARDER";
            this.TRY_HARDER.Size = new System.Drawing.Size(120, 20);
            this.TRY_HARDER.TabIndex = 0;
            this.TRY_HARDER.Text = "Gerekirse zorla";
            this.İpUcu.SetToolTip(this.TRY_HARDER, "Spend more time to try to find a barcode; optimize for accuracy, not speed. Doesn" +
        "\'t\r\nmatter what it maps to;");
            this.TRY_HARDER.UseVisualStyleBackColor = true;
            this.TRY_HARDER.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // DumpBlackPoint
            // 
            this.DumpBlackPoint.AutoSize = true;
            this.DumpBlackPoint.Location = new System.Drawing.Point(9, 106);
            this.DumpBlackPoint.Name = "DumpBlackPoint";
            this.DumpBlackPoint.Size = new System.Drawing.Size(203, 20);
            this.DumpBlackPoint.TabIndex = 0;
            this.DumpBlackPoint.Text = "Gerekirse siyah beyaza çevir";
            this.İpUcu.SetToolTip(this.DumpBlackPoint, resources.GetString("DumpBlackPoint.ToolTip"));
            this.DumpBlackPoint.UseVisualStyleBackColor = true;
            this.DumpBlackPoint.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // Parametre_İzleme
            // 
            this.Parametre_İzleme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Parametre_İzleme.Location = new System.Drawing.Point(300, 288);
            this.Parametre_İzleme.Multiline = true;
            this.Parametre_İzleme.Name = "Parametre_İzleme";
            this.Parametre_İzleme.ReadOnly = true;
            this.Parametre_İzleme.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Parametre_İzleme.Size = new System.Drawing.Size(226, 72);
            this.Parametre_İzleme.TabIndex = 30;
            this.İpUcu.SetToolTip(this.Parametre_İzleme, resources.GetString("Parametre_İzleme.ToolTip"));
            // 
            // Tür
            // 
            this.Tür.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Tür.CheckOnClick = true;
            this.Tür.FormattingEnabled = true;
            this.Tür.Location = new System.Drawing.Point(300, 36);
            this.Tür.Name = "Tür";
            this.Tür.Size = new System.Drawing.Size(226, 242);
            this.Tür.TabIndex = 27;
            this.İpUcu.SetToolTip(this.Tür, "Mevcut görsel içinde aranacak barkod türleri");
            this.Tür.SelectedIndexChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // KarakterKodlama
            // 
            this.KarakterKodlama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KarakterKodlama.Items.AddRange(new object[] {
            "ASCII",
            "UTF-8"});
            this.KarakterKodlama.Location = new System.Drawing.Point(300, 6);
            this.KarakterKodlama.Name = "KarakterKodlama";
            this.KarakterKodlama.Size = new System.Drawing.Size(156, 24);
            this.KarakterKodlama.Sorted = true;
            this.KarakterKodlama.TabIndex = 26;
            this.KarakterKodlama.SelectedIndexChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Karakter Kodlama";
            // 
            // Multi
            // 
            this.Multi.AutoSize = true;
            this.Multi.Location = new System.Drawing.Point(9, 54);
            this.Multi.Name = "Multi";
            this.Multi.Size = new System.Drawing.Size(225, 20);
            this.Multi.TabIndex = 0;
            this.Multi.Text = "Aynı resimde birden fazla barkod";
            this.Multi.UseVisualStyleBackColor = true;
            this.Multi.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // AutoRotate
            // 
            this.AutoRotate.AutoSize = true;
            this.AutoRotate.Location = new System.Drawing.Point(9, 28);
            this.AutoRotate.Name = "AutoRotate";
            this.AutoRotate.Size = new System.Drawing.Size(169, 20);
            this.AutoRotate.TabIndex = 0;
            this.AutoRotate.Text = "Gerekirse resmi döndür";
            this.AutoRotate.UseVisualStyleBackColor = true;
            this.AutoRotate.CheckedChanged += new System.EventHandler(this.Ayar_Değişti);
            // 
            // Sığdır
            // 
            this.Sığdır.AutoSize = true;
            this.Sığdır.Checked = true;
            this.Sığdır.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Sığdır.Location = new System.Drawing.Point(462, 10);
            this.Sığdır.Name = "Sığdır";
            this.Sığdır.Size = new System.Drawing.Size(64, 20);
            this.Sığdır.TabIndex = 33;
            this.Sığdır.Text = "Sığdır";
            this.Sığdır.UseVisualStyleBackColor = true;
            this.Sığdır.CheckedChanged += new System.EventHandler(this.Sığdır_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(532, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Girdi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Çıktı);
            this.splitContainer1.Size = new System.Drawing.Size(240, 354);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 34;
            // 
            // Girdi
            // 
            this.Girdi.BackColor = System.Drawing.Color.Black;
            this.Girdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Girdi.Location = new System.Drawing.Point(0, 0);
            this.Girdi.Name = "Girdi";
            this.Girdi.Size = new System.Drawing.Size(240, 190);
            this.Girdi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Girdi.TabIndex = 33;
            this.Girdi.TabStop = false;
            this.İpUcu.SetToolTip(this.Girdi, "Mevcut görsel\r\n\r\nKaynak resim olduğunda resmi uygulama içine sürükleyin");
            // 
            // Çıktı
            // 
            this.Çıktı.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Çıktı.Location = new System.Drawing.Point(0, 0);
            this.Çıktı.Multiline = true;
            this.Çıktı.Name = "Çıktı";
            this.Çıktı.ReadOnly = true;
            this.Çıktı.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Çıktı.Size = new System.Drawing.Size(240, 160);
            this.Çıktı.TabIndex = 30;
            this.İpUcu.SetToolTip(this.Çıktı, "Mevcut görselin içeriği");
            this.Çıktı.WordWrap = false;
            // 
            // AnaEkran
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 370);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Sığdır);
            this.Controls.Add(this.Parametre_İzleme);
            this.Controls.Add(this.Tür);
            this.Controls.Add(this.KarakterKodlama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ALSO_INVERTED);
            this.Controls.Add(this.RETURN_CODABAR_START_END);
            this.Controls.Add(this.ASSUME_GS1);
            this.Controls.Add(this.TRY_HARDER_WITHOUT_ROTATION);
            this.Controls.Add(this.RELAXED_CODE_39_EXTENDED_MODE);
            this.Controls.Add(this.USE_CODE_39_EXTENDED_MODE);
            this.Controls.Add(this.ASSUME_MSI_CHECK_DIGIT);
            this.Controls.Add(this.ASSUME_CODE_39_CHECK_DIGIT);
            this.Controls.Add(this.TRY_HARDER);
            this.Controls.Add(this.Multi);
            this.Controls.Add(this.DumpBlackPoint);
            this.Controls.Add(this.AutoRotate);
            this.Controls.Add(this.PURE_BARCODE);
            this.Name = "AnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.AnaEkran_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AnaEkran_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AnaEkran_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Girdi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox PURE_BARCODE;
        private System.Windows.Forms.ToolTip İpUcu;
        private System.Windows.Forms.ComboBox KarakterKodlama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ASSUME_CODE_39_CHECK_DIGIT;
        private System.Windows.Forms.CheckBox ASSUME_MSI_CHECK_DIGIT;
        private System.Windows.Forms.CheckBox USE_CODE_39_EXTENDED_MODE;
        private System.Windows.Forms.CheckBox RELAXED_CODE_39_EXTENDED_MODE;
        private System.Windows.Forms.CheckBox TRY_HARDER_WITHOUT_ROTATION;
        private System.Windows.Forms.CheckBox ASSUME_GS1;
        private System.Windows.Forms.CheckBox RETURN_CODABAR_START_END;
        private System.Windows.Forms.CheckBox ALSO_INVERTED;
        private System.Windows.Forms.CheckedListBox Tür;
        private System.Windows.Forms.CheckBox TRY_HARDER;
        private System.Windows.Forms.CheckBox DumpBlackPoint;
        private System.Windows.Forms.CheckBox Multi;
        private System.Windows.Forms.CheckBox AutoRotate;
        private System.Windows.Forms.TextBox Parametre_İzleme;
        private System.Windows.Forms.CheckBox Sığdır;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox Girdi;
        private System.Windows.Forms.TextBox Çıktı;
    }
}

