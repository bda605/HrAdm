using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Attributes;
using BaseWeb.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class LeaveController : XpCtrl
    {
        public ActionResult Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            ViewBag.LeaveTypes = _XpCode.GetLeaveTypes(locale0);
			ViewBag.SignStatuses = _XpCode.GetSignStatuses(locale0);
			//for edit view
			ViewBag.Users = _XpCode.GetUsers();
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new LeaveRead().GetPage(Ctrl, dt));
        }

        private LeaveEdit EditService()
        {
            return new LeaveEdit(Ctrl);
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Create)]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Json.StrToJson(json), t0_FileName));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public ContentResult GetUpdateJson(string key)
        {
            return JsonToCnt(EditService().GetUpdateJson(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Json.StrToJson(json), t0_FileName));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Delete)]
        public JsonResult Delete(string key)
        {
            return Json(EditService().Delete(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public ContentResult GetViewJson(string key)
        {
            return JsonToCnt(EditService().GetViewJson(key));
        }

        //get file/image
        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            return _Xp.ViewLeave(fid, key, ext);
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">Leave.Id</param>
        /// <returns></returns>
        public ActionResult GetSignRows(string id)
        {
            return PartialView("_SignRows", new LeaveService().GetSignRows(id));
        }

    }//class
}