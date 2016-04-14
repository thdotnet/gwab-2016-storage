using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Resize(string name)
        {
            if(string.IsNullOrWhiteSpace(name) == false)
            {
                using(QueueStorageService queueService = new QueueStorageService())
                {
                    await queueService.AddMessage(name);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ListMessages()
        {
            using (QueueStorageService queueService = new QueueStorageService())
            {
                var messages = await queueService.ListMessages();
                
                return Content(String.Join(" ", messages));
            }
        }

        public async Task<ActionResult> Gallery()
        {
            BlobService blobService = new BlobService();

            var images = await blobService.List();

            return View(images);
        }

        public async Task<ActionResult> Upload()
        {
            if(Request.Files.Count > 0)
            {
                using (BlobService blobService = new BlobService())
                {
                    HttpPostedFileWrapper file = Request.Files[0] as HttpPostedFileWrapper;

                    var stream = file.InputStream;
                    var fileName = file.FileName;

                    await blobService.Upload(stream, fileName);
                }
            }
            return RedirectToAction("Gallery");
        }

        public async Task<ActionResult> Template(string emailTemplate)
        {
            using (TableService service = new TableService())
            {
                await service.AddTemplate(emailTemplate);
            }
            return Content(emailTemplate);
        }
    }
}