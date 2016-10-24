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
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Jobnumber
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }

        /// <summary>
        /// Approver
        /// </summary>		
        [MaxLength(50)]
        public string Approver { get; set; }

        /// <summary>
        /// Type
        /// </summary>		
        public int? Type { get; set; }

        /// <summary>
        /// coment
        /// </summary>		
        [MaxLength(500)]
        public string coment { get; set; }

    }
}