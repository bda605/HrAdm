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
    //CMS base controller, abstract class
    abstract public class XpCmsController : XpCtrl 
    {
        //public string ProgName;     //program name
        public string CmsType;      //map to CmsTypeEstr
        public string DirUpload;    //upload dir, no right slash
        public CmsEditDto EditDto;

        //use shared view
        public ActionResult Read()
        {			
            //ViewBag.ProgName = ProgName;
            ViewBag.CmsType = CmsType;
            return View("/Views/XpCms/Read.cshtml", EditDto); //public view
        }

        //read rows with cmsType
        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new XpCmsRead(CmsType).GetPage(Ctrl, dt));
        }

        private XpCmsEdit EditService()
        {
            return new XpCmsEdit(Ctrl);
        }

        //by dirUpload & cmsType
        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Json.StrToJson(json), t0_FileName, DirUpload, CmsType));
        }

        //by dirUpload
        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Json.StrToJson(json), t0_FileName, DirUpload));
        }

        //by cmsType
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