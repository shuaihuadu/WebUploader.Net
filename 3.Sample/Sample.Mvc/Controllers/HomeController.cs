using System.Web.Mvc;
using WebUploader.Net.Handlers;
using WebUploader.Net.Models;

namespace Sample.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Upload(UploadType type = UploadType.Image)
        {
            return Json(WebUploaderHandler.Process(System.Web.HttpContext.Current, type));
        }
    }
}