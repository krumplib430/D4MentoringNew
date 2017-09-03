﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteTaking.Common.Mapping;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.DataAccess.EfCore.Models;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.EfCore.Services
{
	public class UserQuery : IUserQuery
	{
		private readonly IMappingService _mappingService;

		public UserQuery(IMappingService mappingService)
		{
			_mappingService = mappingService;
		}

		public List<User> GetAll()
		{
			using (var context = new NoteTakingContext())
			{
				var userDaos = context.Users.ToList();
				return _mappingService.Map<List<UserDao>, List<User>>(userDaos);
			}
		}

		public async Task<User> GetAsync(Guid id)
		{
			using (var context = new NoteTakingContext())
			{
				var userDao = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
				return userDao == null ? null : _mappingService.Map<UserDao, User>(userDao);
			}
		}
	}
}