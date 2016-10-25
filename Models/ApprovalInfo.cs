using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class ApprovalInfo
    {

        /// <summary>
        /// 表ID
        /// </summary>		
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }
        /// <summary>
        /// 提交申请时间
        /// </summary>
        public DateTime? EmpTime { get; set; }
        /// <summary>
        /// 审批单号
        /// </summary>
        public string HrFilo { get; set; }
        /// <summary>
        /// （HR）审批人
        /// </summary>		
        [MaxLength(50)]
        public string HRApprover { get; set; }

        /// <summary>
        /// HR审批时间
        /// </summary>		      
        public DateTime? HRApproverTime { get; set; }
        /// <summary>
        ///HR流程状态
        /// </summary>		
        public string Status { get; set; }

        /// <summary>
        /// HR审核备注
        /// </summary>		
        [MaxLength(500)]
        public string coment { get; set; }

        /// <summary>
        /// 员工账户提交申请时间
        /// </summary>
        public DateTime? AccountTime { get; set; }
        /// <summary>
        /// 账户申请审批单号
        /// </summary>
        public string AccountFilo { get; set; }
        /// <summary>
        /// （AD）申请账户审批人
        /// </summary>		
        [MaxLength(50)]
        public string AccountApprover { get; set; }

        /// <summary>
        /// （AD）申请账户审批时间
        /// </summary>		      
        public DateTime? AccountApproverTime { get; set; }
        /// <summary>
        ///（AD）申请账户流程状态
        /// </summary>		
        public string AccountStatus { get; set; }

        /// <summary>
        /// （AD）申请账户审核备注
        /// </summary>		
        [MaxLength(500)]
        public string AccountComent { get; set; }





    }
}