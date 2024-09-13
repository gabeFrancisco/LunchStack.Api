using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunchStack.Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LunchStack.Api.Filters
{
    public class WorkgroupHeaderAttribute : Attribute, IAsyncResourceFilter
    {
        private IUserService? _userService;
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            _userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService))!;
            var user = await _userService.GetActualUser() ?? null;

            if (user == null)
            {
                await next();
            }
            else
            {
                context.HttpContext.Response.Headers["workgroup-id"] = user.LastUserWorkgroup.ToString();
                await next();
            }
        }
    }
}