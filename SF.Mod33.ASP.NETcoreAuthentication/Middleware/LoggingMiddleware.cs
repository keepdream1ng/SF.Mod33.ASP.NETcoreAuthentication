using BLL = SF.Mod33.ASP.NETcoreAuthentication.BLL;
namespace SF.Mod33.ASP.NETcoreAuthentication;
public class LogMiddleware 
{
  private readonly BLL.ILogger _logger;
  private readonly RequestDelegate _next;

  public LogMiddleware(RequestDelegate next, BLL.ILogger logger) 
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext httpContext) 
  {
    _logger.WriteEvent($"New connection from {httpContext.Connection.RemoteIpAddress}");
    await _next(httpContext);
  }
}
