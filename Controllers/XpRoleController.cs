using Base.Enums;
using Base.Models;
using Base.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpRoleController : Controller
    {
        public ActionResult Read()
        {
            //for edit view
            ViewBag.Users = _XpCode.GetUsers();
            ViewBag.Progs = _XpCode.GetProgs();
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new XpRoleRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(new XpRoleEdit().Create(_Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(new XpRoleEdit().Update(key, _Json.StrToJson(json)));
        }

        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[Role]", "Id", key, status));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new XpRoleEdit().Delete(key));
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpRoleEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

    }//class
}