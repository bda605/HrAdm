﻿using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class UserEdit
    {
        private EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[User]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new [] 
				{
					new EitemDto { Fid = "Id" },
					new EitemDto { Fid = "Account" },
					new EitemDto { Fid = "Name" },
					new EitemDto { Fid = "DeptId" },
					new EitemDto { Fid = "Status" },
                },
                Childs = new EditDto[]
                {
                    new EditDto
                    {
                        Table = "dbo.[UserJob]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "JobName", Required = true },
							new EitemDto { Fid = "JobType" },
							new EitemDto { Fid = "JobPlace" },
							new EitemDto { Fid = "StartEnd", Required = true },
							new EitemDto { Fid = "CorpName", Required = true },
							new EitemDto { Fid = "CorpUsers" },
							new EitemDto { Fid = "IsManaged" },
							new EitemDto { Fid = "JobDesc" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserSchool]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "SchoolName", Required = true },
							new EitemDto { Fid = "SchoolDept", Required = true },
							new EitemDto { Fid = "SchoolType" },
							new EitemDto { Fid = "StartEnd", Required = true },
							new EitemDto { Fid = "Graduated" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserLang]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
						OrderBy = "Sort",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "LangName", Required = true },
							new EitemDto { Fid = "ListenLevel" },
							new EitemDto { Fid = "SpeakLevel" },
							new EitemDto { Fid = "ReadLevel" },
							new EitemDto { Fid = "WriteLevel" },
							new EitemDto { Fid = "Sort" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserLicense]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "LicenseName", Required = true },
							new EitemDto { Fid = "StartEnd", Required = true },
							new EitemDto { Fid = "FileName" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserSkill]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "SkillName", Required = true },
							new EitemDto { Fid = "SkillDesc" },
							new EitemDto { Fid = "Sort" },
                        },
                    },
                },
            };
        }

        private CrudEdit Service()
        {
            return new CrudEdit(GetDto());
        }

        public JObject GetJson(string key)
        {
            return Service().GetJson(key);
        }

        //t03_FileName: t(table)03(serial)_FileName(fid)
        public async Task<ResultDto> SaveAsnyc(JObject json, List<IFormFile> t03_FileName)
        {
            var service = Service();
            var result = service.Save(json);
            if (_Valid.ResultStatus(result))
            {
                await _WebFile.SaveCrudFilesAsnyc(json, service.GetNewKey(), _Xp.GetDirUserLicence(), t03_FileName, nameof(t03_FileName));
            }
            return result;
        }

        public ResultDto Delete(string key)
        {
            return Service().Delete(key);
        }

    } //class
}
