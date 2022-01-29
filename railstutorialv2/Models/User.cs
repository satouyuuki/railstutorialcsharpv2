﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace railstutorialv2.Models;

public class User
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string PasswordDigest { get; set; }
}