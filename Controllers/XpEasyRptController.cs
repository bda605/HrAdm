using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    public class XpEasyRptController : XpCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new XpEasyRptRead().GetPage(Ctrl, dt));
        }

        private XpEasyRptEdit EditService()
        {
            return new XpEasyRptEdit(Ctrl);
        }

        [HttpPost]
        public ContentResult GetUpdateJson(string key)
        {
            return JsonToCnt(EditService().GetUpdateJson(key));
        }

        [HttpPost]
        public ContentResult GetViewJson(string key)
        {
            return JsonToCnt(EditService().GetViewJson(key));
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(EditService().Create(_Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(EditService().Update(key, _Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().Delete(key));
        }

    }//class
}