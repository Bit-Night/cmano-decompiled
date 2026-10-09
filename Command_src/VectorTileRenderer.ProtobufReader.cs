using System;
using System.Collections.Generic;
using System.Text;

namespace VectorTileRenderer;

internal class ProtobufReader
{
	private readonly byte[] byte_0;

	private int int_0;

	private readonly int int_1;

	public bool HasMore => int_0 < int_1;

	public ProtobufReader(byte[] data)
		: this(data, 0, data.Length)
	{
	}

	public ProtobufReader(byte[] data, int offset, int length)
	{
		byte_0 = data;
		int_0 = offset;
		int_1 = offset + length;
	}

	public List<ProtoField> ReadFields()
	{
		List<ProtoField> list = new List<ProtoField>();
		while (HasMore)
		{
			list.Add(ReadField());
		}
		return list;
	}

	public ProtoField ReadField()
	{
		ulong num = ReadVarint();
		int fieldNumber = (int)(num >> 3);
		WireType wireType = (WireType)(num & 7L);
		ProtoField result = new ProtoField
		{
			FieldNumber = fieldNumber,
			WireType = wireType
		};
		switch (wireType)
		{
		case WireType.Varint:
			result.VarIntValue = ReadVarint();
			break;
		case WireType.Fixed64:
			result.Fixed64Value = method_1();
			break;
		case WireType.LengthDelim:
		{
			int num2 = (int)ReadVarint();
			result.BytesValue = new byte[num2];
			Buffer.BlockCopy(byte_0, int_0, result.BytesValue, 0, num2);
			int_0 += num2;
			break;
		}
		default:
			throw new Exception($"Unsupported protobuf wire type {wireType} at position {int_0}");
		case WireType.Fixed32:
			result.Fixed32Value = method_0();
			break;
		}
		return result;
	}

	public ulong ReadVarint()
	{
		ulong num = 0uL;
		int num2 = 0;
		while (true)
		{
			if (int_0 < int_1)
			{
				byte b = byte_0[int_0++];
				num |= (ulong)((long)(b & 0x7F) << num2);
				if ((b & 0x80) == 0)
				{
					break;
				}
				num2 += 7;
				if (num2 >= 64)
				{
					throw new Exception("Varint too long");
				}
				continue;
			}
			throw new Exception("Buffer overrun reading varint");
		}
		return num;
	}

	public long ReadZigZag()
	{
		ulong num = ReadVarint();
		return (long)((num >> 1) ^ (0L - (num & 1L)));
	}

	private uint method_0()
	{
		int result = byte_0[int_0] | (byte_0[int_0 + 1] << 8) | (byte_0[int_0 + 2] << 16) | (byte_0[int_0 + 3] << 24);
		int_0 += 4;
		return (uint)result;
	}

	private ulong method_1()
	{
		ulong num = 0uL;
		for (int i = 0; i < 8; i++)
		{
			num |= (ulong)byte_0[int_0++] << i * 8;
		}
		return num;
	}

	public static string BytesToString(byte[] bytes)
	{
		return Encoding.UTF8.GetString(bytes);
	}

	public static ProtobufReader FromBytes(byte[] bytes)
	{
		return new ProtobufReader(bytes, 0, bytes.Length);
	}

	public static List<int> UnpackSignedVarints(byte[] bytes)
	{
		ProtobufReader protobufReader = new ProtobufReader(bytes);
		List<int> list = new List<int>();
		while (protobufReader.HasMore)
		{
			list.Add((int)protobufReader.ReadVarint());
		}
		return list;
	}

	public static int ZigZagDecode(int n)
	{
		return (n >> 1) ^ -(n & 1);
	}

	static ProtobufReader()
	{
		Class72.smethod_20();
	}
}
