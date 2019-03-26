using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;

namespace Legis.UtilityLayer.Helper
{
    public class ConvertHtml
    {
        //url https://help.syncfusion.com/file-formats/docio/html
        public void ConvertHtmlToWord()
        {
            string strHtml = @"E:\MEDRAR\docs examples\how to open.html";
            Stream stream = File.Open(strHtml, FileMode.Open);

            //Loads the HTML document against transitional schema validation
            WordDocument document = new WordDocument(stream, FormatType.Html, XHTMLValidationType.Transitional);

            //Saves the Word document
            string strHtmlToDoc = @"E:\MEDRAR\docs examples\htmltoDoc.doc";
            Stream streamDoc = File.Open(strHtmlToDoc, FileMode.Open);
            document.Save(streamDoc, FormatType.Docx);

            //Closes the document
            document.Close();
        }

    }
}
