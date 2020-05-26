
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
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
            await _next(context);

            //    //Format the response from the server
            //    var response = await FormatResponse(context.Response);
            //    //_logger.LogInformation($"Http Response Information: {response}");

            //    //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
            //    await responseBody.CopyToAsync(originalBodyStream);
            //}
            ////First, get the incoming request
            //var request = await FormatRequest(context.Request);
            //_logger.LogInformation($"Http Request Information: {request}");

            ////Copy a pointer to the original response body stream
            //var originalBodyStream = context.Response.Body;

            ////Create a new memory stream...
            //using (var responseBody = new MemoryStream())
            //{
            //    //...and use that for the temporary response body
            //    context.Response.Body = responseBody;

            //    //Continue down the Middleware pipeline, eventually returning to this class
            //    await _next(context);

            //    //Format the response from the server
            //    var response = await FormatResponse(context.Response);
            //    //_logger.LogInformation($"Http Response Information: {response}");

            //    //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
            //    await responseBody.CopyToAsync(originalBodyStream);
            //}
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            Stream body = null;
            body = request.Body;
            HttpRequestRewindExtensions.EnableBuffering(request);

            //This line allows us to set the reader for the request back at the beginning of its stream.
            //request.EnableRewind();
            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            request.Body.Seek(0, SeekOrigin.Begin);

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{response.StatusCode}: {text}";
        }
    }
}

//public async Task Invoke(HttpContext context)
//{

//    //_logger.LogInformation(await FormatRequest(context.Request));
//    await _next(context);
//    //var originalBodyStream = context.Response.Body;

//    //using (var responseBody = new MemoryStream())
//    //{
//    //    context.Response.Body = responseBody;
//    //    await _next(context);

//    //    string responseText = await FormatResponse(context.Response);
//    //    _logger.LogInformation($"Http Response Information:{Environment.NewLine}" +
//    //               $"Schema:{context.Request.Scheme} " +
//    //               $"Host: {context.Request.Host} " +
//    //               $"Path: {context.Request.Path} " +
//    //               $"QueryString: {context.Request.QueryString} " +
//    //               $"Response Body: {responseText}");

//    //    await responseBody.CopyToAsync(originalBodyStream);
//    //}
//}



//private async Task<string> FormatRequest(HttpRequest request)
//{
//    request.EnableBuffering();

//    var body = request.Body;

//    var buffer = new byte[Convert.ToInt32(request.ContentLength)];
//    await request.Body.ReadAsync(buffer, 0, buffer.Length);
//    var bodyAsText = Encoding.UTF8.GetString(buffer);
//    request.Body = body;


//    return $"Http Request Information:{Environment.NewLine}" +
//            $"Schema:{request.Scheme} " +
//            $"Host: {request.Host} " +
//            $"Path: {request.Path} " +
//            $"QueryString: {request.QueryString} " +
//            $"Request Body: {bodyAsText}";
//}

//private async Task<string> FormatResponse(HttpResponse response)
//{
//    response.Body.Seek(0, SeekOrigin.Begin);
//    var text = await new StreamReader(response.Body).ReadToEndAsync();
//    response.Body.Seek(0, SeekOrigin.Begin);

//    return text;
//}

//}
//}
