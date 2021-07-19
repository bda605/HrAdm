using Base.Models;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpTranLogController : MyCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new XpTranLogRead().GetPage(Ctrl, dt));
        }

    }//class
}