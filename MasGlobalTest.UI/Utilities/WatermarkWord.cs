
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Drawing;

namespace Legis.UtilityLayer.Helper
{
    public class WatermarkWord
    {
        //Url https://help.syncfusion.com/file-formats/docio/applying-watermark
        public void AddWatermarkWork()
        {

            ////Creates a new Word document
            //WordDocument document = new WordDocument();

            ////Adds a section and a paragraph in the document
            //document.EnsureMinimal();
            //IWParagraph paragraph = document.LastParagraph;
            //paragraph.AppendText("AdventureWorks Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company.");


            string strDoc = @"E:\MEDRAR\docs examples\pruebas para marca de agua.doc";
            Stream stream = File.Open(strDoc, FileMode.Open);

            // Loads an existing Word document.
            WordDocument wordDocument = new WordDocument(stream, FormatType.Doc);

            // Gets the image from file.
            Image image = Image.FromFile(@"E:\MEDRAR\docs examples\watermaktest.png");

            //Creates a new picture watermark
            PictureWatermark picWatermark = new PictureWatermark();

            //Sets the scaling to picture
            picWatermark.Scaling = 120f;
            picWatermark.Washout = true;

            //Sets the picture watermark to document
            wordDocument.Watermark = picWatermark;

            // Sets the image to the picture watermark ,Saves Word document and closes WordDocument instance.
            picWatermark.Picture = Image.FromFile(@"E:\MEDRAR\docs examples\watermaktest.png");
            
            //save documento whit watermark
            string strDocWatermark = @"E:\MEDRAR\docs examples\watermaktest.doc";
            Stream streamDocWatermark = File.Open(strDocWatermark, FileMode.Open);
            wordDocument.Save(streamDocWatermark, FormatType.Docx);
            wordDocument.Close();




            //string strDocWatermark = @"E:\MEDRAR\docs examples\DocWhitWaterMark.doc";
            //Stream streamDocWatermark = File.Open(strDocWatermark, FileMode.Open);
            //wordDocument.Save(streamDocWatermark, FormatType.Doc);
            //wordDocument.Close();


            //using (Image image = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg"))
            //using (Image watermarkImage = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\watermark.png"))
            //using (Graphics imageGraphics = Graphics.FromImage(image))
            //using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
            //{
            //    int x = (image.Width / 2 - watermarkImage.Width / 2);
            //    int y = (image.Height / 2 - watermarkImage.Height / 2);
            //    watermarkBrush.TranslateTransform(x, y);
            //    imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
            //    image.Save(@"C:\Users\Public\Pictures\Sample Pictures\Desert_watermark.jpg");
            //}
        }

        public Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }

        public byte[] ConvertImageToByte(Image imageFromFile)
        {
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                imageFromFile.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }

            return arr;
        }
    }
}
