﻿using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            var versionObject = new
            {
                Version = assemblyName.Version?.ToString() ?? "version not specified",
                ServiceName = assemblyName.Name
                
            };
            
            await context.Response.WriteAsJsonAsync(versionObject);
        }
    }
}