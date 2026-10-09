#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(FundamentalParameterDataIff))]
[XmlInclude(typeof(BeamData))]
[XmlRoot]
[XmlInclude(typeof(LayerHeader))]
public class IffAtcNavAidsLayer2Pdu : IffAtcNavAidsLayer1Pdu, IEquatable<IffAtcNavAidsLayer2Pdu>
{
	private LayerHeader layerHeader_0 = new LayerHeader();

	private BeamData beamData_0 = new BeamData();

	private BeamData beamData_1 = new BeamData();

	private List<FundamentalParameterDataIff> list_0 = new List<FundamentalParameterDataIff>();

	[XmlElement(Type = typeof(LayerHeader), ElementName = "layerHeader")]
	public LayerHeader LayerHeader
	{
		get
		{
			return layerHeader_0;
		}
		set
		{
			layerHeader_0 = value;
		}
	}

	[XmlElement(Type = typeof(BeamData), ElementName = "beamData")]
	public BeamData BeamData
	{
		get
		{
			return beamData_0;
		}
		set
		{
			beamData_0 = value;
		}
	}

	[XmlElement(Type = typeof(BeamData), ElementName = "secondaryOperationalData")]
	public BeamData SecondaryOperationalData
	{
		get
		{
			return beamData_1;
		}
		set
		{
			beamData_1 = value;
		}
	}

	[XmlElement(ElementName = "fundamentalIffParametersList", Type = typeof(List<FundamentalParameterDataIff>))]
	public List<FundamentalParameterDataIff> FundamentalIffParameters => list_0;

	public static bool operator !=(IffAtcNavAidsLayer2Pdu left, IffAtcNavAidsLayer2Pdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(IffAtcNavAidsLayer2Pdu left, IffAtcNavAidsLayer2Pdu right)
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

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += layerHeader_0.GetMarshalledSize();
		num += beamData_0.GetMarshalledSize();
		num += beamData_1.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			FundamentalParameterDataIff fundamentalParameterDataIff = list_0[i];
			num += fundamentalParameterDataIff.GetMarshalledSize();
		}
		return num;
	}

	public override void MarshalAutoLengthSet(DataOutputStream dos)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dos);
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
		if (dos == null)
		{
			return;
		}
		try
		{
			layerHeader_0.Marshal(dos);
			beamData_0.Marshal(dos);
			beamData_1.Marshal(dos);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
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

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis == null)
		{
			return;
		}
		try
		{
			layerHeader_0.Unmarshal(dis);
			beamData_0.Unmarshal(dis);
			beamData_1.Unmarshal(dis);
			for (int i = 0; i < base.Pad2; i++)
			{
				FundamentalParameterDataIff fundamentalParameterDataIff = new FundamentalParameterDataIff();
				fundamentalParameterDataIff.Unmarshal(dis);
				list_0.Add(fundamentalParameterDataIff);
			}
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

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<IffAtcNavAidsLayer2Pdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<layerHeader>");
			layerHeader_0.Reflection(sb);
			sb.AppendLine("</layerHeader>");
			sb.AppendLine("<beamData>");
			beamData_0.Reflection(sb);
			sb.AppendLine("</beamData>");
			sb.AppendLine("<secondaryOperationalData>");
			beamData_1.Reflection(sb);
			sb.AppendLine("</secondaryOperationalData>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<fundamentalIffParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FundamentalParameterDataIff\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</fundamentalIffParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</IffAtcNavAidsLayer2Pdu>");
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
		return this == obj as IffAtcNavAidsLayer2Pdu;
	}

	public bool Equals(IffAtcNavAidsLayer2Pdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((IffAtcNavAidsLayer1Pdu)obj);
			if (!layerHeader_0.Equals(obj.layerHeader_0))
			{
				flag = false;
			}
			if (!beamData_0.Equals(obj.beamData_0))
			{
				flag = false;
			}
			if (!beamData_1.Equals(obj.beamData_1))
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
			return flag;
		}
		return false;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ layerHeader_0.GetHashCode();
		num = smethod_3(num) ^ beamData_0.GetHashCode();
		num = smethod_3(num) ^ beamData_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static IffAtcNavAidsLayer2Pdu()
	{
		Class72.smethod_20();
	}
}
