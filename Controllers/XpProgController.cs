using Base.Enums;
using Base.Models;
using Base.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpProgController : Controller
    {
        public ActionResult Read()
        {
			//for edit view
			ViewBag.Roles = _XpCode.GetRoles();
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new ProgRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(new XpProgEdit().Create(_Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(new XpProgEdit().Update(key, _Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new XpProgEdit().Delete(key));
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpProgEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

    }//class
}