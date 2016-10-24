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
        /// Id
        /// </summary>		
        //
        [Key]
       // private int _id;
        public int Id { get; set; }
        /// <summary>
        /// Jobnumber
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }
        /// <summary>
        /// CName
        /// </summary>		
        //
        [MaxLength(50)]
        public string CName { get; set; }
        /// <summary>
        /// EName
        /// </summary>		
        [MaxLength(50)]
        public string EName { get; set; }
        /// <summary>
        /// Sex
        /// </summary>		
        public int? Sex { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>		
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Address
        /// </summary>		
       
        [MaxLength(500)]
        public string Address { get; set; }
        /// <summary>
        /// Phone
        /// </summary>		
        [MaxLength(50)]
        public string Phone { get; set; }
        /// <summary>
        /// Position
        /// </summary>	
        [MaxLength(50)]
        public string Position { get; set; }
        /// <summary>
        /// Department
        /// </summary>		
        [MaxLength(50)]
        public string Department { get; set; }
        /// <summary>
        /// WorkState
        /// </summary>		
        public int? WorkState { get; set; }
        /// <summary>
        /// Email
        /// </summary>		
        [MaxLength(200)]
        public string Email { get; set; }
        /// <summary>
        /// ApplyStartTime
        /// </summary>		
        public DateTime? ApplyStartTime { get; set; }
        /// <summary>
        /// ApplyEndTime
        /// </summary>		
        public DateTime? ApplyEndTime { get; set; }
        /// <summary>
        /// ProbationStartTime
        /// </summary>		
        public DateTime? ProbationStartTime { get; set; }

        /// <summary>
        /// ProbationEndTime
        /// </summary>		
        public DateTime? ProbationEndTime { get; set; }

        /// <summary>
        /// Password
        /// </summary>	
               [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// WeChatCode
        /// </summary>		
        [MaxLength(50)]
        public string WeChatCode { get; set; }

        /// <summary>
        /// PM
        /// </summary>		
        [MaxLength(50)]
        public string PM { get; set; }

    }
}