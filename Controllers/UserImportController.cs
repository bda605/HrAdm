using HrAdm.Enums;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //1.inherit
    //[XgProgAuth]
    public class UserImportController : XpImportController
    {
        //2.constructor
        public UserImportController()
        {
            //ProgName = "Import User";
            ImportType = ImportTypeEstr.User;
            TplPath = _Xp.DirTpl + "/UserImport.xlsx";
            DirUpload = _Xp.DirUserImport;
        }

        //3.override
        [HttpPost]
        override public JsonResult Import(IFormFile file)
        {
            return Json(new UserImportService().ImportAsync(file, this.DirUpload));
        }

    }//class
}