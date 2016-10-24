using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class WordTime
    {
        public WordTime()
        {
            Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
        }
        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }

        /// <summary>
        /// WorkDate
        /// </summary>		
       
        [MaxLength(50)]
        public string WorkDate { get; set; }
        /// <summary>
        /// ProjectName
        /// </summary>		
        [MaxLength(50)]
        public string ProjectName { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        
        public DateTime? Date { get; set; }
        /// <summary>
        /// Duration
        /// </summary>		
        [MaxLength(200)]
        public string Duration { get; set; }
  
    }
}