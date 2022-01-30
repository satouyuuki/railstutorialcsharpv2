using System;
using System.ComponentModel.DataAnnotations;

namespace railstutorialv2.ViewModels;

public class LoginViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    [StringLength(50, MinimumLength = 4)]
    public string Password { get; set; }
}