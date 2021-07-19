using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class UserController : MyCtrl
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.Depts = _XpCode.GetDepts();
			//for edit view
			ViewBag.Roles = _XpCode.GetRoles();
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new UserRead().GetPage(Ctrl, dt));
        }

        private UserEdit EditService()
        {
            return new UserEdit(Ctrl);
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(EditService().Create(_Json.StrToJson(json)));
        }

        [HttpPost]
        public ContentResult GetUpdateJson(string key)
        {
            return JsonToCnt(EditService().GetUpdateJson(key));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(EditService().Update(key, _Json.StrToJson(json)));
        }

        /*
        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[User]", "Id", key, status));
        }
        */

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().Delete(key));
        }

        [HttpPost]
        public ContentResult GetViewJson(string key)
        {
            return JsonToCnt(EditService().GetViewJson(key));
        }

    }//class
}