﻿using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class ProgRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select * from Prog
order by Id
",
            Items = new [] {
                new QitemDto { Fid = "Code", Op = ItemOpEstr.Like },
                new QitemDto { Fid = "Name", Op = ItemOpEstr.Like },
            },
        };

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}