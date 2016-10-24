using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class StudyDetails
    {

        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// Emp_Id
        /// </summary>		
        public int? Emp_Id { get; set; }

        /// <summary>
        /// CourseCode
        /// </summary>		
        [MaxLength(50)]
        public string CourseCode { get; set; }

        /// <summary>
        /// Jobnumber
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>		
        public DateTime? StartStudyTime { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>		
        public DateTime? FinishStudyTime { get; set; }

        /// <summary>
        /// StudyDate
        /// </summary>		
        public int? Studystate { get; set; }

        /// <summary>
        /// isStop
        /// </summary>		
        public bool? isStop { get; set; }

        /// <summary>
        /// StopStartTime
        /// </summary>		
        public DateTime? StopStartTime { get; set; }

        /// <summary>
        /// StopFinishTime
        /// </summary>		
        public DateTime? StopEndTime { get; set; }

        /// <summary>
        /// StopReason
        /// </summary>		
        [MaxLength(500)]
        public string StopReason { get; set; }

        /// <summary>
        /// isDefer
        /// </summary>		
        public bool? isDefer { get; set; }

        /// <summary>
        /// DeferStartTime
        /// </summary>		
        public int? DeferTime { get; set; }

        /// <summary>
        /// DeferFinishTime
        /// </summary>		
        public DateTime? ExpectFinishDate { get; set; }

        /// <summary>
        /// DeferReason
        /// </summary>		
        [MaxLength(50)]
        public string DeferReason { get; set; }

    }
}