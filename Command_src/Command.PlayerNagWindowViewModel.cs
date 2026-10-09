using System.IO;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class PlayerNagWindowViewModel : CommandViewModel
{
	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	public string INI_String
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "INI_String");
			OnPropertyChanged("NeverShowAgain");
		}
	}

	public string Title
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Title");
		}
	}

	public string Message
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "Message");
		}
	}

	public bool NeverShowAgain
	{
		get
		{
			IniConfigSource iniConfigSource;
			if (!FileExistsNative.FileExistsFast(method_0()))
			{
				iniConfigSource = new IniConfigSource();
				iniConfigSource.Save(method_0());
			}
			iniConfigSource = new IniConfigSource(method_0());
			string text = iniConfigSource.Configs[INI_String]?.Get("NeverShowAgain");
			if (text == null)
			{
				return false;
			}
			return Conversions.ToBoolean(text);
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				IniConfigSource iniConfigSource;
				if (!FileExistsNative.FileExistsFast(method_0()))
				{
					iniConfigSource = new IniConfigSource();
					iniConfigSource.Save(method_0());
				}
				iniConfigSource = new IniConfigSource(method_0());
				if (iniConfigSource.Configs[INI_String] == null)
				{
					iniConfigSource.AddConfig(INI_String);
				}
				iniConfigSource.Configs[INI_String].Set("NeverShowAgain", value);
				iniConfigSource.Save(method_0());
				OnPropertyChanged("NeverShowAgain");
			}
		}
	}

	[SpecialName]
	private string method_0()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "PlayerDialogOptions.ini");
	}

	static PlayerNagWindowViewModel()
	{
		Class72.smethod_20();
	}
}
