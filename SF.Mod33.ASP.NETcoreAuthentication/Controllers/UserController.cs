using Local = SF.Mod33.ASP.NETcoreAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace SF.Mod33.ASP.NETcoreAuthentication.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly Local.ILogger _logger;

	public UserController(Local.ILogger logger)
	{
		_logger = logger;
		_logger.WriteError("test error");
		_logger.WriteEvent("test event");
		_logger.WriteError("test error2");
	}

	[HttpGet]
	public User GetUser()
	{
		return new User()
		{
			Id = Guid.NewGuid(),
			FirstName = "Иван",
			LastName = "Ivanov",
			Email = "ivan@gmail.com",
			Login = "ivanov",
			Password = "1111111122222qq"
		};
	}

}
