using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public sealed class LuaWrapper_ReferencePoint
{
	private ReferencePoint referencePoint_0;

	private Scenario scenario_0;

	private Side side_0;

	[DoNotPrune]
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
	public object __obj => referencePoint_0;

	[DoNotPrune]
	public string name
	{
		get
		{
			return referencePoint_0.Name;
		}
		set
		{
			referencePoint_0.Name = value;
		}
	}

	[DoNotPrune]
	public object latitude
	{
		get
		{
			return referencePoint_0.Latitude;
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(RuntimeHelpers.GetObjectValue(value));
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as latitude.");
			}
			referencePoint_0.Latitude = num.Value;
		}
	}

	[DoNotPrune]
	public object longitude
	{
		get
		{
			return referencePoint_0.Longitude;
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(RuntimeHelpers.GetObjectValue(value));
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as longitude.");
			}
			referencePoint_0.Longitude = num.Value;
		}
	}

	[DoNotPrune]
	public string guid => referencePoint_0.ObjectID;

	[DoNotPrune]
	public string side => side_0.Name;

	[DoNotPrune]
	public bool highlighted
	{
		get
		{
			return referencePoint_0.IsHighlighted;
		}
		set
		{
			referencePoint_0.IsHighlighted = value;
		}
	}

	[DoNotPrune]
	public bool visible
	{
		get
		{
			return referencePoint_0.IsVisible;
		}
		set
		{
			referencePoint_0.IsVisible = value;
		}
	}

	[DoNotPrune]
	public bool locked
	{
		get
		{
			return referencePoint_0.IsLocked;
		}
		set
		{
			referencePoint_0.IsLocked = value;
		}
	}

	[DoNotPrune]
	public string color
	{
		get
		{
			return referencePoint_0.color.ToArgb().ToString();
		}
		set
		{
			Color color = Color.FromName(value);
			if (color.IsKnownColor)
			{
				referencePoint_0.color = color;
				return;
			}
			try
			{
				referencePoint_0.color = ColorTranslator.FromHtml("#" + value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public ReferencePoint.OrientationType bearingtype
	{
		get
		{
			if (referencePoint_0.IsRelativeTo == null)
			{
				return ReferencePoint.OrientationType.Fixed;
			}
			return referencePoint_0.BearingType;
		}
		set
		{
			if (referencePoint_0.IsRelativeTo != null)
			{
				ReferencePoint.OrientationType result = ReferencePoint.OrientationType.Fixed;
				if (Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString((byte)value), ignoreCase: true, out result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
				{
					referencePoint_0.BearingType = value;
				}
			}
		}
	}

	[DoNotPrune]
	public float relativeBearing
	{
		get
		{
			if (referencePoint_0.IsRelativeTo == null)
			{
				return 0f;
			}
			return referencePoint_0.RelativeBearing;
		}
		set
		{
			if (referencePoint_0.IsRelativeTo != null && value >= 0f && value <= 360f)
			{
				referencePoint_0.RelativeBearing = value;
			}
		}
	}

	[DoNotPrune]
	public float relativeDistance
	{
		get
		{
			if (referencePoint_0.IsRelativeTo != null)
			{
				return referencePoint_0.RelativeDistance;
			}
			return 0f;
		}
		set
		{
			if (referencePoint_0.IsRelativeTo != null)
			{
				referencePoint_0.RelativeDistance = value;
			}
		}
	}

	[DoNotPrune]
	public ScenarioObject relativeto
	{
		get
		{
			return referencePoint_0.IsRelativeTo;
		}
		set
		{
			referencePoint_0.IsRelativeTo = value;
		}
	}

	[DoNotPrune]
	public string relativeto_type => referencePoint_0.IsRelativeTo?.GetType().Name;

	public LuaWrapper_ReferencePoint(ReferencePoint r, Side d, Scenario s)
	{
		referencePoint_0 = r;
		scenario_0 = s;
		side_0 = d;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "{\r\n name = '" + name + "', \r\n latitude = '" + latitude.ToString() + "', \r\n longitude = '" + longitude.ToString() + "', \r\n guid = '" + guid.ToString() + "', \r\n side = '" + side + "', \r\n highlighted = '" + highlighted + "', \r\n visible = '" + visible + "', \r\n locked = '" + locked + "', \r\n";
		if (relativeto != null)
		{
			text = text + " bearingtype = '" + bearingtype.ToString() + "', \r\n relativeto = '" + relativeto.Name + "', \r\n type = '" + relativeto_type + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public LuaTable toTable()
	{
		LuaSandBox.Singleton().CreateTable();
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		luaTable["name"] = name;
		luaTable["guid"] = guid;
		luaTable["longitude"] = RuntimeHelpers.GetObjectValue(longitude);
		luaTable["latitude"] = RuntimeHelpers.GetObjectValue(latitude);
		luaTable["highlighted"] = highlighted;
		luaTable["visible"] = visible;
		luaTable["locked"] = locked;
		luaTable["side"] = side;
		if (!Information.IsNothing((object)relativeto))
		{
			luaTable["relativeto_type"] = relativeto.GetType().Name;
			luaTable["bearingtype"] = bearingtype;
			luaTable["relativeto"] = relativeto.ObjectID;
		}
		luaTable["color"] = color.ToString();
		return luaTable;
	}

	static LuaWrapper_ReferencePoint()
	{
		Class72.smethod_20();
	}
}
