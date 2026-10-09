using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CommNetwork
{
	public enum NetworkCreationReason
	{
		Generic = -1,
		Group,
		Flight,
		Proximity,
		AEWProximity,
		NewNetwork,
		HomeBaseComm,
		AirBases,
		TankerProximity,
		AEWComm,
		Lua,
		Mission
	}

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private HashSet<Module_Unit.Unit> hashSet_0;

	[CompilerGenerated]
	private NetworkCreationReason networkCreationReason_0;

	[CompilerGenerated]
	private Transmission transmission_0;

	[CompilerGenerated]
	private string string_2;

	public string ID
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
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
		set
		{
			string_1 = value;
		}
	}

	public HashSet<Module_Unit.Unit> Members
	{
		[CompilerGenerated]
		get
		{
			return hashSet_0;
		}
		[CompilerGenerated]
		set
		{
			hashSet_0 = value;
		}
	}

	public NetworkCreationReason Reason
	{
		[CompilerGenerated]
		get
		{
			return networkCreationReason_0;
		}
		[CompilerGenerated]
		set
		{
			networkCreationReason_0 = value;
		}
	}

	public Transmission LastTransmission
	{
		[CompilerGenerated]
		get
		{
			return transmission_0;
		}
		[CompilerGenerated]
		set
		{
			transmission_0 = value;
		}
	}

	public string ReferenceObjectID
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public CommNetwork(Side ParentSide, string iD, string name, HashSet<Module_Unit.Unit> members, NetworkCreationReason theReason, string theRefObjectID = null)
	{
		Members = new HashSet<Module_Unit.Unit>();
		ID = ParentSide.ObjectID + "_" + iD;
		Name = name;
		Members = members;
		Reason = theReason;
		ReferenceObjectID = theRefObjectID;
	}

	public CommNetwork()
	{
		Members = new HashSet<Module_Unit.Unit>();
	}

	internal static CommNetwork FromXML(ref XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Side TheSide, ref Scenario theScen)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		CommNetwork result;
		try
		{
			CommNetwork commNetwork = new CommNetwork();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					commNetwork.ID = val.InnerText;
					break;
				case "Name":
					commNetwork.Name = val.InnerText;
					break;
				case "Reason":
					try
					{
						commNetwork.Reason = (NetworkCreationReason)Enum.Parse(typeof(NetworkCreationReason), val.InnerText);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						commNetwork.Reason = NetworkCreationReason.Generic;
						ProjectData.ClearProjectError();
					}
					break;
				case "Members":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						if (Operators.CompareString(val2.Name, "UnitID", false) == 0)
						{
							string innerText = val2.InnerText;
							Module_Unit.Unit unit = new Module_Unit.Unit();
							unit.ObjectID = innerText;
							if (unit != null)
							{
								commNetwork.Members.Add(unit);
							}
						}
					}
					break;
				case "ReferenceObjectID":
					commNetwork.ReferenceObjectID = val.InnerText;
					break;
				}
			}
			if (!commNetwork.ID.Contains("_"))
			{
				commNetwork.ID = Conversions.ToString((int)commNetwork.Reason) + "_" + commNetwork.ID;
			}
			result = commNetwork;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 32165431354311", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal string ToXML(HashSet<string> objectsAlreadySerialized, Scenario theScen)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		stringBuilder.Append("<CommNetwork>");
		stringBuilder.Append("<ID>").Append(ID).Append("</ID>");
		if (objectsAlreadySerialized != null)
		{
			if (objectsAlreadySerialized.Contains(ID.ToString()))
			{
				stringBuilder.Append("</CommNetwork>");
				return stringBuilder.ToString();
			}
			objectsAlreadySerialized.Add(ID.ToString());
		}
		stringBuilder.Append("<Name>").Append(Name).Append("</Name>");
		stringBuilder.Append("<Reason>").Append(Reason.ToString()).Append("</Reason>");
		if (Members.Count > 0)
		{
			stringBuilder.Append("<Members>");
			foreach (Module_Unit.Unit member in Members)
			{
				if (member != null)
				{
					stringBuilder.Append("<UnitID>").Append(member.ObjectID).Append("</UnitID>");
				}
			}
			stringBuilder.Append("</Members>");
		}
		if (!string.IsNullOrEmpty(ReferenceObjectID))
		{
			stringBuilder.Append("<ReferenceObjectID>").Append(ReferenceObjectID).Append("</ReferenceObjectID>");
		}
		stringBuilder.Append("</CommNetwork>");
		return stringBuilder.ToString();
	}

	static CommNetwork()
	{
		Class72.smethod_20();
	}
}
