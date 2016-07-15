﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Threading.Tasks;

namespace AspNetCoreAngular2Seed.Infrastructure.Middleware
{
    /// <summary>
    /// A class to redirect any request other than index.html or starts with '/api/' to index.html
    /// This is required to implement Angular2 path location strategy for URL routing
    /// //http://stackoverflow.com/questions/31415052/angular-2-0-router-not-working-on-reloading-the-browser
    /// </summary>
    public class Angular2Middleware
    {
        private readonly RequestDelegate next;

        public Angular2Middleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path.HasValue && !context.Request.Path.Value.StartsWith("/api/")
                && !context.Request.Path.Value.Equals("/")
                && !context.Request.Path.Value.Equals("/index.html")
                && !context.Request.Path.Value.Contains("."))
            {
                context.Request.Path = new PathString("/index.html");
            }
                await next.Invoke(context);

        }
    }
}

