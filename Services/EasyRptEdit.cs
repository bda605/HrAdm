using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class EasyRptEdit
    {
        private EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.EasyRpt",
                PkeyFid = "Id",
                Col4 = null,
                Items = new [] 
				{
					new EitemDto { Fid = "Id" },
					new EitemDto { Fid = "Name", Required = true },
                    new EitemDto { Fid = "TplFile", Required = true },
                    new EitemDto { Fid = "ToEmails" },
					//new EitemDto { Fid = "ToRoles" },
					new EitemDto { Fid = "Sql", Required = true },
					new EitemDto { Fid = "Status" },
                },
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

        public ResultDto Create(JObject json)
        {
            return Service().Create(json);
        }

        public ResultDto Update(string key, JObject json)
        {
            return Service().Update(key, json);
        }

        public ResultDto Delete(string key)
        {
            return Service().Delete(key);
        }

    } //class
}
