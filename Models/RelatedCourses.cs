using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class RelatedCourses
    {
        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// CourseCode
        /// </summary>		
        [MaxLength(50)]
        public string CourseCode { get; set; }

        /// <summary>
        /// CourseInfo
        /// </summary>		
        [MaxLength(500)]
        public string CourseInfo { get; set; }

        /// <summary>
        /// CourseVideo
        /// </summary>		
        [MaxLength(500)]
        public string CourseVideo { get; set; }

        /// <summary>
        /// VideoInfo
        /// </summary>		
        [MaxLength(500)]
        public string VideoInfo { get; set; }

    }
}