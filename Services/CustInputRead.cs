using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class CustInputRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select * from dbo.CustInput
order by Id
",
            Items = new [] {
                new QitemDto { Fid = "FldText" },
            },
        };

        public async Task<JObject> GetPage(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(ctrl, dto, dt);
        }

    } //class
}