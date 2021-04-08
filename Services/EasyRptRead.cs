using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class EasyRptRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select * from dbo.EasyRpt
order by Id
",
            Items = new [] {
                new QitemDto { Fid = "Name" },
            },
        };

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}