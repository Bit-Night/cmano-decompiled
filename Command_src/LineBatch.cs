using System;
using DirectN;

public class LineBatch : IDisposable
{
	private readonly IComObject<ID2D1PathGeometry> icomObject_0;

	private IComObject<ID2D1SimplifiedGeometrySink> icomObject_1;

	private readonly float float_0;

	private bool bool_0;

	private ID2D1SimplifiedGeometrySink id2D1SimplifiedGeometrySink_0;

	public LineBatch(ID2D1Factory factory, float offsetY)
	{
		factory.CreatePathGeometry(out var pathGeometry);
		icomObject_0 = new ComObject<ID2D1PathGeometry>(pathGeometry);
		icomObject_1 = icomObject_0.Object.Open();
		id2D1SimplifiedGeometrySink_0 = icomObject_1.Object;
		id2D1SimplifiedGeometrySink_0.SetFillMode(D2D1_FILL_MODE.D2D1_FILL_MODE_ALTERNATE);
	}

	public void Add(float x1, float y1, float x2, float y2)
	{
		if (bool_0)
		{
			throw new InvalidOperationException("Error (LineBatch)");
		}
		D2D_POINT_2F startPoint = new D2D_POINT_2F(x1, y1 + float_0);
		D2D_POINT_2F point = new D2D_POINT_2F(x2, y2 + float_0);
		id2D1SimplifiedGeometrySink_0.BeginFigure(startPoint, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_HOLLOW);
		id2D1SimplifiedGeometrySink_0.AddLine(point);
		id2D1SimplifiedGeometrySink_0.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_OPEN);
	}

	public void Close()
	{
		if (!bool_0)
		{
			id2D1SimplifiedGeometrySink_0.Close();
			icomObject_1.Dispose();
			icomObject_1 = null;
			bool_0 = true;
		}
	}

	public void Draw(ID2D1RenderTarget rt, ID2D1Brush brush, float thickness, ID2D1StrokeStyle strokeStyle)
	{
		if (!bool_0)
		{
			Close();
		}
		rt.DrawGeometry(icomObject_0.Object, brush, thickness, strokeStyle);
	}

	public void Dispose()
	{
		if (!bool_0)
		{
			Close();
		}
		icomObject_0.Dispose();
	}

	static LineBatch()
	{
		Class72.smethod_20();
	}
}
