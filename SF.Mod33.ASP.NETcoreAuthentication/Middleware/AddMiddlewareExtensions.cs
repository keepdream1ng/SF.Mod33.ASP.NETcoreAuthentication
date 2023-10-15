namespace SF.Mod33.ASP.NETcoreAuthentication;
public static class AddMiddlewareExtensions 
{
  public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder) 
  {
    return builder.UseMiddleware < LogMiddleware > ();
  }
}
