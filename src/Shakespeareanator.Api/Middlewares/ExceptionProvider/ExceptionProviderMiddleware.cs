namespace Shakespeareanator.Api.Middlewares
{
    using Flurl.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Shakespeareanator.Api.Models;
    using Shakespeareanator.Utils;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class ExceptionProviderMiddleware
    {
        #region Constants

        private const string GENERIC_ERROR = "There was an error while processing your request.";

        #endregion

        #region Fields

        private readonly RequestDelegate next;

        private readonly ILogger<ExceptionProviderMiddleware> logger;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionProviderMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ExceptionProviderMiddleware(RequestDelegate next, ILogger<ExceptionProviderMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // get activity id for error correlation id
                var correlationId = Activity.Current?.RootId;

                // retrieve exception details
                var exceptionInfo = FetchExceptionInfo(ex);

                logger.LogError($"Exception: {exceptionInfo.Message}. [ID:{correlationId}]");

                await WriteResponse(context, correlationId, exceptionInfo.Code, exceptionInfo.Type);
            }
        }

        private ExceptionInfo FetchExceptionInfo(Exception ex)
        {
            var exceptionInfo = new ExceptionInfo();

            if (ex is AggregateException aggregateException)
            {
                if (aggregateException.InnerException is FlurlHttpException exception)
                {
                    exceptionInfo.Code = (int)exception.Call.Response.StatusCode;
                    exceptionInfo.Message = exception.Message;
                    exceptionInfo.Type = exception.Call.Response.StatusCode.ToString();
                }
                else
                {
                    // to manage other exceptions
                }
            }
            else
            {
                // to manage other exceptions
            }

            return exceptionInfo;
        }

        /// <summary>
        /// Writes the response.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        private static async Task WriteResponse(HttpContext context, string correlationId, int errorCode, string exceptionType)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorCode;

            // Create the response
            var response = new ErrorResponse()
            {
                Error = new ErrorResponseDetails
                {
                    CorrelationId = correlationId,
                    Message = GENERIC_ERROR,
                    Type = exceptionType
                }
            };

            await context.Response.WriteAsync(response.ToEasyJson());
        }
    }
}
