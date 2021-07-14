using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class XpCmsRead
    {
        private string _cmsType;

        //constructor
        public XpCmsRead(string cmsType)
        {
            _cmsType = cmsType;
        }

        private ReadDto GetDto()
        {
            return new ReadDto()
            {
                ReadSql = $@"
select *
from dbo.Cms
where CmsType='{_cmsType}'
order by Id desc
",
                Items = new[] {
                    new QitemDto { Fid = "Title", Op = ItemOpEstr.Like },
                },
            };
        }

        public JObject GetPage(string ctrl, DtDto dt)
        {
            return new CrudRead().GetPage(ctrl, GetDto(), dt);
        }

    } //class
}