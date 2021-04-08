using Base.Services;
using BaseWeb.Services;
using HrAdm.Tables;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Services
{
    //project service
    public static class _Xp
    {
        //public const string SiteVer = "20201228f";     //for my.js/css
        public static string SiteVer = _Date.NowSecStr();
        public const string LibVer = "20210325";    //for lib.js/css

        public static string NoImagePath = _Fun.DirRoot + "/wwwroot/images/noImage.jpg";

        //dir
        public static string DirTpl = _Fun.DirRoot + "_template/";
        public static string DirUpload = _Fun.DirRoot + "_upload/";
        public static string DirLeave = DirUpload + "Leave";
        public static string DirUserExt = DirUpload + "UserExt";
        public static string DirUserLicense = DirUpload + "UserLicense";
        public static string DirCustInput = DirUpload + "CustInput";
        public static string DirUserImport = DirUpload + "UserImport";
        //dir cms
        public static string DirCms = DirUpload + "Cms";

        //public static string Locale;
        //public static string LocaleNoDash;

        //view columns 
        //public static int[] ViewCols = new int[] { 12, 2, 3 };

        public static MyContext GetDb()
        {
            return new MyContext();
        }

        #region get file path
        public static string PathUserExt(string key)
        {
            return _File.GetFirstPath(DirUserExt, "PhotoFile_" + key, NoImagePath);
        }
        #endregion

        public static string DirCmsType(string cmsType)
        {
            return DirCms + cmsType;
        }

        #region get file content
        public static FileContentResult FileLeave(string key)
        {
            var path = _File.GetFirstPath(DirLeave, "FileName_" + key, NoImagePath);
            return _WebFile.EchoImage(path);
        }

        public static FileContentResult FileUserExt(string key)
        {
            return _WebFile.EchoImage(PathUserExt(key));
        }
        public static FileContentResult FileUserLicense(string key)
        {
            var path = _File.GetFirstPath(DirUserLicense, "FileName_" + key, NoImagePath);
            return _WebFile.EchoImage(path);
        }
        public static FileContentResult FileCustInput(string key)
        {
            var path = _File.GetFirstPath(DirCustInput, "FldFile_" + key, NoImagePath);
            return _WebFile.EchoImage(path);
        }
        public static FileContentResult FileCmsType(string key, string cmsType)
        {
            var path = _File.GetFirstPath(DirCmsType(cmsType), "FileName_" + key, NoImagePath);
            return _WebFile.EchoImage(path);
        }
        #endregion

        /*
        //constructor
        static _Xp()
        {
            Locale = _Config.GetStr("Locale", "zh-TW");
            LocaleNoDash = Locale.Replace("-", "");
        }
        */

        /*
        //constant
        //上傳檔案最大限制, 單位MB
        public const int UploadFileMax = 5;

        //檢查上傳檔案
        //後端程式不顯示詳細錯誤訊息到前端
        public static ErrorModel CheckUploadFile(HttpPostedFileBase file, int size, string exts)
        {
            var error = new ErrorModel();
            if (!_WebFile.CheckFileSize(file, size))
                error.ErrorMsg = "上傳檔案大小有誤。";
            else if(!_WebFile.CheckFileExt(file, exts))
                error.ErrorMsg = "上傳檔案種類有誤。";

            return error;
        }

        //儲存上傳檔案, 傳回路徑, 如果失敗則傳回空白
        public static string SaveUploadFile(HttpPostedFileBase file)
        {
            //rename existed file if any
            var dir = _Fun.DirRoot + "ImportFiles\\";
            var name = file.FileName;
            var path = dir + Path.GetFileName(name);
            if (File.Exists(path))
            {
                var path2 = dir + Path.GetFileNameWithoutExtension(name) + "_" + _Date.NowSecStr() + Path.GetExtension(name);
                File.Move(path, path2);
            }
            return _WebFile.SaveUploadFile(file, path) ? path : "";
        }

        //switch locale
        public static void SetLocale(string locale)
        {
            _Locale.SetCulture(locale);
        }

        //??
        //功能清單(名稱)設定多國語內容(recursive)
        public static void MenuSetLocale(List<MenuModel> menus)
        {
            //??
            var rm = _Locale.GetResourceFile("");
            rm.GetString("");
        }
        */

    }//class
}