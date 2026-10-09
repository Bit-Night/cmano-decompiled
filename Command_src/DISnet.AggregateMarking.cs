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
public class AggregateMarking
{
	private byte byte_0;

	private byte[] byte_1 = new byte[31];

	[CompilerGenerated]
	private Action<Exception> yomYdeXnErp;

	[XmlElement(Type = typeof(byte), ElementName = "characterSet")]
	public byte CharacterSet
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

	[XmlArray(ElementName = "characters")]
	public byte[] Characters
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

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = yomYdeXnErp;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref yomYdeXnErp, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = yomYdeXnErp;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref yomYdeXnErp, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(AggregateMarking left, AggregateMarking right)
	{
		return !(left == right);
	}

	public static bool operator ==(AggregateMarking left, AggregateMarking right)
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
		return 32;
	}

	protected void OnException(Exception e)
	{
		if (yomYdeXnErp != null)
		{
			yomYdeXnErp(e);
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
			for (int i = 0; i < byte_1.Length; i++)
			{
				dos.WriteUnsignedByte(byte_1[i]);
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
			byte_0 = dis.ReadUnsignedByte();
			for (int i = 0; i < byte_1.Length; i++)
			{
				byte_1[i] = dis.ReadUnsignedByte();
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<AggregateMarking>");
		try
		{
			sb.AppendLine("<characterSet type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</characterSet>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				sb.AppendLine("<characters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</characters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</AggregateMarking>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AggregateMarking;
	}

	public bool Equals(AggregateMarking obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (byte_0 != obj.byte_0)
			{
				flag = false;
			}
			if (obj.byte_1.Length != 31)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 31; i++)
				{
					if (byte_1[i] != obj.byte_1[i])
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
		num = smethod_0(0) ^ byte_0.GetHashCode();
		for (int i = 0; i < 31; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		return num;
	}

	static AggregateMarking()
	{
		Class72.smethod_20();
	}
}
