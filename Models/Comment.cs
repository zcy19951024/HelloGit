using System;
using System.ComponentModel.DataAnnotations;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class Comment
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
        /// 审批人人Ad
        /// </summary>
        [MaxLength(10)]
        [Required]
        public string OperatorAd { get; set; }

        /// <summary>
        /// 审批人姓名
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string Operator { get; set; }

        /// <summary>
        /// 审批动作
        /// </summary>
        [MaxLength(10)]
        [Required]
        public string Action { get; set; }

        /// <summary>
        /// 审批意见内容
        /// </summary>
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 审批记录时间
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }
    }
}