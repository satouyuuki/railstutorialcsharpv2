using System;
using System.ComponentModel.DataAnnotations;
using railstutorialv2.Attributes;

namespace railstutorialv2.ViewModels;

public class UserViewModel
{
    public UserViewModel()
    {
    }
    public int Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    [EmailUserUnique]
    public string Email { get; set; }
    [StringLength(50, MinimumLength = 4)]
    public string Password { get; set; }
    [Compare(nameof(Password))]
    public string PasswordConfirmation { get; set; }
    public string PasswordDigest
    {
        get
        {
            return BCrypt.Net.BCrypt.HashPassword(Password, workFactor: 13);
        }
    }
}