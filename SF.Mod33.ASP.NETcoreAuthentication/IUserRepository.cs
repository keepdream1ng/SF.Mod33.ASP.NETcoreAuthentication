namespace SF.Mod33.ASP.NETcoreAuthentication
{
	public interface IUserRepository
	{
		IEnumerable<User> GetAll();
		User GetByLogin(string login);
	}
}