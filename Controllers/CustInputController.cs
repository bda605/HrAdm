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
    public class CustInputController : XpCtrl
    {
        public ActionResult Read()
        {
            //for testing exception
            //_Fun.Except();

			//for edit view
			ViewBag.Radios = _XpCode.GetRadios();
			ViewBag.Selects = _XpCode.GetSelects();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            //testing error case
            //return JsonToCnt(_Json.GetError());

            return JsonToCnt(await new CustInputRead().GetPage(Ctrl, dt));
        }

        private CustInputEdit EditService()
        {
            return new CustInputEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            //_Fun.Except();
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            //_Fun.Except();
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_FldFile)
        {
            //_Fun.Except();
            return Json(await EditService().CreateAsnyc(_Str.ToJson(json), t0_FldFile));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FldFile)
        {
            //_Fun.Except();
            return Json(await EditService().UpdateAsnyc(key, _Str.ToJson(json), t0_FldFile));
        }

        //TODO: add your code
        //get file/image
        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            //for testing exception
            //_Fun.Except();

            return _Xp.ViewCustInput(fid, key, ext);
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            //testing error case
            //return Json(_Model.GetError());

            return Json(EditService().DeleteAsync(key));
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