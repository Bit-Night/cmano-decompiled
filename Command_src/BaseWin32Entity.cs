using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using SmartAssembly.Attributes;

[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal abstract class BaseWin32Entity
{
	[CompilerGenerated]
	private Dictionary<string, object> dictionary_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private string string_4;

	public Dictionary<string, object> Properties
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		set
		{
			dictionary_0 = value;
		}
	}

	public string Caption
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		protected set
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
		protected set
		{
			string_1 = value;
		}
	}

	public string Manufacturer
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		protected set
		{
			string_2 = value;
		}
	}

	public string Model
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		protected set
		{
			string_3 = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		protected set
		{
			string_4 = value;
		}
	}

	public BaseWin32Entity(ManagementBaseObject obj)
	{
		Properties = new Dictionary<string, object>();
		PropertyDataEnumerator enumerator = obj.Properties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PropertyData current = enumerator.Current;
				Properties.Add(current.Name, current.Value);
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		Caption = ParseValue<string>(obj, "Caption");
		Name = ParseValue<string>(obj, "Name");
		Manufacturer = ParseValue<string>(obj, "Manufacturer");
		Model = ParseValue<string>(obj, "Model");
		Description = ParseValue<string>(obj, "Description");
		if (!string.IsNullOrEmpty(Caption))
		{
			Caption = Caption.ToLower();
		}
		if (!string.IsNullOrEmpty(Name))
		{
			Name = Name.ToLower();
		}
		if (!string.IsNullOrEmpty(Manufacturer))
		{
			Manufacturer = Manufacturer.ToLower();
		}
		if (!string.IsNullOrEmpty(Model))
		{
			Model = Model.ToLower();
		}
		if (!string.IsNullOrEmpty(Description))
		{
			Description = Description.ToLower();
		}
	}

	public override string ToString()
	{
		return $"manufacturer={Manufacturer}, name={Name}, model={Model}, caption={Caption}, description={Description}";
	}

	protected string PrintProperties()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string key in Properties.Keys)
		{
			stringBuilder.AppendLine($"{key} = {method_0(Properties[key])}");
		}
		return stringBuilder.ToString();
	}

	private object method_0(object object_0)
	{
		if (object_0 == null)
		{
			return string.Empty;
		}
		if (!object_0.GetType().IsArray)
		{
			return object_0;
		}
		return ToJSON(object_0);
	}

	protected string ToJSON(object value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new JavaScriptSerializer().Serialize(value);
	}

	protected T ParseValue<T>(ManagementBaseObject obj, string key)
	{
		object obj2 = null;
		PropertyDataEnumerator enumerator = obj.Properties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PropertyData current = enumerator.Current;
				if (current.Name == key)
				{
					obj2 = current.Value;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		if (obj2 == null)
		{
			if (typeof(T) == typeof(string))
			{
				return (T)Convert.ChangeType(string.Empty, typeof(T));
			}
			return default(T);
		}
		return (T)Convert.ChangeType(obj2, typeof(T));
	}

	static BaseWin32Entity()
	{
		Class72.smethod_20();
	}
}
