using System;
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
[DoNotPruneType]
[DoNotPrune]
public sealed class CameraFollowingMinimapViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__11-0
	{
		public double $VB$Local_gw;

		public double $VB$Local_gh;

		public double $VB$Local_MainFormLat;

		public double $VB$Local_MainFormLon;

		public double $VB$Local_MainFormAlt;

		public Geopoint_Struct $VB$Local_UpperLeftCorner;

		public CameraFollowingMinimapViewModel $VB$Me;

		public _Closure$__11-0(_Closure$__11-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_gw = arg0.$VB$Local_gw;
				$VB$Local_gh = arg0.$VB$Local_gh;
				$VB$Local_MainFormLat = arg0.$VB$Local_MainFormLat;
				$VB$Local_MainFormLon = arg0.$VB$Local_MainFormLon;
				$VB$Local_MainFormAlt = arg0.$VB$Local_MainFormAlt;
				$VB$Local_UpperLeftCorner = arg0.$VB$Local_UpperLeftCorner;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_gw = ((FrameworkElement)$VB$Me.GridControl).ActualWidth;
			$VB$Local_gh = ((FrameworkElement)$VB$Me.GridControl).ActualHeight;
			GeoPoint geoPoint = MyProject.Forms.MainForm.get_MapCenter(MustRender: false);
			$VB$Local_MainFormLat = geoPoint.Latitude * CSMath.PI_dividedBy_180;
			$VB$Local_MainFormLon = geoPoint.Longitude * CSMath.PI_dividedBy_180;
			$VB$Local_MainFormAlt = MyProject.Forms.MainForm.CameraAltitude;
		}

		[SpecialName]
		internal void _Lambda$__2()
		{
			$VB$Local_UpperLeftCorner = WWC.WWC_ScreenToWorld_Struct(MyProject.Forms.MainForm.WorldWindow1, 0, 0);
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

		public CameraFollowingMinimapViewModel $VB$Me;

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
			if ($VB$Me.BITMAP_terrain == null)
			{
				flag = true;
			}
			else if ((((BitmapSource)$VB$Me.BITMAP_terrain).Width != $VB$Local_GridWidth) | (((BitmapSource)$VB$Me.BITMAP_terrain).Height != $VB$Local_GridHeight))
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
	internal sealed class _Closure$__28-0
	{
		public double $VB$Local_GridWidth;

		public uint[] $VB$Local_PIXEL_units;

		public uint $VB$Local_alpha;

		public uint $VB$Local_red;

		public uint $VB$Local_green;

		public uint $VB$Local_blue;

		public double $VB$Local_GridHeight;

		public CameraFollowingMinimapViewModel $VB$Me;

		public _Closure$__28-0(_Closure$__28-0 arg0)
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
						if (!Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(obj3, Operators.NegateObject(PipSize), true), Operators.CompareObjectEqual(obj3, PipSize, true)), Operators.CompareObjectEqual(obj, Operators.NegateObject(PipSize), true)), Operators.CompareObjectEqual(obj, PipSize, true))))
						{
							$VB$Local_PIXEL_units[num] = ($VB$Local_alpha << 24) + ($VB$Local_red << 16) + ($VB$Local_green << 8) + $VB$Local_blue;
						}
						else
						{
							$VB$Local_PIXEL_units[num] = (uint)((long)($VB$Local_alpha << 24) + 16711680L + 65280L + 255L);
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
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
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

		static _Closure$__28-0()
		{
			Class72.smethod_20();
		}
	}

	private WriteableBitmap writeableBitmap_0;

	private WriteableBitmap writeableBitmap_1;

	public Dispatcher Dispatcher;

	public Grid GridControl;

	private double ulxHeecRdlr;

	private double double_0;

	private double double_1;

	private double iqnHeGaFcdN;

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

	public CameraFollowingMinimapViewModel()
	{
		ulxHeecRdlr = 0.0;
		double_0 = 0.0;
		double_1 = 0.0;
		iqnHeGaFcdN = 0.0;
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
	}

	private bool method_0(ref double double_12, ref double double_13, ref double double_14, ref double double_15, ref double double_16, ref double double_17, ref double double_18, ref double double_19, ref double double_20, ref double double_21)
	{
		_Closure$__11-0 arg = default(_Closure$__11-0);
		_Closure$__11-0 CS$<>8__locals22 = new _Closure$__11-0(arg);
		CS$<>8__locals22.$VB$Me = this;
		CS$<>8__locals22.$VB$Local_gw = 0.0;
		CS$<>8__locals22.$VB$Local_gh = 0.0;
		CS$<>8__locals22.$VB$Local_MainFormLat = 0.0;
		CS$<>8__locals22.$VB$Local_MainFormLon = 0.0;
		CS$<>8__locals22.$VB$Local_MainFormAlt = 0.0;
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			CS$<>8__locals22.$VB$Local_gw = ((FrameworkElement)CS$<>8__locals22.$VB$Me.GridControl).ActualWidth;
			CS$<>8__locals22.$VB$Local_gh = ((FrameworkElement)CS$<>8__locals22.$VB$Me.GridControl).ActualHeight;
			GeoPoint geoPoint = MyProject.Forms.MainForm.get_MapCenter(MustRender: false);
			CS$<>8__locals22.$VB$Local_MainFormLat = geoPoint.Latitude * CSMath.PI_dividedBy_180;
			CS$<>8__locals22.$VB$Local_MainFormLon = geoPoint.Longitude * CSMath.PI_dividedBy_180;
			CS$<>8__locals22.$VB$Local_MainFormAlt = MyProject.Forms.MainForm.CameraAltitude;
		}));
		double_13 = CS$<>8__locals22.$VB$Local_gw;
		double_12 = CS$<>8__locals22.$VB$Local_gh;
		VB$AnonymousDelegate_2<object, object> vB$AnonymousDelegate_ = [SpecialName] (object Theta) =>
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
		double_14 = Conversions.ToDouble(vB$AnonymousDelegate_(CS$<>8__locals22.$VB$Local_MainFormLat));
		double_15 = Conversions.ToDouble(vB$AnonymousDelegate_(CS$<>8__locals22.$VB$Local_MainFormLon));
		Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			CS$<>8__locals22.$VB$Local_UpperLeftCorner = WWC.WWC_ScreenToWorld_Struct(MyProject.Forms.MainForm.WorldWindow1, 0, 0);
		}));
		if (CS$<>8__locals22.$VB$Local_UpperLeftCorner.Latitude != 0.0 && !double.IsNaN(CS$<>8__locals22.$VB$Local_UpperLeftCorner.Latitude))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(vB$AnonymousDelegate_(CS$<>8__locals22.$VB$Local_UpperLeftCorner.Latitude * CSMath.PI_dividedBy_180 - double_14));
			object objectValue2 = RuntimeHelpers.GetObjectValue(vB$AnonymousDelegate_(CS$<>8__locals22.$VB$Local_UpperLeftCorner.Longitude * CSMath.PI_dividedBy_180 - double_15));
			double_16 = Conversions.ToDouble(Operators.NegateObject(objectValue));
			double_18 = Conversions.ToDouble(objectValue2);
			double_17 = Conversions.ToDouble(objectValue);
			double_19 = Conversions.ToDouble(Operators.NegateObject(objectValue2));
			double_20 = double_17 - double_16;
			double_21 = double_19 - double_18;
			ulxHeecRdlr = double_16;
			double_0 = double_18;
			double_1 = double_13;
			iqnHeGaFcdN = double_12;
			double_2 = double_20;
			double_3 = double_21;
			double_4 = double_14;
			double_5 = double_15;
			return true;
		}
		return false;
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
		if (!method_0(ref CS$<>8__locals32.$VB$Local_GridHeight, ref CS$<>8__locals32.$VB$Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2) || (this.double_6 == double_5 && this.double_7 == double_7 && this.double_8 == CS$<>8__locals32.$VB$Local_GridWidth && double_9 == CS$<>8__locals32.$VB$Local_GridHeight && double_10 == double_ && double_11 == double_2))
		{
			return;
		}
		this.double_6 = double_5;
		this.double_7 = double_7;
		this.double_8 = CS$<>8__locals32.$VB$Local_GridWidth;
		double_9 = CS$<>8__locals32.$VB$Local_GridHeight;
		double_10 = double_;
		double_11 = double_2;
		CS$<>8__locals32.$VB$Local_PIXEL_terrain = new uint[(int)Math.Round(CS$<>8__locals32.$VB$Local_GridHeight * CS$<>8__locals32.$VB$Local_GridWidth) + 1];
		uint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		int num4 = (int)Math.Round(CS$<>8__locals32.$VB$Local_GridWidth - 1.0);
		string htmlColor = default(string);
		for (int i = 0; i <= num4; i++)
		{
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
				short elevation = Terrain.GetElevation(Math2.NormalizeLatitude(num11), Math2.NormalizeLongitude(num12), RequestIsFromGUI: false, Client.CurrentScenario);
				num = 0u;
				num2 = 0u;
				num3 = 0u;
				if (elevation > 0)
				{
					num2 = 64u;
				}
				else
				{
					num3 = 64u;
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
			if (CS$<>8__locals32.$VB$Me.BITMAP_terrain == null)
			{
				flag = true;
			}
			else if ((((BitmapSource)CS$<>8__locals32.$VB$Me.BITMAP_terrain).Width != CS$<>8__locals32.$VB$Local_GridWidth) | (((BitmapSource)CS$<>8__locals32.$VB$Me.BITMAP_terrain).Height != CS$<>8__locals32.$VB$Local_GridHeight))
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

	private bool method_1(double double_12, double double_13, double double_14, double double_15, double double_16, double double_17, double double_18, double double_19)
	{
		double num = double_12 - double_14;
		double num2 = double_13 - double_15;
		int result;
		if (!(num < double_16) && !(num > double_17) && !(num2 < double_18))
		{
			if (!(num2 > double_19))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void UpdateUnits()
	{
		_Closure$__28-0 arg = default(_Closure$__28-0);
		_Closure$__28-0 CS$<>8__locals61 = new _Closure$__28-0(arg);
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
		if (!method_0(ref CS$<>8__locals61.$VB$Local_GridHeight, ref CS$<>8__locals61.$VB$Local_GridWidth, ref double_4, ref double_3, ref double_5, ref double_6, ref double_7, ref double_8, ref double_, ref double_2) || Client.CurrentSide == null)
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
								if (!Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(obj3, Operators.NegateObject(PipSize), true), Operators.CompareObjectEqual(obj3, PipSize, true)), Operators.CompareObjectEqual(obj, Operators.NegateObject(PipSize), true)), Operators.CompareObjectEqual(obj, PipSize, true))))
								{
									CS$<>8__locals61.$VB$Local_PIXEL_units[num14] = (CS$<>8__locals61.$VB$Local_alpha << 24) + (CS$<>8__locals61.$VB$Local_red << 16) + (CS$<>8__locals61.$VB$Local_green << 8) + CS$<>8__locals61.$VB$Local_blue;
								}
								else
								{
									CS$<>8__locals61.$VB$Local_PIXEL_units[num14] = (uint)((long)(CS$<>8__locals61.$VB$Local_alpha << 24) + 16711680L + 65280L + 255L);
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
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
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
		}));
	}

	public void PanMapToPixel(int xprime, int yprime)
	{
		double num = ulxHeecRdlr + (iqnHeGaFcdN - (double)yprime) * (double_2 / iqnHeGaFcdN);
		double num2 = double_0 + (double)xprime * (double_3 / double_1);
		double num3 = num + double_4;
		double num4 = num2 + double_5;
		double theLat = num3 * 180.0 / Math.PI;
		double theLon = num4 * 180.0 / Math.PI;
		MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(theLon, theLat));
	}

	static CameraFollowingMinimapViewModel()
	{
		Class72.smethod_20();
	}
}
