using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class LeaveSignEdit
    {
        private EditDto GetDto()
        {
            var locale = _Xp.GetLocale0();
            return new EditDto
            {
                ReadSql = $@"
select
    SignId=s.Id,
    LeaveId=l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name_{locale},
    UserName=u.Name,
    AgentName=u2.Name
from dbo.XpFlowSign s
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel and s.SignStatus='0'
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.Id='{{0}}'
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
