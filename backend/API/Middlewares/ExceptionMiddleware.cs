using API.Models;
using Domain.Entities.Errors;
using Infrastructure.Context;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace API.Middlewares;

public sealed class ExceptionMiddleware : IMiddleware
{

    private readonly ApplicationDbContext _context;

    public ExceptionMiddleware(ApplicationDbContext context) =>
        _context = context;


    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await LogExceptionToDatabaseAsync(ex, context.Request);
            await HandleExceptionHandle(context, ex);
        }
    }

    private Task HandleExceptionHandle(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        if (ex is ValidationException validationException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            // Transform the ValidationFailure list into a list of error messages
            var errors = validationException.Errors.Select(e => e.ErrorMessage);
            return context.Response.WriteAsync(
                JsonSerializer.Serialize(new
                {
                    Errors = ((ValidationException)ex).Errors.Select(s => s.ErrorMessage).Distinct(),
                    StatusCode = (int)HttpStatusCode.BadRequest
                }));
        }
        return context.Response.WriteAsync(new ErrorResultModel
        {
            Message = ex.Message,
            StatusCode = context.Response.StatusCode
        }.ToString());
    }

    private async Task LogExceptionToDatabaseAsync(Exception ex, HttpRequest request)
    {
        ErrorLog errorLog = new()
        {
            ErrorMessage = ex.Message,
            StackTrace = ex.StackTrace,
            RequestMethod = request.Method,
            RequestPath = request.Path,
            Timestamp = DateTime.Now,
        };
        await _context.Set<ErrorLog>().AddAsync(errorLog, default);
        await _context.SaveChangesAsync(default);
    }
}