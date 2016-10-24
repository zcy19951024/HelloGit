using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Http;
using Bedrock_WeCath_WeiXin.Context;
using Bedrock_WeCath_WeiXin.DTOModels;
using System.Configuration;
using System.Collections;
using Bedrock_WeCath_WeiXin.Models;
using BRC.Common.Library.Email.MailDBHelper.Dal;
using BRC.Common.Library.Email.MailDBHelper.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    public class EmployeeInfoController : ApiController
    {
        //HomeContext db = new HomeContext();
        // GET api/user
       /* [HttpGet]
        public IEnumerable<EmployeeInfo> GetUser()
        {
            return db.EmployeeInfo.ToList();
        }

        // GET api/user/5
        [HttpGet]
        public bool deleteById(int id)
        {
            var EmployeeInfoModel = db.EmployeeInfo.Find(id);
            if (EmployeeInfoModel != null)
            {
                db.EmployeeInfo.Remove(EmployeeInfoModel);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool AddUser(EmployeeInfo newEmployeeInfo)
        {
            db.EmployeeInfo.Add(newEmployeeInfo);

            int result = db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT api/user/5
        [HttpPut]
        public bool ModifUser(EmployeeInfo newEmployeeInfo)
        {
            EmployeeInfo EmployeeInfoModel = db.EmployeeInfo.FirstOrDefault(e => e.Id == newEmployeeInfo.Id);
            EmployeeInfoModel.Jobnumber = newEmployeeInfo.Jobnumber;
            EmployeeInfoModel.Password = newEmployeeInfo.Password;
            EmployeeInfoModel.Phone = newEmployeeInfo.Phone;
            EmployeeInfoModel.PM = newEmployeeInfo.PM;
            EmployeeInfoModel.Position = newEmployeeInfo.Position;
            EmployeeInfoModel.ProbationEndTime = newEmployeeInfo.ProbationEndTime;
            EmployeeInfoModel.ProbationStartTime = newEmployeeInfo.ProbationStartTime;
            EmployeeInfoModel.Sex = newEmployeeInfo.Sex;
            EmployeeInfoModel.WeChatCode = newEmployeeInfo.WeChatCode;
            EmployeeInfoModel.WorkState = newEmployeeInfo.WorkState;
            EmployeeInfoModel.Address = newEmployeeInfo.Address;
            EmployeeInfoModel.ApplyEndTime = newEmployeeInfo.ApplyEndTime;
            EmployeeInfoModel.ApplyStartTime = newEmployeeInfo.ApplyStartTime;
            EmployeeInfoModel.Birthday = newEmployeeInfo.Birthday;
            EmployeeInfoModel.CName = newEmployeeInfo.CName;
            EmployeeInfoModel.Department = newEmployeeInfo.Department;
            EmployeeInfoModel.Email = newEmployeeInfo.Email;
            EmployeeInfoModel.EName = newEmployeeInfo.EName; 
            int result = db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        static readonly Interface1 repository = new EmployeeInfoRepository();
        public IEnumerable<EmployeeInfo> GetAllemps()
        {
            return repository.GetAll();
        }
        public EmployeeInfo GetEmp(int id) {
            EmployeeInfo item = repository.Get(id);
            if (item==null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        //POST: /api/products  
        public HttpResponseMessage PostEmp(EmployeeInfo item)
        {
            item = repository.Add(item);
            //db.EmployeeInfo.Add(item);
            //db.SaveChanges();
            EmployeeInfo emp = new EmployeeInfo();
            var response = Request.CreateResponse<EmployeeInfo>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { ApplyStartTime = item.ApplyStartTime, ApplyEndTime=item.ApplyEndTime,a=item.ProbationStartTime,b=item.ProbationEndTime });
            response.Headers.Location = new Uri(uri);
            
            return response;
        }
       /* public List<UserAD> getUserAD()
        {
            var userList = new List<UserAD> {
            new UserAD{ Id=1,AD="张三",Jobnumber="12",ADPwd="海淀区"},
            new UserAD{Id=2,AD="李四",Jobnumber="12",ADPwd="昌平区"},
            new UserAD{Id=3,AD="王五",Jobnumber="12",ADPwd="朝阳区"}
            };
            var temp = (from u in userList
                        select u).ToList();
            return temp;
        }*/
    }
}
