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
[XmlInclude(typeof(SimulationManagementPduHeader))]
[XmlRoot]
public class StandardVariableSpecification
{
	private ushort ushort_0;

	private List<SimulationManagementPduHeader> list_0 = new List<SimulationManagementPduHeader>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfStandardVariableRecords")]
	public ushort NumberOfStandardVariableRecords
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

	[XmlElement(ElementName = "standardVariablesList", Type = typeof(List<SimulationManagementPduHeader>))]
	public List<SimulationManagementPduHeader> StandardVariables => list_0;

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

	public static bool operator !=(StandardVariableSpecification left, StandardVariableSpecification right)
	{
		return !(left == right);
	}

	public static bool operator ==(StandardVariableSpecification left, StandardVariableSpecification right)
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
		int num = 0;
		num = 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			SimulationManagementPduHeader simulationManagementPduHeader = list_0[i];
			num += simulationManagementPduHeader.GetMarshalledSize();
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
			dos.WriteUnsignedShort((ushort)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
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
			ushort_0 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfStandardVariableRecords; i++)
			{
				SimulationManagementPduHeader simulationManagementPduHeader = new SimulationManagementPduHeader();
				simulationManagementPduHeader.Unmarshal(dis);
				list_0.Add(simulationManagementPduHeader);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<StandardVariableSpecification>");
		try
		{
			sb.AppendLine("<standardVariables type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</standardVariables>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<standardVariables" + i.ToString(CultureInfo.InvariantCulture) + " type=\"SimulationManagementPduHeader\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</standardVariables" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</StandardVariableSpecification>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StandardVariableSpecification;
	}

	public bool Equals(StandardVariableSpecification obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (ushort_0 != obj.ushort_0)
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

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_0(0) ^ ushort_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static StandardVariableSpecification()
	{
		Class72.smethod_20();
	}
}
