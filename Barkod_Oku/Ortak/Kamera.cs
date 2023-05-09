using ArgeMup.HazirKod;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;

namespace Barkod_Oku
{
    static class Kamera
    {
        static VideoCapture Yakalayıcı;
        static byte[] Düzeltme_Gama_Dizisi = null;
        static float Düzeltme_Keskinlik = 0;
        static decimal ÖncekiDeğer_Parlaklık = decimal.MinValue;

        static bool Başlat()
        {
            Durdur();
            IDepo_Eleman Detaylar = Ortak.Depo_Ayarlar["Detaylar"];

            Yakalayıcı = VideoCapture.FromCamera(Detaylar.Oku_TamSayı("Kamera", 0, 0));
            if (    Yakalayıcı == null ||
                    !Yakalayıcı.Set(VideoCaptureProperties.FrameWidth, Detaylar.Oku_TamSayı("Kamera", 640, 1)) ||
                    !Yakalayıcı.Set(VideoCaptureProperties.FrameHeight, Detaylar.Oku_TamSayı("Kamera", 480, 2)) ||
                    !Yakalayıcı.Grab() ||
                    !Yakalayıcı.IsOpened()  ) Durdur();
            else
            {
                Düzeltme_Güncelle((decimal)Detaylar.Oku_Sayı("Kamera", 0, 3), (decimal)Detaylar.Oku_Sayı("Kamera", 0, 4));
            }

            return ÇalışıyorMu();
        }
        public static void Düzeltme_Güncelle(decimal Parlaklık, decimal Keskinlik)
        {
            if (ÖncekiDeğer_Parlaklık != Parlaklık)
            {
                ÖncekiDeğer_Parlaklık = Parlaklık;
                double düzeltme_gama = (double)Parlaklık; //0 - 100 aralığında, 0 kapalı
                if (düzeltme_gama == 0) Düzeltme_Gama_Dizisi = null;
                else
                {
                    Düzeltme_Gama_Dizisi = new byte[256];
                    for (int i = 0; i < Düzeltme_Gama_Dizisi.Length; i++)
                    {
                        Düzeltme_Gama_Dizisi[i] = (byte)(Math.Pow(i / 255.0, 1.0 / düzeltme_gama) * 255.0);
                    }
                }
            }

            Düzeltme_Keskinlik = (float)Keskinlik;
        }
        public static bool ÇalışıyorMu()
        {
            return Yakalayıcı == null ? false : Yakalayıcı.IsOpened();
        }
        public static Bitmap ResimAl()
        {
            if (!ÇalışıyorMu())
            {
                if (!Başlat()) return null;
            }

            Bitmap rsm = null;

            using (Mat çerçeve = Yakalayıcı.RetrieveMat())
            {
                if (Düzeltme_Gama_Dizisi != null) Cv2.LUT(çerçeve, Düzeltme_Gama_Dizisi, çerçeve);
 
                if (Düzeltme_Keskinlik > 0) Cv2.DetailEnhance(çerçeve, çerçeve, Düzeltme_Keskinlik, 0.15f /*0-1*/);
                else if (Düzeltme_Keskinlik < 0) Cv2.GaussianBlur(çerçeve, çerçeve, new OpenCvSharp.Size(), -Düzeltme_Keskinlik);

                rsm = BitmapConverter.ToBitmap(çerçeve);
            }

            return rsm;
        }
        public static void Durdur()
        {
            Yakalayıcı?.Dispose();
            Yakalayıcı = null;
        }
    }
}
