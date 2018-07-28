using System.IO;
using System.Web.Mvc;

namespace LMT.AspNet.ViewToPdf
{
    internal static class HtmlExtension
    {
        internal static string ToHtmlString(this Controller controller, string viewName, object model)
        {
            using (var stringWriter = new StringWriter())
            {
                var viewResult = controller.ViewEngineCollection.FindPartialView(controller.ControllerContext, viewName);

                controller.ViewData.Model = model;

                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, stringWriter);

                viewResult.View.Render(viewContext, stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
