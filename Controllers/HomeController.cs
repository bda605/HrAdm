﻿using Base.Models;
using Base.Services;
using BaseWeb.Attributes;
using BaseWeb.Extensions;
using BaseWeb.Services;
using HrAdm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HrAdmin.Controllers
{
    public class HomeController : Controller
    {
        [XgLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string url = "")
        {
            return View(new LoginVo() { FromUrl = url });
        }

        [HttpPost]
        public ActionResult Login(LoginVo vo)
        {
            //reset UI msg
            vo.AccountMsg = "";
            vo.PwdMsg = "";

            #region check account & password
            if (string.IsNullOrEmpty(vo.Account))
            {
                vo.AccountMsg = "field is required.";
                goto lab_exit;
            }
            if (string.IsNullOrEmpty(vo.Pwd))
            {
                vo.PwdMsg = "field is required.";
                goto lab_exit;
            }

            //check password & get user info
            var sql = @"
select u.Id as UserId, u.Name as UserName, u.Pwd,
    u.DeptId, d.Name as DeptName
from dbo.[User] u
join dbo.Dept d on u.DeptId=d.Id
where u.Account=@Account
";
            var row = _Db.GetJson(sql, new List<object>() { "Account", vo.Account });
            //TODO: encode if need
            //if (row == null || row["Pwd"].ToString() != _Str.Md5(vo.Pwd))
            if (row == null || row["Pwd"].ToString() != vo.Pwd)
            {
                vo.AccountMsg = "input wrong.";
                goto lab_exit;
            }
            #endregion

            #region set base user info
            var userId = row["UserId"].ToString();
            //var authType = AuthTypeEnum.Ctrl;
            var authList = _XpProg.GetAuthList(userId);
            var userInfo = new BaseUserDto()
            {
                UserId = userId,
                UserName = row["UserName"].ToString(),
                DeptId = row["DeptId"].ToString(),
                DeptName = row["DeptName"].ToString(),
                Locale = _Fun.Config.Locale,
                ProgAuthStrs = _XpProg.GetAuthStrs(authList),
                IsLogin = true,
            };
            #endregion

            //set session of base user info
            _Web.GetSession().Set(_Fun.BaseUser, userInfo);   //extension method

            //redirect if need
            var url = string.IsNullOrEmpty(vo.FromUrl) ? "/Home/Index" : vo.FromUrl;
            return Redirect(url);

        lab_exit:
            return View(vo);
        }

        public ActionResult Logout()
        {
            _Web.GetSession().Clear();
            return Redirect("/Home/Index");
        }

        /*
        public string SetLocale(string locale)
        {
            _Locale.SetCulture(locale);
            return locale;
        }
        */
    }
}