using HrAdm.Enums;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class UserImportController : XpImportController
    {
        //constructor
        public UserImportController()
        {
            //ProgName = "匯入用戶資料";
            ImportType = ImportTypeEstr.User;
            PathTpl = _Xp.DirTpl + "/UserImport.xlsx";
            DirUpload = _Xp.DirUserImport;
        }

        //overwrite
        [HttpPost]
        override public JsonResult Import(IFormFile file)
        {
            return Json(new UserImportService().Import(file));
        }

    }//class
}