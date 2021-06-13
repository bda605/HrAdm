using Base.Models;
using Base.Services;
using HrAdm.Tables;
using System.Collections.Generic;

namespace HrAdm.Services
{
    //與下拉欄位有關
    public static class _XpCode
    {
        #region master table to codes
        public static List<IdStrDto> GetProjects(Db db = null)
        {
            return TableToList("Project", db);
        }
        public static List<IdStrDto> GetUsers(Db db = null)
        {
            return TableToList("User", db);
        }
        public static List<IdStrDto> GetDepts(Db db = null)
        {
            return TableToList("Dept", db);
        }
        public static List<IdStrDto> GetRoles(Db db = null)
        {
            return TableToList("XpRole", db);
        }
        public static List<IdStrDto> GetProgs(Db db = null)
        {
            return TableToList("XpProg", db);
        }
        public static List<IdStrDto> GetFlows(Db db = null)
        {
            return TableToList("XpFlow", db);
        }
        #endregion


        #region get from XpCode table
        public static List<IdStrDto> GetLangLevels(string locale, Db db = null)
        {
            return TypeToList(locale, "LangLevel", db);
        }
        public static List<IdStrDto> GetLeaveTypes(string locale, Db db = null)
        {
            return TypeToList(locale, "LeaveType", db);
        }
        public static List<IdStrDto> GetSignStatuses(string locale, Db db = null)
        {
            return TypeToList(locale, "SignStatus", db);
        }

        public static List<IdStrDto> GetSignStatuses2(string locale, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale} as Str
from dbo.XpCode
where Type='SignStatus'
and Ext='1'
order by Sort";
            return SqlToList(sql, db);
        }
        #endregion

        #region for flow
        public static List<IdStrDto> GetNodeTypes(string locale, Db db = null)
        {
            return TypeToList(locale, "NodeType", db);
        }
        public static List<IdStrDto> GetSignerTypes(string locale, Db db = null)
        {
            return TypeToList(locale, "SignerType", db);
        }
        public static List<IdStrDto> GetAndOrs(string locale, Db db = null)
        {
            return TypeToList(locale, "AndOr", db);
        }
        public static List<IdStrDto> GetLineOps(string locale, Db db = null)
        {
            return TypeToList(locale, "LineOp", db);
        }

        /*
        public static List<IdStrDto> GetSignTypes()
        {
            return new List<IdStrDto>()
            {
                new IdStrDto(){ Id = "Y", Str = "同意" },
                new IdStrDto(){ Id = "N", Str = "不同意" },
            };
        }
        */
        #endregion

        #region others
        public static List<IdStrDto> GetSelects()
        {
            return new List<IdStrDto>(){
                new IdStrDto(){ Id="1", Str="Select1"},
                new IdStrDto(){ Id="2", Str="Select2"},
            };
        }
        public static List<IdStrDto> GetRadios()
        {
            return new List<IdStrDto>(){
                new IdStrDto(){ Id="1", Str="Radio1"},
                new IdStrDto(){ Id="2", Str="Radio2"},
            };
        }
        #endregion

        private static List<IdStrDto> TableToList(string table, Db db = null)
        {
            var sql = string.Format(@"
select 
    Id, Name as Str
from dbo.[{0}]
order by Id
", table);
            return SqlToList(sql, db);
        }

        //get codes from sql 
        private static List<IdStrDto> SqlToList(string sql, Db db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = db.GetModels<IdStrDto>(sql);
            _Fun.CheckCloseDb(db, emptyDb);
            return rows;
        }

        //get code table rows for 下拉式欄位
        private static List<IdStrDto> TypeToList(string locale, string type, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale} as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return SqlToList(sql, db);           
        }
        public static string GetValue(XpCode row, string locale)
        {
            var name = "Name_" + locale;
            //return _Linq.FnGetValue<XpCode>(name).ToString();
            return _Model.GetValue<XpCode>(row, name).ToString();
        }

        /*
        public static List<IdStrExtModel> GetCodeExts(string type, Db db = null)
        {
            var emptyDb = (db == null);
            if (emptyDb)
                db = new Db();

            var sql = string.Format(@"
select 
    Value as Id, Name as Str, Ext
from dbo.XpCode
where Type='{0}'
and Ext='0'
order by Sort
", type);
            var rows = db.GetModels<IdStrExtModel>(sql);
            if (emptyDb)
                db.Dispose();
            return rows;
        }
        */

    }//class
}
