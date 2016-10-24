using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace Bedrock_WeCath_WeiXin.Exception
{
    public abstract class AbsCommonExceptionFilterAttribute : ExceptionFilterAttribute
    {
        protected abstract bool AllowException { get; }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //2.返回调用方具体的异常信息
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.NotImplemented);
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Timeout);
            }
            else if (actionExecutedContext.Exception is ArgumentNullException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.ArgumentNull);
            }
            else if (actionExecutedContext.Exception is AccessViolationException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.AccessViolation);
            }
            else if (actionExecutedContext.Exception is AggregateException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Aggregate);
            }
            else if (actionExecutedContext.Exception is IOException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.IO);
            }
            else if (actionExecutedContext.Exception is ArgumentOutOfRangeException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.ArgumentOutOfRange);
            }
            else if (actionExecutedContext.Exception is IndexOutOfRangeException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.IndexOutOfRange);
            }
            else if (actionExecutedContext.Exception is NullReferenceException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.NullReference);
            }
            else if (actionExecutedContext.Exception is StackOverflowException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.StackOverflow);
            }
            else if (actionExecutedContext.Exception is SqlException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Sql);
            }
            else if (actionExecutedContext.Exception is OverflowException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Overflow);
            }
            else if (actionExecutedContext.Exception is ArithmeticException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Arithmetic);
            }
            else if (actionExecutedContext.Exception is FormatException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Format);
            }
            else if (actionExecutedContext.Exception is InvalidCastException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.InvalidCast);
            }
            else if (actionExecutedContext.Exception is NotSupportedException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.NotSupported);
            }
            else if (actionExecutedContext.Exception is HttpCompileException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.HttpCompile);
            }
            else if (actionExecutedContext.Exception is HttpException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Http);
            }
            else if (actionExecutedContext.Exception is TokenExpiredException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.TokenExpired);
            }
            else if (actionExecutedContext.Exception is UnauthorizedAccessException)
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Unauthorized);
            }
            else if (actionExecutedContext.Exception is DbEntityValidationException)
            {
                var e = actionExecutedContext.Exception as DbEntityValidationException;
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var oResponse = new HttpResponseMessage
                        {
                            Content = HandleContent((int)ErrorCode.Other, string.Format("Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage))
                        };
                        actionExecutedContext.Response = oResponse;
                    }
                }
            }
            else
            {
                actionExecutedContext = HandleException(actionExecutedContext, (int)ErrorCode.Other);
            }

            base.OnException(actionExecutedContext);
        }

        public virtual HttpActionExecutedContext HandleException(HttpActionExecutedContext actionExecutedContext, int errorcode)
        {
            var oResponse = new HttpResponseMessage
            {
                Content = HandleContent(errorcode, actionExecutedContext.Exception.Message)
            };
            actionExecutedContext.Response = oResponse;
            return actionExecutedContext;
        }

        public virtual StringContent HandleContent(int errorcode, string errormessage)
        {
            return
                new StringContent(
                    "{\"errormessage\":\"" + errormessage + "\",\"errorcode\":\"" +
                    errorcode + "\"}", Encoding.GetEncoding("UTF-8"), "application/json");
        }
    }
}