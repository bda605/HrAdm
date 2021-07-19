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
    public class UserExtController : MyCtrl
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.Depts = _XpCode.GetDepts();
			//for edit view
			ViewBag.LangLevels = _XpCode.GetLangLevels(_Xp.GetLocale0());
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new UserExtRead().GetPage(Ctrl, dt));
        }

        private UserExtEdit EditService()
        {
            return new UserExtEdit(Ctrl);
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Json.StrToJson(json), t0_PhotoFile, t03_FileName));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Json.StrToJson(json), t0_PhotoFile, t03_FileName));
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
            return Json(EditService().Delete(key));
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

        public void GenWord(string id)
        {
            new UserExtService().GenWord(id);
        }

    }//class
}