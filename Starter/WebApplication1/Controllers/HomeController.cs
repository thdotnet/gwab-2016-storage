using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public async Task<ActionResult> Resize(string name)
        //{
        //}

        //public async Task<ActionResult> ListMessages()
        //{
        //}

        //public async Task<ActionResult> Gallery()
        //{
        //}

        //public async Task<ActionResult> Upload()
        //{
        //    if(Request.Files.Count > 0)
        //    {
        //        using (BlobService blobService = new BlobService())
        //        {
        //            HttpPostedFileWrapper file = Request.Files[0] as HttpPostedFileWrapper;

        //            var stream = file.InputStream;
        //            var fileName = file.FileName;

        //            await blobService.Upload(stream, fileName);
        //        }
        //    }
        //    return RedirectToAction("Gallery");
        //}

        //public async Task<ActionResult> Template(string emailTemplate)
        //{
        //}
    }
}