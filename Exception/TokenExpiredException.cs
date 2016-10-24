using System;

namespace Bedrock_WeCath_WeiXin.Exception
{
    /// <summary>
    /// 自定义凭据过期异常
    /// </summary>
    public class TokenExpiredException : ApplicationException
    {
        public TokenExpiredException() : base("token已过期") { }
        public TokenExpiredException(string message) : base(message) { }
        public TokenExpiredException(string message, System.Exception innerException) : base(message, innerException) { }

        public override string Message
        {
            get
            {
                var msg = base.Message;
                if (!string.IsNullOrEmpty(msg))
                {
                    return msg;
                }
                return "token已过期";
            }
        }
    }
}