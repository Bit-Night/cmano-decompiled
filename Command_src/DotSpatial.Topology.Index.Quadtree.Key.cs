using System;

namespace DotSpatial.Topology.Index.Quadtree;

public class Key
{
	private readonly Coordinate coordinate_0 = new Coordinate();

	private IEnvelope ienvelope_0;

	private int int_0;

	public virtual Coordinate Point => coordinate_0;

	public virtual int Level => int_0;

	public virtual IEnvelope Envelope => ienvelope_0;

	public virtual Coordinate Centre => new Coordinate((ienvelope_0.Minimum.X + ienvelope_0.Maximum.X) / 2.0, (ienvelope_0.Minimum.Y + ienvelope_0.Maximum.Y) / 2.0);

	public Key(IEnvelope itemEnv)
	{
		ComputeKey(itemEnv);
	}

	public static int ComputeQuadLevel(IEnvelope env)
	{
		double width = env.Width;
		double height = env.Height;
		return DoubleBits.GetExponent((width > height) ? width : height) + 1;
	}

	public void ComputeKey(IEnvelope itemEnv)
	{
		int_0 = ComputeQuadLevel(itemEnv);
		ienvelope_0 = new Envelope();
		method_0(int_0, itemEnv);
		while (!ienvelope_0.Contains(itemEnv))
		{
			int_0++;
			method_0(int_0, itemEnv);
		}
	}

	private void method_0(int int_1, IEnvelope ienvelope_1)
	{
		double num = DoubleBits.PowerOf2(int_1);
		coordinate_0.X = Math.Floor(ienvelope_1.Minimum.X / num) * num;
		coordinate_0.Y = Math.Floor(ienvelope_1.Minimum.Y / num) * num;
		ienvelope_0 = new Envelope(coordinate_0.X, coordinate_0.X + num, coordinate_0.Y, coordinate_0.Y + num);
	}

	static Key()
	{
		Class72.smethod_20();
	}
}
