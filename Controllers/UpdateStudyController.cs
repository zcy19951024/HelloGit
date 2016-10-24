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
    public class UpdateStudyController : ApiController
    {
        HomeContext context = new HomeContext();

        // GET: api/UpdateStudy
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UpdateStudy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UpdateStudy
        public void Post([FromBody]string value)
        {



        }

        // PUT: api/UpdateStudy/5
        public void Put(int id, [FromBody]StudyDetails StudDetail)
        {
            StudyDetails StudDetails = context.StudyDetails.FirstOrDefault(x => x.CourseCode == StudDetail.CourseCode && x.Jobnumber == StudDetail.Jobnumber);

           

        }

        // DELETE: api/UpdateStudy/5
        public void Delete(int id)
        {
        }
    }
}
