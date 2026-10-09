using System;
using System.ComponentModel;

namespace DotSpatial.Topology;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class SizeD : ISize
{
	private double double_0;

	private double double_1;

	private double double_2;

	public virtual double XSize
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public virtual double YSize
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public virtual double ZSize
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public SizeD()
	{
	}

	public SizeD(double xSize, double ySize, double zSize)
	{
		double_0 = xSize;
		double_1 = ySize;
		double_2 = zSize;
	}

	static SizeD()
	{
		Class72.smethod_20();
	}
}
