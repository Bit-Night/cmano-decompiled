using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Command_Core;
using Command.My;
using Command.SmartAssembly.Attributes;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class ScenarioMinimapViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__11-0
	{
		public double $VB$Local_gw;

		public double $VB$Local_gh;

		public VB$AnonymousDelegate_2<object, object> $VB$Local_WrapAngle;

		public double $VB$Local_clat;

		public double $VB$Local_clon;

		public ScenarioMinimapViewModel $VB$Me;

		public _Closure$__11-0(_Closure$__11-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_gw = arg0.$VB$Local_gw;
				$VB$Local_gh = arg0.$VB$Local_gh;
				$VB$Local_WrapAngle = arg0.$VB$Local_WrapAngle;
				$VB$Local_clat = arg0.$VB$Local_clat;
				$VB$Local_clon = arg0.$VB$Local_clon;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_gw = ((FrameworkElement)$VB$Me.GridControl).ActualWidth;
			$VB$Local_gh = ((FrameworkElement)$VB$Me.GridControl).ActualHeight;
		}

		[SpecialName]
		internal Tuple<double, double> _Lambda$__3(ActiveUnit F)
		{
			return new Tuple<double, double>(Conversions.ToDouble($VB$Local_WrapAngle(F.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180 - $VB$Local_clat)), Conversions.ToDouble($VB$Local_WrapAngle(F.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180 - $VB$Local_clon)));
		}

		static _Closure$__11-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__26-0
	{
		public double $VB$Local_GridWidth;

		public double $VB$Local_GridHeight;

		public uint[] $VB$Local_PIXEL_terrain;

		public ScenarioMinimapViewModel $VB$Me;

		public _Closure$__26-0(_Closure$__26-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_GridWidth = arg0.$VB$Local_GridWidth;
				$VB$Local_GridHeight = arg0.$VB$Local_GridHeight;
				$VB$Local_PIXEL_terrain = arg0.$VB$Local_PIXEL_terrain;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			bool flag = false;
			if ($VB$Me.BITMAP_terrain != null)
			{
				if ((((BitmapSource)$VB$Me.BITMAP_terrain).Width != $VB$Local_GridWidth) | (((BitmapSource)$VB$Me.BITMAP_terrain).Height != $VB$Local_GridHeight))
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				$VB$Me.BITMAP_terrain = new WriteableBitmap((int)Math.Round($VB$Local_GridWidth), (int)Math.Round($VB$Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, (BitmapPalette)null);
			}
			$VB$Me.BITMAP_terrain.WritePixels(new Int32Rect(0, 0, (int)Math.Round($VB$Local_GridWidth), (int)Math.Round($VB$Local_GridHeight)), (Array)$VB$Local_PIXEL_terrain, (int)Math.Round($VB$Local_GridWidth * 4.0), 0);
		}

		static _Closure$__26-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__27-0
	{
		public double $VB$Local_GridWidth;

		public uint[] $VB$Local_PIXEL_units;

		public uint $VB$Local_alpha;

		public uint $VB$Local_red;

		public uint $VB$Local_green;

		public uint $VB$Local_blue;

		public double $VB$Local_GridHeight;

		public ScenarioMinimapViewModel $VB$Me;

		public _Closure$__27-0(_Closure$__27-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_GridWidth = arg0.$VB$Local_GridWidth;
				$VB$Local_PIXEL_units = arg0.$VB$Local_PIXEL_units;
				$VB$Local_alpha = arg0.$VB$Local_alpha;
				$VB$Local_red = arg0.$VB$Local_red;
				$VB$Local_green = arg0.$VB$Local_green;
				$VB$Local_blue = arg0.$VB$Local_blue;
				$VB$Local_GridHeight = arg0.$VB$Local_GridHeight;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(object xbar, object ybar, object PipSize)
		{
			object obj = default(object);
			object obj2 = default(object);
			if (!ForLoopControl.ForLoopInitObj(obj, Operators.NegateObject(PipSize), PipSize, (object)1, ref obj2, ref obj))
			{
				return;
			}
			object obj3 = default(object);
			object obj4 = default(object);
			do
			{
				if (!ForLoopControl.ForLoopInitObj(obj3, Operators.NegateObject(PipSize), PipSize, (object)1, ref obj4, ref obj3))
				{
					continue;
				}
				do
				{
					int num = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject((object)$VB$Local_GridWidth, Operators.AddObject(ybar, obj3)), Operators.AddObject(xbar, obj)));
					if (num >= 0 && num < $VB$Local_PIXEL_units.Count())
					{
						if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(obj3, Operators.NegateObject(PipSize), true), Operators.CompareObjectEqual(obj3, PipSize, true)), Operators.CompareObjectEqual(obj, Operators.NegateObject(PipSize), true)), Operators.CompareObjectEqual(obj, PipSize, true))))
						{
							$VB$Local_PIXEL_units[num] = (uint)((long)($VB$Local_alpha << 24) + 16711680L + 65280L + 255L);
						}
						else
						{
							$VB$Local_PIXEL_units[num] = ($VB$Local_alpha << 24) + ($VB$Local_red << 16) + ($VB$Local_green << 8) + $VB$Local_blue;
						}
					}
				}
				while (ForLoopControl.ForNextCheckObj(obj3, obj4, ref obj3));
			}
			while (ForLoopControl.ForNextCheckObj(obj, obj2, ref obj));
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			try
			{
				bool flag = false;
				if ($VB$Me.BITMAP_units != null)
				{
					if ((((BitmapSource)$VB$Me.BITMAP_units).Width != $VB$Local_GridWidth) | (((BitmapSource)$VB$Me.BITMAP_units).Height != $VB$Local_GridHeight))
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					$VB$Me.BITMAP_units = new WriteableBitmap((int)Math.Round($VB$Local_GridWidth), (int)Math.Round($VB$Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, (BitmapPalette)null);
				}
				$VB$Me.BITMAP_units.WritePixels(new Int32Rect(0, 0, (int)Math.Round($VB$Local_GridWidth), (int)Math.Round($VB$Local_GridHeight)), (Array)$VB$Local_PIXEL_units, (int)Math.Round($VB$Local_GridWidth * 4.0), 0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		static _Closure$__27-0()
		{
			Class72.smethod_20();
		}
	}

	private WriteableBitmap writeableBitmap_0;

	private WriteableBitmap writeableBitmap_1;

	public Dispatcher Dispatcher;

	public Grid GridControl;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	private double double_9;

	private double double_10;

	private double double_11;

	private double double_12;

	private double double_13;

	public WriteableBitmap BITMAP_terrain
	{
		get
		{
			return writeableBitmap_0;
		}
		set
		{
			SetProperty(ref writeableBitmap_0, value, "BITMAP_terrain");
		}
	}

	public WriteableBitmap BITMAP_units
	{
		get
		{
			return writeableBitmap_1;
		}
		set
		{
			SetProperty(ref writeableBitmap_1, value, "BITMAP_units");
		}
	}

	public ScenarioMinimapViewModel()
	{
		double_0 = 0.0;
		double_1 = 0.0;
		double_2 = 0.0;
		double_3 = 0.0;
		double_4 = 0.0;
		double_5 = 0.0;
		double_6 = 0.0;
		double_7 = 0.0;
		double_8 = 0.0;
		double_9 = 0.0;
		double_10 = 0.0;
		double_11 = 0.0;
		double_12 = 0.0;
		double_13 = 0.0;
	}

	private bool method_0(ref double double_14, ref double double_15, ref double double_16, ref double double_17, ref double double_18, ref double double_19, ref double double_20, ref double double_21, ref double double_22, ref double double_23)
	{
		_Closure$__11-0 arg = default(_Closure$__11-0);
		_Closure$__11-0 CS$<>8__locals16 = new _Closure$__11-0(arg);
		CS$<>8__locals16.$VB$Me = this;
		double_18 = double.MaxValue;
		double_19 = double.MinValue;
		double_20 = double.MaxValue;
		double_21 = double.MinValue;
		CS$<>8__locals16.$VB$Local_gw = 0.0;
		CS$<>8__locals16.$VB$Local_gh = 0.0;
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			CS$<>8__locals16.$VB$Local_gw = ((FrameworkElement)CS$<>8__locals16.$VB$Me.GridControl).ActualWidth;
			CS$<>8__locals16.$VB$Local_gh = ((FrameworkElement)CS$<>8__locals16.$VB$Me.GridControl).ActualHeight;
		}));
		double_15 = CS$<>8__locals16.$VB$Local_gw;
		double_14 = CS$<>8__locals16.$VB$Local_gh;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		List<ActiveUnit> list = Client.CurrentScenario.ActiveUnits_List.Where([SpecialName] (ActiveUnit F) => !F.IsSatellite).ToList();
		if (list.Count < 2)
		{
			return false;
		}
		double num4 = 1.0 / (double)list.Count;
		foreach (ActiveUnit item in list)
		{
			double num5 = 1.0 * Math.Cos(item.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180) * Math.Cos(item.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180);
			double num6 = 1.0 * Math.Sin(item.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180) * Math.Cos(item.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180);
			double num7 = 1.0 * Math.Sin(item.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180);
			num += num5 * num4;
			num2 += num6 * num4;
			num3 += num7 * num4;
		}
		CS$<>8__locals16.$VB$Local_WrapAngle = [SpecialName] (object Theta) =>
		{
			while (Operators.ConditionalCompareObjectGreater(Theta, (object)Math.PI, true))
			{
				Theta = Operators.SubtractObject(Theta, (object)(Math.PI * 2.0));
			}
			while (Operators.ConditionalCompareObjectLess(Theta, (object)(-Math.PI), true))
			{
				Theta = Operators.AddObject(Theta, (object)(Math.PI * 2.0));
			}
			return Theta;
		};
		double_17 = Math.Atan2(num2, num);
		double_16 = Math.PI / 2.0 - Math.Acos(num3);
		double_18 = double.MaxValue;
		double_19 = double.MinValue;
		double_20 = double.MaxValue;
		double_21 = double.MinValue;
		CS$<>8__locals16.$VB$Local_clat = double_16;
		CS$<>8__locals16.$VB$Local_clon = double_17;
		List<Tuple<double, double>> list2 = list.Select([SpecialName] (ActiveUnit F) => new Tuple<double, double>(Conversions.ToDouble(CS$<>8__locals16.$VB$Local_WrapAngle(F.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180 - CS$<>8__locals16.$VB$Local_clat)), Conversions.ToDouble(CS$<>8__locals16.$VB$Local_WrapAngle(F.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180 - CS$<>8__locals16.$VB$Local_clon)))).ToList();
		foreach (Tuple<double, double> item2 in list2)
		{
			double_18 = Math.Min(double_18, item2.Item1);
			double_19 = Math.Max(double_19, item2.Item1);
			double_20 = Math.Min(double_20, item2.Item2);
			double_21 = Math.Max(double_21, item2.Item2);
		}
		double num8 = double_19 - double_18;
		double num9 = double_21 - double_20;
		double_18 -= num8 * 0.1;
		double_19 += num8 * 0.1;
		double_20 -= num9 * 0.1;
		double_21 += num9 * 0.1;
		double_22 = double_19 - double_18;
		double_23 = double_21 - double_20;
		double_0 = double_18;
		double_1 = double_20;
		double_2 = double_15;
		double_3 = double_14;
		double_4 = double_22;
		double_5 = double_23;
		double_6 = double_16;
		double_7 = double_17;
		return true;
	}

	public void UpdateTerrain()
	{
		_Closure$__26-0 arg = default(_Closure$__26-0);
		_Closure$__26-0 CS$<>8__locals32 = new _Closure$__26-0(arg);
		CS$<>8__locals32.$VB$Me = this;
		CS$<>8__locals32.$VB$Local_GridWidth = 0.0;
		CS$<>8__locals32.$VB$Local_GridHeight = 0.0;
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		double double_5 = default(double);
		double double_6 = default(double);
		double double_7 = default(double);
		double double_8 = default(double);
		if (!method_0(ref CS$<>8__locals32.$VB$Local_GridHeight, ref CS$<>8__locals32.$VB$Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2) || (this.double_8 == double_5 && double_9 == double_7 && double_10 == CS$<>8__locals32.$VB$Local_GridWidth && double_11 == CS$<>8__locals32.$VB$Local_GridHeight && double_12 == double_ && double_13 == double_2))
		{
			return;
		}
		this.double_8 = double_5;
		double_9 = double_7;
		double_10 = CS$<>8__locals32.$VB$Local_GridWidth;
		double_11 = CS$<>8__locals32.$VB$Local_GridHeight;
		double_12 = double_;
		double_13 = double_2;
		CS$<>8__locals32.$VB$Local_PIXEL_terrain = new uint[(int)Math.Round(CS$<>8__locals32.$VB$Local_GridHeight * CS$<>8__locals32.$VB$Local_GridWidth) + 1];
		uint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		int num4 = (int)Math.Round(CS$<>8__locals32.$VB$Local_GridWidth - 1.0);
		string htmlColor = default(string);
		for (int i = 0; i <= num4; i++)
		{
			Thread.Sleep(1);
			int num5 = (int)Math.Round(CS$<>8__locals32.$VB$Local_GridHeight - 1.0);
			for (int j = 0; j <= num5; j++)
			{
				int num6 = (int)Math.Round(CS$<>8__locals32.$VB$Local_GridWidth * (double)j + (double)i);
				double num7 = double_5 + (CS$<>8__locals32.$VB$Local_GridHeight - (double)j) * (double_ / CS$<>8__locals32.$VB$Local_GridHeight);
				double num8 = double_7 + (double)i * (double_2 / CS$<>8__locals32.$VB$Local_GridWidth);
				double num9 = num7 + double_4;
				double num10 = num8 + double_3;
				double num11 = num9 * 180.0 / Math.PI;
				double num12 = num10 * 180.0 / Math.PI;
				(bool IsOverland, short? RetrievedElevation) tuple = Terrain.PointIsOverland(Math2.NormalizeLatitude(num11), Math2.NormalizeLongitude(num12));
				num = 0u;
				num2 = 0u;
				num3 = 0u;
				if (!tuple.IsOverland)
				{
					num3 = 64u;
				}
				else
				{
					num2 = 64u;
				}
				switch (LandCover.GetLandCoverAtThisPoint(num11, num12, Client.CurrentScenario))
				{
				case LandCover.LandCoverType.Urban_CloseInnerCity:
				case LandCover.LandCoverType.Urban_SpacedHighRise:
				case LandCover.LandCoverType.Urban_AttachedHouses:
				case LandCover.LandCoverType.Urban_CloseIndustrial:
				case LandCover.LandCoverType.Urban_SpacedApartments:
				case LandCover.LandCoverType.Urban_DetachedHouses:
				case LandCover.LandCoverType.Urban_SpacedIndustrial:
				case LandCover.LandCoverType.Urban_ShantyTown:
					htmlColor = "#f00000";
					break;
				case LandCover.LandCoverType.Water:
					htmlColor = "#10203b";
					break;
				case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					htmlColor = "#0a6305";
					break;
				case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					htmlColor = "#027702";
					break;
				case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					htmlColor = "#38c414";
					break;
				case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					htmlColor = "#008805";
					break;
				case LandCover.LandCoverType.Mixed_forest:
					htmlColor = "#00ea00";
					break;
				case LandCover.LandCoverType.Closed_shrublands:
					htmlColor = "#4c4610";
					break;
				case LandCover.LandCoverType.Open_shrublands:
					htmlColor = "#ccbd2e";
					break;
				case LandCover.LandCoverType.Woody_savannas:
					htmlColor = "#deb416";
					break;
				case LandCover.LandCoverType.Savannas:
					htmlColor = "#ecba47";
					break;
				case LandCover.LandCoverType.Grasslands:
					htmlColor = "#82420b";
					break;
				case LandCover.LandCoverType.Permanent_wetlands:
					htmlColor = "#445e5f";
					break;
				case LandCover.LandCoverType.Croplands:
					htmlColor = "#cfb324";
					break;
				case LandCover.LandCoverType.UrbanAndBuiltUp:
					htmlColor = "#f00000";
					break;
				case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
					htmlColor = "#f0bba6";
					break;
				case LandCover.LandCoverType.SnowAndIce:
					htmlColor = "#efeef1";
					break;
				case LandCover.LandCoverType.BarrenOrSparselyVegetated:
					htmlColor = "#efcaa4";
					break;
				}
				Color color = ColorTranslator.FromHtml(htmlColor);
				num = color.R;
				num2 = color.G;
				num3 = color.B;
				CS$<>8__locals32.$VB$Local_PIXEL_terrain[num6] = (uint)(-1358954496 + (int)(num << 16) + (int)(num2 << 8)) + num3;
			}
		}
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			bool flag = false;
			if (CS$<>8__locals32.$VB$Me.BITMAP_terrain != null)
			{
				if ((((BitmapSource)CS$<>8__locals32.$VB$Me.BITMAP_terrain).Width != CS$<>8__locals32.$VB$Local_GridWidth) | (((BitmapSource)CS$<>8__locals32.$VB$Me.BITMAP_terrain).Height != CS$<>8__locals32.$VB$Local_GridHeight))
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				CS$<>8__locals32.$VB$Me.BITMAP_terrain = new WriteableBitmap((int)Math.Round(CS$<>8__locals32.$VB$Local_GridWidth), (int)Math.Round(CS$<>8__locals32.$VB$Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, (BitmapPalette)null);
			}
			CS$<>8__locals32.$VB$Me.BITMAP_terrain.WritePixels(new Int32Rect(0, 0, (int)Math.Round(CS$<>8__locals32.$VB$Local_GridWidth), (int)Math.Round(CS$<>8__locals32.$VB$Local_GridHeight)), (Array)CS$<>8__locals32.$VB$Local_PIXEL_terrain, (int)Math.Round(CS$<>8__locals32.$VB$Local_GridWidth * 4.0), 0);
		}));
	}

	public void UpdateUnits()
	{
		_Closure$__27-0 arg = default(_Closure$__27-0);
		_Closure$__27-0 CS$<>8__locals61 = new _Closure$__27-0(arg);
		CS$<>8__locals61.$VB$Me = this;
		CS$<>8__locals61.$VB$Local_GridWidth = 0.0;
		CS$<>8__locals61.$VB$Local_GridHeight = 0.0;
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		double double_5 = default(double);
		double double_6 = default(double);
		double double_7 = default(double);
		double double_8 = default(double);
		if (!method_0(ref CS$<>8__locals61.$VB$Local_GridHeight, ref CS$<>8__locals61.$VB$Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2))
		{
			return;
		}
		CS$<>8__locals61.$VB$Local_PIXEL_units = new uint[(int)Math.Round(CS$<>8__locals61.$VB$Local_GridHeight * CS$<>8__locals61.$VB$Local_GridWidth) + 1];
		CS$<>8__locals61.$VB$Local_alpha = 0u;
		CS$<>8__locals61.$VB$Local_red = 0u;
		CS$<>8__locals61.$VB$Local_green = 0u;
		CS$<>8__locals61.$VB$Local_blue = 0u;
		VB$AnonymousDelegate_3<object, object, object> vB$AnonymousDelegate_ = [SpecialName] (object xbar, object ybar, object PipSize) =>
		{
			object obj = default(object);
			object obj2 = default(object);
			if (ForLoopControl.ForLoopInitObj(obj, Operators.NegateObject(PipSize), PipSize, (object)1, ref obj2, ref obj))
			{
				object obj3 = default(object);
				object obj4 = default(object);
				do
				{
					if (ForLoopControl.ForLoopInitObj(obj3, Operators.NegateObject(PipSize), PipSize, (object)1, ref obj4, ref obj3))
					{
						do
						{
							int num14 = Conversions.ToInteger(Operators.AddObject(Operators.MultiplyObject((object)CS$<>8__locals61.$VB$Local_GridWidth, Operators.AddObject(ybar, obj3)), Operators.AddObject(xbar, obj)));
							if (num14 >= 0 && num14 < CS$<>8__locals61.$VB$Local_PIXEL_units.Count())
							{
								if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(obj3, Operators.NegateObject(PipSize), true), Operators.CompareObjectEqual(obj3, PipSize, true)), Operators.CompareObjectEqual(obj, Operators.NegateObject(PipSize), true)), Operators.CompareObjectEqual(obj, PipSize, true))))
								{
									CS$<>8__locals61.$VB$Local_PIXEL_units[num14] = (uint)((long)(CS$<>8__locals61.$VB$Local_alpha << 24) + 16711680L + 65280L + 255L);
								}
								else
								{
									CS$<>8__locals61.$VB$Local_PIXEL_units[num14] = (CS$<>8__locals61.$VB$Local_alpha << 24) + (CS$<>8__locals61.$VB$Local_red << 16) + (CS$<>8__locals61.$VB$Local_green << 8) + CS$<>8__locals61.$VB$Local_blue;
								}
							}
						}
						while (ForLoopControl.ForNextCheckObj(obj3, obj4, ref obj3));
					}
				}
				while (ForLoopControl.ForNextCheckObj(obj, obj2, ref obj));
			}
		};
		foreach (ActiveUnit item in Client.CurrentSide.Units.ToList())
		{
			Thread.Sleep(1);
			if (item != null)
			{
				double num = item.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180;
				double num2 = item.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180;
				double a = (0.0 - (num - double_4 - double_5) * CS$<>8__locals61.$VB$Local_GridHeight) / double_ + CS$<>8__locals61.$VB$Local_GridHeight;
				double a2 = (num2 - double_3 - double_7) * (CS$<>8__locals61.$VB$Local_GridWidth / double_2);
				int num3 = (int)Math.Round(a);
				int num4 = (int)Math.Round(a2);
				CS$<>8__locals61.$VB$Local_red = 0u;
				CS$<>8__locals61.$VB$Local_green = 0u;
				CS$<>8__locals61.$VB$Local_blue = 255u;
				CS$<>8__locals61.$VB$Local_alpha = 255u;
				vB$AnonymousDelegate_(num4, num3, 4);
			}
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side == Client.CurrentSide || !Module_Side.IsAlliedWithThisSide(side, Client.CurrentSide) || !Module_Side.IsAlliedWithThisSide(Client.CurrentSide, side))
			{
				continue;
			}
			Thread.Sleep(1);
			foreach (ActiveUnit unit in side.Units)
			{
				Thread.Sleep(1);
				double num6 = unit.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180;
				double num7 = unit.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180;
				double a3 = (0.0 - (num6 - double_4 - double_5) * CS$<>8__locals61.$VB$Local_GridHeight) / double_ + CS$<>8__locals61.$VB$Local_GridHeight;
				double a4 = (num7 - double_3 - double_7) * (CS$<>8__locals61.$VB$Local_GridWidth / double_2);
				int num8 = (int)Math.Round(a3);
				int num9 = (int)Math.Round(a4);
				CS$<>8__locals61.$VB$Local_red = 0u;
				CS$<>8__locals61.$VB$Local_green = 0u;
				CS$<>8__locals61.$VB$Local_blue = 255u;
				CS$<>8__locals61.$VB$Local_alpha = 255u;
				vB$AnonymousDelegate_(num9, num8, 4);
			}
		}
		foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
		{
			Thread.Sleep(1);
			Color color = Client.get_ColorFromStance(contacts_.get_Stance(Client.CurrentSide));
			double num10 = ((Module_Unit.Unit)contacts_).get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180;
			double num11 = ((Module_Unit.Unit)contacts_).get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180;
			double a5 = (0.0 - (num10 - double_4 - double_5) * CS$<>8__locals61.$VB$Local_GridHeight) / double_ + CS$<>8__locals61.$VB$Local_GridHeight;
			double a6 = (num11 - double_3 - double_7) * (CS$<>8__locals61.$VB$Local_GridWidth / double_2);
			int num12 = (int)Math.Round(a5);
			int num13 = (int)Math.Round(a6);
			if (!(color == Client.Color_Hostile))
			{
				if (!(color == Client.Color_Friendly))
				{
					CS$<>8__locals61.$VB$Local_red = color.R;
					CS$<>8__locals61.$VB$Local_green = color.G;
					CS$<>8__locals61.$VB$Local_blue = color.B;
				}
				else
				{
					CS$<>8__locals61.$VB$Local_red = 0u;
					CS$<>8__locals61.$VB$Local_green = 0u;
					CS$<>8__locals61.$VB$Local_blue = 255u;
				}
			}
			else
			{
				CS$<>8__locals61.$VB$Local_red = 255u;
				CS$<>8__locals61.$VB$Local_green = 0u;
				CS$<>8__locals61.$VB$Local_blue = 0u;
			}
			CS$<>8__locals61.$VB$Local_alpha = 255u;
			vB$AnonymousDelegate_(num13, num12, 4);
		}
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			try
			{
				bool flag = false;
				if (CS$<>8__locals61.$VB$Me.BITMAP_units != null)
				{
					if ((((BitmapSource)CS$<>8__locals61.$VB$Me.BITMAP_units).Width != CS$<>8__locals61.$VB$Local_GridWidth) | (((BitmapSource)CS$<>8__locals61.$VB$Me.BITMAP_units).Height != CS$<>8__locals61.$VB$Local_GridHeight))
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					CS$<>8__locals61.$VB$Me.BITMAP_units = new WriteableBitmap((int)Math.Round(CS$<>8__locals61.$VB$Local_GridWidth), (int)Math.Round(CS$<>8__locals61.$VB$Local_GridHeight), 96.0, 96.0, PixelFormats.Bgra32, (BitmapPalette)null);
				}
				CS$<>8__locals61.$VB$Me.BITMAP_units.WritePixels(new Int32Rect(0, 0, (int)Math.Round(CS$<>8__locals61.$VB$Local_GridWidth), (int)Math.Round(CS$<>8__locals61.$VB$Local_GridHeight)), (Array)CS$<>8__locals61.$VB$Local_PIXEL_units, (int)Math.Round(CS$<>8__locals61.$VB$Local_GridWidth * 4.0), 0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}));
	}

	public void PanMapToPixel(int xprime, int yprime)
	{
		double num = double_0 + (double_3 - (double)yprime) * (double_4 / double_3);
		double num2 = double_1 + (double)xprime * (double_5 / double_2);
		double num3 = num + double_6;
		double num4 = num2 + double_7;
		double theLat = num3 * 180.0 / Math.PI;
		double theLon = num4 * 180.0 / Math.PI;
		MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(theLon, theLat));
	}

	static ScenarioMinimapViewModel()
	{
		Class72.smethod_20();
	}
}
