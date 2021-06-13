using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class XpFlowSignEdit
    {
        public JObject GetJson(string flowCode, string key)
        {
            string sql = "";
            var locale = _Xp.GetLocale0();
            if (flowCode == "Leave")
            {
                sql = $@"
select
    l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name_{locale},
    UserName=u.Name,
    AgentName=u2.Name
from dbo.Leave l
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where l.Id='{{0}}'
";
            }

            var dto = new EditDto() { ReadSql = sql };
            return new CrudEdit(dto).GetJson(key);
        }

    } //class
}
