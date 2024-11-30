using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUD.Filters
{
    public class LogActivityFilter : IActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;        
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"executing Action{context.ActionDescriptor.DisplayName} on controllers {context.Controller}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"after exection Action {context.ActionDescriptor}  on controllers {context.Controller}");
            
        }

    }
}

