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

        // POST: api/Entry  入职
        public ApprovalInfo PostEntry([FromBody]EmployeeInfo emp)
        {
            db.EmployeeInfo.Add(emp);
            db.SaveChanges();
            EmployeeInfo empId = db.EmployeeInfo.Find(emp.Id);
            empId.Jobnumber = "Bedrock" + DateTime.Now.ToString("yyyyMMdd") + empId.Id;
            db.SaveChanges();
            ApprovalInfo app = new ApprovalInfo();
            app.EmpTime = DateTime.Now;//入职申请提交的时间
            app.Jobnumber = emp.Jobnumber;//员工编号
            app.Status = "HR待审核";
            app.HrFilo = DateTime.Now.ToString("yyyyMMddHHmmss")+empId.Id;//生成单号
            db.ApprovalInfo.Add(app);
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
        /// HR审核    http://192.168.0.122/BedrockAPI/api/Entry/PostHrEntry?=jobnumber
        /// </summary>
        /// <param name="filo"></param>
        /// <param name="emp"></param>
        /// <returns></returns>
        //[HttpGet]
        public EmployeeInfo PostHrEntry(string jobnumber,EmployeeInfo emp)
        {
            var emem = from s in db.EmployeeInfo where s.Jobnumber == jobnumber select s;
            foreach (var item in emem)
            {
                emp.CName = item.CName;//姓名
                emp.EName = item.EName;//英文名
                emp.Sex = item.Sex;//性别
                emp.Jobnumber = item.Jobnumber;//员工编号
                emp.IDcare = item.IDcare;// 身份证号
                //emjob.Birthday = emp.Birthday;// 生日
                emp.CareAddress = item.CareAddress;// 身份证地址
                emp.NowAddress = item.NowAddress;// 现居住地址
                emp.Phone = item.Phone;// 手机号
                emp.MaritalStatus = item.MaritalStatus;// 婚姻状况
                emp.Education = item.Education;// 最终学历
                emp.Position = item.Position;// 职位
                //emjob.Department = emp.Department;// 部门
                emp.EntryStartTime = item.EntryStartTime;// 入职日期
                emp.ContractStartTime = item.ContractStartTime;// 合同开始日期
                emp.ContractEndTime = item.ContractEndTime;// 合同到期日期
                emp.ProbationEndTime = item.ProbationEndTime;// 试用期到期日期
                emp.Probationsalary = item.Probationsalary;// 试用期工资
                emp.Contractsalary = item.Contractsalary;// 合同工资
                emp.PM = item.PM;// 项目经理      
            }
            db.SaveChanges();
            var app = from a in db.ApprovalInfo where a.Jobnumber == jobnumber select a;
            foreach (var items in app)
            {
                items.HRApproverTime = DateTime.Now;
                items.Status = "HR已审核";
            }
            db.SaveChanges();
            /*ApprovalInfo app = new ApprovalInfo();
            app.HRApproverTime = DateTime.Now;
            app.Status = "已审核";*/


            return emp;
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
