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
       
        // POST: api/Entry  员工入职
        public ApprovalInfo PostEntry([FromBody]EmployeeInfo emp)
        {
            db.EmployeeInfo.Add(emp);
            db.SaveChanges();
            EmployeeInfo empId = db.EmployeeInfo.Find(emp.Id);
            /* empId.Jobnumber = "Bedrock" + DateTime.Now.ToString("yyyyMMdd") + empId.Id;
             db.SaveChanges();*/
            ApprovalInfo app = new ApprovalInfo();
            app.EmpTime = DateTime.Now;//入职申请提交的时间
            app.Jobnumber = emp.Jobnumber;//员工编号
            app.Status = "HR待审核";
            app.HrFilo = DateTime.Now.ToString("yyyyMMddHHmmss")+empId.Id;//生成单号PostResuleEntry
            db.ApprovalInfo.Add(app);
            db.SaveChanges();
            return app;
        }
        //员工入职重新提交
        public IEnumerable<ApprovalInfo> PostResuleEntry(string jobnumber,[FromBody]EmployeeInfo emp)
        {
            var emps = db.EmployeeInfo.Where(e=>e.Jobnumber==jobnumber);
            foreach (var item in emps)
            {
                item.CName = emp.CName;
                item.EName = emp.EName;
                item.Sex = emp.Sex;
                item.IDcare = emp.IDcare;
                item.CareAddress = emp.CareAddress;
                item.NowAddress = emp.NowAddress;
                item.MaritalStatus = emp.MaritalStatus;
                item.Education = emp.Education;
                item.Phone = emp.Phone;
            }
            db.SaveChanges();
            var app = db.ApprovalInfo.Where(a=>a.Jobnumber==jobnumber);
            foreach (var items in app)
            {
                items.Status = "HR待审核";
                items.EmpTime = DateTime.Now;
            }
            db.SaveChanges();
            return app;
        }



        /// <summary>
        /// 一开始就加载进HR审批页面的入职信息   http://192.168.0.122/BedrockAPI/api/Entry/PostHrApprovel
        /// </summary>
        /// <param name="hrfilo"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<EmployeeInfo> GetHrApprovel(string id)
        {
            var emp = from e in db.EmployeeInfo where e.Jobnumber==id select e;
            return emp;
        }
        /// <summary>
        /// HR审核通过    http://192.168.0.122/BedrockAPI/api/Entry/PostHrEntry?=jobnumber
        /// </summary>
        /// <param name="filo"></param>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public EmployeeInfo PostHrEntry(string jobnumber, [FromBody]EmployeeInfo emp)
        {
            var emem = from s in db.EmployeeInfo where s.Jobnumber == jobnumber select s;
            foreach (var item in emem)
            {
                item.PositionEmp = emp.PositionEmp;// 职位
                item.EntryStartTime = emp.EntryStartTime;// 入职日期
                item.ContractStartTime = emp.ContractStartTime;// 合同开始日期
                item.ContractEndTime = emp.ContractEndTime;// 合同到期日期
                item.ProbationEndTime = emp.ProbationEndTime;// 试用期到期日期
                item.Probationsalary = emp.Probationsalary;// 试用期工资
                item.Contractsalary = emp.Contractsalary;// 合同工资
                item.PM = emp.PM;// 项目经理  
                item.hrcoment = emp.hrcoment;//备注
            }
            db.SaveChanges();
            var app = from a in db.ApprovalInfo where a.Jobnumber == jobnumber select a;
            foreach (var items in app)
            {
                items.HRApproverTime = DateTime.Now;
                items.Status = "HR已审核";
                items.coment = "审核通过";
            }
            db.SaveChanges();
            return emp;
        }




        
        /// <summary>
        /// HR审核退回    http://192.168.0.122/BedrockAPI/api/Entry/PostHrRetrun?=jobnumber
        /// </summary>
        /// <param name="filo"></param>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<ApprovalInfo> PostHrRetrun(string jobnumber,ApprovalInfo apps)
        {
            var app = from a in db.ApprovalInfo where a.Jobnumber == jobnumber select a;
            foreach (var items in app)
            {
                items.HRApproverTime = DateTime.Now;
                items.Status = "HR退回";
                items.coment = apps.coment;                
            }
            db.SaveChanges();
            return app;
        }





        [HttpGet]//填了入职信息后一开始就加载 http://192.168.0.132/BedrockAPI/api/Entry/GetIndex?id=Bedrock2016102158
        public IEnumerable<object> GetIndex(string id)
        {
            var app = from a in db.ApprovalInfo
                      where a.Jobnumber == id
                      select new { Jobnumber = a.Jobnumber,Status=a.Status };
            IEnumerable<ApprovalInfo> apps = app.ToList().Select(a => new ApprovalInfo { Jobnumber = a.Jobnumber, Status = a.Status }).ToList();
            var emp = from e in db.EmployeeInfo where e.Jobnumber==id
                      select new
                      {
                          Id = e.Id,
                          Jobnumber = e.Jobnumber,
                          CName = e.CName,
                          EName = e.EName,
                          Sex = e.Sex,
                          IDcare = e.IDcare,
                          CareAddress = e.CareAddress,
                          NowAddress = e.NowAddress,
                          Phone = e.Phone,
                          MaritalStatus = e.MaritalStatus,
                          Education = e.Education
                      };
            IEnumerable<EmployeeInfo> emps = emp.ToList().Select(e => new EmployeeInfo
            {
                Id = e.Id,
                Jobnumber = e.Jobnumber,
                CName = e.CName,
                EName = e.EName,
                Sex = e.Sex,
                IDcare = e.IDcare,
                CareAddress = e.CareAddress,
                NowAddress = e.NowAddress,
                Phone = e.Phone,
                MaritalStatus = e.MaritalStatus,
                Education = e.Education
            }).ToList();
            var temps = from ee in emps
                        join aa in apps on ee.Jobnumber equals aa.Jobnumber
                        where (aa.Jobnumber == ee.Jobnumber)
                        select new
                        {
                            Id = ee.Id,
                            Jobnumber = ee.Jobnumber,
                            CName = ee.CName,
                            EName = ee.EName,
                            Sex = ee.Sex,
                            IDcare = ee.IDcare,
                            CareAddress = ee.CareAddress,
                            NowAddress = ee.NowAddress,
                            Phone = ee.Phone,
                            MaritalStatus = ee.MaritalStatus,
                            Education = ee.Education,
                            Status=aa.Status,
                        };
            return temps;

        }
    }
}
