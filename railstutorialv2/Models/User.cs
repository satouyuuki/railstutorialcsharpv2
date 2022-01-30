using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace railstutorialv2.Models;

public class User
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string PasswordDigest { get; set; }
	/// <summary>
    /// パスワードを検証する
    /// </summary>
    /// <param name="password">ユーザーに入力されたパスワード</param>
    /// <returns>bool</returns>
    public bool Authenticate(string password)
    {
		return BCrypt.Net.BCrypt.Verify(password, PasswordDigest);
	}
}