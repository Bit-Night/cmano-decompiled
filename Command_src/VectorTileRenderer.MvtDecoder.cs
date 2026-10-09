using System;
using System.Collections.Generic;

namespace VectorTileRenderer;

public static class MvtDecoder
{
	public static DecodedTile Decode(byte[] data)
	{
		DecodedTile decodedTile = new DecodedTile();
		foreach (ProtoField item in new ProtobufReader(data).ReadFields())
		{
			if (item.FieldNumber == 3 && item.WireType == WireType.LengthDelim)
			{
				decodedTile.Layers.Add(smethod_0(item.BytesValue));
			}
		}
		return decodedTile;
	}

	private static TileLayer smethod_0(byte[] byte_0)
	{
		TileLayer tileLayer = new TileLayer
		{
			Extent = 4096u
		};
		List<string> list = new List<string>();
		List<TileValue> list2 = new List<TileValue>();
		List<byte[]> list3 = new List<byte[]>();
		foreach (ProtoField item in new ProtobufReader(byte_0).ReadFields())
		{
			switch (item.FieldNumber)
			{
			case 1:
				tileLayer.Name = ProtobufReader.BytesToString(item.BytesValue);
				break;
			case 2:
				list3.Add(item.BytesValue);
				break;
			case 3:
				list.Add(ProtobufReader.BytesToString(item.BytesValue));
				break;
			case 4:
				list2.Add(smethod_1(item.BytesValue));
				break;
			case 5:
				tileLayer.Extent = (uint)item.VarIntValue;
				break;
			}
		}
		foreach (byte[] item2 in list3)
		{
			TileFeature tileFeature = smethod_2(item2, list, list2);
			if (tileFeature != null)
			{
				tileLayer.Features.Add(tileFeature);
			}
		}
		return tileLayer;
	}

	private static TileValue smethod_1(byte[] byte_0)
	{
		TileValue tileValue = new TileValue();
		foreach (ProtoField item in new ProtobufReader(byte_0).ReadFields())
		{
			switch (item.FieldNumber)
			{
			case 1:
				tileValue.StringValue = ProtobufReader.BytesToString(item.BytesValue);
				break;
			case 2:
				tileValue.FloatValue = BitConverter.ToSingle(BitConverter.GetBytes(item.Fixed32Value), 0);
				break;
			case 3:
				tileValue.DoubleValue = BitConverter.Int64BitsToDouble((long)item.Fixed64Value);
				break;
			case 4:
				tileValue.IntValue = (long)item.VarIntValue;
				break;
			case 5:
				tileValue.nullable_0 = item.VarIntValue;
				break;
			case 6:
				tileValue.nullable_1 = smethod_4(item.VarIntValue);
				break;
			case 7:
				tileValue.BoolValue = item.VarIntValue > 0L;
				break;
			}
		}
		return tileValue;
	}

	private static TileFeature smethod_2(byte[] byte_0, List<string> list_0, List<TileValue> list_1)
	{
		TileFeature tileFeature = new TileFeature();
		byte[] array = null;
		byte[] array2 = null;
		int type = 0;
		foreach (ProtoField item in new ProtobufReader(byte_0).ReadFields())
		{
			switch (item.FieldNumber)
			{
			case 1:
				tileFeature.Id = item.VarIntValue;
				break;
			case 2:
				array = item.BytesValue;
				break;
			case 3:
				type = (int)item.VarIntValue;
				break;
			case 4:
				array2 = item.BytesValue;
				break;
			}
		}
		tileFeature.Type = (GeometryType)type;
		if (array != null)
		{
			List<int> list = ProtobufReader.UnpackSignedVarints(array);
			for (int i = 0; i + 1 < list.Count; i += 2)
			{
				int num = list[i];
				int num2 = list[i + 1];
				if (num < list_0.Count && num2 < list_1.Count)
				{
					tileFeature.Tags[list_0[num]] = list_1[num2];
				}
			}
		}
		if (array2 != null)
		{
			tileFeature.Geometry = smethod_3(array2, tileFeature.Type);
		}
		return tileFeature;
	}

	private static TileGeometry smethod_3(byte[] byte_0, GeometryType geometryType_0)
	{
		TileGeometry tileGeometry = new TileGeometry
		{
			Type = geometryType_0
		};
		List<int> list = ProtobufReader.UnpackSignedVarints(byte_0);
		int num = 0;
		int num2 = 0;
		List<TilePoint> list2 = null;
		int num3 = 0;
		while (num3 < list.Count)
		{
			int num4 = list[num3++];
			int num5 = num4 & 7;
			int num6 = num4 >> 3;
			switch (num5)
			{
			case 1:
			{
				for (int j = 0; j < num6; j++)
				{
					if (num3 + 1 >= list.Count)
					{
						break;
					}
					int num10 = ProtobufReader.ZigZagDecode(list[num3++]);
					int num11 = ProtobufReader.ZigZagDecode(list[num3++]);
					num += num10;
					num2 += num11;
					list2 = new List<TilePoint>();
					list2.Add(new TilePoint(num, num2));
					tileGeometry.Parts.Add(list2);
				}
				continue;
			}
			case 2:
			{
				int num7;
				if (list2 == null)
				{
					list2 = new List<TilePoint>();
					tileGeometry.Parts.Add(list2);
					num7 = 0;
				}
				else
				{
					num7 = 0;
				}
				for (int i = num7; i < num6; i++)
				{
					if (num3 + 1 >= list.Count)
					{
						break;
					}
					int num8 = ProtobufReader.ZigZagDecode(list[num3++]);
					int num9 = ProtobufReader.ZigZagDecode(list[num3++]);
					num += num8;
					num2 += num9;
					list2.Add(new TilePoint(num, num2));
				}
				continue;
			}
			case 7:
				if (list2 != null && list2.Count > 0)
				{
					TilePoint item = list2[0];
					TilePoint tilePoint = list2[list2.Count - 1];
					if (item.X != tilePoint.X || item.Y != tilePoint.Y)
					{
						list2.Add(item);
					}
				}
				list2 = null;
				continue;
			}
			break;
		}
		return tileGeometry;
	}

	private static long smethod_4(ulong ulong_0)
	{
		return (long)((ulong_0 >> 1) ^ (0L - (ulong_0 & 1L)));
	}

	static MvtDecoder()
	{
		Class72.smethod_20();
	}
}
