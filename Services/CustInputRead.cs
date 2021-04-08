﻿using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

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

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}