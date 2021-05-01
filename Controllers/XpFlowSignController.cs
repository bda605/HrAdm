using Base.Enums;
using Base.Models;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpFlowSignController : Controller
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
            return Content(new XpFlowSignRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpFlowSignEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

        //TODO: add your code
        //get file/image
        public FileContentResult GetFile(string table, string fid, string key)
        {
            return _Xp.FileLeave(key);
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">Leave.Id</param>
        /// <returns></returns>
        public ActionResult GetSignRows(string id)
        {
            return PartialView("Views/Leave/_SignRows.cshtml", new LeaveService().GetSignRows(id));
        }

    }//class
}