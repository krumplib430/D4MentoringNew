﻿using System;

namespace NoteTaking.WebApi.Models
{
	public class UserListItemDto
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public DateTime RegisteredOn { get; set; }
	}
}