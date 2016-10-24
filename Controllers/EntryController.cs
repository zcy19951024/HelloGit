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
    public class EntryController : ApiController
    {
        // GET: api/Entry
        HomeContext db = new HomeContext();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Entry/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Entry
        public EmployeeInfo Post([FromBody]EmployeeInfo emp)
        {
            db.EmployeeInfo.Add(emp);
            db.SaveChanges();
            return emp;
        }

        // PUT: api/Entry/5
        public EmployeeInfo Put(int? id, [FromBody]EmployeeInfo emp)
        {
            EmployeeInfo emps = db.EmployeeInfo.Find(id);
            emps.CName = emp.CName;
            emps.Sex = emp.Sex;
            emps.EName = emp.EName;
            emps.Email = emp.Email;
            emps.Password = emp.Password;
            emps.Birthday = emp.Birthday;
            emps.Address = emp.Address;
            emps.Phone = emp.Phone;
            db.EmployeeInfo.Add(emps);
            db.SaveChanges();
            return emps;
        } 

        // DELETE: api/Entry/5
        public void Delete(int id)
        {
        }
    }
}
