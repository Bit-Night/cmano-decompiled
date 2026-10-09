using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class RecordSpecificationElement
{
	private uint uint_0;

	private uint uint_1;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private byte wTkYamdkUeC;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordID")]
	public uint RecordID
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "recordSetSerialNumber")]
	public uint RecordSetSerialNumber
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordCount")]
	public ushort RecordCount
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordValues")]
	public ushort RecordValues
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

	[XmlElement(Type = typeof(byte), ElementName = "pad4")]
	public byte Pad4
	{
		get
		{
			return wTkYamdkUeC;
		}
		set
		{
			wTkYamdkUeC = value;
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

	public static bool operator !=(RecordSpecificationElement left, RecordSpecificationElement right)
	{
		return !(left == right);
	}

	public static bool operator ==(RecordSpecificationElement left, RecordSpecificationElement right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 15;
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
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedInt(uint_1);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
				dos.WriteUnsignedByte(wTkYamdkUeC);
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
				uint_0 = dis.ReadUnsignedInt();
				uint_1 = dis.ReadUnsignedInt();
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
				wTkYamdkUeC = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<RecordSpecificationElement>");
		try
		{
			sb.AppendLine("<recordID type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordID>");
			sb.AppendLine("<recordSetSerialNumber type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</recordSetSerialNumber>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<recordCount type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</recordCount>");
			sb.AppendLine("<recordValues type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</recordValues>");
			sb.AppendLine("<pad4 type=\"byte\">" + wTkYamdkUeC.ToString(CultureInfo.InvariantCulture) + "</pad4>");
			sb.AppendLine("</RecordSpecificationElement>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RecordSpecificationElement;
	}

	public bool Equals(RecordSpecificationElement obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (uint_0 != obj.uint_0)
		{
			result = false;
		}
		if (uint_1 != obj.uint_1)
		{
			result = false;
		}
		if (ushort_0 != obj.ushort_0)
		{
			result = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			result = false;
		}
		if (wTkYamdkUeC != obj.wTkYamdkUeC)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ wTkYamdkUeC.GetHashCode();
	}

	static RecordSpecificationElement()
	{
		Class72.smethod_20();
	}
}
