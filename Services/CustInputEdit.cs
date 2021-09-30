using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class CustInputEdit : XpEdit
    {
        public CustInputEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[CustInput]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new [] 
				{
					new EitemDto { Fid = "Id" },
                    new EitemDto { Fid = "FldCheck", Required = true },
                    new EitemDto { Fid = "FldDate", Required = true },
                    new EitemDto { Fid = "FldDt", Required = true },
                    new EitemDto { Fid = "FldDec", Required = true },
                    new EitemDto { Fid = "FldInt", Required = true },
                    new EitemDto { Fid = "FldFile", Required = true },
                    new EitemDto { Fid = "FldHtml", Required = true },
                    new EitemDto { Fid = "FldLink", Col = "FldFile" },
					new EitemDto { Fid = "FldRadio", Required = true },
                    new EitemDto { Fid = "FldRead", Col = "FldText" },
                    new EitemDto { Fid = "FldSelect", Required = true },
                    new EitemDto { Fid = "FldTextarea", Required = true },
                    new EitemDto { Fid = "FldText", Required = true },
					//new EitemDto { Fid = "FldColor", Required = true },
                },
            };
        }

        public async Task<ResultDto> CreateAsnyc(JObject json, IFormFile t0_FldFile)
        {
            var service = Service();
            var result = await service.CreateAsync(json);
            if (_Valid.ResultStatus(result))
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirCustInput, t0_FldFile, nameof(t0_FldFile));
            return result;
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> UpdateAsnyc(string key, JObject json, IFormFile t0_FldFile)
        {
            var service = Service();
            var result = await service.UpdateAsync(key, json);
            if (_Valid.ResultStatus(result))
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirCustInput, t0_FldFile, nameof(t0_FldFile));
            return result;
        }

    } //class
}
