using Base.Services;
using HrAdm.Models;
using System.Collections.Generic;
using System.Linq;

namespace HrAdm.Services
{
    public class LeaveService
    {
        public List<SignRowDto> GetSignRows(string id)
        {
            var db = _Xp.GetDb();
            return (from s in db.FlowSign
                    join f in db.Flow on s.FlowId equals f.Id
                    join c in db.Code on new { Type = "SignStatus", Value = s.SignStatus } 
                        equals new { c.Type, c.Value }
                    where (f.Code == "Leave" && s.SourceId == id)
                    orderby s.FlowLevel
                    select new SignRowDto()
                    {
                        NodeName = s.NodeName,
                        SignerName = s.SignerName,
                        SignStatusName = c.Name,
                        SignTime = (s.SignTime == null) 
                            ? "" : s.SignTime.Value.ToString(_Fun.CsDtFormat),
                        Note = s.Note,
                    })
                    .ToList();
        }

    } //class
}