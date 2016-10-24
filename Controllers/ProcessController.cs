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
using BRC.K2.Library.Text;
using BRC.K2.Library.Generic;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    [RoutePrefix("process")]
    public class ProcessController : ApiController
    {
        private string planServer = ConfigurationManager.AppSettings["K2PlanServer"];
        private string domainName = ConfigurationManager.AppSettings["K2DomainName"];
        private string userName = ConfigurationManager.AppSettings["K2UserName"];
        private string password = ConfigurationManager.AppSettings["K2Password"];
        private string k2port = ConfigurationManager.AppSettings["K2Port"];
        private string k2adminAccount = ConfigurationManager.AppSettings["K2adminAccount"];
        private string processName = ConfigurationManager.AppSettings["ProcessName"];
        private string approvalUrl = ConfigurationManager.AppSettings["ApprovalUrl"];
        private string returnUrl = ConfigurationManager.AppSettings["ProjectCode"];
        private string escalationGuid = Guid.NewGuid().ToString();

        [Route("start")]
        [HttpPost]
        public string Start(DTO_Master dtoMaster)
        {
            using (var db = new HomeContext())
            {
                // TODO 业务数据处理

                // TODO 创建邮件
                CreateMail(dtoMaster, "Start");
                CreateEscalationMail(dtoMaster, "Escalation");
                // 保存业务数据
                db.SaveChanges();
                // 发起流程
                StartProcess(dtoMaster);
                return "start success";
            }
        }
        private void CreateMail(DTO_Master dtoMaster, string templateCode)
        {
            var projectCode = ConfigurationManager.AppSettings["ProjectCode"];
            var mailEnableFromDB = new MailConfigDal().GetConfigByProcessNameAndKeyName(projectCode, "MailEnable");
            var sender = new MailConfigDal().GetConfigByProcessNameAndKeyName("All", "Sender");
            var mailEnable = mailEnableFromDB == "" ? false : true;
            if (mailEnable)
            {
                MailTemplateDal templateDal = new MailTemplateDal();
                var template = templateDal.GetMailTemplate(projectCode, templateCode);
                if (template.Id > 0)
                {
                    var subject = template.Subject;
                    var body = template.Body;
                    subject = string.Format(subject, dtoMaster.master.Applicant);
                    body = string.Format(body, dtoMaster.master.Applicant, dtoMaster.master.Folio);
                    MailInfo info = new MailInfo();
                    MailInfoDal infoDal = new MailInfoDal();
                    info.MailGuid = dtoMaster.master.ActivityGuid;
                    info.MailTo = "lemon.deng@bedrock.com.cn;allen_yang@bedrock.com.cn";
                    info.Subject = subject;
                    info.Body = body;
                    info.Project = projectCode;
                    info.Sender = sender;
                    info.TemplateCode = templateCode;
                    info.RecordTime = DateTime.Now;
                    info.Retry = 3;
                    infoDal.Add(info);
                }
            }
        }

        private void CreateEscalationMail(DTO_Master dtoMaster, string templateCode)
        {
            var projectCode = ConfigurationManager.AppSettings["ProjectCode"];
            var escalationMailEnableFromDb = new MailConfigDal().GetConfigByProcessNameAndKeyName(projectCode, "EscalationMailEnable");
            var sender = new MailConfigDal().GetConfigByProcessNameAndKeyName("All", "Sender");
            var escalationMailEnable = escalationMailEnableFromDb == "" ? false : true;
            if (escalationMailEnable)
            {
                MailTemplateDal templateDal = new MailTemplateDal();
                var template = templateDal.GetMailTemplate(projectCode, templateCode);
                if (template.Id > 0)
                {
                    var subject = template.Subject;
                    var body = template.Body;
                    subject = string.Format(subject, dtoMaster.master.Applicant);
                    body = string.Format(body, dtoMaster.master.Applicant, dtoMaster.master.Folio, dtoMaster.master.ApplicationDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    MailInfo info = new MailInfo();
                    MailInfoDal infoDal = new MailInfoDal();
                    info.MailGuid = escalationGuid;
                    info.MailTo = "lemon.deng@bedrock.com.cn";
                    info.Subject = subject;
                    info.Body = body;
                    info.Project = projectCode;
                    info.Sender = sender;
                    info.TemplateCode = templateCode;
                    info.RecordTime = DateTime.Now;
                    info.Retry = 3;
                    infoDal.Add(info);
                }
            }
        }

        [Route("getdata")]
        [HttpGet]
        public DTO_Master GetProcessData(string sn)
        {
            K2Helper k2 = new K2Helper(planServer, processName, domainName, k2port, userName, password, sn);
            k2.GetProcessField("ActivityGuid");
            using (new HomeContext())
            {
                // TODO 获取业务数据
                return new DTO_Master();
            }
        }

        [Route("viewdata")]
        [HttpGet]
        public DTO_Master GetViewData(string activityguid)
        {
            using (var db = new HomeContext())
            {
                // 业务数据处理
                return new DTO_Master();
            }
        }

        [Route("update")]
        [HttpPost]
        public string Update(DTO_Master dtoMaster, string sn, string action)
        {
            K2Helper k2 = new K2Helper(planServer, processName, domainName, k2port, userName, password, sn);
            var oldActivityGuid = k2.GetProcessField("ActivityGuid");
            using (var db = new HomeContext())
            {
                var activityGuid = Guid.NewGuid().ToString();
                // TODO 更新业务数据
                db.SaveChanges();
                // TODO 更新K2数据
                UpdateProcess(dtoMaster, k2, action);
                return "update success";
            }
        }

        private string CreateFolio()
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["ReimbursementContext"].ConnectionString;
            var folio = FlowNumber.Get(connectionStr, "Reimbursement");
            return folio;
        }

        private void StartProcess(DTO_Master master)
        {
            K2Helper k2 = new K2Helper(planServer, processName, domainName, k2port, userName, password);
            Hashtable table = new Hashtable();
            table.Add("Applicant", master.master.ApplicantAd);
            table.Add("ProcessGuid", master.master.ProcessGuid);
            table.Add("ActivityGuid", master.master.ActivityGuid);
            table.Add("EscalationGuid", escalationGuid);
            table.Add("Folio", master.master.Folio);
            table.Add("NextApprover", "根据业务逻辑获取得到");
            table.Add("ApprovalUrl", approvalUrl);
            table.Add("ReturnUrl", returnUrl);
            k2.StartNewProcessInstance(table, new Hashtable(), master.master.Folio);
        }

        private void UpdateProcess(DTO_Master master, K2Helper k2, string action)
        {
            Hashtable table = new Hashtable();
            table.Add("ActivityGuid", master.master.ActivityGuid);
            table.Add("EscalationGuid", escalationGuid);
            k2.UpdateProcessField(table);
            k2.FinishActivity();
        }
    }
}
