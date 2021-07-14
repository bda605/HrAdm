using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using HrAdm.Models;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //CMS base controller
    abstract public class XpCmsController : MyController 
    {
        //public string ProgName;     //program name
        public string CmsType;   //map to ImportLog.Type
        public string DirUpload;    //upload dir, no right slash
        public CmsEditDto EditDto;

        public ActionResult Read()
        {			
            //ViewBag.ProgName = ProgName;
            ViewBag.CmsType = CmsType;
            return View("/Views/XpCms/Read.cshtml", EditDto); //public view
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new XpCmsRead(CmsType).GetPage(Ctrl, dt));
        }

        private XpCmsEdit EditService()
        {
            return new XpCmsEdit(Ctrl);
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Json.StrToJson(json), t0_FileName, DirUpload, CmsType));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Json.StrToJson(json), t0_FileName, DirUpload));
        }

        /*
        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[User]", "Id", key, status));
        }
        */

        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            return _Xp.ViewCmsType(fid, key, ext, CmsType);
        }

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

    }//class
}