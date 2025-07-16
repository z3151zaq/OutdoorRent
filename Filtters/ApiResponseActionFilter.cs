﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebCoreApi.Filtters;

public class ApiResponse<T>
{
    public int statusCode { get; set; }
    public T data { get; set; }
    public bool success { get; set; }

    public ApiResponse(T data, int statusCode = 200, bool success = true)
    {
        this.data = data;
        this.statusCode = statusCode;
        this.success = success;
    }

}

public class ApiResponseActionFilter : IActionFilter, IExceptionFilter
    {
        public void OnActionExecuting(ActionExecutingContext ctx)
        {
        }

        public void OnActionExecuted(ActionExecutedContext ctx)
        {
            if (ctx.Result is OkObjectResult okResult)
            {
                var data = okResult.Value;
                ctx.Result = new OkObjectResult(new ApiResponse<dynamic>(data));
            }
        }
        public void OnException(ExceptionContext context)
        {
            // exception handle logic
            var response = new ApiResponse<string>(context.Exception.Message,500, false);
            context.Result = new JsonResult(response)
            {
                StatusCode = 200
            };
            context.ExceptionHandled = true;
        }
    }

