using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Nini.Config;

public class ConfigCollection : ICollection, IEnumerable, IList
{
	private ArrayList arrayList_0 = new ArrayList();

	private ConfigSourceBase configSourceBase_0;

	[CompilerGenerated]
	private ConfigEventHandler IbSyOpWyEkH;

	[CompilerGenerated]
	private ConfigEventHandler configEventHandler_0;

	public int Count => arrayList_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public IConfig this[int index] => (IConfig)arrayList_0[index];

	object IList.this[int index]
	{
		get
		{
			return arrayList_0[index];
		}
		set
		{
		}
	}

	public IConfig this[string configName]
	{
		get
		{
			IConfig result = null;
			foreach (IConfig item in arrayList_0)
			{
				if (item.Name == configName)
				{
					result = item;
					break;
				}
			}
			return result;
		}
	}

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public event ConfigEventHandler ConfigAdded
	{
		[CompilerGenerated]
		add
		{
			ConfigEventHandler configEventHandler = IbSyOpWyEkH;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Combine(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref IbSyOpWyEkH, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigEventHandler configEventHandler = IbSyOpWyEkH;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Remove(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref IbSyOpWyEkH, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
	}

	public event ConfigEventHandler ConfigRemoved
	{
		[CompilerGenerated]
		add
		{
			ConfigEventHandler configEventHandler = configEventHandler_0;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Combine(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref configEventHandler_0, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ConfigEventHandler configEventHandler = configEventHandler_0;
			ConfigEventHandler configEventHandler2;
			do
			{
				configEventHandler2 = configEventHandler;
				ConfigEventHandler value2 = (ConfigEventHandler)Delegate.Remove(configEventHandler2, value);
				configEventHandler = Interlocked.CompareExchange(ref configEventHandler_0, value2, configEventHandler2);
			}
			while ((object)configEventHandler != configEventHandler2);
		}
	}

	public ConfigCollection(ConfigSourceBase owner)
	{
		configSourceBase_0 = owner;
	}

	public void Add(IConfig config)
	{
		if (!arrayList_0.Contains(config))
		{
			IConfig config2 = this[config.Name];
			if (config2 == null)
			{
				arrayList_0.Add(config);
				OnConfigAdded(new ConfigEventArgs(config));
				return;
			}
			string[] keys = config.GetKeys();
			for (int i = 0; i < keys.Length; i++)
			{
				config2.Set(keys[i], config.Get(keys[i]));
			}
			return;
		}
		throw new ArgumentException("IConfig already exists");
	}

	int IList.Add(object config)
	{
		if (!(config is IConfig config2))
		{
			throw new Exception("Must be an IConfig");
		}
		Add(config2);
		return IndexOf(config2);
	}

	public IConfig Add(string name)
	{
		ConfigBase configBase = null;
		if (this[name] != null)
		{
			throw new ArgumentException("An IConfig of that name already exists");
		}
		configBase = new ConfigBase(name, configSourceBase_0);
		arrayList_0.Add(configBase);
		OnConfigAdded(new ConfigEventArgs(configBase));
		return configBase;
	}

	public void Remove(IConfig config)
	{
		arrayList_0.Remove(config);
		OnConfigRemoved(new ConfigEventArgs(config));
	}

	public void Remove(object config)
	{
		arrayList_0.Remove(config);
		OnConfigRemoved(new ConfigEventArgs((IConfig)config));
	}

	public void RemoveAt(int index)
	{
		IConfig config = (IConfig)arrayList_0[index];
		arrayList_0.RemoveAt(index);
		OnConfigRemoved(new ConfigEventArgs(config));
	}

	public void Clear()
	{
		arrayList_0.Clear();
	}

	public IEnumerator GetEnumerator()
	{
		return arrayList_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		arrayList_0.CopyTo(array, index);
	}

	public void CopyTo(IConfig[] array, int index)
	{
		((ICollection)arrayList_0).CopyTo((Array)array, index);
	}

	public bool Contains(object config)
	{
		return arrayList_0.Contains(config);
	}

	public int IndexOf(object config)
	{
		return arrayList_0.IndexOf(config);
	}

	public void Insert(int index, object config)
	{
		arrayList_0.Insert(index, config);
	}

	protected void OnConfigAdded(ConfigEventArgs e)
	{
		if (IbSyOpWyEkH != null)
		{
			IbSyOpWyEkH(this, e);
		}
	}

	protected void OnConfigRemoved(ConfigEventArgs e)
	{
		if (configEventHandler_0 != null)
		{
			configEventHandler_0(this, e);
		}
	}

	static ConfigCollection()
	{
		Class72.smethod_20();
	}
}
