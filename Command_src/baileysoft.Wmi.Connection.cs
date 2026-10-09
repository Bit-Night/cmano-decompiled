using System;
using System.Management;

namespace baileysoft.Wmi;

public sealed class Connection
{
	private ManagementScope managementScope_0;

	private ConnectionOptions connectionOptions_0;

	public ManagementScope GetConnectionScope => managementScope_0;

	public ConnectionOptions GetOptions => connectionOptions_0;

	public static ConnectionOptions SetConnectionOptions()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		return new ConnectionOptions
		{
			Impersonation = (ImpersonationLevel)3,
			Authentication = (AuthenticationLevel)0,
			EnablePrivileges = true
		};
	}

	public static ManagementScope SetConnectionScope(string machineName, ConnectionOptions options)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0035: Expected O, but got Unknown
		ManagementScope val = new ManagementScope();
		val.Path = new ManagementPath("\\\\" + machineName + "\\root\\CIMV2");
		val.Options = options;
		try
		{
			val.Connect();
		}
		catch (ManagementException ex)
		{
			ManagementException ex2 = ex;
			Console.WriteLine("An Error Occurred: " + ((Exception)(object)ex2).Message.ToString());
		}
		return val;
	}

	public Connection()
	{
		method_0(null, null, null, Environment.MachineName);
	}

	public Connection(string userName, string password, string domain, string machineName)
	{
		method_0(userName, password, domain, machineName);
	}

	private void method_0(string string_0, string string_1, string string_2, string string_3)
	{
		connectionOptions_0 = SetConnectionOptions();
		if (string_2 != null || string_0 != null)
		{
			connectionOptions_0.Username = string_2 + "\\" + string_0;
			connectionOptions_0.Password = string_1;
		}
		managementScope_0 = SetConnectionScope(string_3, connectionOptions_0);
	}

	static Connection()
	{
		Class72.smethod_20();
	}
}
