using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using BaseWeb.Attributes;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class LeaveController : Controller
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.LeaveTypes = _Code.GetLeaveTypes();
			ViewBag.SignStatuses = _Code.GetSignStatuses();
			//for edit view
			ViewBag.Users = _Code.GetUsers();
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new LeaveRead().GetPage(dt).ToString(), _Web.AppJson);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new LeaveEdit().GetJson(key).ToString(), _Web.AppJson);
        }

        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[Leave]", "Id", key, status));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await new LeaveEdit().CreateAsnyc(_Json.StrToJson(json), t0_FileName));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await new LeaveEdit().UpdateAsnyc(key, _Json.StrToJson(json), t0_FileName));
        }

        //TODO: add your code
        //get file/image
        public FileContentResult GetFile(string table, string fid, string key)
        {
            var path = _File.GetFirstPath(_Xp.GetDirLeave(), "FileName_" + key, _Xp.NoImagePath);
            return _WebFile.EchoImage(path);
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new LeaveEdit().Delete(key));
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">Leave.Id</param>
        /// <returns></returns>
        public ActionResult SignRows(string id)
        {
            return PartialView("_SignRows", new LeaveService().GetSignRows(id));
        }

    }//class
}