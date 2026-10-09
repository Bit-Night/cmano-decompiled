using System.Collections;
using DotSpatial.Topology.Index.Bintree;
using DotSpatial.Topology.Index.Chain;

namespace DotSpatial.Topology.Algorithm;

public sealed class McPointInRing : IPointInRing
{
	private class Class63 : MonotoneChainSelectAction
	{
		private readonly McPointInRing mcPointInRing_0;

		private readonly Coordinate coordinate_0 = Coordinate.Empty;

		public Class63(McPointInRing mcPointInRing_1, Coordinate coordinate_1)
		{
			mcPointInRing_0 = mcPointInRing_1;
			coordinate_0 = coordinate_1;
		}

		public override void Select(LineSegment seg)
		{
			mcPointInRing_0.method_1(coordinate_0, seg);
		}

		static Class63()
		{
			Class72.smethod_20();
		}
	}

	private readonly Interval interval_0 = new Interval();

	private readonly ILinearRing ilinearRing_0;

	private int int_0;

	private Bintree bintree_0;

	public McPointInRing(ILinearRing ring)
	{
		ilinearRing_0 = ring;
		method_0();
	}

	public bool IsInside(Coordinate pt)
	{
		int_0 = 0;
		Envelope ienvelope_ = new Envelope(double.NegativeInfinity, double.PositiveInfinity, pt.Y, pt.Y);
		interval_0.Min = pt.Y;
		interval_0.Max = pt.Y;
		IList list = bintree_0.Query(interval_0);
		Class63 monotoneChainSelectAction_ = new Class63(this, pt);
		IEnumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MonotoneChain monotoneChain_ = (MonotoneChain)enumerator.Current;
			smethod_0(ienvelope_, monotoneChainSelectAction_, monotoneChain_);
		}
		if (int_0 % 2 == 1)
		{
			return true;
		}
		return false;
	}

	private void method_0()
	{
		bintree_0 = new Bintree();
		IList chains = MonotoneChainBuilder.GetChains(CoordinateArrays.RemoveRepeatedPoints(ilinearRing_0.Coordinates));
		for (int i = 0; i < chains.Count; i++)
		{
			MonotoneChain monotoneChain = (MonotoneChain)chains[i];
			Envelope envelope = monotoneChain.Envelope;
			interval_0.Min = envelope.Minimum.Y;
			interval_0.Max = envelope.Maximum.Y;
			bintree_0.Insert(interval_0, monotoneChain);
		}
	}

	private static void smethod_0(IEnvelope ienvelope_0, MonotoneChainSelectAction monotoneChainSelectAction_0, MonotoneChain monotoneChain_0)
	{
		monotoneChain_0.Select(ienvelope_0, monotoneChainSelectAction_0);
	}

	private void method_1(Coordinate coordinate_0, ILineSegmentBase ilineSegmentBase_0)
	{
		Coordinate p = ilineSegmentBase_0.P0;
		Coordinate p2 = ilineSegmentBase_0.P1;
		double x = p.X - coordinate_0.X;
		double num = p.Y - coordinate_0.Y;
		double x2 = p2.X - coordinate_0.X;
		double num2 = p2.Y - coordinate_0.Y;
		if ((num > 0.0 && num2 <= 0.0) || (num2 > 0.0 && num <= 0.0))
		{
			double num3 = (double)RobustDeterminant.SignOfDet2X2(x, num, x2, num2) / (num2 - num);
			if (0.0 < num3)
			{
				int_0++;
			}
		}
	}

	static McPointInRing()
	{
		Class72.smethod_20();
	}
}
