using System;
using System.ComponentModel;
using DotSpatial.Serialization;

namespace DotSpatial;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class SerializeExtent : ICloneable
{
	[Serialize("XMax")]
	public double XMax;

	[Serialize("XMin")]
	public double XMin;

	[Serialize("YMax")]
	public double YMax;

	[Serialize("YMin")]
	public double YMin;

	public SerializeExtent()
	{
		XMin = double.MaxValue;
		XMax = double.MinValue;
		YMin = double.MaxValue;
		YMax = double.MinValue;
	}

	public SerializeExtent(double xMin, double yMin, double xMax, double yMax)
	{
		XMin = xMin;
		YMin = yMin;
		XMax = xMax;
		YMax = yMax;
	}

	public SerializeExtent(double[] values, int offset)
	{
		XMin = values[offset];
		YMin = values[1 + offset];
		XMax = values[2 + offset];
		YMax = values[3 + offset];
	}

	public SerializeExtent(double[] values)
	{
		XMin = values[0];
		YMin = values[1];
		XMax = values[2];
		YMax = values[3];
	}

	public object Clone()
	{
		return new SerializeExtent(XMin, YMin, XMax, YMax);
	}

	public bool IsEmpty()
	{
		int result;
		if (!(XMin <= XMax))
		{
			result = 1;
		}
		else
		{
			if (YMin <= YMax)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	static SerializeExtent()
	{
		Class72.smethod_20();
	}
}
