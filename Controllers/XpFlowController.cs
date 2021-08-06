using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HrAdm.Controllers
{
    public class XpFlowController : XpCtrl
    {
        public ActionResult Read()
        {
            using(var db = new Db())
            {
                var locale0 = _Xp.GetLocale0();
                ViewBag.NodeTypes = _XpCode.GetNodeTypes(locale0, db);
                ViewBag.SignerTypes = _XpCode.GetSignerTypes(locale0, db);
                ViewBag.AndOrs = _XpCode.GetAndOrs(locale0, db);
                ViewBag.LineOps = _XpCode.GetLineOps(locale0, db);
            }
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return JsonToCnt(new XpFlowRead().GetPage(Ctrl, dt));
        }

        private XpFlowEdit EditService()
        {
            return new XpFlowEdit(Ctrl);
        }

        [HttpPost]
        public ContentResult GetUpdateJson(string key)
        {
            return JsonToCnt(EditService().GetUpdateJson(key));
        }

        [HttpPost]
        public ContentResult GetViewJson(string key)
        {
            return JsonToCnt(EditService().GetViewJson(key));
        }

        /*
        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[Flow]", "Id", key, status));
        }
        */

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(EditService().Create(_Json.StrToJson(json), FnSetNewKey));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(EditService().Update(key, _Json.StrToJson(json), FnSetNewKey));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().Delete(key));
        }

        /// <summary>
        /// delegate for setNewKey
        /// </summary>
        /// <param name="inputJson"></param>
        /// <param name="edit"></param>
        /// <returns></returns>
        private bool FnSetNewKey(CrudEdit editService, JObject inputJson, EditDto edit)
        {
            return (
                editService.SetNewKeyJson(inputJson, edit) &&
                editService.SetChildFkey(inputJson, 1, "StartNode", "00") &&
                editService.SetChildFkey(inputJson, 1, "EndNode", "00"));
        }

    } //class
}