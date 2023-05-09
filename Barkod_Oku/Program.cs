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
                    Dosya.Sil(Kendi.Klasörü + "\\dll.zip");
                    Dosya.Sil(Kendi.Klasörü + "\\dll_x86.zip");
                    Dosya.Sil(Kendi.Klasörü + "\\dll_x64.zip");
                    Dosya.Sil(Kendi.Klasörü + "\\zxing.dll");
                    Dosya.Sil(Kendi.Klasörü + "\\OpenCvSharp.dll");
                    Dosya.Sil(Kendi.Klasörü + "\\OpenCvSharp.Extensions.dll");
                    Dosya.Sil(Kendi.Klasörü + "\\System.Drawing.Common.dll");

                    _Dosyayı_İndir_("https://github.com/ArgeMup/Barkod_Oku/blob/main/Barkod_Oku/bin/Release/Barkod_Oku.exe?raw=true", Kendi.DosyaYolu);
                    return;
                }
                else if (File.Exists(BaşlangıçParamaetreleri[0]))
                {
                    Ortak.Depo_Komut_DosyaYolu = BaşlangıçParamaetreleri[0];
                    Ortak.Depo_Komut = new Depo_(File.ReadAllText(Ortak.Depo_Komut_DosyaYolu));
                }
            }

            //Ek dosyaların çıkarılması
            if (!File.Exists(Kendi.Klasörü + "\\zxing.dll"))
            {
                if (!File.Exists(Kendi.Klasörü + "\\dll.zip") && !_Dosyayı_İndir_("https://github.com/ArgeMup/Barkod_Oku/blob/main/Barkod_Oku/bin/Release/dll.zip?raw=true", Kendi.Klasörü + "\\dll.zip")) return;
                SıkıştırılmışDosya.Klasöre(Kendi.Klasörü + "\\dll.zip", Kendi.Klasörü);
            }
            if (!Directory.Exists(Kendi.Klasörü + "\\dll\\x86"))
            {
                if (!File.Exists(Kendi.Klasörü + "\\dll_x86.zip") && !_Dosyayı_İndir_("https://github.com/ArgeMup/Barkod_Oku/blob/main/Barkod_Oku/bin/Release/dll_x86.zip?raw=true", Kendi.Klasörü + "\\dll_x86.zip")) return;
                SıkıştırılmışDosya.Klasöre(Kendi.Klasörü + "\\dll_x86.zip", Kendi.Klasörü);
            }
            if (!Directory.Exists(Kendi.Klasörü + "\\dll\\x64"))
            {
                if (!File.Exists(Kendi.Klasörü + "\\dll_x64.zip") && !_Dosyayı_İndir_("https://github.com/ArgeMup/Barkod_Oku/blob/main/Barkod_Oku/bin/Release/dll_x64.zip?raw=true", Kendi.Klasörü + "\\dll_x64.zip")) return;
                SıkıştırılmışDosya.Klasöre(Kendi.Klasörü + "\\dll_x64.zip", Kendi.Klasörü);
            }

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

            bool _Dosyayı_İndir_(string Kaynak_Uri, string HedefDosyaYolu)
            {
                YeniYazılımKontrolü_ YeniYazılımKontrolü = new YeniYazılımKontrolü_();
                YeniYazılımKontrolü.Başlat(new Uri(Kaynak_Uri), HedefDosyaYolu:HedefDosyaYolu);
                while (!YeniYazılımKontrolü.KontrolTamamlandı) System.Threading.Thread.Sleep(1000);
                YeniYazılımKontrolü.Durdur();
                bool sonuç = File.Exists(HedefDosyaYolu);

                if (!sonuç) File.WriteAllText("Hata.txt", "Dosya indirilemedi" + Environment.NewLine + HedefDosyaYolu + Environment.NewLine + Kaynak_Uri);
                return sonuç;
            }
        }
    }
}
