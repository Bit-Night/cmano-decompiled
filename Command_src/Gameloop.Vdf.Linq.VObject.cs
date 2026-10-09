using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using Gameloop.Vdf.Utilities;

namespace Gameloop.Vdf.Linq;

public sealed class VObject : VToken, IDictionary<string, VToken>, ICollection<KeyValuePair<string, VToken>>, IEnumerable<KeyValuePair<string, VToken>>, IEnumerable
{
	private class Class27 : DynamicProxy<VObject>
	{
		public override bool TryGetMember(VObject instance, GetMemberBinder binder, out object result)
		{
			result = instance[binder.Name];
			return true;
		}

		public override bool TrySetMember(VObject instance, SetMemberBinder binder, object value)
		{
			VToken vToken = value as VToken;
			if (vToken == null)
			{
				vToken = new VValue(value);
			}
			instance[binder.Name] = vToken;
			return true;
		}

		public override IEnumerable<string> GetDynamicMemberNames(VObject instance)
		{
			return from p in instance.Children()
				select p.Key;
		}

		static Class27()
		{
			Class72.smethod_20();
		}
	}

	private readonly List<VProperty> OrpyqmxcExf;

	public int Count => OrpyqmxcExf.Count;

	public override VToken this[object key]
	{
		get
		{
			ValidationUtils.ArgumentNotNull(key, "key");
			if (!(key is string key2))
			{
				throw new ArgumentException("Accessed JObject values with invalid key value: " + MiscellaneousUtils.ToString(key) + ". Object property name expected.");
			}
			return this[key2];
		}
		set
		{
			ValidationUtils.ArgumentNotNull(key, "key");
			if (!(key is string key2))
			{
				throw new ArgumentException("Set JObject values with invalid key value: " + MiscellaneousUtils.ToString(key) + ". Object property name expected.");
			}
			this[key2] = value;
		}
	}

	public VToken this[string key]
	{
		get
		{
			if (TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}
		set
		{
			VProperty vProperty = OrpyqmxcExf.FirstOrDefault((VProperty x) => x.Key == key);
			if (vProperty != null)
			{
				vProperty.Value = value;
			}
			else
			{
				Add(key, value);
			}
		}
	}

	ICollection<string> IDictionary<string, VToken>.Keys => OrpyqmxcExf.Select((VProperty x) => x.Key).ToList();

	ICollection<VToken> IDictionary<string, VToken>.Values
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	bool ICollection<KeyValuePair<string, VToken>>.IsReadOnly => false;

	public VObject()
	{
		OrpyqmxcExf = new List<VProperty>();
	}

	public override IEnumerable<VProperty> Children()
	{
		return OrpyqmxcExf;
	}

	public void Add(string key, VToken value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		OrpyqmxcExf.Add(new VProperty(key, value));
	}

	public void Add(VProperty property)
	{
		if (property != null)
		{
			if (property.Value == null)
			{
				throw new ArgumentNullException("Value");
			}
			OrpyqmxcExf.Add(property);
			return;
		}
		throw new ArgumentNullException("property");
	}

	public void Clear()
	{
		OrpyqmxcExf.Clear();
	}

	public bool ContainsKey(string key)
	{
		return OrpyqmxcExf.Exists((VProperty x) => x.Key == key);
	}

	public void CopyTo(VProperty[] array, int arrayIndex)
	{
		OrpyqmxcExf.CopyTo(array, arrayIndex);
	}

	public bool Remove(string key)
	{
		return OrpyqmxcExf.RemoveAll((VProperty x) => x.Key == key) != 0;
	}

	public bool TryGetValue(string key, out VToken value)
	{
		value = OrpyqmxcExf.FirstOrDefault((VProperty x) => x.Key == key)?.Value;
		return value != null;
	}

	public void RemoveAt(string key)
	{
		OrpyqmxcExf.RemoveAll((VProperty x) => x.Key == key);
	}

	public override void WriteTo(VdfWriter writer)
	{
		writer.WriteObjectStart();
		foreach (VProperty item in OrpyqmxcExf)
		{
			item.WriteTo(writer);
		}
		writer.WriteObjectEnd();
	}

	public IEnumerator<KeyValuePair<string, VToken>> GetEnumerator()
	{
		foreach (VProperty item in OrpyqmxcExf)
		{
			yield return new KeyValuePair<string, VToken>(item.Key, item.Value);
		}
	}

	void ICollection<KeyValuePair<string, VToken>>.Add(KeyValuePair<string, VToken> item)
	{
		Add(new VProperty(item.Key, item.Value));
	}

	void ICollection<KeyValuePair<string, VToken>>.Clear()
	{
		OrpyqmxcExf.Clear();
	}

	bool ICollection<KeyValuePair<string, VToken>>.Contains(KeyValuePair<string, VToken> item)
	{
		VProperty vProperty = OrpyqmxcExf.FirstOrDefault((VProperty x) => x.Key == item.Key);
		if (vProperty != null)
		{
			return vProperty.Value == item.Value;
		}
		return false;
	}

	void ICollection<KeyValuePair<string, VToken>>.CopyTo(KeyValuePair<string, VToken>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex >= 0)
		{
			if (arrayIndex >= array.Length && arrayIndex != 0)
			{
				throw new ArgumentException("arrayIndex is equal to or greater than the length of array.");
			}
			if (Count <= array.Length - arrayIndex)
			{
				for (int i = 0; i < OrpyqmxcExf.Count; i++)
				{
					array[arrayIndex + i] = new KeyValuePair<string, VToken>(OrpyqmxcExf[i].Key, OrpyqmxcExf[i].Value);
				}
				return;
			}
			throw new ArgumentException("The number of elements in the source JObject is greater than the available space from arrayIndex to the end of the destination array.");
		}
		throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex is less than 0.");
	}

	bool ICollection<KeyValuePair<string, VToken>>.Remove(KeyValuePair<string, VToken> item)
	{
		if (((ICollection<KeyValuePair<string, VToken>>)this).Contains(item))
		{
			((IDictionary<string, VToken>)this).Remove(item.Key);
			return true;
		}
		return false;
	}

	protected override DynamicMetaObject GetMetaObject(Expression parameter)
	{
		return new DynamicProxyMetaObject<VObject>(parameter, this, new Class27());
	}

	static VObject()
	{
		Class72.smethod_20();
	}
}
