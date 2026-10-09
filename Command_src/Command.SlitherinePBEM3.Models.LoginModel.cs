using System;
using Newtonsoft.Json;

namespace Command.SlitherinePBEM3.Models;

internal class LoginModel
{
	public string Username;

	public int UserID;

	public string Token;

	public string ExpirationDate;

	public bool IsAnonymous;

	public int RatingScore;

	[JsonIgnore]
	public string Password;

	public bool HasTokenExpired()
	{
		if (DateTime.TryParse(ExpirationDate, out var result))
		{
			return DateTime.Compare(DateTime.UtcNow, result.ToUniversalTime().AddMinutes(-2.0)) >= 0;
		}
		return true;
	}

	static LoginModel()
	{
		Class72.smethod_20();
	}
}
