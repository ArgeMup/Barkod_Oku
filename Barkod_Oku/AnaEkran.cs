using ArgeMup.HazirKod;
using ArgeMup.HazirKod.Ekİşlemler;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Barkod_Oku
{
    public partial class AnaEkran : Form
    {
        bool İlkAçılışİşlemleriTamamlandı = false, GeçiciOlarakDurdur = false;
        long KuyruktakiResimSayısı = 0;
        int Sayac_Panel = 0, Sayac_Resim = 0;

        #region Resim Tutucular
        const int ResimTutucu_Adet = 6;
        Panel[] ResimTutucu_P = new Panel[ResimTutucu_Adet];
        CheckBox[] ResimTutucu_Kullan = new CheckBox[ResimTutucu_Adet];
        PictureBox[] ResimTutucu_Resim = new PictureBox[ResimTutucu_Adet];
        #endregion

        #region Genel
        public AnaEkran()
        {
            InitializeComponent();

            if (Ortak.NormalÇalışma)
            {
                P_Sol_Sağ.Panel1Collapsed = true;

                if (Ortak.Depo_Komut["Komut", 0] == "Barkod Oku")
                {
                    Ortak.Barkod = new Barkod_();

                    Tuş_Çıkış.Location = new Point(Tuş_TekrarYakala.Location.X, Tuş_TekrarYakala.Location.Y);
                    Tuş_TekrarYakala.Visible = false;
                    Tuş_BunuKullan.Visible = false;

                    İpUcu.SetToolTip(Girdi, "Çıkış (ESC) : Uygulamayı kapatır");
                }
                else if (Ortak.Depo_Komut["Komut", 0] == "Resim Çek")
                {
                    Girdi.MouseClick += new MouseEventHandler(P_Resim_MouseClick);

                    İpUcu.SetToolTip(Girdi,
                        "Çıkış (ESC) : Uygulamayı kapatır" + Environment.NewLine +
                        "Yakala (F1) : Kameradan yeni bir resim yakalayıp tutucu bölgeye kopyalar" + Environment.NewLine +
                        "Kullan (F2) : Tutucu bölgedeki seçili olan resimleri üst uygulamaya bildirir" + Environment.NewLine + Environment.NewLine +
                        "Klavyedeki harflerin üstündeki 1 - " + ResimTutucu_Adet + " : Tutucu içindeki seçilen resmi kullanılmak üzere isaretler" + Environment.NewLine + Environment.NewLine +
                        "Klavyedeki sağdaki rakamlar 0 : Kamera görüntüsünü ekranda büyütür" + Environment.NewLine +
                        "Klavyedeki sağdaki rakamlar 1 - " + ResimTutucu_Adet + " : Tutucu içindeki seçilen resmi ekranda büyütür");
                }
            }
            else //Ayarla
            {
                İpUcu.SetToolTip(Girdi, "Bir barkodu okutabilmek için" + Environment.NewLine +
                    "Barkodu kameranın önüne gelecek şekilde tutabilirsiniz veya" + Environment.NewLine +
                    "Önceden resmi çekilmiş bir barkodun resmini sürükle bırak yapabilirsiniz.");

                KarakterKodlama.SelectedIndex = 0;
                Tür.Items.AddRange(string.Join("?", Enum.GetNames(typeof(ZXing.BarcodeFormat))).Split('?'));

                IDepo_Eleman Detaylar = Ortak.Depo_Ayarlar["Detaylar"];
                KameraNo.Value = Detaylar.Oku_TamSayı("Kamera No");
                KarakterKodlama.Text = Detaylar.Oku("Karakter Kodlama", "ASCII");
                if (Detaylar["Tür", 0] == "Tümü") Tür.SetItemChecked(0, true);
                else
                {
                    foreach (string t in Detaylar["Tür"].İçeriği)
                    {
                        int konum = Tür.Items.IndexOf(t);
                        if (konum >= 0) Tür.SetItemChecked(konum, true);
                    }

                    if (Tür.CheckedItems.Count == 0) Tür.SetItemChecked(0, true);
                }
                AutoRotate.Checked = Detaylar.Oku_Bit("AutoRotate", false);
                Multi.Checked = Detaylar.Oku_Bit("Multi", false);
                TRY_HARDER.Checked = Detaylar.Oku_Bit("TRY_HARDER", false);
                DumpBlackPoint.Checked = Detaylar.Oku_Bit("DumpBlackPoint", false);
                PURE_BARCODE.Checked = Detaylar.Oku_Bit("PURE_BARCODE", false);
                ASSUME_CODE_39_CHECK_DIGIT.Checked = Detaylar.Oku_Bit("ASSUME_CODE_39_CHECK_DIGIT", false);
                ASSUME_MSI_CHECK_DIGIT.Checked = Detaylar.Oku_Bit("ASSUME_MSI_CHECK_DIGIT", false);
                USE_CODE_39_EXTENDED_MODE.Checked = Detaylar.Oku_Bit("USE_CODE_39_EXTENDED_MODE", true);
                RELAXED_CODE_39_EXTENDED_MODE.Checked = Detaylar.Oku_Bit("RELAXED_CODE_39_EXTENDED_MODE", true);
                TRY_HARDER_WITHOUT_ROTATION.Checked = Detaylar.Oku_Bit("TRY_HARDER_WITHOUT_ROTATION", true);
                ASSUME_GS1.Checked = Detaylar.Oku_Bit("ASSUME_GS1", false);
                RETURN_CODABAR_START_END.Checked = Detaylar.Oku_Bit("RETURN_CODABAR_START_END", false);
                ALSO_INVERTED.Checked = Detaylar.Oku_Bit("ALSO_INVERTED", false);

                Girdi.MouseClick += new MouseEventHandler(P_Resim_MouseClick);
            }

            #if !DEBUG
                TopMost = true;
                WindowState = FormWindowState.Maximized;
            #endif

            for (int i = 0; i < ResimTutucu_Adet; i++)
            {
                ResimTutucu_P[i] = P_Sol_Sağ.Panel2.Controls.Find("P" + (i + 1), true)[0] as Panel;
                ResimTutucu_Kullan[i] = P_Sol_Sağ.Panel2.Controls.Find("P" + (i + 1) + "_Kullan", true)[0] as CheckBox;
                ResimTutucu_Resim[i] = P_Sol_Sağ.Panel2.Controls.Find("P" + (i + 1) + "_Resim", true)[0] as PictureBox;
                ResimTutucu_Resim[i].Tag = i + 1;
            }
            Girdi.Tag = 0;

            İlkAçılışİşlemleriTamamlandı = true;
        }
        private void AnaEkran_Shown(object sender, EventArgs e)
        {
            KameraNo_ValueChanged(null, null);

            Kaydet.Enabled = false;

            İşçi.RunWorkerAsync();
        }
        private void AnaEkran_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;

                case Keys.F1:
                    Tuş_TekrarYakala_Click(null, null);
                    break;

                case Keys.F2:
                    Tuş_BunuKullan_Click(null, null);   
                    break;

                default:
                    if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
                    {
                        int tuş = e.KeyCode - Keys.D1;

                        if (tuş < 0 || 
                            tuş >= ResimTutucu_Adet ||
                            !ResimTutucu_P[tuş].Visible) return;

                        ResimTutucu_Kullan[tuş].Checked = !ResimTutucu_Kullan[tuş].Checked;
                    }
                    else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                    {
                        int tuş = e.KeyCode - Keys.NumPad0;

                        if (tuş < 0 ||
                            tuş > ResimTutucu_Adet) return;

                        PictureBox rsm;
                        if (tuş == 0) rsm = Girdi;
                        else rsm = ResimTutucu_Resim[tuş - 1];
                        P_Resim_MouseClick(rsm, null);
                    }
                    break;
            }
        }
        private void İşçi_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int TaramaGecikmesi = 1000 / 30 /*msn olarak - sn deki kare sayısına göre*/;
            bool BarkodOku_1_ResimÇek_0 = true; //ayarla aşamasında barkod okuyabilmesi için

            if (Ortak.NormalÇalışma)
            {
                if (Ortak.Depo_Komut["Komut", 0] == "Barkod Oku")
                {
                    BarkodOku_1_ResimÇek_0 = true;
                }
                else if (Ortak.Depo_Komut["Komut", 0] == "Resim Çek")
                {
                    BarkodOku_1_ResimÇek_0 = false;
                }
                else
                {
                    Depo_Çalıştır_İçineKaydet_Kapan(true, "Hatalı Komut");
                    return;
                }
            }

            while (Ortak.Çalışsın)
            {
                if (!GeçiciOlarakDurdur && Interlocked.Read(ref KuyruktakiResimSayısı) == 0)
                {
                    Bitmap rsm = Kamera.ResimAl();
                    if (rsm == null)
                    {
                        if (!Kamera.ÇalışıyorMu())
                        {
                            if (Ortak.NormalÇalışma)
                            {
                                Depo_Çalıştır_İçineKaydet_Kapan(true, "Kamera açılamadı.");
                                break;
                            }
                            else
                            {
                                Hata_Göster("Kamera açılamadı.");
                                Thread.Sleep(1000);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (BarkodOku_1_ResimÇek_0)
                        {
                            try
                            {
                                if (Ortak.Barkod.Oku(rsm))
                                {
                                    Depo_Çalıştır_İçineKaydet_Kapan(false, null);
                                }
                            }
                            catch (Exception ex)
                            {
                                Depo_Çalıştır_İçineKaydet_Kapan(true, ex.ToString());
                            }
                        }

                        Interlocked.Increment(ref KuyruktakiResimSayısı);
                        İşçi.ReportProgress(0, rsm);
                    }
                }

                Thread.Sleep(TaramaGecikmesi);
            }

            Kamera.Durdur();
        }
        private void İşçi_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Bitmap rsm = (Bitmap)e.UserState;
           
            if (GeçiciOlarakDurdur) rsm?.Dispose();
            else
            {
                Girdi.Image?.Dispose();
                Girdi.Image = rsm;

                ResimSayacı.Text = Sayac_Resim++.ToString();
            }

            Interlocked.Exchange(ref KuyruktakiResimSayısı, 0);
        }

        void Depo_Çalıştır_İçineKaydet_Kapan(bool Hatalı, string HataAçıklaması)
        {
            Ortak.Depo_Komut["Komut", 1] = Hatalı ? "Hatalı" : "Başarılı";
            Ortak.Depo_Komut["Komut", 2] = HataAçıklaması;

            string içerik = Ortak.Depo_Komut.YazıyaDönüştür();
            if (Ortak.NormalÇalışma) File.WriteAllText(Ortak.Depo_Komut_DosyaYolu, içerik);
            else Hata_Göster(içerik);

            if (Ortak.NormalÇalışma)
            {
                Ortak.Çalışsın = false; //tamamlandı, kapan
                Close();
            }
        }
        void Hata_Göster(string Mesaj)
        {
            if (Çıktı.InvokeRequired)
            {
                Çıktı.Invoke(new Action(() =>
                {
                    _Hata_Göster_();
                }));
            }
            else _Hata_Göster_();

            void _Hata_Göster_()
            {
                Çıktı.Text = Mesaj.Replace("\n", Environment.NewLine);
            }
        }
        #endregion

        #region Ayarlama
        private void AnaEkran_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void AnaEkran_DragDrop(object sender, DragEventArgs e)
        {
            string[] dosyalar = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (dosyalar != null && 
                dosyalar.Length == 1 &&
                File.Exists(dosyalar[0]))
            {
                string soyadı = Path.GetExtension(dosyalar[0]).ToLower();
                if (soyadı == ".jpg" || soyadı == ".png" || soyadı == ".bmp")
                {
                    Girdi.Image?.Dispose();
                    Girdi.Image = Image.FromFile(dosyalar[0]);

                    bool Kaydet_enabled = Kaydet.Enabled;
                    Ayar_Değişti(null, null);
                    Kaydet.Enabled = Kaydet_enabled;
                }
            }
        }
        private void AnaEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Kaydet.Enabled)
            {
                DialogResult dr = MessageBox.Show("Değişiklikleri kaydetmeden çıkmak istiyor musunuz?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Ortak.Çalışsın = false;
        }
        private void Sığdır_CheckedChanged(object sender, EventArgs e)
        {
            Girdi.SizeMode = Sığdır.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
        }
        private void KameraNo_ValueChanged(object sender, EventArgs e)
        {
            Kamera.Durdur();

            if (!Ortak.NormalÇalışma) Ayar_Değişti(null, null);
        }
        private void Ayar_Değişti(object sender, EventArgs e)
        {
            if (!İlkAçılışİşlemleriTamamlandı) return;

            IDepo_Eleman Detaylar = Ortak.Depo_Ayarlar["Detaylar"];
            Detaylar.Yaz("Kamera No", (int)KameraNo.Value);
            Detaylar.Yaz("Karakter Kodlama", KarakterKodlama.Text);
            if (Tür.GetItemChecked(0)) Detaylar["Tür"].İçeriği = new string[] { "Tümü" };
            else
            {
                string[] l = new string[Tür.CheckedItems.Count];

                for (int i = 0; i < Tür.CheckedItems.Count; i++)
                {
                    l[i] = Tür.CheckedItems[i].ToString();
                }

                Detaylar["Tür"].İçeriği = l;
            }
            Detaylar.Yaz("AutoRotate", AutoRotate.Checked);
            Detaylar.Yaz("Multi", Multi.Checked);
            Detaylar.Yaz("TRY_HARDER", TRY_HARDER.Checked);
            Detaylar.Yaz("DumpBlackPoint", DumpBlackPoint.Checked);
            Detaylar.Yaz("PURE_BARCODE", PURE_BARCODE.Checked);
            Detaylar.Yaz("ASSUME_CODE_39_CHECK_DIGIT", ASSUME_CODE_39_CHECK_DIGIT.Checked);
            Detaylar.Yaz("ASSUME_MSI_CHECK_DIGIT", ASSUME_MSI_CHECK_DIGIT.Checked);
            Detaylar.Yaz("USE_CODE_39_EXTENDED_MODE", USE_CODE_39_EXTENDED_MODE.Checked);
            Detaylar.Yaz("RELAXED_CODE_39_EXTENDED_MODE", RELAXED_CODE_39_EXTENDED_MODE.Checked);
            Detaylar.Yaz("TRY_HARDER_WITHOUT_ROTATION", TRY_HARDER_WITHOUT_ROTATION.Checked);
            Detaylar.Yaz("ASSUME_GS1", ASSUME_GS1.Checked);
            Detaylar.Yaz("RETURN_CODABAR_START_END", RETURN_CODABAR_START_END.Checked);
            Detaylar.Yaz("ALSO_INVERTED", ALSO_INVERTED.Checked);

            Bitmap bmp = null;
            try
            {
                Ortak.Barkod = new Barkod_();
                bmp = new Bitmap(Girdi.Image);
                if (Ortak.Barkod.Oku(bmp))
                {
                    Çıktı.Text = Ortak.Depo_Komut.YazıyaDönüştür().Replace("\n", Environment.NewLine);
                }
                else Çıktı.Text = "Bulunamadı";
            }
            catch (Exception ex)
            {
                Çıktı.Text = ex.Message;
            }
            bmp?.Dispose();

            Kaydet.Enabled = true;
        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
            Klasör.Oluştur(System.IO.Path.GetDirectoryName(Ortak.Depo_Komut["Ayarlar", 0]));
            System.IO.File.WriteAllText(Ortak.Depo_Komut["Ayarlar", 0], Ortak.Depo_Ayarlar.YazıyaDönüştür());

            Kaydet.Enabled = false;
        }
        #endregion

        #region Normal Resim Çekme
        private void Tuş_BunuKullan_Click(object sender, EventArgs e)
        {
            DateTime şimdi = DateTime.Now;
            string kls = Kendi.Klasörü + "\\Resimler\\";
            Klasör.Sil(kls);
            Klasör.Oluştur(kls);

            Ortak.Depo_Komut.Sil("Resimler", false, true);
            Ortak.Depo_Komut.Yaz("Resimler", DateTime.Now);

            for (int i = 0; i < ResimTutucu_Adet; i++)
            {
                if (ResimTutucu_Kullan[i].Checked)
                {
                    string dsy = kls + şimdi.Yazıya(ArgeMup.HazirKod.Dönüştürme.D_TarihSaat.Şablon_DosyaAdı2) + ".png";
                    ResimTutucu_Resim[i].Image.Save(dsy, System.Drawing.Imaging.ImageFormat.Png);

                    Ortak.Depo_Komut["Resimler/" + i, 0] = dsy;

                    şimdi = şimdi.AddMilliseconds(2);
                }
            }

            if (Ortak.Depo_Komut["Resimler"].Elemanları.Length == 0)
            {
                MessageBox.Show("Hiç resim seçilmedi.", Text);
                return;
            }

            Depo_Çalıştır_İçineKaydet_Kapan(false, null);
        }
        private void Tuş_TekrarYakala_Click(object sender, EventArgs e)
        {
            if (Girdi.Image == null) return;

            for (int i = 0; i < ResimTutucu_Adet; i++)
            {
                if (!ResimTutucu_P[i].Visible)
                {
                    ResimTutucu_Resim[i].Image = Girdi.Image;
                    Girdi.Image = null;

                    ResimTutucu_Kullan[i].Checked = false;
                    ResimTutucu_P[i].Visible = true;
                    return;
                }
            }

            for (int i = 0; i < ResimTutucu_Adet; i++)
            {
                ResimTutucu_Kullan[i].BackColor = SystemColors.Control;
            }

            for (int i = 0; i < ResimTutucu_Adet; i++)
            {
                int şimdiki = (i + Sayac_Panel) % ResimTutucu_Adet;
                if (ResimTutucu_Kullan[şimdiki].Checked) continue;

                ResimTutucu_Resim[şimdiki].Image?.Dispose();
                ResimTutucu_Resim[şimdiki].Image = Girdi.Image;
                ResimTutucu_Kullan[şimdiki].BackColor = Color.DeepSkyBlue;

                Girdi.Image = null;
                Sayac_Panel = şimdiki + 1;
                return;
            }

            MessageBox.Show("Tüm resim tutucular dolu olduğu için işlem tamamlanamadı.", Text);
        }
        private void P_Resim_MouseClick(object sender, MouseEventArgs e)
        {
            Girdi.Image?.Dispose();
            Girdi.Image = null;
            GeçiciOlarakDurdur = true;
            Tuş_TekrarYakala.Enabled = false;

            Girdi.BackColor = SystemColors.Control;
            for (int i = 0; i < ResimTutucu_Adet; i++)
            {
                ResimTutucu_P[i].BackColor = SystemColors.Control;
            }

            int no = (int)(sender as PictureBox).Tag;
            if (no == 0)
            {
                GeçiciOlarakDurdur = false;
                Girdi.BackColor = Color.YellowGreen;
                Tuş_TekrarYakala.Enabled = true;
            }
            else
            {
                no--;
                if (ResimTutucu_Resim[no].Image == null) return;
                Girdi.Image = ResimTutucu_Resim[no].Image.Clone() as Image;
                ResimTutucu_P[no].BackColor = Color.YellowGreen;
            }
        }
        private void Tuş_Çıkış_Click(object sender, EventArgs e)
        {
            Depo_Çalıştır_İçineKaydet_Kapan(true, "Kapatıldı");

            if (!Ortak.NormalÇalışma) Close();
        }
        #endregion
    }
}
