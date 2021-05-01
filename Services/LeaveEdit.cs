using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class LeaveEdit
    {
        private EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[Leave]",
                PkeyFid = "Id",
                ReadSql = @"
select l.*,
    FlowStatusName=c.Name,
    CreatorName=u.Name,
    ReviserName=u2.Name
from dbo.Leave l
join dbo.XpCode c on c.Type='FlowStatus' and l.FlowStatus=c.Value
join dbo.[User] u on l.Creator=u.Id
left join dbo.[User] u2 on l.Reviser=u2.Id
where l.Id='{0}'
",
                Items = new [] 
				{
					new EitemDto { Fid = "Id" },
					new EitemDto { Fid = "UserId", Required = true },
					new EitemDto { Fid = "AgentId", Required = true },
					new EitemDto { Fid = "LeaveType", Required = true },
					new EitemDto { Fid = "StartTime", Required = true },
					new EitemDto { Fid = "EndTime", Required = true },
					new EitemDto { Fid = "Hours", Required = true },
                    new EitemDto { Fid = "FileName" },
                    new EitemDto { Fid = "FlowLevel", Value = "1" },
                    new EitemDto { Fid = "FlowStatus", Value = "0" },
					new EitemDto { Fid = "Status" },
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

        //private string _newKey;
        private JObject _inputRow;

        //delegate function of FnAfterSave
        private string FnCreateSignRows(Db db, JObject newKeyJson)
        {
            var newKey = _Str.ReadNewKeyJson(newKeyJson);
            return _Flow.CreateSignRows(_inputRow, "UserId", "Leave", newKey, db);
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> CreateAsnyc(JObject json, IFormFile t0_FileName)
        {
            _inputRow = _Json.ReadInputJson0(json);
            var service = Service();
            var result = service.Create(json, null, FnCreateSignRows);
            if (_Valid.ResultStatus(result))
            {
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirLeave, t0_FileName, nameof(t0_FileName));
            }
            return result;
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> UpdateAsnyc(string key, JObject json, IFormFile t0_FileName)
        {
            var service = Service();
            var result = service.Update(key, json);
            if (_Valid.ResultStatus(result))
            {
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirLeave, t0_FileName, nameof(t0_FileName));
            }
            return result;
        }


        public ResultDto Delete(string key)
        {
            return Service().Delete(key);
        }

    } //class
}
