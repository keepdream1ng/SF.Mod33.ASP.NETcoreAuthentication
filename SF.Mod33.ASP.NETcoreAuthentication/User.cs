﻿namespace SF.Mod33.ASP.NETcoreAuthentication
{
	public class User
	{
		public Guid Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}
}
