using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Exception
{
    /// <summary>
    /// Namespace:BRC.Portal.WebApi.Exception
    /// Description:错误code枚举
    /// Author:TerryZhu
    /// Create Date:2016-07-30
    /// </summary>
    public enum ErrorCode : int
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        Other = 999,
        /// <summary>
        /// 
        /// </summary>
        NotImplemented = 1000,
        /// <summary>
        /// 
        /// </summary>
        Timeout = 1001,
        /// <summary>
        /// 
        /// </summary>
        ArgumentNull = 1002,
        /// <summary>
        /// 
        /// </summary>
        AccessViolation = 1003,
        /// <summary>
        /// 
        /// </summary>
        Aggregate = 1004,
        /// <summary>
        /// 
        /// </summary>
        IO = 1005,
        /// <summary>
        /// 
        /// </summary>
        ArgumentOutOfRange = 1006,
        /// <summary>
        /// 
        /// </summary>
        IndexOutOfRange = 1007,
        /// <summary>
        /// 
        /// </summary>
        NullReference = 1008,
        /// <summary>
        /// 
        /// </summary>
        FileNotFound = 1009,
        /// <summary>
        /// 
        /// </summary>
        Sql = 1010,
        /// <summary>
        /// 
        /// </summary>
        StackOverflow = 1011,
        /// <summary>
        /// 
        /// </summary>
        Overflow = 1012,
        /// <summary>
        /// 
        /// </summary>
        Arithmetic = 1013,
        /// <summary>
        /// 
        /// </summary>
        DivideByZero = 1014,
        /// <summary>
        /// 
        /// </summary>
        Format = 1015,
        /// <summary>
        /// 
        /// </summary>
        InvalidCast = 1016,
        /// <summary>
        /// 
        /// </summary>
        NotSupported = 1017,
        /// <summary>
        /// 
        /// </summary>
        HttpCompile = 1018,
        /// <summary>
        /// 
        /// </summary>
        Http = 1019,
        /// <summary>
        /// token过期
        /// </summary>
        TokenExpired = 1020,
        /// <summary>
        /// 用户未授权
        /// </summary>
        Unauthorized = 1021
    }
}