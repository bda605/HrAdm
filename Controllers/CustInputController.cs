using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    public class CustInputController : MyController
    {
        public ActionResult Read()
        {
			//for edit view
			ViewBag.Radios = _XpCode.GetRadios();
			ViewBag.Selects = _XpCode.GetSelects();
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new CustInputRead().GetPage(Ctrl, dt));
        }

        private CustInputEdit EditService()
        {
            return new CustInputEdit(Ctrl);
        }

        [HttpPost]
        public ContentResult GetUpdateJson(string key)
        {
            return JsonToCnt(EditService().GetUpdateJson(key));
        }

        [HttpPost]
        public ContentResult GetViewJson(string key)
        {
            return JsonToCnt(EditService().GetViewJson(key));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FldFile)
        {
            return Json(await EditService().CreateAsnyc(_Json.StrToJson(json), t0_FldFile));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FldFile)
        {
            return Json(await EditService().UpdateAsnyc(key, _Json.StrToJson(json), t0_FldFile));
        }

        //get file/image
        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            return _Xp.ViewCustInput(fid, key, ext);
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().Delete(key));
        }

        /// <summary>
        /// upload html image, image fileName: time string
        /// </summary>
        /// <param name="file"></param>
        /// <param name="prog"></param>
        /// <returns>return url</returns>
        public async Task<string> SetHtmlImage(IFormFile file, string prog)
        {
            var fileName = await _WebFile.SaveHtmlImage(file, prog);
            return $"/image/{prog}/{fileName}";
        }

    }//class
}