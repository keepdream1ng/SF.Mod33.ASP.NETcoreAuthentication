using BLL = SF.Mod33.ASP.NETcoreAuthentication.BLL;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Authentication;

namespace SF.Mod33.ASP.NETcoreAuthentication.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly BLL.ILogger _logger;
	private readonly IUserRepository _repository;
	private readonly IMapper _mapper;

	public UserController(
		BLL.ILogger logger,
		IUserRepository repository,
		IMapper mapper
		)
	{
		_logger = logger;
		_repository = repository;
		_mapper = mapper;
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

	[HttpGet]
	[Route("viewmodel")]
	public UserViewModel GetUserViewModel()
	{
		User user = new User()
		{
			Id = Guid.NewGuid(),
			FirstName = "Иван",
			LastName = "Иванов",
			Email = "ivan@gmail.com",
			Password = "11111122222qq",
			Login = "ivanov"
		};

		UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);

		return userViewModel;
	}
	[HttpPost]
	[Route("authenticate")]
	public UserViewModel Authenticate(string login, string password)
	{
		if (String.IsNullOrEmpty(login) ||
		  String.IsNullOrEmpty(password))
			throw new ArgumentNullException("Запрос не корректен");

		UserEntity user = _repository.GetByLogin(login);
		if (user is null)
			throw new AuthenticationException("Пользователь на найден");

		if (user.Password != password)
			throw new AuthenticationException("Введенный пароль не корректен");

		return _mapper.Map<UserViewModel>(user);
	}
}
