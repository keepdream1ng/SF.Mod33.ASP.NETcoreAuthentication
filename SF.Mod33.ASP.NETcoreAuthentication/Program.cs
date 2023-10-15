using BLL = SF.Mod33.ASP.NETcoreAuthentication.BLL;
using DAL = SF.Mod33.ASP.NETcoreAuthentication.DAL;
using AutoMapper;
using SF.Mod33.ASP.NETcoreAuthentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
	.AddCookie("Cookies", options =>
	{
		options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
		{
			OnRedirectToLogin = redirectConext =>
			{
				redirectConext.HttpContext.Response.StatusCode = 401;
				return Task.CompletedTask;
			}
		};
	});
//builder.Services.AddDbContext<DAL.AppContext>();
builder.Services.AddScoped<repository.IUserRepository, repository.UserRepository>();
builder.Services.AddSingleton<BLL.ILogger, BLL.Logger>();
builder.Services.AddSingleton(GetConfiguredMapper());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware();

app.MapControllers();

app.Run();

IMapper GetConfiguredMapper()
{
	var mapperConfig = new MapperConfiguration(v =>
	{
		v.AddProfile(new MappingProfile());
	});
	return mapperConfig.CreateMapper();
}
