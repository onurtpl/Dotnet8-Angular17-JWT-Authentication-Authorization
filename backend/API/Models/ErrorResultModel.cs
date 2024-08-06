using Newtonsoft.Json;

namespace API.Models;

public class ErrorResultModel : ErrorStatusCodeModel
{
    public string? Message { get; set; }
}

public class ErrorStatusCodeModel
{
    public int StatusCode { get; set; }

    public override string ToString() =>
        JsonConvert.SerializeObject(this);

}

public sealed class ValidationErrorDetailsModel : ErrorStatusCodeModel
{
    public IEnumerable<string> Errors { get; set; } = [];
}