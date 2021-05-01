﻿using Base.Enums;
using Base.Models;
using Base.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class UserExtController : Controller
    {
        public ActionResult Read()
        {
			//for read view
			ViewBag.Depts = _XpCode.GetDepts();
			//for edit view
			ViewBag.LangLevels = _XpCode.GetLangLevels();
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new UserExtRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await new UserExtEdit().CreateAsnyc(_Json.StrToJson(json), t0_PhotoFile, t03_FileName));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await new UserExtEdit().UpdateAsnyc(key, _Json.StrToJson(json), t0_PhotoFile, t03_FileName));
        }

        //TODO: add your code
        //get file/image
        public FileContentResult GetFile(string table, string fid, string key)
        {
            return (fid == "PhotoFile")
                ? _Xp.FileUserExt(key)
                : _Xp.FileUserLicense(key);
        }

        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[UserExt]", "Id", key, status));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new UserExtEdit().Delete(key));
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new UserExtEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

        public void GenWord(string id)
        {
            new UserExtService().GenDocu(id);
        }

    }//class
}