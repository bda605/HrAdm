using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class LeaveRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select l.*,
    UserName=u.Name,
    AgentName=u2.Name,
    LeaveName=c.Name,
    SignStatusName=c2.Name
from Leave l
join [User] u on l.UserId=u.Id
join [User] u2 on l.AgentId=u2.Id
join [Code] c on c.Type='LeaveType' and l.LeaveType=c.Value
join [Code] c2 on c2.Type='FlowStatus' and l.FlowStatus=c2.Value
order by l.Id
",
            Items = new [] {
                new QitemDto { Fid = "StartTime", Type = QitemTypeEnum.Date },
                new QitemDto { Fid = "LeaveType" },
                new QitemDto { Fid = "FlowStatus" },
            },
        };

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}