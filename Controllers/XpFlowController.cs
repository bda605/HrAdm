using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HrAdm.Controllers
{
    public class XpFlowController : Controller
    {
        public ActionResult Read()
        {
            using(var db = new Db())
            {
                ViewBag.NodeTypes = _XpCode.GetNodeTypes(db);
                ViewBag.SignerTypes = _XpCode.GetSignerTypes(db);
                ViewBag.AndOrs = _XpCode.GetAndOrs(db);
                ViewBag.LineOps = _XpCode.GetLineOps(db);
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ContentResult GetPage(DtDto dt)
        {
            return Content(new XpFlowRead().GetPage(dt).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public ContentResult GetJson(string key)
        {
            return Content(new XpFlowEdit().GetJson(key).ToString(), ContentTypeEstr.Json);
        }

        [HttpPost]
        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[Flow]", "Id", key, status));
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(new XpFlowEdit().Create(_Json.StrToJson(json), MySetNewKey));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(new XpFlowEdit().Update(key, _Json.StrToJson(json), MySetNewKey));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(new XpFlowEdit().Delete(key));
        }

        /// <summary>
        /// delegate for setNewKey
        /// </summary>
        /// <param name="inputJson"></param>
        /// <param name="edit"></param>
        /// <returns></returns>
        private bool MySetNewKey(CrudEdit editService, JObject inputJson, EditDto edit)
        {
            return (
                editService.SetNewKeyJson(inputJson, edit) &&
                editService.SetRelatId(inputJson, 1, "StartNode", "00") &&
                editService.SetRelatId(inputJson, 1, "EndNode", "00"));
        }

    } //class
}