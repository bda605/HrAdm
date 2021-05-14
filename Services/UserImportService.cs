using Base.Models;
using Base.Services;
using BaseWeb.Services;
using HrAdm.Enums;
using HrAdm.Models;
using HrAdm.Tables;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HrAdm.Services
{
    public class UserImportService
    {
        /// <summary>
        /// import excel file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>result</returns>
        public ResultImportDto Import(IFormFile file)
        {
            var importDto = new ExcelImportDto<UserImportVo>()
            {
                ImportType = ImportTypeEstr.User,
                TplPath = _Xp.DirTpl + "UserImport.xlsx",
                SaveDir = _Xp.DirUserImport,
                FnSaveImportRows = SaveImportRows,
                CreatorName = _Fun.GetBaseUser().UserName,
            };
            return _WebExcel.ImportByFile(file, importDto);
        }

        private List<string> SaveImportRows(List<UserImportVo> okRows)
        {
            var db = _Xp.GetDb();
            var deptIds = db.Dept.Select(a => a.Id).ToList();
            var results = new List<string>();
            foreach (var row in okRows)
            {
                //check deptId
                if (!deptIds.Contains(row.DeptId))
                {
                    results.Add("DeptId wrong");
                    continue;
                }

                db.User.Add(new User() { 
                    Id = _Str.NewId(),
                    Name = row.Name,
                    Account = row.Account,
                    Pwd = row.Pwd,
                    DeptId = row.DeptId,
                    Status = true,
                });

                try
                {
                    db.SaveChanges();
                    results.Add("");
                }
                catch (Exception ex)
                {
                    results.Add(ex.InnerException.Message);
                }
            }
            return results;
        }

    } //class
}