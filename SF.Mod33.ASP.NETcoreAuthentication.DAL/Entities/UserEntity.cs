﻿namespace SF.Mod33.ASP.NETcoreAuthentication.DAL;

public class UserEntity
{
	public Guid Id { get; set; }
	public string Login { get; set; }
	public string Password { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }

	public RoleEntity Role { get; set; }
}
