using Base.Enums;
using Base.Models;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class LeaveSignController : Controller
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.LeaveTypes = _XpCode.GetLeaveTypes();
			ViewBag.SignStatuses = _XpCode.GetSignStatuses();
			//for edit view
			ViewBag.Users = _XpCode.GetUsers();
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new LeaveSignRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new LeaveSignEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
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
            return Json(_XpFlow.SignRow(id, (status == "Y"), note, "Leave"));
        }

        //TODO: add your code
        //get file/image
        public FileContentResult GetFile(string table, string fid, string key)
        {
            return _Xp.FileLeave(key);
        }

    }//class
}