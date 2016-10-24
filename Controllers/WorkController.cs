using Bedrock_WeCath_WeiXin.Context;
using Bedrock_WeCath_WeiXin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    public class WorkController : ApiController
    {
        // GET: api/Work
        HomeContext context = new HomeContext();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Work/5
        public  List<IEnumerable<WordTime>> Get(string id)
        {
            //获取请求参数日期
            var query = Request.GetQueryNameValuePairs();
            var date = query.ToList();
            DateTime sdate= DateTime.Parse(date[0].Value); 
            string dt = string.Format(date[1].Value+" 23:59:59");

            DateTime edate = Convert.ToDateTime(dt);

            var works = from w in context.WordTime
                        where w.Jobnumber == id.ToString() && sdate <= w.Date && w.Date <= edate
                        select w;
            var workList = works.GroupBy(x =>x.Date).ToList();
            List<IEnumerable<WordTime>> data = new List<IEnumerable<WordTime>>();
            foreach (var item in workList)
            {
                data.Add(item);
            }
            return data;
        }

        // POST: api/Work
        public string Post([FromBody]List<WordTime> workList)
        {
            DateTime date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            var works = context.WordTime;
            foreach (var item in workList)
            {
               var  re = works.Any(x => x.Jobnumber == item.Jobnumber && x.Date == date);
                if (re)
                {
                    return "请勿重复添加工时！";

                }
                context.WordTime.Add(item);
               
            }
            context.SaveChanges();
            return "OK";
        }

        // PUT: api/Work/5
        public string Put(int id, [FromBody]WordTime work)
        {
             
            WordTime Work = context.WordTime.Find(id);

            return "OK";

        }

        // DELETE: api/Work/5
        public void Delete(int id)
        {

        }
    }
}
