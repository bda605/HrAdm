using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class LeaveSignRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = $@"
select 
    s.Id, s.NodeName,
    l.StartTime, l.EndTime, l.Hours, l.Created,
    UserName=u.Name,
    LeaveName=c.Name
from dbo.XpFlowSign s
join dbo.XpFlow f on f.Code='Leave' and s.FlowId=f.Id
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel and s.SignStatus='0'
join dbo.[User] u on l.UserId=u.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.SignerId='{_Fun.UserId()}'
order by l.Created
",
            /*
            Items = new [] {
                new QitemDto { Fid = "StartTime", Type = QitemTypeEnum.Date },
                new QitemDto { Fid = "LeaveType" },
                new QitemDto { Fid = "FlowStatus" },
            },
            */
        };

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}