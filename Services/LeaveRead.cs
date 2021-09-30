using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class LeaveRead
    {
        private ReadDto GetReadDto()
        {
            var locale = _Xp.GetLocale0();
            return new ReadDto()
            {
                ReadSql = $@"
select l.*,
    UserName=u.Name,
    AgentName=u2.Name,
    LeaveName=c.Name_{locale},
    SignStatusName=c2.Name_{locale}
from dbo.Leave l
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
join dbo.XpCode c2 on c2.Type='FlowStatus' and l.FlowStatus=c2.Value
order by l.Id
",
                Items = new[] {
                    new QitemDto { Fid = "StartTime", Type = QitemTypeEnum.Date },
                    new QitemDto { Fid = "LeaveType" },
                    new QitemDto { Fid = "FlowStatus" },
                },
            };
        }

        public async Task<JObject> GetPage(string ctrl, DtDto dtDto)
        {
            return await new CrudRead().GetPageAsync(ctrl, GetReadDto(), dtDto);
        }

    } //class
}