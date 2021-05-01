using Base.Enums;
using Base.Models;
using Base.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    public class XpEasyRptController : Controller
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new XpEasyRptRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpEasyRptEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(new XpEasyRptEdit().Create(_Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(new XpEasyRptEdit().Update(key, _Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new CustInputEdit().Delete(key));
        }

    }//class
}