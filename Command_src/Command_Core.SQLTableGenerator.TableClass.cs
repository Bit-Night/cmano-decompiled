using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using ServiceStack.Text;

namespace Command_Core.SQLTableGenerator;

public sealed class TableClass
{
	private List<KeyValuePair<string, Type>> list_0;

	private string string_0;

	private static Dictionary<Type, string> dictionary_0;

	public List<KeyValuePair<string, Type>> Fields
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public string ClassName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	[SpecialName]
	private static Dictionary<Type, string> smethod_0()
	{
		if (dictionary_0 == null)
		{
			dictionary_0 = new Dictionary<Type, string>();
			dictionary_0.Add(typeof(int), "BIGINT");
			dictionary_0.Add(typeof(string), "NVARCHAR");
			dictionary_0.Add(typeof(bool), "BIT");
			dictionary_0.Add(typeof(DateTime), "DATETIME");
			dictionary_0.Add(typeof(float), "FLOAT");
			dictionary_0.Add(typeof(double), "FLOAT");
			dictionary_0.Add(typeof(decimal), "DECIMAL(18,0)");
			dictionary_0.Add(typeof(Guid), "UNIQUEIDENTIFIER");
			dictionary_0.Add(typeof(TimeSpan), "NVARCHAR");
		}
		return dictionary_0;
	}

	public TableClass(Type t)
	{
		list_0 = new List<KeyValuePair<string, Type>>();
		string_0 = string.Empty;
		string_0 = t.Name;
		PropertyInfo[] properties = t.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			KeyValuePair<string, Type> item = new KeyValuePair<string, Type>(propertyInfo.Name, propertyInfo.PropertyType);
			Fields.Add(item);
		}
	}

	internal string CreateTableScript()
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		stringBuilder.AppendLine("CREATE TABLE " + ClassName);
		stringBuilder.AppendLine("(");
		stringBuilder.AppendLine("\t ID BIGINT IDENTITY(1,1) NOT NULL,");
		int num = Fields.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			KeyValuePair<string, Type> keyValuePair = Fields[i];
			if (smethod_0().ContainsKey(keyValuePair.Value))
			{
				stringBuilder.Append("\t " + keyValuePair.Key + " " + smethod_0()[keyValuePair.Value]);
			}
			else
			{
				stringBuilder.Append("\t " + keyValuePair.Key + " BIGINT");
			}
			if (i != Fields.Count - 1)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append(Environment.NewLine);
		}
		stringBuilder.AppendLine(")");
		string result = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return result;
	}

	static TableClass()
	{
		Class72.smethod_20();
	}
}
