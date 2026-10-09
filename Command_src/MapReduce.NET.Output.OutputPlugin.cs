using System;
using System.Collections;
using System.Collections.Generic;
using MapReduce.NET.Serializer;

namespace MapReduce.NET.Output;

public abstract class OutputPlugin : IOPlugin
{
	protected ISerializer serializer;

	public OutputPlugin(string outputLocation, ISerializer serializer)
	{
		base.Location = outputLocation;
		this.serializer = serializer;
	}

	public void Save(IDictionary output)
	{
		Type[] genericArguments = output.GetType().GetGenericArguments();
		Type type = genericArguments[0];
		Type type2 = genericArguments[1];
		GetType().GetMethod("SaveGeneric").MakeGenericMethod(type, type2).Invoke(this, new object[1] { output });
	}

	public void SaveGeneric<K, V>(IDictionary<K, V> output)
	{
		uint num = 0u;
		Open();
		foreach (KeyValuePair<K, V> item in output)
		{
			SaveItem(item.Key, item.Value);
			if (++num % base.ReportEveryNth == 0)
			{
				RaiseStatusUpdate(UpdateType.Output, num);
			}
		}
		Close();
		RaiseStatusUpdate(UpdateType.Output, num);
	}

	protected abstract void SaveItem<K, V>(K key, V value);

	protected abstract void Open();

	protected abstract void Close();

	static OutputPlugin()
	{
		Class72.smethod_20();
	}
}
