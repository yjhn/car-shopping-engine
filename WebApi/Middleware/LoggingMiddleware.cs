using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Models;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Server.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContext;

        public LoggingMiddleware(RequestDelegate next, ILogger logger, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _logger = logger;
            _httpContext = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // DOES NOT WORK //

            if (false)
            {
                var controllerActionDescriptor =
                    context
                    .GetEndpoint()
                    .Metadata
                    .GetMetadata<ControllerActionDescriptor>();
                if (controllerActionDescriptor != null)
                {
                    var controllerName = controllerActionDescriptor.ControllerName;
                    var actionName = controllerActionDescriptor.ActionName;

                    if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        string role = _httpContext.HttpContext.User.IsInRole(UserRole.User) ? UserRole.User : _httpContext.HttpContext.User.IsInRole(UserRole.Admin) ? UserRole.Admin : "unknown role";
                        _logger.Information($"User '{_httpContext.HttpContext.User.Identity.Name}' in role '{role}' accessed action '{actionName}' in controller '{controllerName}'");
                    }
                    else
                    {
                        _logger.Information($"Action '{actionName}' in controller '{controllerName}' was accessed anonymously");
                    }
                }
            }
            await _next(context);
        }
    }
}