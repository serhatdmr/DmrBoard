﻿using DmrBoard.Core.AuditLogs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmrBoard.Web.Host.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {

            //_logger.LogInformation(await FormatRequest(context.Request));
            await _next(context);
            //var originalBodyStream = context.Response.Body;

            //using (var responseBody = new MemoryStream())
            //{
            //    context.Response.Body = responseBody;
            //    await _next(context);

            //    string responseText = await FormatResponse(context.Response);
            //    _logger.LogInformation($"Http Response Information:{Environment.NewLine}" +
            //               $"Schema:{context.Request.Scheme} " +
            //               $"Host: {context.Request.Host} " +
            //               $"Path: {context.Request.Path} " +
            //               $"QueryString: {context.Request.QueryString} " +
            //               $"Response Body: {responseText}");

            //    await responseBody.CopyToAsync(originalBodyStream);
            //}
        }



        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var body = request.Body;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;


            return $"Http Request Information:{Environment.NewLine}" +
                    $"Schema:{request.Scheme} " +
                    $"Host: {request.Host} " +
                    $"Path: {request.Path} " +
                    $"QueryString: {request.QueryString} " +
                    $"Request Body: {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return text;
        }

    }
}
