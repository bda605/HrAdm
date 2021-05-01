using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class XpTranLogRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select *
from dbo.XpTranLog
order by Sn desc
",
            Items = new [] {
                new QitemDto { Fid = "TableName", Op = ItemOpEstr.Like },
                new QitemDto { Fid = "ColName", Op = ItemOpEstr.Like },
                new QitemDto { Fid = "RowId" },
            },
        };

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}