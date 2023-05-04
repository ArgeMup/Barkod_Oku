# Barkod_Oku
Genel amaçlı kamera veya resimden barkod okuma uygulaması ArgeMup@yandex.com

## Thanks
Many thanks to the team of the [opencvsharp project](https://github.com/shimat/opencvsharp) for their great work. Barkod_Oku would not be possible without your work!

Many thanks to the team of the [zxing.net project](https://https://github.com/micjahn/ZXing.Net) for their great work. Barkod_Oku would not be possible without your work!

Many thanks to the team of the [zxing project](https://github.com/zxing/zxing) for their great work. ZXing.Net would not be possible without your work!

    Seçenek 1 - Barkod_Oku.exe <Komut Verme Depo Dosyasının Yolu>
    Seçenek 2 - Barkod_Oku.exe <Komut Verme Depo Dosyası İçeriğinin Base64 Hali>
    Seçenek 3 - Barkod_Oku.exe YeniYazilimKontrolu                                  (Kontrolü bitirip kapanır)
    Seçenek 4 - Barkod_Oku.exe                                                      (Bu durumda değişiklikleri kendi alt klasörüne kaydeder)

    Komut Verme Depo Dosyası İçeriği
        Komut / Ayarla VEYA
        Komut / Çalıştır
        Ayarlar / <Ayarlar Depo Dosya Yolu>

    Uygulama "Çalıştır" komutuyla çalıştırıldığında "Çalıştır.mup" dosyasının üretilmesini veya son değişiklik tarihinin değişmesini bekler.
        <Kök Klasör - ...\Barkod_Oku.exe dosya yolu>\Çalıştır.mup

    Çalıştır Depo Dosyası İçeriği
        Komut / Barkod Oku veya
        Komut / Resim Çek veya
        Komut / Kamera Bağlı Mı
        Resimler / <Okuma Tarihi>
            <Resim No> / <Dosya Yolu>
        Kamera Bağlı Mı / bit
        Barkodlar / <Okuma Tarihi>
            <Barkod No>
                İçerik / <yazı> / <hex>
                Tür / <Tür - BarcodeFormat>
                    Sıfırlama Noktası
                        <Sıra No> / <Sol - piksel> / <Üst - piksel>
                Detaylar (Barkoda göre değişken)
                    <Sıra No> / QR_MASK_PATTERN / <Detay>
                    <Sıra No>
                        BYTE_SEGMENTS
                            <Sıra No> / <Detay>
                    <Sıra No> / ERROR_CORRECTION_LEVEL / <Detay>
                    <Sıra No> / SYMBOLOGY_IDENTIFIER / <Detay>
                    <Sıra No> / ORIENTATION / <Detay>
        
    Ayarlar Depo Dosyası İçeriği
        Detaylar
            Kamera No / Tamsayı
            Karakter Kodlama / ASCII veya UTF-8
            Tür / Tümü veya <BarcodeFormat> / <BarcodeFormat> / ...
            AutoRotate
            Multi
            TRY_HARDER
            DumpBlackPoint
            PURE_BARCODE
            ASSUME_CODE_39_CHECK_DIGIT
            ASSUME_MSI_CHECK_DIGIT
            USE_CODE_39_EXTENDED_MODE
            RELAXED_CODE_39_EXTENDED_MODE
            TRY_HARDER_WITHOUT_ROTATION
            ASSUME_GS1
            RETURN_CODABAR_START_END
            ALSO_INVERTED