using HtmlRendererCore.PdfSharp;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.IO;

namespace ConvertHtmlToPdf
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public void ConvertHtmlToPdf(string html, string dstinationFilePath)
        {
            var pdf = new PdfDocument();
            var pdfConfig = new PdfGenerateConfig();
            pdfConfig.PageSize = PageSize.A4;
            PdfGenerator.AddPdfPages(pdf, html, PageSize.A4);

            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                pdf.Save(ms);
                res = ms.ToArray();
            }

            File.WriteAllBytes(dstinationFilePath, res);
        }
    }
}
