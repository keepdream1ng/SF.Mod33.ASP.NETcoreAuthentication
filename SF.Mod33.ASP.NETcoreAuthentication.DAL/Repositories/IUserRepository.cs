namespace SF.Mod33.ASP.NETcoreAuthentication.DAL
{
	public interface IUserRepository
	{
		IEnumerable<UserEntity> GetAll();
		UserEntity GetByLogin(string login);
	}
}