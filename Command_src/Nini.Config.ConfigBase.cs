using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Nini.Util;

namespace Nini.Config;

public class ConfigBase : IConfig
{
	private string string_0;

	private IConfigSource iconfigSource_0;

	private AliasText aliasText_0;

	private IFormatProvider iformatProvider_0 = NumberFormatInfo.CurrentInfo;

	protected OrderedList keys = new OrderedList();

	[CompilerGenerated]
	private ConfigKeyEventHandler configKeyEventHandler_0;

	[CompilerGenerated]
	private ConfigKeyEventHandler configKeyEventHandler_1;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				Rename(value);
			}
		}
	}

	public IConfigSource ConfigSource => iconfigSource_0;

	public AliasText Alias => aliasText_0;

	public event ConfigKeyEventHandler KeySet
	{
		[CompilerGenerated]
		add
		{
			ConfigKeyEventHandler configKeyEventHandler = configKeyEventHandler_0;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Combine(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref configKeyEventHandler_0, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigKeyEventHandler configKeyEventHandler = configKeyEventHandler_0;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Remove(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref configKeyEventHandler_0, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
	}

	public event ConfigKeyEventHandler KeyRemoved
	{
		[CompilerGenerated]
		add
		{
			ConfigKeyEventHandler configKeyEventHandler = configKeyEventHandler_1;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Combine(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref configKeyEventHandler_1, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigKeyEventHandler configKeyEventHandler = configKeyEventHandler_1;
			ConfigKeyEventHandler configKeyEventHandler2;
			do
			{
				configKeyEventHandler2 = configKeyEventHandler;
				ConfigKeyEventHandler value2 = (ConfigKeyEventHandler)Delegate.Remove(configKeyEventHandler2, value);
				configKeyEventHandler = Interlocked.CompareExchange(ref configKeyEventHandler_1, value2, configKeyEventHandler2);
			}
			while ((object)configKeyEventHandler != configKeyEventHandler2);
		}
	}

	public ConfigBase(string name, IConfigSource source)
	{
		string_0 = name;
		iconfigSource_0 = source;
		aliasText_0 = new AliasText();
	}

	public bool Contains(string key)
	{
		return Get(key) != null;
	}

	public virtual string Get(string key)
	{
		string result = null;
		if (keys.Contains(key))
		{
			result = keys[key].ToString();
		}
		return result;
	}

	public string Get(string key, string defaultValue)
	{
		string text = Get(key);
		if (text != null)
		{
			return text;
		}
		return defaultValue;
	}

	public string GetExpanded(string key)
	{
		return ConfigSource.GetExpanded(this, key);
	}

	public string GetString(string key)
	{
		return Get(key);
	}

	public string GetString(string key, string defaultValue)
	{
		return Get(key, defaultValue);
	}

	public int GetInt(string key)
	{
		return Convert.ToInt32(Get(key) ?? throw new ArgumentException("Value not found: " + key), iformatProvider_0);
	}

	public int GetInt(string key, bool fromAlias)
	{
		if (!fromAlias)
		{
			return GetInt(key);
		}
		string text = Get(key);
		if (text == null)
		{
			throw new ArgumentException("Value not found: " + key);
		}
		return method_0(key, text);
	}

	public int GetInt(string key, int defaultValue)
	{
		string text = Get(key);
		if (text == null)
		{
			return defaultValue;
		}
		return Convert.ToInt32(text, iformatProvider_0);
	}

	public int GetInt(string key, int defaultValue, bool fromAlias)
	{
		if (fromAlias)
		{
			string text = Get(key);
			if (text != null)
			{
				return method_0(key, text);
			}
			return defaultValue;
		}
		return GetInt(key, defaultValue);
	}

	public long GetLong(string key)
	{
		return Convert.ToInt64(Get(key) ?? throw new ArgumentException("Value not found: " + key), iformatProvider_0);
	}

	public long GetLong(string key, long defaultValue)
	{
		string text = Get(key);
		if (text == null)
		{
			return defaultValue;
		}
		return Convert.ToInt64(text, iformatProvider_0);
	}

	public bool GetBoolean(string key)
	{
		string text = Get(key);
		if (text == null)
		{
			throw new ArgumentException("Value not found: " + key);
		}
		return method_1(text);
	}

	public bool GetBoolean(string key, bool defaultValue)
	{
		string text = Get(key);
		if (text != null)
		{
			return method_1(text);
		}
		return defaultValue;
	}

	public float GetFloat(string key)
	{
		return Convert.ToSingle(Get(key) ?? throw new ArgumentException("Value not found: " + key), iformatProvider_0);
	}

	public float GetFloat(string key, float defaultValue)
	{
		string text = Get(key);
		if (text != null)
		{
			return Convert.ToSingle(text, iformatProvider_0);
		}
		return defaultValue;
	}

	public double GetDouble(string key)
	{
		return Convert.ToDouble(Get(key) ?? throw new ArgumentException("Value not found: " + key), iformatProvider_0);
	}

	public double GetDouble(string key, double defaultValue)
	{
		string text = Get(key);
		if (text != null)
		{
			return Convert.ToDouble(text, iformatProvider_0);
		}
		return defaultValue;
	}

	public string[] GetKeys()
	{
		string[] array = new string[keys.Keys.Count];
		keys.Keys.CopyTo(array, 0);
		return array;
	}

	public string[] GetValues()
	{
		string[] array = new string[keys.Values.Count];
		keys.Values.CopyTo(array, 0);
		return array;
	}

	public void Add(string key, string value)
	{
		keys.Add(key, value);
	}

	public virtual void Set(string key, object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("Value cannot be null");
		}
		if (Get(key) == null)
		{
			Add(key, value.ToString());
		}
		else
		{
			keys[key] = value.ToString();
		}
		if (ConfigSource.AutoSave)
		{
			ConfigSource.Save();
		}
		OnKeySet(new ConfigKeyEventArgs(key, value.ToString()));
	}

	public virtual void Remove(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("Key cannot be null");
		}
		if (Get(key) != null)
		{
			string keyValue = null;
			if (configKeyEventHandler_0 != null)
			{
				keyValue = Get(key);
			}
			keys.Remove(key);
			OnKeyRemoved(new ConfigKeyEventArgs(key, keyValue));
		}
	}

	protected void OnKeySet(ConfigKeyEventArgs e)
	{
		if (configKeyEventHandler_0 != null)
		{
			configKeyEventHandler_0(this, e);
		}
	}

	protected void OnKeyRemoved(ConfigKeyEventArgs e)
	{
		if (configKeyEventHandler_1 != null)
		{
			configKeyEventHandler_1(this, e);
		}
	}

	private void Rename(string name)
	{
		ConfigSource.Configs.Remove(this);
		string_0 = name;
		ConfigSource.Configs.Add(this);
	}

	private int method_0(string string_1, string string_2)
	{
		int num = -1;
		if (aliasText_0.ContainsInt(string_1, string_2))
		{
			return aliasText_0.GetInt(string_1, string_2);
		}
		return ConfigSource.Alias.GetInt(string_1, string_2);
	}

	private bool method_1(string string_1)
	{
		bool flag = false;
		if (aliasText_0.ContainsBoolean(string_1))
		{
			return aliasText_0.GetBoolean(string_1);
		}
		if (!ConfigSource.Alias.ContainsBoolean(string_1))
		{
			throw new ArgumentException("Alias value not found: " + string_1 + ". Add it to the Alias property.");
		}
		return ConfigSource.Alias.GetBoolean(string_1);
	}

	static ConfigBase()
	{
		Class72.smethod_20();
	}
}
