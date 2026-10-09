#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;
using OpenDis.Enumerations;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
public class EntityType
{
	private EntityKind entityKind_0;

	private byte byte_0;

	private Country country_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(EntityKind), ElementName = "entityKind")]
	public EntityKind EntityKind
	{
		get
		{
			return entityKind_0;
		}
		set
		{
			entityKind_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "domain")]
	public byte Domain
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "country")]
	public Country Country
	{
		get
		{
			return country_0;
		}
		set
		{
			country_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "category")]
	public byte Category
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "subcategory")]
	public byte Subcategory
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "specific")]
	public byte Specific
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "extra")]
	public byte Extra
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	public event EventHandler<PduExceptionEventArgs> ExceptionOccured
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static bool operator !=(EntityType left, EntityType right)
	{
		return !(left == right);
	}

	public static bool operator ==(EntityType left, EntityType right)
	{
		if ((object)left == right)
		{
			return true;
		}
		int result;
		if ((object)left != null)
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual int GetMarshalledSize()
	{
		return 8;
	}

	protected void RaiseExceptionOccured(Exception e)
	{
		if (PduBase.FireExceptionEvents && eventHandler_0 != null)
		{
			eventHandler_0(this, new PduExceptionEventArgs(e));
		}
	}

	public virtual void Marshal(DataOutputStream dos)
	{
		if (dos == null)
		{
			return;
		}
		try
		{
			dos.WriteUnsignedByte((byte)entityKind_0);
			dos.WriteUnsignedByte(byte_0);
			dos.WriteUnsignedShort((ushort)country_0);
			dos.WriteUnsignedByte(byte_1);
			dos.WriteUnsignedByte(byte_2);
			dos.WriteUnsignedByte(byte_3);
			dos.WriteUnsignedByte(byte_4);
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dis)
	{
		if (dis == null)
		{
			return;
		}
		try
		{
			entityKind_0 = (EntityKind)dis.ReadUnsignedByte();
			byte_0 = dis.ReadUnsignedByte();
			country_0 = (Country)dis.ReadUnsignedShort();
			byte_1 = dis.ReadUnsignedByte();
			byte_2 = dis.ReadUnsignedByte();
			byte_3 = dis.ReadUnsignedByte();
			byte_4 = dis.ReadUnsignedByte();
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EntityType>");
		try
		{
			sb.AppendLine("<entityKind type=\"byte\">" + entityKind_0.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
			sb.AppendLine("<domain type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</domain>");
			sb.AppendLine("<country type=\"ushort\">" + country_0.ToString(CultureInfo.InvariantCulture) + "</country>");
			sb.AppendLine("<category type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</category>");
			sb.AppendLine("<subcategory type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			sb.AppendLine("<specific type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</specific>");
			sb.AppendLine("<extra type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</extra>");
			sb.AppendLine("</EntityType>");
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityType;
	}

	public bool Equals(EntityType obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (entityKind_0 != obj.entityKind_0)
			{
				result = false;
			}
			if (byte_0 != obj.byte_0)
			{
				result = false;
			}
			if (country_0 != obj.country_0)
			{
				result = false;
			}
			if (byte_1 != obj.byte_1)
			{
				result = false;
			}
			if (byte_2 != obj.byte_2)
			{
				result = false;
			}
			if (byte_3 != obj.byte_3)
			{
				result = false;
			}
			if (byte_4 != obj.byte_4)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityKind_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ country_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode();
	}

	static EntityType()
	{
		Class72.smethod_20();
	}
}
