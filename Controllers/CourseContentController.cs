using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bedrock_WeCath_WeiXin.Context;
using Bedrock_WeCath_WeiXin.Models;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    public class CourseContentController : ApiController
    {
        HomeContext context = new HomeContext();
        // GET: api/CourseContent
        public StudyCourseIinfo Get(string CourseCode)
        {
            var CourseIinfo = context.StudyCourseIinfo.FirstOrDefault(x => x.CourseCode==CourseCode);
            
            return CourseIinfo;
        }

        // GET: api/CourseContent/5
        public CourseContent Get(int id,string CourseCode)
        { 
            var CourseContent = context.CourseContent.FirstOrDefault(x => x.CourseCode == CourseCode);

            return CourseContent;
        }

        // POST: api/CourseContent
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CourseContent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CourseContent/5
        public void Delete(int id)
        {
        }
    }
}
