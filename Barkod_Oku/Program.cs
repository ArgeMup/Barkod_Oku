using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Barkod_Oku
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Parametreler)
        {
            if (!System.IO.File.Exists(ArgeMup.HazirKod.Kendi.Klasörü + "\\zxing.dll")) System.IO.File.WriteAllBytes(ArgeMup.HazirKod.Kendi.Klasörü + "\\zxing.dll", Properties.Resources.zxing);

            if (Parametreler != null && Parametreler.Length > 0)
            {
                System.IO.Directory.SetCurrentDirectory(ArgeMup.HazirKod.Kendi.Klasörü);

                Barkod B = new Barkod(Parametreler);
                string çıktı = B.Oku(new Bitmap(Parametreler.Last()));

                File.WriteAllText("cikti.txt", çıktı);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AnaEkran());
            }
        }
    }
}
