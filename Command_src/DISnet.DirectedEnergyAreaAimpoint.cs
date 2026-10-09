using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(BeamAntennaPattern))]
[XmlInclude(typeof(DirectedEnergyTargetEnergyDeposition))]
public class DirectedEnergyAreaAimpoint
{
	private uint uint_0 = 4001u;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private List<BeamAntennaPattern> list_0 = new List<BeamAntennaPattern>();

	private List<DirectedEnergyTargetEnergyDeposition> list_1 = new List<DirectedEnergyTargetEnergyDeposition>();

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

	[XmlElement(Type = typeof(ushort), ElementName = "beamAntennaPatternRecordCount")]
	public ushort BeamAntennaPatternRecordCount
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

	[XmlElement(Type = typeof(ushort), ElementName = "directedEnergyTargetEnergyDepositionRecordCount")]
	public ushort DirectedEnergyTargetEnergyDepositionRecordCount
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

	[XmlElement(ElementName = "beamAntennaParameterListList", Type = typeof(List<BeamAntennaPattern>))]
	public List<BeamAntennaPattern> BeamAntennaParameterList => list_0;

	[XmlElement(ElementName = "directedEnergyTargetEnergyDepositionRecordListList", Type = typeof(List<DirectedEnergyTargetEnergyDeposition>))]
	public List<DirectedEnergyTargetEnergyDeposition> DirectedEnergyTargetEnergyDepositionRecordList => list_1;

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

	public static bool operator !=(DirectedEnergyAreaAimpoint left, DirectedEnergyAreaAimpoint right)
	{
		return !(left == right);
	}

	public static bool operator ==(DirectedEnergyAreaAimpoint left, DirectedEnergyAreaAimpoint right)
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
		int num = 0;
		num = 4;
		num = 6;
		num = 8;
		num = 10;
		num = 12;
		for (int i = 0; i < list_0.Count; i++)
		{
			BeamAntennaPattern beamAntennaPattern = list_0[i];
			num += beamAntennaPattern.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			DirectedEnergyTargetEnergyDeposition directedEnergyTargetEnergyDeposition = list_1[j];
			num += directedEnergyTargetEnergyDeposition.GetMarshalledSize();
		}
		return num;
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
		if (dos == null)
		{
			return;
		}
		try
		{
			dos.WriteUnsignedInt(uint_0);
			dos.WriteUnsignedShort(ushort_0);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedShort((ushort)list_0.Count);
			dos.WriteUnsignedShort((ushort)list_1.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
			}
		}
		catch (Exception e)
		{
			OnException(e);
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
			uint_0 = dis.ReadUnsignedInt();
			ushort_0 = dis.ReadUnsignedShort();
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			for (int i = 0; i < BeamAntennaPatternRecordCount; i++)
			{
				BeamAntennaPattern beamAntennaPattern = new BeamAntennaPattern();
				beamAntennaPattern.Unmarshal(dis);
				list_0.Add(beamAntennaPattern);
			}
			for (int j = 0; j < DirectedEnergyTargetEnergyDepositionRecordCount; j++)
			{
				DirectedEnergyTargetEnergyDeposition directedEnergyTargetEnergyDeposition = new DirectedEnergyTargetEnergyDeposition();
				directedEnergyTargetEnergyDeposition.Unmarshal(dis);
				list_1.Add(directedEnergyTargetEnergyDeposition);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DirectedEnergyAreaAimpoint>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<beamAntennaParameterList type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</beamAntennaParameterList>");
			sb.AppendLine("<directedEnergyTargetEnergyDepositionRecordList type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</directedEnergyTargetEnergyDepositionRecordList>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<beamAntennaParameterList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"BeamAntennaPattern\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</beamAntennaParameterList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<directedEnergyTargetEnergyDepositionRecordList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"DirectedEnergyTargetEnergyDeposition\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</directedEnergyTargetEnergyDepositionRecordList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</DirectedEnergyAreaAimpoint>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyAreaAimpoint;
	}

	public bool Equals(DirectedEnergyAreaAimpoint obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (uint_0 != obj.uint_0)
		{
			flag = false;
		}
		if (ushort_0 != obj.ushort_0)
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (ushort_3 != obj.ushort_3)
		{
			flag = false;
		}
		if (list_0.Count != obj.list_0.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				if (!list_0[i].Equals(obj.list_0[i]))
				{
					flag = false;
				}
			}
		}
		if (list_1.Count != obj.list_1.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				if (!list_1[j].Equals(obj.list_1[j]))
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_0(0) ^ uint_0.GetHashCode();
		num = smethod_0(num) ^ ushort_0.GetHashCode();
		num = smethod_0(num) ^ ushort_1.GetHashCode();
		num = smethod_0(num) ^ ushort_2.GetHashCode();
		num = smethod_0(num) ^ ushort_3.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_0(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}

	static DirectedEnergyAreaAimpoint()
	{
		Class72.smethod_20();
	}
}
