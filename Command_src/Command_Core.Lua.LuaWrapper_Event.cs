using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public sealed class LuaWrapper_Event
{
	protected SimEvent ev;

	protected Scenario ScenarioContext;

	protected int level;

	protected bool bool_0;

	public object fields
	{
		get
		{
			Type type = GetType();
			int num = 0;
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] methods = type.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				MethodInfo[] array2 = methods;
				foreach (MethodInfo obj in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj.Name, text2, false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			MethodInfo[] array3 = methods;
			foreach (MethodInfo methodInfo in array3)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text3 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text3 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text3 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text3 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public object __obj => ev;

	[DoNotPrune]
	public LuaTable details
	{
		get
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Expected O, but got Unknown
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Expected O, but got Unknown
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Expected O, but got Unknown
			try
			{
				HashSet<string> hashSet = new HashSet<string>();
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				if (level == 0 || level == 1)
				{
					foreach (EventTrigger trigger in ev.Triggers)
					{
						EventTrigger theEvent = trigger;
						LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
						XmlDocument xml = new XmlDocument();
						StringBuilder sb = new StringBuilder();
						StringWriter stringWriter = new StringWriter(sb);
						LuaEvent.AddUnitToSerialized(ref theEvent, hashSet);
						XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
						try
						{
							theEvent.ToXML(val, hashSet, ScenarioContext);
							val.Flush();
						}
						finally
						{
							((IDisposable)val)?.Dispose();
						}
						xml.LoadXml(stringWriter.ToString());
						if (bool_0)
						{
							luaTable3["xml"] = xml.InnerXml;
						}
						luaTable3[theEvent.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xml);
						luaTable2[luaTable2.Keys.Count + 1] = luaTable3;
					}
					luaTable["triggers"] = luaTable2;
				}
				luaTable2 = LuaSandBox.Singleton().CreateTable();
				if (level == 0 || level == 2)
				{
					foreach (EventCondition condition in ev.Conditions)
					{
						LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
						XmlDocument xml2 = new XmlDocument();
						StringBuilder sb2 = new StringBuilder();
						StringWriter stringWriter2 = new StringWriter(sb2);
						XmlWriter val2 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter2);
						try
						{
							condition.ToXML(val2, hashSet, ScenarioContext);
							val2.Flush();
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
						xml2.LoadXml(stringWriter2.ToString());
						if (bool_0)
						{
							luaTable4["xml"] = xml2.InnerXml;
						}
						luaTable4[condition.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xml2);
						luaTable2[luaTable2.Keys.Count + 1] = luaTable4;
					}
					luaTable["conditions"] = luaTable2;
				}
				luaTable2 = LuaSandBox.Singleton().CreateTable();
				if (level == 0 || level == 3)
				{
					foreach (EventAction action in ev.Actions)
					{
						LuaTable luaTable5 = LuaSandBox.Singleton().CreateTable();
						luaTable5["type"] = action.Type.ToString();
						XmlDocument xml3 = new XmlDocument();
						StringBuilder sb3 = new StringBuilder();
						StringWriter stringWriter3 = new StringWriter(sb3);
						XmlWriter val3 = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter3);
						try
						{
							action.ToXML(val3, hashSet, ScenarioContext);
							val3.Flush();
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
						xml3.LoadXml(stringWriter3.ToString());
						if (bool_0)
						{
							luaTable5["xml"] = xml3.InnerXml;
						}
						luaTable5[action.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xml3);
						luaTable2[luaTable2.Keys.Count + 1] = luaTable5;
					}
					luaTable["actions"] = luaTable2;
				}
				if (level == 0 || level == 4)
				{
					luaTable["name"] = ev.Name;
					luaTable["guid"] = ev.ObjectID;
					luaTable["description"] = ev.Description;
					luaTable["isActive"] = ev.IsActive;
					luaTable["isShown"] = ev.IsShown;
					luaTable["isRepeatable"] = ev.IsRepeatable;
					luaTable["probability"] = ev.Probability;
				}
				return luaTable;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	[DoNotPrune]
	public string guid => ev.ObjectID;

	[DoNotPrune]
	public string description
	{
		get
		{
			return ev.Description;
		}
		set
		{
			ev.Description = value;
		}
	}

	[DoNotPrune]
	public string name => ev.Name;

	[DoNotPrune]
	public object isActive
	{
		get
		{
			return ev.IsActive;
		}
		set
		{
			ev.IsActive = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public object isShown
	{
		get
		{
			return ev.IsShown.ToString();
		}
		set
		{
			ev.IsShown = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public object isRepeatable
	{
		get
		{
			return ev.IsRepeatable.ToString();
		}
		set
		{
			ev.IsRepeatable = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public string probability
	{
		get
		{
			return ev.Probability.ToString();
		}
		set
		{
			short result = 0;
			short.TryParse(value, out result);
			if (result >= 0 && result <= 100)
			{
				ev.Probability = result;
			}
		}
	}

	[DoNotPrune]
	public LuaTable triggers
	{
		get
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			HashSet<string> hashSet = new HashSet<string>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (EventTrigger trigger in ev.Triggers)
			{
				EventTrigger theEvent = trigger;
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				XmlDocument xml = new XmlDocument();
				StringBuilder sb = new StringBuilder();
				StringWriter stringWriter = new StringWriter(sb);
				LuaEvent.AddUnitToSerialized(ref theEvent, hashSet);
				XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
				try
				{
					theEvent.ToXML(val, hashSet, ScenarioContext);
					val.Flush();
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				xml.LoadXml(stringWriter.ToString());
				if (bool_0)
				{
					luaTable2["xml"] = xml.InnerXml;
				}
				luaTable2[theEvent.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xml);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable conditions
	{
		get
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (EventCondition condition in ev.Conditions)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				XmlDocument xml = new XmlDocument();
				StringBuilder sb = new StringBuilder();
				StringWriter stringWriter = new StringWriter(sb);
				XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
				try
				{
					condition.ToXML(val, objectsAlreadySerialized, ScenarioContext);
					val.Flush();
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				xml.LoadXml(stringWriter.ToString());
				if (bool_0)
				{
					luaTable2["xml"] = xml.InnerXml;
				}
				luaTable2[condition.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xml);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable actions
	{
		get
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			HashSet<string> objectsAlreadySerialized = new HashSet<string>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (EventAction action in ev.Actions)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["type"] = action.Type.ToString();
				XmlDocument xml = new XmlDocument();
				StringBuilder sb = new StringBuilder();
				StringWriter stringWriter = new StringWriter(sb);
				XmlWriter val = (XmlWriter)new XmlTextWriter((TextWriter)stringWriter);
				try
				{
					action.ToXML(val, objectsAlreadySerialized, ScenarioContext);
					val.Flush();
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				xml.LoadXml(stringWriter.ToString());
				if (bool_0)
				{
					luaTable2["xml"] = xml.InnerXml;
				}
				luaTable2[action.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xml);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	public LuaWrapper_Event(SimEvent a, int l, bool xml, Scenario s)
	{
		ev = a;
		ScenarioContext = s;
		level = l;
		bool_0 = xml;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return (("event {\r\n name = '" + name + "', \r\n guid = '" + guid.ToString() + "', \r\n description = '" + description + "', \r\n active = '" + isActive.ToString() + "', \r\n") ?? "") + "}";
	}

	static LuaWrapper_Event()
	{
		Class72.smethod_20();
	}
}
