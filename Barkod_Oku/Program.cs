using ArgeMup.HazirKod;
using ArgeMup.HazirKod.Ekİşlemler;
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

            ////Seçenek 1
            //KomutVermeDeposu["Komut", 0] = "Ayarla";
            //BaşlangıçParamaetreleri = new string[] { @"C:\Deneme\Komut.txt" };
            //File.WriteAllText(BaşlangıçParamaetreleri[0], KomutVermeDeposu.YazıyaDönüştür());

            ////Seçenek 2
            //KomutVermeDeposu["Komut", 0] = "Ayarla";
            //BaşlangıçParamaetreleri = new string[] { KomutVermeDeposu.YazıyaDönüştür().BaytDizisine().Taban64e() };

            ////Seçenek 3
            //BaşlangıçParamaetreleri = new string[] { "YeniYazilimKontrolu" };

            ////Seçenek 4
#endif

            if (BaşlangıçParamaetreleri != null && BaşlangıçParamaetreleri.Length == 1)
            {
                if (BaşlangıçParamaetreleri[0] == "YeniYazilimKontrolu")
                {
                    Dosya.Sil(Kendi.Klasörü + "\\zxing.dll");

                    YeniYazılımKontrolü_ YeniYazılımKontrolü = new YeniYazılımKontrolü_();
                    YeniYazılımKontrolü.Başlat(new System.Uri("https://github.com/ArgeMup/Barkod_Oku/blob/main/Barkod_Oku/bin/Release/Barkod_Oku.exe?raw=true"));
                    while (!YeniYazılımKontrolü.KontrolTamamlandı) System.Threading.Thread.Sleep(1000);
                    YeniYazılımKontrolü.Durdur();
                    return;
                }
                else if (File.Exists(BaşlangıçParamaetreleri[0]))
                {
                    Ortak.Depo_Komut = new Depo_(File.ReadAllText(BaşlangıçParamaetreleri[0]));
                }
                else
                {
                    BaşlangıçParamaetreleri[0] = BaşlangıçParamaetreleri[0].Taban64ten().Yazıya();
                    Ortak.Depo_Komut = new Depo_(BaşlangıçParamaetreleri[0]);
                }
            }

            if (!System.IO.File.Exists(ArgeMup.HazirKod.Kendi.Klasörü + "\\zxing.dll")) System.IO.File.WriteAllBytes(ArgeMup.HazirKod.Kendi.Klasörü + "\\zxing.dll", Properties.Resources.zxing);

            if (Ortak.Depo_Komut == null)
            {
                Ortak.Depo_Komut = new Depo_();
                Ortak.Depo_Komut["Komut", 0] = "Ayarla";
                Ortak.Depo_Komut["Ayarlar", 0] = Kendi.Klasörü + "\\Ayarlar.mup";
            }

            Ortak.Depo_Ayarlar = new Depo_(File.Exists(Ortak.Depo_Komut["Ayarlar", 0]) ? File.ReadAllText(Ortak.Depo_Komut["Ayarlar", 0]) : null);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new AnaEkran());
        }
    }
}
