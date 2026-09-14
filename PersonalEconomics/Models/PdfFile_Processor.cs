using System;
using System.Drawing;
using System.IO;
using Docnet.Core;
using Docnet.Core.Models;
using System.Runtime.InteropServices;

using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Net;


public sealed class PdfThumbnail {
    public byte[] Pixels { get; }
    public int Width { get; }
    public int Height { get; }

    public PdfThumbnail(byte[] pixels, int width, int height) {
        Pixels = pixels;
        Width = width;
        Height = height;
    }
}

public class PdfFile_Processor {
    public string FileName { get; }
    public string FilePath { get; }
    public object? Thumbnail { get; set; }

    public PdfFile_Processor(string filePath) {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        FileName = Path.GetFileName(filePath);

        Thumbnail = CreateThumbnail(filePath);
    }

    public static PdfThumbnail? CreateThumbnail(string pdfPath) {
        try {
            using var docLib = DocLib.Instance;
            using var docReader = docLib.GetDocReader(
                pdfPath,
                new PageDimensions(200, 280));

            using var pageReader = docReader.GetPageReader(0);

            var rawBytes = pageReader.GetImage();

            var width = pageReader.GetPageWidth();
            var height = pageReader.GetPageHeight();

            // Make a copy because the underlying page reader owns
            // the original image buffer.
            var pixels = new byte[rawBytes.Length];
            Array.Copy(rawBytes, pixels, rawBytes.Length);

            return new PdfThumbnail(pixels, width, height);
        } catch {
            return null;
        }
    }
}

public static class AvaloniaPdfThumbnailConverter {
    public static Avalonia.Media.Imaging.Bitmap ToBitmap(PdfThumbnail thumbnail) {
        var bitmap = new WriteableBitmap(
            new PixelSize(thumbnail.Width, thumbnail.Height),
            new Vector(96, 96),
            PixelFormat.Bgra8888,
            AlphaFormat.Opaque);

        using var framebuffer = bitmap.Lock();

        Marshal.Copy(thumbnail.Pixels, 0, framebuffer.Address, thumbnail.Pixels.Length);

        return bitmap;
    }
}