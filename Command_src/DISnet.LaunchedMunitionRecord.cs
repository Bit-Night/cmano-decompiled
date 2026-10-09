using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EventIdentifier))]
[XmlRoot]
[XmlInclude(typeof(Vector3Double))]
public class LaunchedMunitionRecord
{
	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private ushort ushort_0;

	private EventIdentifier eventIdentifier_1 = new EventIdentifier();

	private ushort ushort_1;

	private EventIdentifier eventIdentifier_2 = new EventIdentifier();

	private ushort ushort_2;

	private Vector3Double vector3Double_0 = new Vector3Double();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "fireEventID")]
	public EventIdentifier FireEventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "firingEntityID")]
	public EventIdentifier FiringEntityID
	{
		get
		{
			return eventIdentifier_1;
		}
		set
		{
			eventIdentifier_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "targetEntityID")]
	public EventIdentifier TargetEntityID
	{
		get
		{
			return eventIdentifier_2;
		}
		set
		{
			eventIdentifier_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding3")]
	public ushort Padding3
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Double), ElementName = "targetLocation")]
	public Vector3Double TargetLocation
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(LaunchedMunitionRecord left, LaunchedMunitionRecord right)
	{
		return !(left == right);
	}

	public static bool operator ==(LaunchedMunitionRecord left, LaunchedMunitionRecord right)
	{
		if ((object)left == right)
		{
			return true;
		}
		int result;
		if ((object)left == null)
		{
			result = 0;
		}
		else
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual int GetMarshalledSize()
	{
		return 0 + eventIdentifier_0.GetMarshalledSize() + 2 + eventIdentifier_1.GetMarshalledSize() + 2 + eventIdentifier_2.GetMarshalledSize() + 2 + vector3Double_0.GetMarshalledSize();
	}

	protected void OnException(Exception e)
	{
		if (action_0 != null)
		{
			action_0(e);
		}
	}

	public virtual void Marshal(DataOutputStream dos)
	{
		if (dos != null)
		{
			try
			{
				eventIdentifier_0.Marshal(dos);
				dos.WriteUnsignedShort(ushort_0);
				eventIdentifier_1.Marshal(dos);
				dos.WriteUnsignedShort(ushort_1);
				eventIdentifier_2.Marshal(dos);
				dos.WriteUnsignedShort(ushort_2);
				vector3Double_0.Marshal(dos);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dis)
	{
		if (dis != null)
		{
			try
			{
				eventIdentifier_0.Unmarshal(dis);
				ushort_0 = dis.ReadUnsignedShort();
				eventIdentifier_1.Unmarshal(dis);
				ushort_1 = dis.ReadUnsignedShort();
				eventIdentifier_2.Unmarshal(dis);
				ushort_2 = dis.ReadUnsignedShort();
				vector3Double_0.Unmarshal(dis);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<LaunchedMunitionRecord>");
		try
		{
			sb.AppendLine("<fireEventID>");
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</fireEventID>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<firingEntityID>");
			eventIdentifier_1.Reflection(sb);
			sb.AppendLine("</firingEntityID>");
			sb.AppendLine("<padding2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<targetEntityID>");
			eventIdentifier_2.Reflection(sb);
			sb.AppendLine("</targetEntityID>");
			sb.AppendLine("<padding3 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			sb.AppendLine("<targetLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</targetLocation>");
			sb.AppendLine("</LaunchedMunitionRecord>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LaunchedMunitionRecord;
	}

	public bool Equals(LaunchedMunitionRecord obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (!eventIdentifier_0.Equals(obj.eventIdentifier_0))
		{
			result = false;
		}
		if (ushort_0 != obj.ushort_0)
		{
			result = false;
		}
		if (!eventIdentifier_1.Equals(obj.eventIdentifier_1))
		{
			result = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (!eventIdentifier_2.Equals(obj.eventIdentifier_2))
		{
			result = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			result = false;
		}
		if (!vector3Double_0.Equals(obj.vector3Double_0))
		{
			result = false;
		}
		return result;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ eventIdentifier_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ eventIdentifier_1.GetHashCode()) ^ ushort_1.GetHashCode()) ^ eventIdentifier_2.GetHashCode()) ^ ushort_2.GetHashCode()) ^ vector3Double_0.GetHashCode();
	}

	static LaunchedMunitionRecord()
	{
		Class72.smethod_20();
	}
}
