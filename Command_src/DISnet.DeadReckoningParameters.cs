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
[XmlInclude(typeof(Vector3Float))]
public class DeadReckoningParameters
{
	private byte byte_0;

	private byte[] byte_1 = new byte[15];

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Float vector3Float_1 = new Vector3Float();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
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

	[XmlArray(ElementName = "parameters")]
	public byte[] Parameters
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
	public Vector3Float EntityLinearAcceleration
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityAngularVelocity")]
	public Vector3Float EntityAngularVelocity
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

	public static bool operator !=(DeadReckoningParameters left, DeadReckoningParameters right)
	{
		return !(left == right);
	}

	public static bool operator ==(DeadReckoningParameters left, DeadReckoningParameters right)
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
		return 16 + vector3Float_0.GetMarshalledSize() + vector3Float_1.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_0);
			for (int i = 0; i < byte_1.Length; i++)
			{
				dos.WriteUnsignedByte(byte_1[i]);
			}
			vector3Float_0.Marshal(dos);
			vector3Float_1.Marshal(dos);
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
			vector3Float_0.Unmarshal(dis);
			vector3Float_1.Unmarshal(dis);
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DeadReckoningParameters>");
		try
		{
			sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				sb.AppendLine("<parameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</parameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<entityLinearAcceleration>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</entityLinearAcceleration>");
			sb.AppendLine("<entityAngularVelocity>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</entityAngularVelocity>");
			sb.AppendLine("</DeadReckoningParameters>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DeadReckoningParameters;
	}

	public bool Equals(DeadReckoningParameters obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (byte_0 != obj.byte_0)
			{
				flag = false;
			}
			if (obj.byte_1.Length != 15)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 15; i++)
				{
					if (byte_1[i] != obj.byte_1[i])
					{
						flag = false;
					}
				}
			}
			if (!vector3Float_0.Equals(obj.vector3Float_0))
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(obj.vector3Float_1))
			{
				flag = false;
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
		for (int i = 0; i < 15; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		num = smethod_0(num) ^ vector3Float_0.GetHashCode();
		return smethod_0(num) ^ vector3Float_1.GetHashCode();
	}

	static DeadReckoningParameters()
	{
		Class72.smethod_20();
	}
}
