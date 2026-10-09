using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using System.Xml;
using Cysharp.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class LoggedMessage : ScenarioObject
{
	public enum MessageType : byte
	{
		None = 0,
		NewContact = 1,
		ContactChange = 2,
		WeaponEndgame = 3,
		WeaponDamage = 4,
		AirOps = 5,
		UnitLost = 6,
		UnitDamage = 7,
		PointDefence = 8,
		UI = 9,
		WeaponLogic = 10,
		UnitAI = 11,
		EventEngine = 13,
		NewWeaponContact = 14,
		DockingOps = 15,
		SpecialMessage = 16,
		NewMineContact = 17,
		CommsIsolatedMessage = 18,
		NewAirContact = 19,
		NewSurfaceContact = 20,
		NewUnderwaterContact = 21,
		NewGroundContact = 22,
		UnguidedWeaponModifiers = 23,
		const_23 = 24,
		Debug = 25,
		UnitAIEmergency = 26,
		CommsRelatedMessage = 27,
		CustomUI = 28
	}

	public class MessageSettings
	{
		public bool ShowOnMessageLog;

		public bool PopUp;

		public bool ShowBaloon;

		public bool bool_0;

		public MessageSettings(bool _ShowOnMessageLog, bool _PopUp, bool _ShowBaloon, bool _SwitchToTimeScale1X)
		{
			ShowOnMessageLog = _ShowOnMessageLog;
			PopUp = _PopUp;
			ShowBaloon = _ShowBaloon;
			bool_0 = _SwitchToTimeScale1X;
		}

		static MessageSettings()
		{
			Class72.smethod_20();
		}
	}

	public long Increment;

	public string Text;

	private DateTime dateTime_0;

	public long Timestamp_ticks;

	public byte Level;

	public MessageType Type;

	public string ReporterID;

	public Side Side;

	public Geopoint_Struct? Location;

	public bool ProcessedByClient;

	public string Summary;

	public bool ForceMapRecentre;

	public DateTime Timestamp
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			Timestamp_ticks = value.Ticks;
			dateTime_0 = value;
		}
	}

	public Color MessageColor
	{
		get
		{
			switch (Type)
			{
			case MessageType.ContactChange:
				return Color.Yellow;
			case MessageType.UnitLost:
				return Color.IndianRed;
			case MessageType.UnitDamage:
				return Color.OrangeRed;
			case MessageType.PointDefence:
				return Color.Gray;
			case MessageType.UnitAI:
				return Color.Gray;
			case MessageType.EventEngine:
				return Color.LightBlue;
			case MessageType.AirOps:
			case MessageType.DockingOps:
				return Color.LimeGreen;
			case MessageType.NewWeaponContact:
			case MessageType.NewMineContact:
				return Color.IndianRed;
			case MessageType.NewContact:
			case MessageType.NewAirContact:
			case MessageType.NewSurfaceContact:
			case MessageType.NewUnderwaterContact:
			case MessageType.NewGroundContact:
				return Color.Yellow;
			case MessageType.WeaponEndgame:
			case MessageType.WeaponDamage:
			case MessageType.WeaponLogic:
			case MessageType.UnguidedWeaponModifiers:
				return Color.LightGray;
			case MessageType.const_23:
				return Color.Gray;
			default:
				return Color.White;
			case MessageType.UnitAIEmergency:
				return Color.OrangeRed;
			case MessageType.CommsIsolatedMessage:
			case MessageType.CommsRelatedMessage:
				return Color.Gray;
			}
		}
	}

	public Font MessageFont
	{
		get
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			switch (Type)
			{
			default:
				return new Font(SeedFont, (FontStyle)0);
			case MessageType.WeaponEndgame:
			case MessageType.WeaponDamage:
			case MessageType.PointDefence:
			case MessageType.WeaponLogic:
			case MessageType.UnitAI:
			case MessageType.CommsIsolatedMessage:
			case MessageType.UnguidedWeaponModifiers:
			case MessageType.const_23:
			case MessageType.CommsRelatedMessage:
				return new Font(SeedFont, (FontStyle)2);
			}
		}
	}

	internal bool IsContactRelated()
	{
		int result;
		switch (Type)
		{
		case MessageType.NewAirContact:
		case MessageType.NewSurfaceContact:
		case MessageType.NewUnderwaterContact:
		case MessageType.NewGroundContact:
			result = 1;
			break;
		default:
			return false;
		case MessageType.NewContact:
		case MessageType.ContactChange:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public string ToXML()
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		string result;
		try
		{
			utf16ValueStringBuilder.Append("<LM>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			utf16ValueStringBuilder.Append("<Inc>");
			utf16ValueStringBuilder.Append(Increment);
			utf16ValueStringBuilder.Append("</Inc>");
			utf16ValueStringBuilder.Append("<Text>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Text));
			utf16ValueStringBuilder.Append("</Text>");
			utf16ValueStringBuilder.Append("<Summary>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Summary));
			utf16ValueStringBuilder.Append("</Summary>");
			utf16ValueStringBuilder.Append("<TStamp>");
			utf16ValueStringBuilder.Append(dateTime_0.ToBinary());
			utf16ValueStringBuilder.Append("</TStamp>");
			if (Level != 0)
			{
				utf16ValueStringBuilder.Append("<Level>");
				utf16ValueStringBuilder.Append((int)Level);
				utf16ValueStringBuilder.Append("</Level>");
			}
			utf16ValueStringBuilder.Append("<Type>");
			utf16ValueStringBuilder.Append((int)Type);
			utf16ValueStringBuilder.Append("</Type>");
			if (!string.IsNullOrEmpty(ReporterID))
			{
				utf16ValueStringBuilder.Append("<R_ID>");
				utf16ValueStringBuilder.Append(ReporterID);
				utf16ValueStringBuilder.Append("</R_ID>");
			}
			if (Side != null)
			{
				utf16ValueStringBuilder.Append("<Side>");
				utf16ValueStringBuilder.Append(Side.ObjectID);
				utf16ValueStringBuilder.Append("</Side>");
			}
			if (Location.HasValue && (Location.Value.Latitude != 0.0 || Location.Value.Longitude != 0.0))
			{
				utf16ValueStringBuilder.Append("<Loc>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(Location.Value.Longitude));
				utf16ValueStringBuilder.Append("_");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(Location.Value.Latitude));
				utf16ValueStringBuilder.Append("</Loc>");
			}
			utf16ValueStringBuilder.Append("</LM>");
			string text = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			result = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101011", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = string.Empty;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private LoggedMessage()
	{
	}

	public static LoggedMessage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		LoggedMessage result;
		try
		{
			LoggedMessage loggedMessage = new LoggedMessage();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Text":
					loggedMessage.Text = val.InnerText;
					break;
				case "Inc":
				case "Increment":
					loggedMessage.Increment = Conversions.ToLong(val.InnerText);
					break;
				case "Level":
					loggedMessage.Level = Conversions.ToByte(val.InnerText);
					break;
				case "Summary":
					loggedMessage.Summary = val.InnerText;
					break;
				case "ID":
					loggedMessage.ObjectID_Set(val.InnerText);
					break;
				case "Side":
					if (theDictionary.ContainsKey(val.InnerText))
					{
						loggedMessage.Side = (Side)theDictionary[val.InnerText];
						break;
					}
					result = null;
					goto end_IL_0001;
				case "Location":
				case "Loc":
				{
					if (val.ChildNodes.Count > 1)
					{
						loggedMessage.Location = Geopoint_Struct.FromXML(val, theDictionary);
						break;
					}
					string[] array = val.InnerText.Split(new char[1] { '_' });
					loggedMessage.Location = new Geopoint_Struct(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "R_ID":
				case "ReporterID":
					loggedMessage.ReporterID = val.InnerText;
					break;
				case "Type":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						loggedMessage.Type = (MessageType)Conversions.ToByte(val.InnerText);
					}
					else
					{
						loggedMessage.Type = (MessageType)Enum.Parse(typeof(MessageType), val.InnerText, ignoreCase: true);
					}
					break;
				case "TStamp":
				case "TimeStamp":
					loggedMessage.Timestamp = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				}
			}
			result = loggedMessage;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101012", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new LoggedMessage();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public LoggedMessage(long theIncrement, string theText, string Summary, MessageType theType, DateTime theTimestamp, string theReporterID, byte theLevel, Side theSide = null, Geopoint_Struct? theLocation = null, bool theForceMapRecentre = false)
	{
		Increment = theIncrement;
		Text = theText;
		this.Summary = Summary;
		Timestamp = theTimestamp;
		Level = theLevel;
		Type = theType;
		ReporterID = theReporterID;
		Side = theSide;
		Location = theLocation;
		ForceMapRecentre = theForceMapRecentre;
	}

	static LoggedMessage()
	{
		Class72.smethod_20();
	}
}
