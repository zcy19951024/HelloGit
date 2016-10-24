using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class UserAD
    {

        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// AD
        /// </summary>		
        [MaxLength(50)]
        public string AD { get; set; }

        /// <summary>
        /// Jobnumber
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }

        /// <summary>
        /// ADPwd
        /// </summary>		
        [MaxLength(50)]
        public string ADPwd { get; set; }

    }
}