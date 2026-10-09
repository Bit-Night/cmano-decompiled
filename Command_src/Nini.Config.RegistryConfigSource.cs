using System;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace Nini.Config;

public class RegistryConfigSource : ConfigSourceBase
{
	private class Class44 : ConfigBase
	{
		private RegistryKey registryKey_0;

		private bool bool_0;

		public RegistryKey Key
		{
			get
			{
				return registryKey_0;
			}
			set
			{
				registryKey_0 = value;
			}
		}

		public Class44(string string_1, IConfigSource iconfigSource_1)
			: base(string_1, iconfigSource_1)
		{
		}

		[SpecialName]
		public bool method_2()
		{
			return bool_0;
		}

		[SpecialName]
		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		static Class44()
		{
			Class72.smethod_20();
		}
	}

	private RegistryKey registryKey_0;

	public RegistryKey DefaultKey
	{
		get
		{
			return registryKey_0;
		}
		set
		{
			registryKey_0 = value;
		}
	}

	public override IConfig AddConfig(string name)
	{
		if (DefaultKey == null)
		{
			throw new ApplicationException("You must set DefaultKey");
		}
		return AddConfig(name, DefaultKey);
	}

	public IConfig AddConfig(string name, RegistryKey key)
	{
		Class44 @class = new Class44(name, this);
		@class.Key = key;
		@class.method_3(bool_1: true);
		base.Configs.Add(@class);
		return @class;
	}

	public void AddMapping(RegistryKey registryKey, string path)
	{
		RegistryKey val = registryKey.OpenSubKey(path, true);
		if (val == null)
		{
			throw new ArgumentException("The specified key does not exist");
		}
		method_2(val, method_6(val));
	}

	public void AddMapping(RegistryKey registryKey, string path, RegistryRecurse recurse)
	{
		RegistryKey val = registryKey.OpenSubKey(path, true);
		if (val != null)
		{
			if (recurse == RegistryRecurse.Namespacing)
			{
				method_2(val, path);
			}
			else
			{
				method_2(val, method_6(val));
			}
			string[] subKeyNames = val.GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				switch (recurse)
				{
				case RegistryRecurse.Flattened:
					AddMapping(val, subKeyNames[i], recurse);
					break;
				case RegistryRecurse.Namespacing:
					AddMapping(registryKey, path + "\\" + subKeyNames[i], recurse);
					break;
				}
			}
			return;
		}
		throw new ArgumentException("The specified key does not exist");
	}

	public override void Save()
	{
		method_3();
		for (int i = 0; i < base.Configs.Count; i++)
		{
			if (base.Configs[i] is Class44)
			{
				Class44 @class = (Class44)base.Configs[i];
				string[] keys = @class.GetKeys();
				for (int j = 0; j < keys.Length; j++)
				{
					@class.Key.SetValue(keys[j], (object)@class.Get(keys[j]));
				}
			}
		}
	}

	public override void Reload()
	{
		method_4();
	}

	private void method_2(RegistryKey registryKey_1, string string_0)
	{
		Class44 @class = new Class44(string_0, this);
		@class.Key = registryKey_1;
		string[] valueNames = registryKey_1.GetValueNames();
		foreach (string text in valueNames)
		{
			@class.Add(text, registryKey_1.GetValue(text).ToString());
		}
		base.Configs.Add(@class);
	}

	private void method_3()
	{
		foreach (IConfig config in base.Configs)
		{
			if (config is Class44)
			{
				Class44 @class = (Class44)config;
				if (@class.method_2())
				{
					@class.Key = @class.Key.CreateSubKey(@class.Name);
				}
				method_5(@class);
				string[] keys = config.GetKeys();
				for (int i = 0; i < keys.Length; i++)
				{
					@class.Key.SetValue(keys[i], (object)config.Get(keys[i]));
				}
				@class.Key.Flush();
			}
		}
	}

	private void method_4()
	{
		RegistryKey[] array = (RegistryKey[])(object)new RegistryKey[base.Configs.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ((Class44)base.Configs[i]).Key;
		}
		base.Configs.Clear();
		for (int j = 0; j < array.Length; j++)
		{
			method_2(array[j], method_6(array[j]));
		}
	}

	private void method_5(Class44 class44_0)
	{
		string[] valueNames = class44_0.Key.GetValueNames();
		foreach (string text in valueNames)
		{
			if (!class44_0.Contains(text))
			{
				class44_0.Key.DeleteValue(text);
			}
		}
	}

	private string method_6(RegistryKey registryKey_1)
	{
		int num = registryKey_1.Name.LastIndexOf("\\");
		if (num != -1)
		{
			return registryKey_1.Name.Substring(num + 1);
		}
		return registryKey_1.Name;
	}

	static RegistryConfigSource()
	{
		Class72.smethod_20();
	}
}
