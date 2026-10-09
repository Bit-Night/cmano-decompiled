using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
[XmlInclude(typeof(EulerAngles))]
public class LinearSegmentParameter
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private ushort ushort_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "segmentNumber")]
	public byte SegmentNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "segmentModification")]
	public byte SegmentModification
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

	[XmlElement(Type = typeof(ushort), ElementName = "generalSegmentAppearance")]
	public ushort GeneralSegmentAppearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "specificSegmentAppearance")]
	public ushort SpecificSegmentAppearance
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "segmentLocation")]
	public Vector3Double SegmentLocation
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

	[XmlElement(Type = typeof(EulerAngles), ElementName = "segmentOrientation")]
	public EulerAngles SegmentOrientation
	{
		get
		{
			return eulerAngles_0;
		}
		set
		{
			eulerAngles_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "segmentLength")]
	public ushort SegmentLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentWidth")]
	public ushort SegmentWidth
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "segmentHeight")]
	public ushort SegmentHeight
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "segmentDepth")]
	public ushort SegmentDepth
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
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

	public static bool operator !=(LinearSegmentParameter left, LinearSegmentParameter right)
	{
		return !(left == right);
	}

	public static bool operator ==(LinearSegmentParameter left, LinearSegmentParameter right)
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
		return 6 + vector3Double_0.GetMarshalledSize() + eulerAngles_0.GetMarshalledSize() + 2 + 2 + 2 + 2;
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
				vector3Double_0.Marshal(dos);
				eulerAngles_0.Marshal(dos);
				dos.WriteUnsignedShort(ushort_2);
				dos.WriteUnsignedShort(ushort_3);
				dos.WriteUnsignedShort(ushort_4);
				dos.WriteUnsignedShort(ushort_5);
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
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				vector3Double_0.Unmarshal(dis);
				eulerAngles_0.Unmarshal(dis);
				ushort_2 = dis.ReadUnsignedShort();
				ushort_3 = dis.ReadUnsignedShort();
				ushort_4 = dis.ReadUnsignedShort();
				ushort_5 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<LinearSegmentParameter>");
		try
		{
			sb.AppendLine("<segmentNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
			sb.AppendLine("<segmentModification type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</segmentModification>");
			sb.AppendLine("<generalSegmentAppearance type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</generalSegmentAppearance>");
			sb.AppendLine("<specificSegmentAppearance type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</specificSegmentAppearance>");
			sb.AppendLine("<segmentLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</segmentLocation>");
			sb.AppendLine("<segmentOrientation>");
			eulerAngles_0.Reflection(sb);
			sb.AppendLine("</segmentOrientation>");
			sb.AppendLine("<segmentLength type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
			sb.AppendLine("<segmentWidth type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
			sb.AppendLine("<segmentHeight type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
			sb.AppendLine("<segmentDepth type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
			sb.AppendLine("</LinearSegmentParameter>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LinearSegmentParameter;
	}

	public bool Equals(LinearSegmentParameter obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
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
			if (ushort_1 != obj.ushort_1)
			{
				result = false;
			}
			if (!vector3Double_0.Equals(obj.vector3Double_0))
			{
				result = false;
			}
			if (!eulerAngles_0.Equals(obj.eulerAngles_0))
			{
				result = false;
			}
			if (ushort_2 != obj.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != obj.ushort_3)
			{
				result = false;
			}
			if (ushort_4 != obj.ushort_4)
			{
				result = false;
			}
			if (ushort_5 != obj.ushort_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ eulerAngles_0.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ ushort_4.GetHashCode()) ^ ushort_5.GetHashCode();
	}

	static LinearSegmentParameter()
	{
		Class72.smethod_20();
	}
}
