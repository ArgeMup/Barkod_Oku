using ArgeMup.HazirKod;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZXing;

namespace Barkod_Oku
{
    public partial class AnaEkran : Form
    {
        bool İlkAçılışİşlemleriTamamlandı = false;
        public AnaEkran()
        {
            InitializeComponent();

            if (Ortak.Depo_Komut["Komut", 0] == "Çalıştır")
            {
                P_Sol_Sağ.Panel1Collapsed = true;
            }
            else //Ayarla
            {
                İpUcu.SetToolTip(Girdi, "Bir barkodu okutabilmek için" + Environment.NewLine +
                    "Barkodu kameranın önüne gelecek şekilde tutabilirsiniz veya" + Environment.NewLine +
                    "Önceden resmi çekilmiş bir barkodun resmini sürükle bırak yapabilirsiniz.");

                KarakterKodlama.SelectedIndex = 0;
                Tür.Items.AddRange(string.Join("?", Enum.GetNames(typeof(BarcodeFormat))).Split('?'));

                IDepo_Eleman Detaylar = Ortak.Depo_Ayarlar["Detaylar"];
                KameraNumarası.Value = (decimal)Detaylar.Oku_TamSayı("Kamera Numarası");
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

                Ortak.Depo_Çalıştır = new Depo_();
            }

            Ortak.Barkod = new Barkod_();

#if !DEBUG
            TopMost = true;
            WindowState = FormWindowState.Maximized;
#endif

            İlkAçılışİşlemleriTamamlandı = true;
        }
        private void AnaEkran_Shown(object sender, EventArgs e)
        {
            Ayar_Değişti(null, null);

            Kaydet.Enabled = false;
        }
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
                    if (Girdi.Image != null) Girdi.Image.Dispose();
                    Girdi.Image = Image.FromFile(dosyalar[0]);

                    Ayar_Değişti(null, null);
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
                }
            }
        }
        private void Sığdır_CheckedChanged(object sender, EventArgs e)
        {
            Girdi.SizeMode = Sığdır.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
        }
        private void Ayar_Değişti(object sender, EventArgs e)
        {
            if (!İlkAçılışİşlemleriTamamlandı) return;

            IDepo_Eleman Detaylar = Ortak.Depo_Ayarlar["Detaylar"];
            Detaylar.Yaz("Kamera Numarası", (int)KameraNumarası.Value);
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

            try
            {
                Ortak.Barkod = new Barkod_();
                if (Girdi.Image != null && Ortak.Barkod.Oku(new Bitmap(Girdi.Image)))
                {
                    Çıktı.Text = Ortak.Depo_Çalıştır.YazıyaDönüştür().Replace("\n", Environment.NewLine);
                }
                else Çıktı.Text = "Bulunamadı";
            }
            catch (Exception ex)
            {
                Çıktı.Text = ex.Message;
            }

            Kaydet.Enabled = true;
        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
            Klasör.Oluştur(System.IO.Path.GetDirectoryName(Ortak.Depo_Komut["Ayarlar", 0]));
            System.IO.File.WriteAllText(Ortak.Depo_Komut["Ayarlar", 0], Ortak.Depo_Ayarlar.YazıyaDönüştür());

            Kaydet.Enabled = false;
        }

        private void Tuş_BunuKullan_Click(object sender, EventArgs e)
        {

        }
        private void Tuş_TekrarYakala_Click(object sender, EventArgs e)
        {

        }
        private void Tuş_Çıkış_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
