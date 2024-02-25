using CleanArchitecture.Domain.Entites.Common;

namespace CleanArchitecture.Domain.Entites.ErrorLog;

public sealed class ErrorLog : BaseEntity
{
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
    public string RequestPath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime TimeStamp { get; set; }
}
