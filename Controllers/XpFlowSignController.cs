using Base.Enums;
using Base.Models;
using BaseWeb.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpFlowSignController : MyController
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
            return JsonToCnt(new XpFlowSignRead().GetPage(Ctrl, dt));
        }

        private XpFlowSignEdit EditService(string flowCode)
        {
            return new XpFlowSignEdit(Ctrl, flowCode);
        }

        [HttpPost]
        public ContentResult GetUpdateJson(string flowCode, string key)
        {
            return JsonToCnt(EditService(flowCode).GetUpdateJson(key));
        }

        [HttpPost]
        public ContentResult GetViewJson(string flowCode, string key)
        {
            return JsonToCnt(EditService(flowCode).GetViewJson(key));
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
            return PartialView("Views/Leave/_SignRows.cshtml", new LeaveService().GetSignRows(id));
        }

    }//class
}