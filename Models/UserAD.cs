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
        /// AD账号
        /// </summary>		
        [MaxLength(50)]
        public string AD { get; set; }
        /// <summary>
        /// AD密码
        /// </summary>		
        [MaxLength(50)]
        public string ADPwd { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>		
        [MaxLength(200)]
        public string Email { get; set; }
        /// <summary>
        /// 邮箱密码
        /// </summary>	
        [MaxLength(50)]
        public string Password { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>		
        [MaxLength(50)]
        public string Jobnumber { get; set; }

        /// <summary>
        /// 备注/描述
        /// </summary>
         [MaxLength(500)]
        public string Desc { get; set; }
             

    }
}