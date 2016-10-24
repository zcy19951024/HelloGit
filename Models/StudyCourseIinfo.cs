using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class StudyCourseIinfo
    {
        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// CourseTitle
        /// </summary>		
        [MaxLength(50)]
        public string CourseTitle { get; set; }

        /// <summary>
        /// CourseDesc
        /// </summary>		
        [MaxLength(500)]
        public string CourseDesc { get; set; }

        /// <summary>
        /// CourseFinishTime
        /// </summary>		
        public Double CourseFinishTime { get; set; }

        /// <summary>
        /// CourseCode
        /// </summary>		
        [MaxLength(50)]
        public string CourseCode { get; set; }

        /// <summary>
        /// CoursePrincipal
        /// </summary>		
        [MaxLength(50)]
        public string CoursePrincipal { get; set; }

        /// <summary>
        /// CoursePM
        /// </summary>		
        [MaxLength(50)]
        public string CoursePM { get; set; }

        /// <summary>
        /// Courseimages
        /// </summary>		
        [MaxLength(500)]
        public string Courseimages { get; set; }

    }
}