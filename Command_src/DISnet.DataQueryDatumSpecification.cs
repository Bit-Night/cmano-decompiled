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
[XmlInclude(typeof(GClass11))]
[XmlRoot]
[XmlInclude(typeof(GClass11))]
public class DataQueryDatumSpecification
{
	private uint uint_0;

	private uint uint_1;

	private List<GClass11> list_0 = new List<GClass11>();

	private List<GClass11> list_1 = new List<GClass11>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatums")]
	public uint NumberOfFixedDatums
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatums")]
	public uint NumberOfVariableDatums
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

	[XmlElement(ElementName = "fixedDatumIDListList", Type = typeof(List<GClass11>))]
	public List<GClass11> FixedDatumIDList => list_0;

	[XmlElement(ElementName = "variableDatumIDListList", Type = typeof(List<GClass11>))]
	public List<GClass11> VariableDatumIDList => list_1;

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

	public static bool operator !=(DataQueryDatumSpecification left, DataQueryDatumSpecification right)
	{
		return !(left == right);
	}

	public static bool operator ==(DataQueryDatumSpecification left, DataQueryDatumSpecification right)
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
		num = 4;
		num = 8;
		for (int i = 0; i < list_0.Count; i++)
		{
			GClass11 gClass = list_0[i];
			num += gClass.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			GClass11 gClass2 = list_1[j];
			num += gClass2.GetMarshalledSize();
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
			dos.WriteUnsignedInt((uint)list_0.Count);
			dos.WriteUnsignedInt((uint)list_1.Count);
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
			uint_1 = dis.ReadUnsignedInt();
			for (int i = 0; i < NumberOfFixedDatums; i++)
			{
				GClass11 gClass = new GClass11();
				gClass.Unmarshal(dis);
				list_0.Add(gClass);
			}
			for (int j = 0; j < NumberOfVariableDatums; j++)
			{
				GClass11 gClass2 = new GClass11();
				gClass2.Unmarshal(dis);
				list_1.Add(gClass2);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DataQueryDatumSpecification>");
		try
		{
			sb.AppendLine("<fixedDatumIDList type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatumIDList>");
			sb.AppendLine("<variableDatumIDList type=\"uint\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumIDList>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<fixedDatumIDList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"UnsignedDISInteger\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</fixedDatumIDList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<variableDatumIDList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"UnsignedDISInteger\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</variableDatumIDList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</DataQueryDatumSpecification>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DataQueryDatumSpecification;
	}

	public bool Equals(DataQueryDatumSpecification obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (uint_0 != obj.uint_0)
			{
				flag = false;
			}
			if (uint_1 != obj.uint_1)
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
		num = smethod_0(0) ^ uint_0.GetHashCode();
		num = smethod_0(num) ^ uint_1.GetHashCode();
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

	static DataQueryDatumSpecification()
	{
		Class72.smethod_20();
	}
}
