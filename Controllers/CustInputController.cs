using Base.Enums;
using Base.Models;
using Base.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    public class CustInputController : Controller
    {
        public ActionResult Read()
        {
			//for edit view
			ViewBag.Radios = _XpCode.GetRadios();
			ViewBag.Selects = _XpCode.GetSelects();
            return View();
        }

        /*
        public ActionResult Edit()
        {
            return View();
        }
        */

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new CustInputRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new CustInputEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.CustInput", "Id", key, status));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_FldFile)
        {
            return Json(await new CustInputEdit().CreateAsnyc(_Json.StrToJson(json), t0_FldFile));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FldFile)
        {
            return Json(await new CustInputEdit().UpdateAsnyc(key, _Json.StrToJson(json), t0_FldFile));
        }

        //TODO: add your code
        //get file/image
        public FileContentResult GetFile(string table, string fid, string key)
        {
            return _Xp.FileCustInput(key);
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new CustInputEdit().Delete(key));
        }

    }//class
}