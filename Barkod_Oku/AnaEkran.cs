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
        public AnaEkran()
        {
            InitializeComponent();

            Text = "ArGeMuP " + Kendi.Adı + " " + Kendi.Sürüm;

            KarakterKodlama.SelectedIndex = 0;
            Tür.Items.Add("Tümünü Dahil Et");
            Tür.Items.AddRange(string.Join("?", Enum.GetNames(typeof(BarcodeFormat))).Split('?')); Tür.SetItemChecked(Tür.Items.IndexOf(BarcodeFormat.QR_CODE.ToString()), true);
        }
        private void AnaEkran_Shown(object sender, EventArgs e)
        {
            Ayar_Değişti(null, null);
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

        private void Ayar_Değişti(object sender, EventArgs e)
        {
            Parametre_İzleme.Text = KarakterKodlama.Text + " ";
            if (Tür.CheckedItems.Count > 0 && Tür.GetItemChecked(0)) Parametre_İzleme.Text += "TUMU ";
            else
            {
                for (int i = 0; i < Tür.CheckedItems.Count; i++)
                {
                    Parametre_İzleme.Text += Tür.CheckedItems[i].ToString() + ",";
                }
                Parametre_İzleme.Text = Parametre_İzleme.Text.TrimEnd(',') + " ";
            }
            Parametre_İzleme.Text +=
                (AutoRotate.Checked ? "E " : "H ") +
                (Multi.Checked ? "E " : "H ") +
                (TRY_HARDER.Checked ? "E " : "H ") +
                (DumpBlackPoint.Checked ? "E " : "H ") +
                (PURE_BARCODE.Checked ? "E " : "H ") +
                (ASSUME_CODE_39_CHECK_DIGIT.Checked ? "E " : "H ") +
                (ASSUME_MSI_CHECK_DIGIT.Checked ? "E " : "H ") +
                (USE_CODE_39_EXTENDED_MODE.Checked ? "E " : "H ") +
                (RELAXED_CODE_39_EXTENDED_MODE.Checked ? "E " : "H ") +
                (TRY_HARDER_WITHOUT_ROTATION.Checked ? "E " : "H ") +
                (ASSUME_GS1.Checked ? "E " : "H ") +
                (RETURN_CODABAR_START_END.Checked ? "E " : "H ") +
                (ALSO_INVERTED.Checked ? "E " : "H ") + 
                "\"ResimDosyasınınYolu\"";

            try
            {
                if (Girdi.Image == null) throw new Exception("Resim yüklenmedi");

                Barkod B = new Barkod(Parametre_İzleme.Text.Split(' '));
                Çıktı.Text = B.Oku(new Bitmap(Girdi.Image)).Replace("\n", Environment.NewLine);
            }
            catch (Exception ex)
            {
                Çıktı.Text = ex.Message;
            }
        }

        private void Sığdır_CheckedChanged(object sender, EventArgs e)
        {
            Girdi.SizeMode = Sığdır.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
        }
    }
}
