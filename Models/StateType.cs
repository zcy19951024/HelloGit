using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class StateType
    {
        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// TypeName
        /// </summary>		

        public string TypeName { get; set; }

    }
}