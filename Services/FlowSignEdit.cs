using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class FlowSignEdit
    {
        private EditDto GetDto()
        {
            return new EditDto
            {
				//Table = "dbo.[Leave]",
                //PkeyFid = "Id",
                ReadSql = @"
select
    SignId=s.Id,
    LeaveId=l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name,
    UserName=u.Name,
    AgentName=u2.Name
from dbo.FlowSign s
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel and s.SignStatus='0'
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.Code c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.Id='{0}'
",
                /*
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
                    new EitemDto { Fid = "FlowLevel", Value = "0" },
                    new EitemDto { Fid = "FlowStatus", Value = "0" },
					new EitemDto { Fid = "Status" },
                },
                */
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
        //private JObject _inputRow;

        /*
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
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.GetDirLeave(), t0_FileName, nameof(t0_FileName));
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
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.GetDirLeave(), t0_FileName, nameof(t0_FileName));
            }
            return result;
        }


        public ResultDto Delete(string key)
        {
            return Service().Delete(key);
        }
        */

    } //class
}
