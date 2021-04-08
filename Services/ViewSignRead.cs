﻿using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class ViewSignRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = $@"
select l.Id,
  l.StartTime, l.EndTime, l.Hours, l.Created,
  FlowStatusName=c2.Name,
  UserName=u.Name,
  LeaveName=c.Name 
from Leave l
join [User] u on l.UserId=u.Id
join [Code] c on c.Type='LeaveType' and l.LeaveType=c.Value 
join [Code] c2 on c2.Type='FlowStatus' and l.FlowStatus=c2.Value 
order by l.Created
",            
            Items = new [] {
                new QitemDto { Fid = "StartTime", Type = QitemTypeEnum.Date },
                new QitemDto { Fid = "LeaveType" },
                new QitemDto { Fid = "FlowStatus" },
            },
        };

        public JObject GetPage(DtDto dt)
        {
            return new CrudRead().GetPage(dto, dt);
        }

    } //class
}