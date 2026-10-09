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
public class TwoByteChunk
{
	private byte[] byte_0 = new byte[2];

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlArray(ElementName = "otherParameters")]
	public byte[] OtherParameters
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

	public static bool operator !=(TwoByteChunk left, TwoByteChunk right)
	{
		return !(left == right);
	}

	public static bool operator ==(TwoByteChunk left, TwoByteChunk right)
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
		return 2;
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
			for (int i = 0; i < byte_0.Length; i++)
			{
				dos.WriteByte(byte_0[i]);
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
			for (int i = 0; i < byte_0.Length; i++)
			{
				byte_0[i] = dis.ReadByte();
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<TwoByteChunk>");
		try
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				sb.AppendLine("<otherParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_0[i] + "</otherParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</TwoByteChunk>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as TwoByteChunk;
	}

	public bool Equals(TwoByteChunk obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (obj.byte_0.Length != 2)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 2; i++)
				{
					if (byte_0[i] != obj.byte_0[i])
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
		for (int i = 0; i < 2; i++)
		{
			num = smethod_0(num) ^ byte_0[i].GetHashCode();
		}
		return num;
	}

	static TwoByteChunk()
	{
		Class72.smethod_20();
	}
}
