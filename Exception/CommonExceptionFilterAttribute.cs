using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Exception
{
    public class CommonExceptionFilterAttribute : AbsCommonExceptionFilterAttribute
    {
        protected override bool AllowException => false;
    }
}