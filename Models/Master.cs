using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bedrock_WeCath_WeiXin.Models
{
    /// <summary>
    /// 业务主数据Model
    /// </summary>
    public class Master
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 流程Guid
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string ProcessGuid { get; set; }

        /// <summary>
        /// 当前环节Guid
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string ActivityGuid { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Folio { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Applicant { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Required]
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// 申请人Ad
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string ApplicantAd { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Required]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string ProcessStatus { get; set; }

        /// <summary>
        /// 下一审批人
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string NextApprover { get; set; }
    }
}