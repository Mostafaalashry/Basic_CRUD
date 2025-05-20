using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace CRUD.Filters;

public class LogSensetiveActionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Debug.WriteLine("sensetive action executing !!!!!!!!!!");

    }


}

