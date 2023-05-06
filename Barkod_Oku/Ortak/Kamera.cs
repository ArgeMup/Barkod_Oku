using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace Barkod_Oku
{
    static class Kamera
    {
        static VideoCapture Yakalayıcı;

        static bool Başlat()
        {
            Durdur();

            int KameraNo = Ortak.Depo_Ayarlar.Oku_TamSayı("Detaylar/Kamera No");
            Yakalayıcı = new VideoCapture(KameraNo);

            return ÇalışıyorMu();
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
                if (!çerçeve.Empty())
                {
                    //Console.Write(çerçeve.CountNonZero());
                    rsm = BitmapConverter.ToBitmap(çerçeve);
                }
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
