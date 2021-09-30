using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class UserController : XpCtrl
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.Depts = _XpCode.GetDeptsAsync();
			//for edit view
			ViewBag.Roles = _XpCode.GetRolesAsync();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserRead().GetPage(Ctrl, dt));
        }

        private UserEdit EditService()
        {
            return new UserEdit(Ctrl);
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(EditService().CreateAsync(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(EditService().UpdateAsync(key, _Str.ToJson(json)));
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
            return Json(EditService().DeleteAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

    }//class
}