using Domain.Entities.Abstractions;

namespace Domain.Entities.Errors;

public sealed class ErrorLog : BaseEntity
{
    public string? ErrorMessage { get; set; }
    public string? StackTrace { get; set; }
    public string? RequestPath { get; set; }
    public string? RequestMethod { get; set; }
    public DateTime Timestamp { get; set; }
}