using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SF.Mod33.ASP.NETcoreAuthentication;
namespace SF.Mod33.ASP.NETcoreAuthentication.BLL;

public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		string message = "Unknown error occured, but dont worry, help is on the way!";
		if (context.Exception is CustomException)
		{
			message = context.Exception.Message;
		}

		context.Result = new BadRequestObjectResult(message);
	}
}
