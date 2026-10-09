using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class InternetConnectivityCheck
{
	public static bool InternetConnectionAvailable;

	static InternetConnectivityCheck()
	{
		Class72.smethod_20();
		InternetConnectionAvailable = true;
	}

	public static void CheckConnectivity(bool CheckAsynchronously)
	{
		if (CheckAsynchronously)
		{
			Task.Factory.StartNew([SpecialName] () =>
			{
				smethod_2();
			});
		}
		else
		{
			smethod_2();
		}
	}

	private static void smethod_0()
	{
	}

	private static void smethod_1()
	{
	}

	private static void smethod_2()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		bool internetConnectionAvailable = InternetConnectionAvailable;
		InternetConnectionAvailable = false;
		string[] array = new string[3] { "https://www.defense.gov", "https://www.nist.gov", "https://www.google.com" };
		foreach (string text in array)
		{
			try
			{
				HttpClient val = new HttpClient();
				try
				{
					val.Timeout = TimeSpan.FromSeconds(3.0);
					if (!val.SendAsync(new HttpRequestMessage(HttpMethod.Head, text)).Result.IsSuccessStatusCode)
					{
						continue;
					}
					InternetConnectionAvailable = true;
					break;
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		if (InternetConnectionAvailable != internetConnectionAvailable)
		{
			if (!InternetConnectionAvailable)
			{
				smethod_1();
			}
			else
			{
				smethod_0();
			}
		}
	}
}
