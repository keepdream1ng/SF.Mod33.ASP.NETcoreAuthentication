using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod33.ASP.NETcoreAuthentication.DAL;

public class UserRepository : IUserRepository
{
	public AppContext Context { get; }
	public UserRepository(AppContext context)
	{
		Context = context;
	}

	public IEnumerable<UserEntity> GetAll()
	{
		return Context.Users.ToList();
	}
	public UserEntity GetByLogin(string login)
	{
		return Context.Users.SingleOrDefault(u => u.Login == login);
	}

}
