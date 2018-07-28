using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static LMT.AspNet.ViewToPdf.PdfView;

namespace Lmt.AspNet.ViewToPdf.Test.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index()
        {
            return this.Pdf("index", "world");
        }
    }
}