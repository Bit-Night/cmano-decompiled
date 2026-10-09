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
[XmlInclude(typeof(FourByteChunk))]
public class RecordQuerySpecification
{
	private uint uint_0;

	private List<FourByteChunk> list_0 = new List<FourByteChunk>();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecords")]
	public uint NumberOfRecords
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

	[XmlElement(ElementName = "recordsList", Type = typeof(List<FourByteChunk>))]
	public List<FourByteChunk> Records => list_0;

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

	public static bool operator !=(RecordQuerySpecification left, RecordQuerySpecification right)
	{
		return !(left == right);
	}

	public static bool operator ==(RecordQuerySpecification left, RecordQuerySpecification right)
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
		for (int i = 0; i < list_0.Count; i++)
		{
			FourByteChunk fourByteChunk = list_0[i];
			num += fourByteChunk.GetMarshalledSize();
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
			uint_0 = dis.ReadUnsignedInt();
			for (int i = 0; i < NumberOfRecords; i++)
			{
				FourByteChunk fourByteChunk = new FourByteChunk();
				fourByteChunk.Unmarshal(dis);
				list_0.Add(fourByteChunk);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<RecordQuerySpecification>");
		try
		{
			sb.AppendLine("<records type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</records>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<records" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</records" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</RecordQuerySpecification>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RecordQuerySpecification;
	}

	public bool Equals(RecordQuerySpecification obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (uint_0 != obj.uint_0)
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
		num = smethod_0(0) ^ uint_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static RecordQuerySpecification()
	{
		Class72.smethod_20();
	}
}
