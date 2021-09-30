using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class UserExtController : XpCtrl
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.Depts = _XpCode.GetDeptsAsync();
			//for edit view
			ViewBag.LangLevels = _XpCode.GetLangLevelsAsync(_Xp.GetLocale0());
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserExtRead().GetPage(Ctrl, dt));
        }

        private UserExtEdit EditService()
        {
            return new UserExtEdit(Ctrl);
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Str.ToJson(json), t0_PhotoFile, t03_FileName));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Str.ToJson(json), t0_PhotoFile, t03_FileName));
        }

        //TODO: add your code
        //get file/image
        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            return (fid == "PhotoFile")
                ? _Xp.ViewUserExt(fid, key, ext)
                : _Xp.ViewUserLicense(fid, key, ext);
        }

        /*
        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[UserExt]", "Id", key, status));
        }
        */

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().DeleteAsync(key));
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

        //generate word resume
        public void GenWord(string id)
        {
            //for testing exception
            //_Fun.Except();

            new UserExtService().GenWord(id);
        }

    }//class
}