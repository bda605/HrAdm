using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpProgController : MyCtrl
    {
        public ActionResult Read()
        {
            //for edit view
            using (var db = new Db())
            {
                ViewBag.Roles = _XpCode.GetRoles(db);
                ViewBag.AuthRanges = _XpCode.GetAuthRanges(_Xp.GetLocale0(), db);
            }
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new XpProgRead().GetPage(Ctrl, dt));
        }

        private XpProgEdit EditService()
        {
            return new XpProgEdit(Ctrl);
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

    }//class
}