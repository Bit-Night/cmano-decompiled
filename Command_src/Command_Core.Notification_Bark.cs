using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Notification_Bark
{
	public struct MessageWrapper : IEquatable<MessageWrapper>
	{
		public string text;

		public Color Color;

		public float FontSize;

		public bool MoveUpward;

		public bool Fades;

		public float Lifetime;

		public float? ValueHolder;

		public MessageWrapper(string _text, Color _Color, float _FontSize, bool _MoveUpward, bool _Fades, float _Lifetime)
		{
			this = default(MessageWrapper);
			text = _text;
			Color = _Color;
			FontSize = _FontSize;
			MoveUpward = _MoveUpward;
			Fades = _Fades;
			Lifetime = _Lifetime;
		}

		public bool Equals(MessageWrapper other)
		{
			int result;
			if (Operators.CompareString(text, other.text, false) == 0)
			{
				if (!(Color == other.Color))
				{
					result = 0;
					goto IL_0064;
				}
				if (FontSize == other.FontSize && MoveUpward == other.MoveUpward && Fades == other.Fades)
				{
					return Lifetime == other.Lifetime;
				}
			}
			result = 0;
			goto IL_0064;
			IL_0064:
			return (byte)result != 0;
		}

		public static bool operator ==(MessageWrapper Message, MessageWrapper Message2)
		{
			return Message.Equals(Message2);
		}

		public static bool operator !=(MessageWrapper Message, MessageWrapper Message2)
		{
			return !Message.Equals(Message2);
		}

		public override string ToString()
		{
			if (!ValueHolder.HasValue)
			{
				return text;
			}
			return text.Replace("<value>", ValueHolder.Value.ToString("0.0"));
		}

		static MessageWrapper()
		{
			Class72.smethod_20();
		}
	}

	public static List<Notification_Bark> AllBarksInstance;

	public static Dictionary<string, Notification_Bark> AllBarksInstance_RefAnchor;

	public DateTime CreationDate;

	public DateTime Expiration;

	public List<KeyValuePair<MessageWrapper, int>> Messages;

	public Geopoint_Struct Position;

	public Module_Unit.Unit Anchor;

	public double Progress;

	private GlobalSingleton globalSingleton_0;

	private static LockObject lockObject_0;

	public float Lifetime
	{
		get
		{
			if (Messages.Count > 0)
			{
				return Messages[0].Key.Lifetime;
			}
			return 0f;
		}
	}

	public float FontSize
	{
		get
		{
			if (Messages.Count > 0)
			{
				return Messages[0].Key.FontSize;
			}
			return 0f;
		}
	}

	public bool Fades
	{
		get
		{
			if (Messages.Count > 0)
			{
				return Messages[0].Key.Fades;
			}
			return false;
		}
	}

	public bool MoveUpward
	{
		get
		{
			if (Messages.Count > 0)
			{
				return Messages[0].Key.MoveUpward;
			}
			return false;
		}
	}

	public string Text
	{
		get
		{
			if (Messages.Count > 0)
			{
				return Messages.ElementAt(0).Key.text;
			}
			return "";
		}
	}

	static Notification_Bark()
	{
		Class72.smethod_20();
		AllBarksInstance = new List<Notification_Bark>();
		AllBarksInstance_RefAnchor = new Dictionary<string, Notification_Bark>();
		lockObject_0 = new LockObject();
	}

	public Notification_Bark(double Longitude, double Latitude, MessageWrapper BarkMessage)
	{
		Messages = new List<KeyValuePair<MessageWrapper, int>>();
		Position = default(Geopoint_Struct);
		Position = new Geopoint_Struct(Longitude, Latitude);
		Initialise(null);
		AddMessage(BarkMessage);
	}

	public Notification_Bark(double Longitude, double Latitude)
	{
		Messages = new List<KeyValuePair<MessageWrapper, int>>();
		Position = default(Geopoint_Struct);
		Position = new Geopoint_Struct(Longitude, Latitude);
		Initialise(null);
	}

	public Notification_Bark(Module_Unit.Unit AnchorUnit)
	{
		Messages = new List<KeyValuePair<MessageWrapper, int>>();
		Position = default(Geopoint_Struct);
		Initialise(AnchorUnit);
	}

	public Notification_Bark(Module_Unit.Unit AnchorUnit, MessageWrapper BarkMessage)
	{
		Messages = new List<KeyValuePair<MessageWrapper, int>>();
		Position = default(Geopoint_Struct);
		Initialise(AnchorUnit);
		AddMessage(BarkMessage);
	}

	public void Initialise(Module_Unit.Unit AnchorUnit)
	{
		try
		{
			Anchor = AnchorUnit;
			ReAttachToAnchor();
			ResetTimer();
			globalSingleton_0 = GlobalSingleton.GetInstance();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9876548754898", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void Create(double Longitude, double Latitude, string text, Color _Color, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		lock (lockObject_0)
		{
			AllBarksInstance.Add(new Notification_Bark(Longitude, Latitude, new MessageWrapper(text, _Color, FontSize, MoveUpward, Fades, Lifetime)));
		}
	}

	public static void Create(Geopoint_Struct Position, string text, Color _Color, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		Create(Position.Longitude, Position.Latitude, text, _Color, MoveUpward, Fades, Lifetime, FontSize);
	}

	public static void Create(double Longitude, double Latitude, List<string> text, Color _Color, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		foreach (string item in text)
		{
			try
			{
				Create(Longitude, Latitude, item, _Color, MoveUpward, Fades, Lifetime, FontSize);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 987654875481", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void Create(Geopoint_Struct Position, List<string> text, Color _Color, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		foreach (string item in text)
		{
			Create(Position.Longitude, Position.Latitude, item, _Color, MoveUpward, Fades, Lifetime, FontSize);
		}
	}

	public static void Create(Module_Unit.Unit AnchorUnit, List<string> text, Color _Color, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		foreach (string item in text)
		{
			Create(AnchorUnit, item, _Color, MoveUpward, Fades, Lifetime, FontSize);
		}
	}

	private static bool smethod_0(Module_Unit.Unit unit_0)
	{
		if (unit_0 != null && unit_0.IsAggregatedUnit)
		{
			return true;
		}
		return SimConfiguration.DefaultGamePreferences.ShowAU_Behaviour_Bark switch
		{
			Game.GamePreferences.Unit_Behaviour_Bark.All => true, 
			Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit => unit_0?.get_UnitSide(SetSideOnly: false).SelectedUnits.Contains(unit_0) ?? false, 
			Game.GamePreferences.Unit_Behaviour_Bark.DontShow => false, 
			_ => true, 
		};
	}

	public static void Create_UnitBehaviour(Module_Unit.Unit AnchorUnit, string msg, Color? _Color = null)
	{
		if (smethod_0(AnchorUnit))
		{
			if (!_Color.HasValue)
			{
				_Color = Color.Red;
			}
			Create(AnchorUnit, msg, _Color.Value, MoveUpward: true, Fades: true, 5f);
		}
	}

	public static void Create(Module_Unit.Unit AnchorUnit, string text, Color _Color, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f, float? DynamicValue = null)
	{
		try
		{
			lock (lockObject_0)
			{
				Notification_Bark value = null;
				if (!AllBarksInstance_RefAnchor.TryGetValue(AnchorUnit.ObjectID, out value))
				{
					value = new Notification_Bark(AnchorUnit, new MessageWrapper(text, _Color, FontSize, MoveUpward, Fades, Lifetime));
					AllBarksInstance_RefAnchor.Add(AnchorUnit.ObjectID, value);
					AllBarksInstance.Add(value);
				}
				else
				{
					value.AddMessage(new MessageWrapper(text, _Color, FontSize, MoveUpward, Fades, Lifetime));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 14675178645", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Color GetCurrentColor()
	{
		if (Messages.Count > 0)
		{
			Color color = Messages[0].Key.Color;
			return Color.FromArgb((int)Math.Round(255.0 * (1.0 - Progress)), color.R, color.G, color.B);
		}
		return default(Color);
	}

	public string GetCurrentText()
	{
		if (Messages.Count <= 0)
		{
			return "";
		}
		if (Messages[0].Value > 1)
		{
			return Messages[0].Key.ToString() + " (x" + Messages[0].Value + ")";
		}
		return Messages[0].Key.ToString();
	}

	public void AddMessage(MessageWrapper MessageToAdd)
	{
		try
		{
			if (Messages.Count > 0)
			{
				int num = Messages.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Messages[i].Key == MessageToAdd)
					{
						Messages[i] = new KeyValuePair<MessageWrapper, int>(MessageToAdd, Messages[i].Value + 1);
						ResetTimer();
						return;
					}
				}
			}
			Messages.Add(new KeyValuePair<MessageWrapper, int>(MessageToAdd, 1));
			if (Messages.Count == 1)
			{
				ResetTimer();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9876548754847", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResetTimer()
	{
		Progress = 0.0;
		CreationDate = DateTime.Now;
		Expiration = CreationDate.AddSeconds(Lifetime);
	}

	internal bool HasAnchor()
	{
		return Anchor != null;
	}

	public void ReAttachToAnchor()
	{
		if (HasAnchor())
		{
			Position.Longitude = Anchor.get_Longitude((GlobalVariables.BooleanObject)null);
			Position.Latitude = Anchor.get_Latitude((GlobalVariables.BooleanObject)null);
			Position.Altitude = Anchor.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
	}

	public void DetachFromAnchor()
	{
		HasAnchor();
	}

	public bool Cycle()
	{
		DateTime now = DateTime.Now;
		int result;
		if (DateTime.Compare(now, Expiration) <= 0)
		{
			if (Fades)
			{
				TimeSpan timeSpan = Expiration - CreationDate;
				Progress = (now - CreationDate).TotalSeconds / timeSpan.TotalSeconds;
				result = 1;
			}
			else
			{
				result = 1;
			}
		}
		else
		{
			if (Messages.Count <= 1)
			{
				DetachFromAnchor();
				return false;
			}
			Messages.RemoveAt(0);
			ReAttachToAnchor();
			ResetTimer();
			result = 1;
		}
		return (byte)result != 0;
	}
}
