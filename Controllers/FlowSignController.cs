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
using BaseFlow.Services;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class FlowSignController : Controller
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
            return Content(new FlowSignRead().GetPage(dt).ToString(), _Web.AppJson);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new FlowSignEdit().GetJson(key).ToString(), _Web.AppJson);
        }

        /// <summary>
        /// sign one row
        /// </summary>
        /// <param name="id">FlowSign.Id</param>
        /// <param name="status">signStatus</param>
        /// <param name="note">sign note</param>
        /// <returns>ResultDto</returns>
        [HttpPost]
        public JsonResult SignRow(string id, string status, string note)
        {
            return Json(_Flow.SignRow(id, (status == "Y"), note, "Leave"));
        }

        //TODO: add your code
        //get file/image
        public FileContentResult GetFile(string table, string fid, string key)
        {
            var path = _File.GetFirstPath(_Xp.GetDirLeave(), "FileName_" + key, _Xp.NoImagePath);
            return _WebFile.EchoImage(path);
        }

    }//class
}