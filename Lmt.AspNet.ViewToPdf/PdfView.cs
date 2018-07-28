using SelectPdf;
using System.Web.Mvc;

namespace LMT.AspNet.ViewToPdf
{
    /// <summary>
    /// LMT.AspNet.ViewToPdf extension
    /// </summary>
    public static class PdfView
    {
        /// <summary>
        /// Return view as Pdf
        /// </summary>
        /// <param name="controller">Controller handling the pdf request</param>
        /// <param name="viewName">Name of view (not view path)</param>
        /// <param name="model">View's model</param>
        /// <returns></returns>
        public static FileResult Pdf(this Controller controller, string viewName, object model = null)
        {
            var htmlString = controller.ToHtmlString(viewName, model);

            var converter = new HtmlToPdf();
            var doc = converter.ConvertHtmlString(htmlString);
            var pdfByte = doc.Save();
            doc.Close();

            return typeof(Controller)
                .GetMethod("File", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, new[] { typeof(byte[]), typeof(string) }, null)
                .Invoke(controller, new object []{ pdfByte, "application/pdf" }) as FileResult;
        }
    }
}
