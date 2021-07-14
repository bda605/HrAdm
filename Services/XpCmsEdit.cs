﻿using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class XpCmsEdit : MyEdit
    {
        public XpCmsEdit(string ctrl) : base(ctrl) { }

        private string _cmsType;
        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.Cms",
                PkeyFid = "Id",
                ReadSql = @"
select c.*,
    CreatorName=u.Name,
    ReviserName=u2.Name
from dbo.Cms c
join dbo.[User] u on c.Creator=u.Id
left join dbo.[User] u2 on c.Reviser=u2.Id
where c.Id='{0}'
",
                Items = new [] 
				{
                    new EitemDto { Fid = "Id" },
					new EitemDto { Fid = "CmsType", Value = _cmsType },
                    //new EitemDto { Fid = "DataType", Value = "0" },
                    new EitemDto { Fid = "Title", Required = true },
                    new EitemDto { Fid = "Text" },
					new EitemDto { Fid = "Html" },
					new EitemDto { Fid = "Note" },
                    new EitemDto { Fid = "FileName" },
                    new EitemDto { Fid = "StartTime", Required = true },
                    new EitemDto { Fid = "EndTime", Required = true },
                    new EitemDto { Fid = "Status" },
                },
            };
        }

        public async Task<ResultDto> CreateAsnyc(JObject json, IFormFile t0_FileName, string dirUpload, string cmsType)
        {
            _cmsType = cmsType;
            var service = Service();
            var result = service.Create(json);
            if (_Valid.ResultStatus(result))
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), dirUpload, t0_FileName, nameof(t0_FileName));
            return result;
        }

        public async Task<ResultDto> UpdateAsnyc(string key, JObject json, IFormFile t0_FileName, string dirUpload)
        {
            var service = Service();
            var result = service.Update(key, json);
            if (_Valid.ResultStatus(result))
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), dirUpload, t0_FileName, nameof(t0_FileName));
            return result;
        }

    } //class
}
