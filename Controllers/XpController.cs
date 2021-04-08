using Base.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdmin.Controllers
{
    //no auth action
    public class XpController : Controller
    {
        /// <summary>
        /// download template file
        /// </summary>
        /// <param name="file">file name</param>
        /// <returns>file</returns>
        /*
        public FileResult Template(string file)
        {
            //must PhysicalFile !!
            return PhysicalFile(_Xp.DirTpl + file, _Str.FileExtToContentType(_File.GetFileExt(file)), file);
        }
        */

    }//class
}