﻿using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpProgController : XpCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for edit view
            await using (var db = new Db())
            {
                ViewBag.Roles = _XpCode.GetRolesAsync(db);
                ViewBag.AuthRanges = _XpCode.GetAuthRangesAsync(_Xp.GetLocale0(), db);
            }
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpProgRead().GetPageAsync(Ctrl, dt));
        }

        private XpProgEdit EditService()
        {
            return new XpProgEdit(Ctrl);
        }

        [HttpPost]
        public JsonResult Create(string json)
        {
            return Json(EditService().CreateAsync(_Str.ToJson(json)));
        }

        [HttpPost]
        public JsonResult Update(string key, string json)
        {
            return Json(EditService().UpdateAsync(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            return Json(EditService().DeleteAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

    }//class
}