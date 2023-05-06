using ArgeMup.HazirKod;
using System;
using System.IO;

namespace Barkod_Oku
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] BaşlangıçParamaetreleri)
        {
#if DEBUG
            Depo_ KomutVermeDeposu = new Depo_();
            KomutVermeDeposu["Ayarlar", 0] = @"C:\Deneme\Ayarlar.mup";

            ////Seçenek 1 A
            //KomutVermeDeposu["Komut", 0] = "Ayarla";
            //BaşlangıçParamaetreleri = new string[] { @"C:\Deneme\Komut.txt" };
            //File.WriteAllText(BaşlangıçParamaetreleri[0], KomutVermeDeposu.YazıyaDönüştür());

            ////Seçenek 1 B
            //KomutVermeDeposu["Komut", 0] = "Barkod Oku";
            //BaşlangıçParamaetreleri = new string[] { @"C:\Deneme\Komut.txt" };
            //File.WriteAllText(BaşlangıçParamaetreleri[0], KomutVermeDeposu.YazıyaDönüştür());

            ////Seçenek 1 C
            //KomutVermeDeposu["Komut", 0] = "Resim Çek";
            //BaşlangıçParamaetreleri = new string[] { @"C:\Deneme\Komut.txt" };
            //File.WriteAllText(BaşlangıçParamaetreleri[0], KomutVermeDeposu.YazıyaDönüştür());

            ////Seçenek 2
            //BaşlangıçParamaetreleri = new string[] { "YeniYazilimKontrolu" };

            ////Seçenek 3
#endif

            if (BaşlangıçParamaetreleri != null && BaşlangıçParamaetreleri.Length == 1)
            {
                if (BaşlangıçParamaetreleri[0] == "YeniYazilimKontrolu")
                {
                    Klasör.Sil(Kendi.Klasörü + "\\dll");
                    Dosya.Sil(Kendi.Klasörü + "\\EkDosyalar.zip");
                    Dosya.Sil(Kendi.Klasörü + "\\zxing.dll");
                    Dosya.Sil(Kendi.Klasörü + "\\OpenCvSharp.dll");
                    Dosya.Sil(Kendi.Klasörü + "\\OpenCvSharp.Extensions.dll");
                    Dosya.Sil(Kendi.Klasörü + "\\System.Drawing.Common.dll");

                    YeniYazılımKontrolü_ YeniYazılımKontrolü = new YeniYazılımKontrolü_();
                    YeniYazılımKontrolü.Başlat(new System.Uri("https://github.com/ArgeMup/Barkod_Oku/blob/main/Barkod_Oku/bin/Release/Barkod_Oku.exe?raw=true"));
                    while (!YeniYazılımKontrolü.KontrolTamamlandı) System.Threading.Thread.Sleep(1000);
                    YeniYazılımKontrolü.Durdur();
                    return;
                }
                else if (File.Exists(BaşlangıçParamaetreleri[0]))
                {
                    Ortak.Depo_Komut_DosyaYolu = BaşlangıçParamaetreleri[0];
                    Ortak.Depo_Komut = new Depo_(File.ReadAllText(Ortak.Depo_Komut_DosyaYolu));
                }
            }

            //Ek dosyaların çıkarılması
            if (!File.Exists(Kendi.Klasörü + "\\EkDosyalar.zip")) File.WriteAllBytes(Kendi.Klasörü + "\\EkDosyalar.zip", Properties.Resources.EkDosyalar);
            if (!Directory.Exists(Kendi.Klasörü + "\\dll")) SıkıştırılmışDosya.Klasöre(Kendi.Klasörü + "\\EkDosyalar.zip", Kendi.Klasörü);

            if (Ortak.Depo_Komut == null)
            {
                Ortak.Depo_Komut = new Depo_();
                Ortak.Depo_Komut["Komut", 0] = "Ayarla";
                Ortak.Depo_Komut["Ayarlar", 0] = Kendi.Klasörü + "\\Ayarlar.mup";

                Ortak.Depo_Komut_DosyaYolu = Kendi.Klasörü + "\\Komut.mup";
            }

            Ortak.NormalÇalışma = Ortak.Depo_Komut.Oku("Komut") != "Ayarla";
            Ortak.Depo_Ayarlar = new Depo_(File.Exists(Ortak.Depo_Komut["Ayarlar", 0]) ? File.ReadAllText(Ortak.Depo_Komut["Ayarlar", 0]) : null);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new AnaEkran());
        }
    }
}
