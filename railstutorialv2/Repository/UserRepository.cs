using System;
using railstutorialv2.Models;
namespace railstutorialv2.Repository
{
	public static class UserRepository
	{
		public static List<User> Users = new()
		{
			new() { Id = 1, Name = "test1", Email = "test1@hoge.com" },
			new() { Id = 2, Name = "test2", Email = "test2@hoge.com" },
			new() { Id = 3, Name = "test3", Email = "test3@hoge.com" },
			new() { Id = 4, Name = "test4", Email = "test4@hoge.com" },
			new() { Id = 5, Name = "test5", Email = "test5@hoge.com" }
		};
	}
}

