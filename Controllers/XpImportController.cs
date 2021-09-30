using Base.Models;
using BaseWeb.Controllers;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //Excel import base controller
    abstract public class XpImportController : XpCtrl 
    {
        //public string ProgName;     //program display name
        public string ImportType;   //map to ImportLog.Type
        public string TplPath;      //template file path
        public string DirUpload;    //upload dir, no right slash

        public ActionResult Read()
        {			
            //ViewBag.ProgName = ProgName;
            ViewBag.ImportType = ImportType;
            return View("/Views/XpImport/Read.cshtml"); //public view
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpImportRead(ImportType).GetPageAsync(Ctrl, dt));
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
            return _WebFile.ViewFile(TplPath);  //use this instead of PhysicalFile()
        }

        //download source import file
        public FileResult GetSource(string id, string name)
        {
            return GetFile(id, name);
            /*
            var file = GetFile(id, name);
            return (file == null)
                ? NotFound() : file;
            */
        }

        //download failed import file
        public FileResult GetFail(string id, string name)
        {
            return GetFile(id + "_fail", name);
        }

        //download import file
        private FileResult GetFile(string realFileStem, string downFileName)
        {
            return _WebFile.ViewFile($"{DirUpload}/{realFileStem}.xlsx", downFileName);
        }

    }//class
}