using Bedrock_WeCath_WeiXin.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bedrock_WeCath_WeiXin.Models;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    
    public class IndexController : ApiController
    {
        HomeContext db = new HomeContext();
        // GET: api/Index
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        // GET: api/Index/5 http://192.168.0.122/BedrockAPI/api/Index/GetSel?id=46

        public IEnumerable<ApprovalInfo> GetSel(string jobnumber)
        {
            /*var app = db.ApprovalInfo.Where(a=>a.Jobnumber== jobnumber);
            ApprovalInfo apps = new ApprovalInfo();
            foreach (var itema in app)
            {
               itema.Status = apps.Status;
               itema.AccountStatus = apps.AccountStatuss;
            }*/
            var app = from a in db.ApprovalInfo where (a.Jobnumber == jobnumber) select a;
            return app;
        }
    }
}
