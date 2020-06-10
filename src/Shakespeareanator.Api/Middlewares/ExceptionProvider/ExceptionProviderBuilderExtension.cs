using Microsoft.AspNetCore.Builder;
using System;

namespace Shakespeareanator.Api.Middlewares
{
    /// <summary>
    /// The exception provider app builder extension
    /// </summary>
    public static class ExceptionProviderBuilderExtension
    {
        /// <summary>
        /// Uses the API exception provider.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">app</exception>
        public static IApplicationBuilder UseExceptionProvider(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<ExceptionProviderMiddleware>();
        }
    }
}
