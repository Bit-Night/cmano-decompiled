using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSMaterial.Sonar;

public sealed class SonarRender
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct <>c__DisplayClass13_0
	{
		public SonarRender sonarRender_0;

		public double double_0;

		public double double_1;
	}

	public int SideGutter_px = 75;

	public int TopGutter_px = 75;

	public int Width_px;

	public int Height_px;

	public List<TerrainProfiler_Step> TerrainData = new List<TerrainProfiler_Step>();

	public WriteableBitmap SubjectABitmap;

	public WriteableBitmap SubjectBBitmap;

	public double LeftDepth_m;

	public double RightDepth_m;

	public double Dist_m;

	public double MaxHeight_m;

	public double MinHeight_m;

	public WriteableBitmap Bitmap;

	public void Render()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		<>c__DisplayClass13_0 <>c__DisplayClass13_0_ = default(<>c__DisplayClass13_0);
		<>c__DisplayClass13_0_.sonarRender_0 = this;
		WriteableBitmap bitmap = Bitmap;
		double num = Math.Max(0.0, MaxHeight_m);
		double num2 = Math.Min(0.0, MinHeight_m);
		<>c__DisplayClass13_0_.double_0 = num - num2;
		<>c__DisplayClass13_0_.double_1 = (<>c__DisplayClass13_0_.double_0 + (double)TopGutter_px) / (double)Height_px;
		bitmap.Clear(Colors.Black);
		for (int i = 0; i < TerrainData.Count; i++)
		{
			int num3 = i + SideGutter_px;
			bitmap.DrawLine(num3, 0, num3, method_0(0.0, ref <>c__DisplayClass13_0_), Colors.Aqua);
			bitmap.DrawLine(num3, method_0(0.0, ref <>c__DisplayClass13_0_), num3, Height_px, Colors.DarkBlue);
			bitmap.DrawLine(num3, method_0(TerrainData.ElementAt(i).Height, ref <>c__DisplayClass13_0_), num3, Height_px, Colors.RosyBrown);
			foreach (TerrainProfiler_Layer layer in TerrainData[i].Layers)
			{
				bitmap.DrawLine(num3, method_0(layer.Top_m, ref <>c__DisplayClass13_0_), num3, method_0(layer.Top_m - layer.Height_m, ref <>c__DisplayClass13_0_), layer.color);
			}
		}
	}

	[CompilerGenerated]
	private int method_0(double double_0, ref <>c__DisplayClass13_0 <>c__DisplayClass13_0_0)
	{
		double num = double_0 + (0.0 - MinHeight_m);
		return (int)((<>c__DisplayClass13_0_0.double_0 - num) / <>c__DisplayClass13_0_0.double_1) + TopGutter_px;
	}

	static SonarRender()
	{
		Class72.smethod_20();
	}
}
