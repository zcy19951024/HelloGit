using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class EmployeeInfo
    {
        /// <summary>
        /// 表ID
        /// </summary>		
        //
        [Key]
       // private int _id;
        public int Id { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>		
        //
        [MaxLength(50)]
        public string CName { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>		
        [MaxLength(50)]
        public string EName { get; set; }
        /// <summary>
        ///性别
        /// </summary>		
        [MaxLength(50)]
        public string Sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>		
        public string IDcare { get; set; }
        /// <summary>
        /// 生日
        /// </summary>		
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 身份证地址
        /// </summary>		
       
        [MaxLength(500)]
        public string CareAddress { get; set; }
        /// <summary>
        /// 现居住地址
        /// </summary>		

        [MaxLength(500)]
        public string NowAddress { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>		
        [MaxLength(50)]
        public string Phone { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>		
        public string MaritalStatus { get; set; }
        /// <summary>
        /// 最终学历
        /// </summary>		
        public string Education { get; set; }
        /// <summary>
        /// 职位
        /// </summary>	
        [MaxLength(50)]
        public string PositionEmp { get; set; }
        /// <summary>
        /// 部门
        /// </summary>		
        [MaxLength(50)]
        public string Department { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>		
        public DateTime? EntryStartTime { get; set; }

        /// <summary>
        /// 合同开始日期
        /// </summary>		
        public DateTime? ContractStartTime { get; set; }
        /// <summary>
        /// 合同到期日期
        /// </summary>		
        public DateTime? ContractEndTime { get; set; }
        /// <summary>
        /// 试用期到期日期
        /// </summary>
        public DateTime? ProbationEndTime { get; set; }
        /// <summary>
        /// 试用期工资
        /// </summary>
        public string Probationsalary{get;set;}
        /// <summary>
        /// 合同工资
        /// </summary>
        public string Contractsalary { get; set; }
        /// <summary>
        /// 项目经理
        /// </summary>		
        [MaxLength(50)]
        public string PM { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string hrcoment { get; set; }
        /// <summary>
        /// 就职状态
        /// </summary>		
        public string WorkState { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>		
        [MaxLength(50)]
        public string WeChatCode { get; set; }
    }
}