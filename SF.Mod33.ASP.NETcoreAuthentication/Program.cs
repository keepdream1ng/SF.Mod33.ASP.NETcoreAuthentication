using BLL = SF.Mod33.ASP.NETcoreAuthentication.BLL;
using DAL = SF.Mod33.ASP.NETcoreAuthentication.DAL;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DAL.AppContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
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

app.UseAuthorization();

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
