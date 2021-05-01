using Base.Enums;
using Base.Models;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpTranLogController : Controller
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new XpTranLogRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        /*
        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpTranLogEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }
        */

    }//class
}