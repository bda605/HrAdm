using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //Excel import base controller
    abstract public class XpImportController : Controller 
    {
        public string ProgName;     //program name
        public string ImportType;   //map to ImportLog.Type
        public string PathTpl;      //template file path
        public string DirUpload;    //upload dir, no right slash

        public ActionResult Read()
        {			
            ViewBag.ProgName = ProgName;
            ViewBag.ImportType = ImportType;
            return View("/Views/XpImport/Read.cshtml"); //public view
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            //call public method
            return Content(new XpImportRead(ImportType).GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        //run import, drived class implement !!
        abstract public JsonResult Import(IFormFile file);

        /// <summary>
        /// download template file
        /// </summary>
        /// <param name="file">file name</param>
        /// <returns>file</returns>
        public FileResult Template()
        {
            //must PhysicalFile !!
            return PhysicalFile(PathTpl, ContentTypeEstr.Excel, _File.GetFileName(PathTpl));
        }

        //download source import file
        public FileResult GetSource(string id, string name)
        {
            return GetFile(id, name);
        }
        //download failed import file
        public FileResult GetFail(string id, string name)
        {
            return GetFile(id + "_fail", name);
        }
        //download import file
        private FileResult GetFile(string realFileStem, string downFileName)
        {
            return PhysicalFile($"{DirUpload}/{realFileStem}.xlsx", ContentTypeEstr.Excel, downFileName);
        }

    }//class
}