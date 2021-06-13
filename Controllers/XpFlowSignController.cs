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
            ViewBag.Flows = _XpCode.GetFlows();
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new XpFlowSignRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public ContentResult GetJson(string flowCode, string key)
        {
            return Content(new XpFlowSignEdit().GetJson(flowCode, key).ToString(), ContentTypeEstr.Json);
        }

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