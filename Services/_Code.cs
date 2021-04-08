using Base.Models;
using Base.Services;
using BaseWeb.Services;
using System.Collections.Generic;

namespace HrAdm.Services
{
    //與下拉欄位有關
    public static class _Code
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
            return TableToList("Role", db);
        }
        public static List<IdStrDto> GetProgs(Db db = null)
        {
            return TableToList("Prog", db);
        }
        #endregion


        #region get from Code table
        public static List<IdStrDto> GetLangLevels(Db db = null)
        {
            return TypeToList("LangLevel", db);
        }
        public static List<IdStrDto> GetLeaveTypes(Db db = null)
        {
            return TypeToList("LeaveType", db);
        }
        public static List<IdStrDto> GetSignStatuses(Db db = null)
        {
            return TypeToList("SignStatus", db);
        }
        #endregion

        #region for flow
        public static List<IdStrDto> GetNodeTypes(Db db = null)
        {
            return TypeToList("NodeType", db);
        }
        public static List<IdStrDto> GetSignerTypes(Db db = null)
        {
            return TypeToList("SignerType", db);
        }
        public static List<IdStrDto> GetAndOrs(Db db = null)
        {
            return TypeToList("AndOr", db);
        }
        public static List<IdStrDto> GetLineOps(Db db = null)
        {
            return TypeToList("LineOp", db);
        }

        public static List<IdStrDto> GetSignTypes()
        {
            return new List<IdStrDto>()
            {
                new IdStrDto(){ Id = "Y", Str = "同意" },
                new IdStrDto(){ Id = "N", Str = "不同意" },
            };
        }
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
        private static List<IdStrDto> TypeToList(string type, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name as Str
from dbo.Code
where Type='{type}'
order by Sort";
            return SqlToList(sql, db);           
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
from dbo.Code
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
