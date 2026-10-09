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
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
public class DirectedEnergyPrecisionAimpoint
{
	private uint uint_0 = 4000u;

	private ushort ushort_0 = 88;

	private ushort ushort_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private Vector3Float vector3Float_2 = new Vector3Float();

	private EntityID entityID_0 = new EntityID();

	private byte byte_0;

	private byte byte_1;

	private float float_0;

	private float float_1;

	private float float_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "targetSpotLocation")]
	public Vector3Double TargetSpotLocation
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotEntityLocation")]
	public Vector3Float TargetSpotEntityLocation
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotVelocity")]
	public Vector3Float TargetSpotVelocity
	{
		get
		{
			return vector3Float_1;
		}
		set
		{
			vector3Float_1 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "targetSpotAcceleration")]
	public Vector3Float TargetSpotAcceleration
	{
		get
		{
			return vector3Float_2;
		}
		set
		{
			vector3Float_2 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "targetEntityID")]
	public EntityID TargetEntityID
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "targetComponentID")]
	public byte TargetComponentID
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

	[XmlElement(Type = typeof(byte), ElementName = "SpotShape")]
	public byte SpotShape
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

	[XmlElement(Type = typeof(float), ElementName = "BeamSpotXSecSemiMajorAxis")]
	public float BeamSpotXSecSemiMajorAxis
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "BeamSpotCrossSectionSemiMinorAxis")]
	public float BeamSpotCrossSectionSemiMinorAxis
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "BeamSpotCrossSectionOrientAngle")]
	public float BeamSpotCrossSectionOrientAngle
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
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

	public static bool operator !=(DirectedEnergyPrecisionAimpoint left, DirectedEnergyPrecisionAimpoint right)
	{
		return !(left == right);
	}

	public static bool operator ==(DirectedEnergyPrecisionAimpoint left, DirectedEnergyPrecisionAimpoint right)
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
		return 8 + vector3Double_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + vector3Float_1.GetMarshalledSize() + vector3Float_2.GetMarshalledSize() + entityID_0.GetMarshalledSize() + 1 + 1 + 4 + 4 + 4;
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
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
				vector3Double_0.Marshal(dos);
				vector3Float_0.Marshal(dos);
				vector3Float_1.Marshal(dos);
				vector3Float_2.Marshal(dos);
				entityID_0.Marshal(dos);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				dos.WriteFloat(float_2);
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
			uint_0 = dis.ReadUnsignedInt();
			ushort_0 = dis.ReadUnsignedShort();
			ushort_1 = dis.ReadUnsignedShort();
			vector3Double_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			vector3Float_1.Unmarshal(dis);
			vector3Float_2.Unmarshal(dis);
			entityID_0.Unmarshal(dis);
			byte_0 = dis.ReadUnsignedByte();
			byte_1 = dis.ReadUnsignedByte();
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			float_2 = dis.ReadFloat();
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DirectedEnergyPrecisionAimpoint>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<targetSpotLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</targetSpotLocation>");
			sb.AppendLine("<targetSpotEntityLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</targetSpotEntityLocation>");
			sb.AppendLine("<targetSpotVelocity>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</targetSpotVelocity>");
			sb.AppendLine("<targetSpotAcceleration>");
			vector3Float_2.Reflection(sb);
			sb.AppendLine("</targetSpotAcceleration>");
			sb.AppendLine("<targetEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</targetEntityID>");
			sb.AppendLine("<targetComponentID type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</targetComponentID>");
			sb.AppendLine("<SpotShape type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</SpotShape>");
			sb.AppendLine("<BeamSpotXSecSemiMajorAxis type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</BeamSpotXSecSemiMajorAxis>");
			sb.AppendLine("<BeamSpotCrossSectionSemiMinorAxis type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</BeamSpotCrossSectionSemiMinorAxis>");
			sb.AppendLine("<BeamSpotCrossSectionOrientAngle type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</BeamSpotCrossSectionOrientAngle>");
			sb.AppendLine("</DirectedEnergyPrecisionAimpoint>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyPrecisionAimpoint;
	}

	public bool Equals(DirectedEnergyPrecisionAimpoint obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (uint_0 != obj.uint_0)
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
			if (!vector3Float_0.Equals(obj.vector3Float_0))
			{
				result = false;
			}
			if (!vector3Float_1.Equals(obj.vector3Float_1))
			{
				result = false;
			}
			if (!vector3Float_2.Equals(obj.vector3Float_2))
			{
				result = false;
			}
			if (!entityID_0.Equals(obj.entityID_0))
			{
				result = false;
			}
			if (byte_0 != obj.byte_0)
			{
				result = false;
			}
			if (byte_1 != obj.byte_1)
			{
				result = false;
			}
			if (float_0 != obj.float_0)
			{
				result = false;
			}
			if (float_1 != obj.float_1)
			{
				result = false;
			}
			if (float_2 != obj.float_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ vector3Float_1.GetHashCode()) ^ vector3Float_2.GetHashCode()) ^ entityID_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode();
	}

	static DirectedEnergyPrecisionAimpoint()
	{
		Class72.smethod_20();
	}
}
