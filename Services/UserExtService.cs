using Base.Models;
using Base.Services;
using BaseWeb.Services;
using DocumentFormat.OpenXml.Packaging;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HrAdm.Services
{
    public class UserExtService
    {
        /// <summary>
        /// generate word docu
        /// </summary>
        /// <param name="userId">User.Id</param>
        public void GenDocu(string userId)
        {
            #region check data
            var error = "";
            if (string.IsNullOrEmpty(userId))
            {
                error = "UserId is need.";
                goto lab_error;
            }

            var tplPath = _Xp.DirTpl + "UserExt.docx";
            if (!File.Exists(tplPath))
            {
                error = "no file " + tplPath;
                goto lab_error;
            }
            #endregion

            #region read row/rows
            var db = _Xp.GetDb();
            var user = db.User
                .Select(a => a)
                .FirstOrDefault(a => a.Id == userId);

            var userJobs = db.UserJob
                .Where(a => a.UserId == userId)
                .Select(a => a)
                .ToList();

            var userSchools = db.UserSchool
                .Where(a => a.UserId == userId)
                .Select(a => new {
                    a.SchoolName,
                    a.SchoolDept,
                    a.SchoolType,
                    a.StartEnd,
                    Graduated = a.Graduated ? "(畢)" : "(肄)",
                })
                .ToList();

            var userLicenses = db.UserLicense
                .Where(a => a.UserId == userId)
                .Select(a => a)
                .ToList();

            var langLevel = "LangLevel";
            var locale = _Xp.GetLocale0();
            var userLangs = (from a in db.UserLang
                             join c1 in db.XpCode on new { Type = langLevel, Value = a.ListenLevel } equals new { c1.Type, c1.Value }
                             join c2 in db.XpCode on new { Type = langLevel, Value = a.SpeakLevel } equals new { c2.Type, c2.Value }
                             join c3 in db.XpCode on new { Type = langLevel, Value = a.ReadLevel } equals new { c3.Type, c3.Value }
                             join c4 in db.XpCode on new { Type = langLevel, Value = a.WriteLevel } equals new { c4.Type, c4.Value }
                             where a.UserId == userId
                             orderby a.Sort
                             select new
                             {
                                 a.LangName,
                                 ListenLevel = _XpCode.GetValue(c1, locale),
                                 SpeakLevel = _XpCode.GetValue(c2, locale),
                                 ReadLevel = _XpCode.GetValue(c3, locale),
                                 WriteLevel = _XpCode.GetValue(c4, locale),
                             })
                             .ToList();

            var userSkills = db.UserSkill
                .Where(a => a.UserId == userId)
                .Select(a => a)
                .ToList();
            #endregion

            #region ms stream for echo
            //model為anonymous type, 必須使用 IEnumerable
            var childs = new List<IEnumerable<dynamic>>() 
            {
                userJobs, userSchools, userLicenses, 
                userLangs, userSkills
            };
            var images = new List<WordImageDto>()
            {
                new WordImageDto(){ Code = "Photo", FilePath = _Xp.PathUserExt(user.Id) },
            };
            _WebWord.ExportByTplRow(tplPath, "UserExt.docx", user, childs, images);
            return;
            #endregion

        lab_error:
            _Log.Error("UserExtService.cs GenDocu() failed: " + error);
            return;
        }

    }//class
}
