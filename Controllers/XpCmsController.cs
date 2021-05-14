using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using HrAdm.Models;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //CMS base controller
    abstract public class XpCmsController : Controller 
    {
        public string ProgName;     //program name
        public string CmsType;   //map to ImportLog.Type
        //public string PathTpl;      //template file path
        public string DirUpload;    //upload dir, no right slash
        public CmsEditDto EditDto;

        public ActionResult Read()
        {			
            ViewBag.ProgName = ProgName;
            ViewBag.CmsType = CmsType;
            return View("~/Views/XpCms/Read.cshtml", EditDto); //public view
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            //call public method
            return Content(new XpCmsRead(CmsType).GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await new XpCmsEdit().CreateAsnyc(_Json.StrToJson(json), t0_FileName, DirUpload, CmsType));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await new XpCmsEdit().UpdateAsnyc(key, _Json.StrToJson(json), t0_FileName, DirUpload));
        }

        /*
        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[User]", "Id", key, status));
        }
        */

        public FileContentResult GetFile(string table, string fid, string key)
        {
            return _Xp.FileCmsType(key, CmsType);
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new XpCmsEdit().Delete(key));
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpCmsEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

    }//class
}