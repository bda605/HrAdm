using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class XpFlowSignRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select a.SourceId, a.SignerName, a.SignTime,
	FlowCode=f.Code, FlowName=f.Name
from dbo.XpFlowSign a
join dbo.XpFlow f on a.FlowId=f.Id
where a.FlowLevel=0
order by a.SignTime
",            
            TableAs = "a",
            Items = new [] {
                new QitemDto { Fid = "SignTime", Type = QitemTypeEnum.Date },
                new QitemDto { Fid = "FlowId", Col = "f.Id" },
                //new QitemDto { Fid = "FlowStatus" },
            },
        };

        public JObject GetPage(string ctrl, DtDto dt)
        {
            return new CrudRead().GetPage(ctrl, dto, dt);
        }

    } //class
}