namespace CSMaterial.ClipperLib;

internal class TEdge
{
	internal IntPoint Bot;

	internal IntPoint Curr;

	internal IntPoint Top;

	internal IntPoint Delta;

	internal double Dx;

	internal PolyType PolyTyp;

	internal EdgeSide Side;

	internal int WindDelta;

	internal int WindCnt;

	internal int WindCnt2;

	internal int OutIdx;

	internal TEdge Next;

	internal TEdge Prev;

	internal TEdge tedge_0;

	internal TEdge tedge_1;

	internal TEdge tedge_2;

	internal TEdge tedge_3;

	internal TEdge tedge_4;

	static TEdge()
	{
		Class72.smethod_20();
	}
}
