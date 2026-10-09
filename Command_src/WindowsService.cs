using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class WindowsService
{
	private static Regex regex_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private FileInfo fileInfo_0;

	[CompilerGenerated]
	private FileVersionInfo fileVersionInfo_0;

	public string DisplayName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		private set
		{
			string_1 = value;
		}
	}

	public string CommandLine
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		private set
		{
			string_2 = value;
		}
	}

	public FileInfo Executable
	{
		[CompilerGenerated]
		get
		{
			return fileInfo_0;
		}
		[CompilerGenerated]
		private set
		{
			fileInfo_0 = value;
		}
	}

	public FileVersionInfo Version
	{
		[CompilerGenerated]
		get
		{
			return fileVersionInfo_0;
		}
		[CompilerGenerated]
		private set
		{
			fileVersionInfo_0 = value;
		}
	}

	public WindowsService(ServiceController service)
	{
		Name = service.ServiceName.ToLower();
		DisplayName = service.DisplayName.ToLower();
		try
		{
			string text = "SYSTEM\\CurrentControlSet\\Services\\" + service.ServiceName;
			RegistryKey obj = Registry.LocalMachine.OpenSubKey(text);
			string name = obj.GetValue("ImagePath").ToString();
			obj.Close();
			CommandLine = Environment.ExpandEnvironmentVariables(name).ToLower();
			Match match = regex_0.Match(CommandLine);
			if (!match.Success)
			{
				return;
			}
			string text2 = match.Groups["name"].Value;
			if (!FileExistsNative.FileExistsFast(text2))
			{
				text2 += ".exe";
			}
			if (FileExistsNative.FileExistsFast(text2))
			{
				Executable = new FileInfo(text2);
				if (Executable != null && Executable.Exists)
				{
					Version = FileVersionInfo.GetVersionInfo(text2);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} ({1})", DisplayName, Name);
		if (Executable != null)
		{
			if (Executable != null)
			{
				stringBuilder.AppendFormat(" - {0}", Executable.ToString());
			}
			if (Version != null)
			{
				stringBuilder.AppendFormat(" (v{0})", Version.ProductVersion);
			}
		}
		else
		{
			stringBuilder.AppendFormat(" - {0}", CommandLine);
		}
		return stringBuilder.ToString();
	}

	static WindowsService()
	{
		Class72.smethod_20();
		regex_0 = new Regex("((?<name>[A-Z]:.+?(\\.exe|\\Z))|(?:\"(?<name>.+?)\"))", RegexOptions.IgnoreCase);
	}
}
