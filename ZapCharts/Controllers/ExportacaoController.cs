using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZapCharts.Controllers
{
    public class ExportacaoController : Controller
    {
        // GET: Exportacao
        [HttpPost, ValidateInput(false)]
        public ActionResult GeraPDF(string conteudoPdf)
        {
            conteudoPdf = string.IsNullOrEmpty(conteudoPdf) ? "Arquivo sem dados ..." : conteudoPdf;
            //var x = View("_ReportTemplate", conteudoPdf).ToString();
            var arquivoPDF = CriaPDF(conteudoPdf);
            DownloadPDF(arquivoPDF);
            return View();
        }
        private byte[] CriaPDF(string htmlConteudo)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(htmlConteudo);
            const float margemDoPDF = 25;
            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, margemDoPDF, margemDoPDF, margemDoPDF, margemDoPDF);



            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();
            bPDF = ms.ToArray();
            return bPDF;
        }
        private void DownloadPDF(byte[] bPDF)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToShortDateString() + "-arquivo.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bPDF);
            Response.End();
        }
    }
}