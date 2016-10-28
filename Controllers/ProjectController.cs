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

   
    public class ProjectController : ApiController
    {
        HomeContext Context = new HomeContext();
        // GET: api/Project
        public IEnumerable<Project> Get()
        {

            return Context.Project;
        }

        // GET: api/Project/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Project
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }
    }
}
