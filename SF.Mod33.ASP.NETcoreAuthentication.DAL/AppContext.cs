using Microsoft.EntityFrameworkCore;

namespace SF.Mod33.ASP.NETcoreAuthentication.DAL;

public class AppContext : DbContext
{
	public DbSet<UserEntity> Users { get; set; }

	public AppContext()
	{
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		// I'm running a docker linux container instead of server on windows for study purposes.
		optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=ASPcoreAuthentication;User Id=SA;Password=Password1sSafe!;TrustServerCertificate=true;");
	}
}
