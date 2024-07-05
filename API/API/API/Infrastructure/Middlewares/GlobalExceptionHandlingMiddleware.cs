﻿namespace API.Infrastructure.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            
            _next = next;
             _logger = logger;

        }
        public async Task InvokeAsync(HttpContext context) {

            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                
            }
        }
    }
}
