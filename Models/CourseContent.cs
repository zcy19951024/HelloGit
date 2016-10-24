using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class CourseContent
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
        /// Content
        /// </summary>		
        [MaxLength(500)]
        public string Content { get; set; }


    }
}