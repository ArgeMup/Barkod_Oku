using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

using ZXing;
using ZXing.Common;

using ArgeMup.HazirKod;
using ArgeMup.HazirKod.Ekİşlemler;

namespace Barkod_Oku
{
    public class Barkod
    {
        _Config config = new _Config();

        public Barkod(string[] Parametreler)
        {
            if (Parametreler.Length != 16) throw new Exception("Parametreleri kontrol ediniz");

            config.Hints = new Dictionary<DecodeHintType, Object>();
            
            if (Parametreler[0] != "ASCII") config.Hints[DecodeHintType.CHARACTER_SET] = "UTF-8";

            List<BarcodeFormat> Türler;
            if (Parametreler[1] == "TUMU")
            {
                Türler = new List<BarcodeFormat>()
                {
                    //Ürünlerde kullanılanlar
                    BarcodeFormat.UPC_A,
                    BarcodeFormat.UPC_E,
                    BarcodeFormat.EAN_13,
                    BarcodeFormat.EAN_8,
                    BarcodeFormat.RSS_14,
                    BarcodeFormat.RSS_EXPANDED,

                    //Ürünlerde kullanılmayanlar
                    BarcodeFormat.CODE_39,
                    BarcodeFormat.CODE_93,
                    BarcodeFormat.CODE_128,
                    BarcodeFormat.ITF,
                    BarcodeFormat.QR_CODE,
                    BarcodeFormat.DATA_MATRIX,
                    BarcodeFormat.AZTEC,
                    BarcodeFormat.PDF_417,
                    BarcodeFormat.CODABAR,
                    BarcodeFormat.MAXICODE
                };
            }
            else
            {
                Türler = new List<BarcodeFormat>();
                string[] d = Parametreler[1].Split(',');

                foreach (string s in d) 
                {
                    Türler.Add((BarcodeFormat)Enum.Parse(typeof(BarcodeFormat), s, false));
                }
            }
            config.Hints[DecodeHintType.POSSIBLE_FORMATS] = Türler;

            config.AutoRotate = Parametreler[2] == "E";
            config.Multi = Parametreler[3] == "E";

            config.TryHarder = Parametreler[4] == "E";
            if (config.TryHarder) config.Hints[DecodeHintType.TRY_HARDER] = true;

            config.DumpBlackPoint = Parametreler[5] == "E";

            config.PureBarcode = Parametreler[6] == "E";
            if (config.PureBarcode) config.Hints[DecodeHintType.PURE_BARCODE] = true;

            bool b = Parametreler[7] == "E";
            if (b) config.Hints[DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT] = true;

            b = Parametreler[8] == "E";
            if (b) config.Hints[DecodeHintType.ASSUME_MSI_CHECK_DIGIT] = true;

            b = Parametreler[9] == "E";
            if (b) config.Hints[DecodeHintType.USE_CODE_39_EXTENDED_MODE] = true;

            b = Parametreler[10] == "E";
            if (b) config.Hints[DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE] = true;

            b = Parametreler[11] == "E";
            if (b) config.Hints[DecodeHintType.TRY_HARDER_WITHOUT_ROTATION] = true;

            b = Parametreler[12] == "E";
            if (b) config.Hints[DecodeHintType.ASSUME_GS1] = true;

            b = Parametreler[13] == "E";
            if (b) config.Hints[DecodeHintType.RETURN_CODABAR_START_END] = true;

            config.TryInverted = Parametreler[14] == "E";
            if (config.TryInverted) config.Hints[DecodeHintType.ALSO_INVERTED] = true;
        }

        public string Oku(Bitmap Resim)
        {
            using (Resim)
            {
                LuminanceSource source = new BitmapLuminanceSource(Resim);

                if (config.DumpBlackPoint)
                {
                    var bitmap = new BinaryBitmap(new HybridBinarizer(source));
                    dumpBlackPoint(Resim, bitmap, source);
                }

                var reader = new BarcodeReader { AutoRotate = config.AutoRotate };
                foreach (var entry in config.Hints)
                {
                    if (reader.Options.Hints.ContainsKey(entry.Key)) reader.Options.Hints[entry.Key] = entry.Value;
                    else reader.Options.Hints.Add(entry.Key, entry.Value);
                }

                Result[] results;
                if (config.Multi) results = reader.DecodeMultiple(source); 
                else results = new Result[] { reader.Decode(source) };

                if (config.TryHarder && (results == null || results.Length == 0 || results[0] == null))
                {
                    reader = new BarcodeReader(null, null, s => new GlobalHistogramBinarizer(s));
                    foreach (var entry in config.Hints)
                    {
                        if (reader.Options.Hints.ContainsKey(entry.Key)) reader.Options.Hints[entry.Key] = entry.Value;
                        else reader.Options.Hints.Add(entry.Key, entry.Value);
                    }

                    if (config.Multi) results = reader.DecodeMultiple(source);
                    else results = new Result[] { reader.Decode(source) };
                }

                if (results != null && results.Length > 0 && results[0] != null)
                {
                    Depo_ d = new Depo_();
                    for (int i = 0; i < results.Length; i++)
                    {
                        IDepo_Eleman yeni = d.Bul(i.ToString(), true);
                        yeni["İçerik"].İçeriği = new string[] { results[i].Text, results[i].RawBytes.HexYazıya() };

                        yeni["Tür"].İçeriği = new string[] { results[i].BarcodeFormat.ToString() };
                        for (int ii = 0; ii < results[i].ResultPoints.Length; ii++)
                        {
                            yeni["Tür/Sıfırlama Noktası/" + ii].İçeriği = new string[] { results[i].ResultPoints[ii].X.ToString(), results[i].ResultPoints[ii].Y.ToString() };
                        }

                        for (int ii = 0; ii < results[i].ResultMetadata.Count; ii++)
                        {
                            yeni["Detaylar/" + ii].İçeriği = new string[] { results[i].ResultMetadata.ElementAt(ii).Key.ToString(), results[i].ResultMetadata.ElementAt(ii).Value.ToString() };
                        }
                    }
                    return d.YazıyaDönüştür();
                }

                return "Bulunamadı";
            }
        }

        /**
         * Writes out a single PNG which is three times the width of the input image, containing from left
         * to right: the original image, the row sampling monochrome version, and the 2D sampling
         * monochrome version.
         */
        private static void dumpBlackPoint(Bitmap image, BinaryBitmap bitmap, LuminanceSource luminanceSource)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int stride = width * 4;
            var result = new Bitmap(stride, height, PixelFormat.Format32bppArgb);
            var offset = 0;

            // The original image
            for (int indexH = 0; indexH < height; indexH++)
            {
                for (int indexW = 0; indexW < width; indexW++)
                {
                    result.SetPixel(indexW, indexH, image.GetPixel(indexW, indexH));
                }
            }

            // Row sampling
            BitArray row = new BitArray(width);
            offset += width;
            for (int y = 0; y < height; y++)
            {
                row = bitmap.getBlackRow(y, row);
                if (row == null)
                {
                    // If fetching the row failed, draw a red line and keep going.
                    for (int x = 0; x < width; x++)
                    {
                        result.SetPixel(offset + x, y, Color.Red);
                    }
                    continue;
                }

                for (int x = 0; x < width; x++)
                {
                    result.SetPixel(offset + x, y, row[x] ? Color.Black : Color.White);
                }
            }

            // 2D sampling
            offset += width;
            BitMatrix matrix = bitmap.BlackMatrix;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result.SetPixel(offset + x, y, matrix[x, y] ? Color.Black : Color.White);
                }
            }

            offset += width;
            var luminanceMatrix = luminanceSource.Matrix;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result.SetPixel(offset + x, y, Color.FromArgb(luminanceMatrix[y * width + x], luminanceMatrix[y * width + x], luminanceMatrix[y * width + x]));
                }
            }

            #if DEBUG
                result.Save("mono.png", ImageFormat.Png);
            #endif
        }
    }

    class _Config
    {
        public IDictionary<DecodeHintType, object> Hints { get; set; }

        public bool TryHarder { get; set; }
        public bool TryInverted { get; set; }
        public bool PureBarcode { get; set; }
        public bool DumpBlackPoint { get; set; }
        public bool Multi { get; set; }
        public bool AutoRotate { get; set; }
    }
}
