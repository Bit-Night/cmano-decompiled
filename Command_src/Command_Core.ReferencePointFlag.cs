using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public sealed class ReferencePointFlag : ScenarioObject
{
	public string ToXML([Optional][DefaultParameterValue(null)] ref HashSet<string> ObjectsAlreadySerialized)
	{
		string result = default(string);
		try
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Clear();
			stringBuilder.Append("<RPointFlag>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder.Append("</RPointFlag>");
					result = stringBuilder.ToString();
					return result;
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			stringBuilder.Append("</RPointFlag>");
			string text = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100584_b", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ReferencePointFlag FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		ReferencePointFlag result;
		try
		{
			ReferencePointFlag referencePointFlag = new ReferencePointFlag("");
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "ID", false) != 0)
				{
					if (Operators.CompareString(name, "Name", false) == 0)
					{
						referencePointFlag.Name = val.InnerText;
					}
					continue;
				}
				if (!theDictionary.ContainsKey(val.InnerText))
				{
					referencePointFlag.ObjectID_Set(val.InnerText);
					theDictionary.TryAdd(referencePointFlag.ObjectID, referencePointFlag);
					continue;
				}
				result = (ReferencePointFlag)theDictionary[val.InnerText];
				goto end_IL_0001;
			}
			result = referencePointFlag;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100585_b", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ReferencePointFlag("");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public ReferencePointFlag(string _Name)
	{
		Name = _Name;
	}

	static ReferencePointFlag()
	{
		Class72.smethod_20();
	}
}
