using Base.Models;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class LeaveSignController : XpCtrl
    {
        public ActionResult Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            ViewBag.SignStatuses2 = _XpCode.GetSignStatuses2Async(locale0);
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new LeaveSignRead().GetPage(Ctrl, dt));
        }

        private LeaveSignEdit EditService()
        {
            return new LeaveSignEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

        /// <summary>
        /// sign one row
        /// </summary>
        /// <param name="id">XpFlowSign.Id</param>
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
        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            return _Xp.ViewLeave(fid, key, ext);
        }

    }//class
}