#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class RadioEntityType
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private ushort ushort_1;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "entityKind")]
	public byte EntityKind
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

	[XmlElement(Type = typeof(byte), ElementName = "domain")]
	public byte Domain
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

	[XmlElement(Type = typeof(ushort), ElementName = "country")]
	public ushort Country
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

	[XmlElement(Type = typeof(byte), ElementName = "category")]
	public byte Category
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

	[XmlElement(Type = typeof(byte), ElementName = "subcategory")]
	public byte Subcategory
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

	[XmlElement(Type = typeof(byte), ElementName = "nomenclatureVersion")]
	public byte NomenclatureVersion
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

	[XmlElement(Type = typeof(ushort), ElementName = "nomenclature")]
	public ushort Nomenclature
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

	public static bool operator !=(RadioEntityType left, RadioEntityType right)
	{
		return !(left == right);
	}

	public static bool operator ==(RadioEntityType left, RadioEntityType right)
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
		return 9;
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
			dos.WriteUnsignedByte(byte_0);
			dos.WriteUnsignedByte(byte_1);
			dos.WriteUnsignedShort(ushort_0);
			dos.WriteUnsignedByte(byte_2);
			dos.WriteUnsignedByte(byte_3);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedShort(ushort_1);
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
		if (dis != null)
		{
			byte_0 = dis.ReadUnsignedByte();
			byte_1 = dis.ReadUnsignedByte();
			ushort_0 = dis.ReadUnsignedShort();
			byte_2 = dis.ReadUnsignedByte();
			byte_3 = dis.ReadUnsignedByte();
			byte_4 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<RadioEntityType>");
		try
		{
			sb.AppendLine("<entityKind type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
			sb.AppendLine("<domain type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</domain>");
			sb.AppendLine("<country type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</country>");
			sb.AppendLine("<category type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</category>");
			sb.AppendLine("<subcategory type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			sb.AppendLine("<nomenclatureVersion type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</nomenclatureVersion>");
			sb.AppendLine("<nomenclature type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</nomenclature>");
			sb.AppendLine("</RadioEntityType>");
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
		return this == obj as RadioEntityType;
	}

	public bool Equals(RadioEntityType obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (byte_0 != obj.byte_0)
		{
			result = false;
		}
		if (byte_1 != obj.byte_1)
		{
			result = false;
		}
		if (ushort_0 != obj.ushort_0)
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
		if (ushort_1 != obj.ushort_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode()) ^ ushort_1.GetHashCode();
	}

	static RadioEntityType()
	{
		Class72.smethod_20();
	}
}
