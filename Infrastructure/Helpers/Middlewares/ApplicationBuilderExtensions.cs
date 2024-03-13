using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseUserSessionValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserSessionValidationMiddleware>();
        }
    }
}
