using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class XpFlowSignEdit
    {
        private EditDto GetDto()
        {
            return new EditDto
            {
				//Table = "dbo.[Leave]",
                //PkeyFid = "Id",
                ReadSql = @"
select
    l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name,
    UserName=u.Name,
    AgentName=u2.Name
from dbo.Leave l
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where l.Id='{0}'
",
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

    } //class
}
