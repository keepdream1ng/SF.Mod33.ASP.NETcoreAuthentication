﻿using AutoMapper;

namespace SF.Mod33.ASP.NETcoreAuthentication.BLL;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<User, UserViewModel>()
			.ConstructUsing(v => new UserViewModel(v));
	}
}
