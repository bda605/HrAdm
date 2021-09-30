using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    public class XpEasyRptController : XpCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpEasyRptRead().GetPageAsync(Ctrl, dt));
        }

        private XpEasyRptEdit EditService()
        {
            return new XpEasyRptEdit(Ctrl);
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

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(EditService().CreateAsync(_Str.ToJson(json)));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(EditService().UpdateAsync(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().DeleteAsync(key));
        }

    }//class
}