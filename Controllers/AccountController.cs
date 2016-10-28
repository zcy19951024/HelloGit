using Bedrock_WeCath_WeiXin.Context;
using Bedrock_WeCath_WeiXin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    public class AccountController : ApiController
    {
        HomeContext db = new HomeContext();
        [HttpGet]//账户申请一开始就加载 http://192.168.0.132/BedrockAPI/api/Account/GetAccountIndex?id=Bedrock2016102158
        public IEnumerable<object> GetAccountIndex(string jobnumber)
        {
            var app = from a in db.ApprovalInfo where a.Jobnumber == jobnumber select new { Jobnumber = a.Jobnumber, AccountStatus = a.AccountStatus, AccountApprover = a.AccountApprover };
            IEnumerable<ApprovalInfo> apps = app.ToList().Select(a=>new ApprovalInfo
            {
                Jobnumber=a.Jobnumber,
                AccountStatus=a.AccountStatus,
                AccountApprover=a.AccountApprover
                
            }).ToList();
            var user = from u in db.UserAD where u.Jobnumber == jobnumber select new { Jobnumber = u.Jobnumber,Email=u.Email, Password = u.Password,AD=u.AD, ADPwd = u.ADPwd };
            IEnumerable<UserAD> users = user.ToList().Select(u=>new UserAD
            {
                Jobnumber=u.Jobnumber,
                Email = u.Email,
                Password = u.Password,
                AD = u.AD,
                ADPwd =u.ADPwd
            }).ToList();
            var test = from uu in users
                       join aa in apps on uu.Jobnumber equals aa.Jobnumber
                       select new
                       {
                           Jobnumber=uu.Jobnumber,
                           AccountStatus=aa.AccountStatus,
                           AccountApprover = aa.AccountApprover,
                           Email = uu.Email,
                           Password = uu.Password,
                           AD = uu.AD,
                           ADPwd = uu.ADPwd
                       };
            return test;
        }

        // PUT: api/Entry/5 http://192.168.0.132/BedrockAPI/api/Account/PostAccount?jobnumber=Bedrock2016102158
        [HttpPost]//账户申请
        public UserAD PostAccount(string jobnumber, [FromBody]UserAD user)
        {
            user.Jobnumber = jobnumber;
            db.UserAD.Add(user);
            db.SaveChanges();
            var APPAD = db.ApprovalInfo.Where(a => a.Jobnumber == jobnumber);
            foreach (var item in APPAD)
            {
                item.AccountFilo = DateTime.Now.ToString("yyyyMMddHHmmss") + user.Id;//生成单号
                item.AccountTime = DateTime.Now;
                item.AccountStatus = "AD待审核";
            }
            db.SaveChanges();
            return user;
        }
        [HttpPost]//账户重新申请
        public UserAD PostAccountRetrun(string jobnumber, [FromBody]UserAD user)
        {
            /*user.Jobnumber = jobnumber;
            db.UserAD.Add(user);
            db.SaveChanges();*/
            var users = db.UserAD.Where(u=>u.Jobnumber==jobnumber);
            foreach (var items in users)
            {
                items.Password = user.Password; 
            }
            db.SaveChanges();
            var APPAD = db.ApprovalInfo.Where(a => a.Jobnumber == jobnumber);
            foreach (var item in APPAD)
            {
                //item.AccountFilo = DateTime.Now.ToString("yyyyMMddHHmmss") + user.Id;//生成单号
                item.AccountTime = DateTime.Now;
                item.AccountStatus = "AD待审核";
            }
            db.SaveChanges();
            return user;
        }



        [HttpGet]//AD审批一开始就将员工信息传入审核页面
        public IEnumerable<object> GetAccountApproval(string jobnumber)
        {
            var emp = db.EmployeeInfo.Where(e=>e.Jobnumber==jobnumber);
            EmployeeInfo emps = new EmployeeInfo();
            foreach (var item in emp)
            {
                emps.CName = item.CName;
                emps.EName = item.EName;
                emps.Sex = item.Sex;
            }
            var user = db.UserAD.Where(u=>u.Jobnumber==jobnumber);
            UserAD users = new UserAD();
            foreach (var item in user)
            {
                users.Password = item.Password;
            }
            var temps = from ee in emp
                        join uu in user on ee.Jobnumber equals uu.Jobnumber
                        select new
                        {
                            CName = ee.CName,
                            EName = ee.EName,
                            Sex = ee.Sex,
                            Password = uu.Password
                        };
            return temps;
        }
        [HttpPost]//账户申请点击确定审核 http://192.168.0.132/BedrockAPI/api/Account/PostADApproval?jobnumber=Bedrock2016102158
        public IEnumerable<UserAD> PostADApproval(string jobnumber,[FromBody]UserAD user)
        {
            var users = db.UserAD.Where(u=>u.Jobnumber==jobnumber);
            foreach (var item in users)
            {
                item.Jobnumber = jobnumber;
                item.AD = user.AD;
                item.ADPwd = user.ADPwd;
                item.Email = user.Email;
                item.Password = user.Password;
                item.Desc = user.Desc;
            }
            db.SaveChanges();
            var apps = db.ApprovalInfo.Where(a=>a.Jobnumber==jobnumber);
            foreach (var itemapp in apps)
            {
                itemapp.AccountApproverTime = DateTime.Now;
                itemapp.AccountStatus = "AD已审核";
                itemapp.AccountComent = "审核通过";
            }
            db.SaveChanges();
            return users;
        }
        //退回
        [HttpPost]
        public IEnumerable<ApprovalInfo> PostADRetrun(string jobnumber,[FromBody]ApprovalInfo app)
        {
            var apps = db.ApprovalInfo.Where(a => a.Jobnumber == jobnumber);
            foreach (var itemapp in apps)
            {
                itemapp.AccountApproverTime = DateTime.Now;
                itemapp.AccountStatus = "AD退回";
                itemapp.AccountComent = app.AccountComent;
            }
            db.SaveChanges();
            return apps;
        }


    }
}
