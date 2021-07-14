using Base.Models;
using BaseWeb.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpTranLogController : MyController
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