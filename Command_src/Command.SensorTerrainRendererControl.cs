using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using CSMaterial;
using CSMaterial.Sonar;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Worldwind.Component;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
[DesignerGenerated]
public sealed class SensorTerrainRendererControl : UserControl, IComponentConnector
{
	public sealed class Subject
	{
		public Module_Unit.Unit Unit;

		public ReferencePoint RP;

		public GeoPoint Geopoint;

		public Subject(Module_Unit.Unit _Unit)
		{
			Unit = _Unit;
		}

		public Subject(ReferencePoint _RP)
		{
			RP = _RP;
		}

		public Subject(GeoPoint _Geopoint)
		{
			Geopoint = _Geopoint;
		}

		public string GetDisplayName()
		{
			if (!Information.IsNothing((object)Unit))
			{
				return Unit.Name;
			}
			if (Information.IsNothing((object)RP))
			{
				if (Information.IsNothing((object)Geopoint))
				{
					return "Error";
				}
				return "Lat : " + Geopoint.Latitude + " / Long :" + Geopoint.Longitude;
			}
			return RP.Name;
		}

		public Geopoint_Struct GetGeopoint()
		{
			Geopoint_Struct result;
			if (Unit == null)
			{
				if (RP == null)
				{
					if (Geopoint != null)
					{
						return Geopoint.ToGeopoint_Struct();
					}
					result = new Geopoint_Struct(0.0, 0.0);
				}
				else
				{
					result = new Geopoint_Struct(RP.Longitude, RP.Latitude, 0f);
				}
			}
			else
			{
				result = new Geopoint_Struct(Unit.get_Longitude((GlobalVariables.BooleanObject)null), Unit.get_Latitude((GlobalVariables.BooleanObject)null), Unit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			return result;
		}

		public bool IsValid()
		{
			if (Unit != null)
			{
				return true;
			}
			return false;
		}

		static Subject()
		{
			Class72.smethod_20();
		}
	}

	public Subject SubjectA;

	public Subject SubjectB;

	[CompilerGenerated]
	private WriteableBitmap writeableBitmap_0;

	[AccessedThroughProperty("DisplayStack")]
	[CompilerGenerated]
	private StackPanel stackPanel_0;

	private bool bool_0;

	public WriteableBitmap SonarBitmap
	{
		[CompilerGenerated]
		get
		{
			return writeableBitmap_0;
		}
		[CompilerGenerated]
		set
		{
			writeableBitmap_0 = value;
		}
	}

	internal virtual StackPanel DisplayStack
	{
		[CompilerGenerated]
		get
		{
			return stackPanel_0;
		}
		[CompilerGenerated]
		set
		{
			stackPanel_0 = value;
		}
	}

	public SensorTerrainRendererControl()
	{
		InitializeComponent();
		((FrameworkElement)this).DataContext = this;
	}

	public void Refresh(Subject A, Subject B, VerticalProfilerRenderer Renderer)
	{
		SubjectA = A;
		SubjectB = B;
		Refresh(Renderer);
	}

	public bool IsReadyToRender()
	{
		if ((SubjectA == null) | (SubjectB == null))
		{
			return false;
		}
		return SubjectA.IsValid() && SubjectB.IsValid();
	}

	private void Refresh(VerticalProfilerRenderer Renderer)
	{
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		if (!IsReadyToRender())
		{
			return;
		}
		SonarRender sonarRender = new SonarRender();
		sonarRender.SideGutter_px = 0;
		sonarRender.TopGutter_px = 0;
		sonarRender.Width_px = 1400;
		sonarRender.Height_px = 800;
		int num = sonarRender.Width_px - sonarRender.SideGutter_px * 2;
		Geopoint_Struct Point = SubjectA.GetGeopoint();
		Geopoint_Struct Point2 = SubjectB.GetGeopoint();
		MainForm mainForm = MyProject.Forms.MainForm;
		MainForm mainForm2 = MyProject.Forms.MainForm;
		Module_Unit.Unit unit = SubjectA.Unit;
		bool IconIsDirectional = false;
		bool IsCustomIcon = false;
		int CustomSize = -1;
		bool Rotatable = false;
		mainForm.GetIconPath(mainForm2.CL_GetUnitIcon(unit, ref IconIsDirectional, ref IsCustomIcon, ref CustomSize, ref Rotatable));
		try
		{
			PictureBox pictureSubjectA = Renderer.PictureSubjectA;
			MainForm mainForm3 = MyProject.Forms.MainForm;
			MainForm mainForm4 = MyProject.Forms.MainForm;
			Module_Unit.Unit unit2 = SubjectA.Unit;
			Rotatable = false;
			IsCustomIcon = false;
			CustomSize = -1;
			IconIsDirectional = false;
			pictureSubjectA.Image = Image.FromFile(mainForm3.GetIconPath(mainForm4.CL_GetUnitIcon(unit2, ref Rotatable, ref IsCustomIcon, ref CustomSize, ref IconIsDirectional)));
			PictureBox pictureBox = Renderer.PictureBox1;
			MainForm mainForm5 = MyProject.Forms.MainForm;
			MainForm mainForm6 = MyProject.Forms.MainForm;
			Module_Unit.Unit unit3 = SubjectB.Unit;
			IconIsDirectional = false;
			IsCustomIcon = false;
			CustomSize = -1;
			Rotatable = false;
			pictureBox.Image = Image.FromFile(mainForm5.GetIconPath(mainForm6.CL_GetUnitIcon(unit3, ref IconIsDirectional, ref IsCustomIcon, ref CustomSize, ref Rotatable)));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				ProjectData.ClearProjectError();
				return;
			}
			ProjectData.ClearProjectError();
		}
		sonarRender.LeftDepth_m = Point.Altitude;
		sonarRender.RightDepth_m = Point2.Altitude;
		sonarRender.Dist_m = (double)Math2.CalcDist(ref Point, ref Point2) * 1852.0;
		double lat = Point.Latitude * CSMath.PI_dividedBy_180;
		double lon = Point.Longitude * CSMath.PI_dividedBy_180;
		CustomSize = num;
		for (int i = 0; i <= CustomSize; i++)
		{
			Tuple<double, double> tuple = CommandLayer.UTIL_OrthodromicInterpolation(lat, lon, Point2.Latitude * CSMath.PI_dividedBy_180, Point2.Longitude * CSMath.PI_dividedBy_180, (double)i / (double)num);
			TerrainProfiler_Step terrainProfiler_Step = new TerrainProfiler_Step(Terrain.GetElevation(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, RequestIsFromGUI: true, Client.CurrentScenario));
			sonarRender.TerrainData.Add(terrainProfiler_Step);
			if (terrainProfiler_Step.Height > 0.0)
			{
				Color color_LandCoverType = LandCover.GetColor_LandCoverType(LandCover.GetLandCoverAtThisPoint(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, Client.CurrentScenario));
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(terrainProfiler_Step.Height, 400.0, Color.FromArgb(color_LandCoverType.A, color_LandCoverType.R, color_LandCoverType.G, color_LandCoverType.B)));
			}
			else
			{
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, 0, Client.CurrentScenario);
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(thermalLayerAtThisLocation.Ceiling, -thermalLayerAtThisLocation.Floor + thermalLayerAtThisLocation.Ceiling, Color.FromArgb(byte.MaxValue, (byte)(55 + (byte)Math.Round(thermalLayerAtThisLocation.Strength * 200f)), (byte)0, (byte)125)));
			}
			Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(Client.CurrentScenario, tuple.Item1 * 180.0 / Math.PI, tuple.Item2 * 180.0 / Math.PI, 0);
			double num2 = terrainProfiler_Step.Height;
			double num3 = terrainProfiler_Step.Height;
			if ((double)weatherProfile.CloudInfo.HighCloudTop_m > terrainProfiler_Step.Height)
			{
				num2 = weatherProfile.CloudInfo.HighCloudTop_m;
			}
			if ((double)weatherProfile.CloudInfo.HighCloudBase_m > terrainProfiler_Step.Height)
			{
				num3 = weatherProfile.CloudInfo.HighCloudBase_m;
			}
			if (num2 != terrainProfiler_Step.Height)
			{
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(num2, 0.0 - num3 + num2, Color.FromArgb((byte)185, (byte)245, (byte)245, (byte)245)));
			}
			num2 = terrainProfiler_Step.Height;
			num3 = terrainProfiler_Step.Height;
			if ((double)weatherProfile.CloudInfo.MiddleCloudTop_m > terrainProfiler_Step.Height)
			{
				num2 = weatherProfile.CloudInfo.MiddleCloudTop_m;
			}
			if ((double)weatherProfile.CloudInfo.MiddleCloudBase_m > terrainProfiler_Step.Height)
			{
				num3 = weatherProfile.CloudInfo.MiddleCloudBase_m;
			}
			if (num2 != terrainProfiler_Step.Height)
			{
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(num2, 0.0 - num3 + num2, Color.FromArgb((byte)185, (byte)245, (byte)245, (byte)245)));
			}
			num2 = terrainProfiler_Step.Height;
			num3 = terrainProfiler_Step.Height;
			if ((double)weatherProfile.CloudInfo.LowCloudTop_m > terrainProfiler_Step.Height)
			{
				num2 = weatherProfile.CloudInfo.LowCloudTop_m;
			}
			if ((double)weatherProfile.CloudInfo.LowCloudBase_m > terrainProfiler_Step.Height)
			{
				num3 = weatherProfile.CloudInfo.LowCloudBase_m;
			}
			if (num2 != terrainProfiler_Step.Height)
			{
				terrainProfiler_Step.Layers.Add(new TerrainProfiler_Layer(num2, 0.0 - num3 + num2, Color.FromArgb((byte)185, (byte)245, (byte)245, (byte)245)));
			}
			if (sonarRender.MaxHeight_m < terrainProfiler_Step.Height)
			{
				sonarRender.MaxHeight_m = terrainProfiler_Step.Height;
			}
			if (sonarRender.MinHeight_m > terrainProfiler_Step.Height)
			{
				sonarRender.MinHeight_m = terrainProfiler_Step.Height;
			}
		}
		sonarRender.MaxHeight_m = Math.Max(sonarRender.MaxHeight_m, Point.Altitude);
		sonarRender.MaxHeight_m = Math.Max(sonarRender.MaxHeight_m, Point2.Altitude);
		sonarRender.MinHeight_m = Math.Min(sonarRender.MinHeight_m, Point.Altitude);
		sonarRender.MinHeight_m = Math.Min(sonarRender.MinHeight_m, Point2.Altitude);
		Renderer.Label_BottomAltitude.Text = (int)Math.Round(sonarRender.MinHeight_m) + "m";
		Renderer.Label_TopAltitude.Text = (int)Math.Round(sonarRender.MaxHeight_m) + "m";
		sonarRender.Bitmap = new WriteableBitmap(sonarRender.Width_px, sonarRender.Height_px, 96.0, 96.0, PixelFormats.Bgra32, (BitmapPalette)null);
		SonarBitmap = sonarRender.Bitmap;
		sonarRender.Render();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/verticalprofiler/verticalprofilerenderercontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		if (connectionId == 1)
		{
			DisplayStack = (StackPanel)target;
		}
		else
		{
			bool_0 = true;
		}
	}

	static SensorTerrainRendererControl()
	{
		Class72.smethod_20();
	}
}
