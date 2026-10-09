using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Nini.Config;

public abstract class ConfigSourceBase : IConfigSource
{
	private ArrayList deOyOaymmur = new ArrayList();

	private ConfigCollection configCollection_0;

	private bool bool_0;

	private AliasText aliasText_0 = new AliasText();

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	public ConfigCollection Configs => configCollection_0;

	public bool AutoSave
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public AliasText Alias => aliasText_0;

	public event EventHandler Reloaded
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler Saved
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ConfigSourceBase()
	{
		configCollection_0 = new ConfigCollection(this);
	}

	public void Merge(IConfigSource source)
	{
		if (!deOyOaymmur.Contains(source))
		{
			deOyOaymmur.Add(source);
		}
		foreach (IConfig config in source.Configs)
		{
			Configs.Add(config);
		}
	}

	public virtual IConfig AddConfig(string name)
	{
		return configCollection_0.Add(name);
	}

	public string GetExpanded(IConfig config, string key)
	{
		return method_0(config, key, bool_1: false);
	}

	public virtual void Save()
	{
		OnSaved(new EventArgs());
	}

	public virtual void Reload()
	{
		OnReloaded(new EventArgs());
	}

	public void ExpandKeyValues()
	{
		string[] array = null;
		foreach (IConfig item in configCollection_0)
		{
			array = item.GetKeys();
			for (int i = 0; i < array.Length; i++)
			{
				method_0(item, array[i], bool_1: true);
			}
		}
	}

	public void ReplaceKeyValues()
	{
		ExpandKeyValues();
	}

	protected void OnReloaded(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}

	protected void OnSaved(EventArgs e)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}

	private string method_0(IConfig iconfig_0, string string_0, bool bool_1)
	{
		string text = iconfig_0.Get(string_0);
		if (text != null)
		{
			while (true)
			{
				int num = text.IndexOf("${", 0);
				if (num == -1)
				{
					break;
				}
				int num2 = text.IndexOf("}", num + 2);
				if (num2 == -1)
				{
					break;
				}
				string text2 = text.Substring(num + 2, num2 - (num + 2));
				if (!(text2 == string_0))
				{
					string newValue = method_1(iconfig_0, text2);
					text = text.Replace("${" + text2 + "}", newValue);
					continue;
				}
				throw new ArgumentException("Key cannot have a expand value of itself: " + string_0);
			}
			if (bool_1)
			{
				iconfig_0.Set(string_0, text);
			}
			return text;
		}
		throw new ArgumentException($"[{string_0}] not found in [{iconfig_0.Name}]");
	}

	private string method_1(IConfig iconfig_0, string string_0)
	{
		string text = null;
		string[] array = string_0.Split(new char[1] { '|' });
		if (array.Length > 1)
		{
			text = (Configs[array[0]] ?? throw new ArgumentException("Expand config not found: " + array[0])).Get(array[1]);
			if (text == null)
			{
				throw new ArgumentException("Expand key not found: " + array[1]);
			}
		}
		else
		{
			text = iconfig_0.Get(string_0);
			if (text == null)
			{
				throw new ArgumentException("Key not found: " + string_0);
			}
		}
		return text;
	}

	static ConfigSourceBase()
	{
		Class72.smethod_20();
	}
}
