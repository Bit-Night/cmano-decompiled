using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DarkSecondaryFormBase : CommandDarkFormParent
{
	public bool _IsDisposed;

	private IContainer icontainer_0;

	internal bool ApplyStoredPositionSettings;

	internal bool ApplyStoredSizeSettings;

	public DarkSecondaryFormBase()
	{
		((Form)this).Activated += DarkSecondaryFormBase_Activated;
		ApplyStoredPositionSettings = true;
		ApplyStoredSizeSettings = true;
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
			_IsDisposed = true;
		}
	}

	private void InitializeComponent()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DarkSecondaryFormBase));
		((Control)this).SuspendLayout();
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(284, 261);
		((Control)this).DoubleBuffered = true;
		((Control)this).Font = new Font("Segoe UI", 9f);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "DarkSecondaryFormBase";
		((Form)this).Text = "DarkSecondaryFormBase";
		((Control)this).ResumeLayout(false);
		WindowDarkMode.UseImmersiveDarkMode(((Control)this).Handle, enabled: true);
	}

	[DllImport("dwmapi.dll")]
	private static extern int DwmSetWindowAttribute(IntPtr intptr_0, int int_0, ref int int_1, int int_2);

	protected override void OnHandleCreated(EventArgs e)
	{
		((Form)this).OnHandleCreated(e);
		method_0();
	}

	private void method_0()
	{
		int int_ = 1;
		DwmSetWindowAttribute(((Control)this).Handle, 20, ref int_, 4);
		int int_2 = 1;
		DwmSetWindowAttribute(((Control)this).Handle, 33, ref int_2, 4);
		int int_3 = ColorTranslator.ToWin32(Color.FromArgb(45, 45, 48));
		DwmSetWindowAttribute(((Control)this).Handle, 35, ref int_3, 4);
	}

	protected override void OnMove(EventArgs e)
	{
		((Control)this).OnMove(e);
		if (((Control)this).Visible)
		{
			WindowPlacement.UpdateWindowPlacementSetting(((Control)this).Name, ((Form)this).Location.X, ((Form)this).Location.Y, ((Control)this).Width, ((Control)this).Height);
		}
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		((Control)this).OnSizeChanged(e);
		if (((Control)this).Visible)
		{
			WindowPlacement.UpdateWindowPlacementSetting(((Control)this).Name, ((Form)this).Location.X, ((Form)this).Location.Y, ((Control)this).Width, ((Control)this).Height);
		}
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		((Form)this).OnVisibleChanged(e);
		if (((Control)this).Visible)
		{
			WindowPlacement.GetWindowPlacementSetting(this);
			if (!method_1(((Form)this).Location, ((Form)this).Size))
			{
				((Form)this).CenterToScreen();
			}
		}
	}

	private bool method_1(Point point_0, Size size_0, double double_0 = 0.1)
	{
		double num = 0.0;
		Rectangle a = new Rectangle(point_0, size_0);
		Screen[] allScreens = Screen.AllScreens;
		foreach (Screen val in allScreens)
		{
			Rectangle rectangle = Rectangle.Intersect(a, val.WorkingArea);
			if ((rectangle.Width != 0) & (rectangle.Height != 0))
			{
				num += (double)(rectangle.Width * rectangle.Height);
			}
		}
		return num >= (double)(a.Width * a.Height) * double_0;
	}

	private void DarkSecondaryFormBase_Activated(object sender, EventArgs e)
	{
		if (!Client.ShutdownInitiated)
		{
			try
			{
				((Form)this).Owner = (Form)(object)MyProject.Forms.MainForm;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public Color GetComponentDamageColor(PlatformComponent theComp)
	{
		if (theComp.Status == PlatformComponent._ComponentStatus.Damaged)
		{
			switch (theComp.DamageSeverity)
			{
			case PlatformComponent._DamageSeverityFactor.Light:
				return Color.Yellow;
			case PlatformComponent._DamageSeverityFactor.Medium:
				return Color.Orange;
			case PlatformComponent._DamageSeverityFactor.Heavy:
				return Color.OrangeRed;
			}
		}
		if (theComp.Status == PlatformComponent._ComponentStatus.Destroyed)
		{
			return Color.IndianRed;
		}
		if ((object)theComp.GetType() == typeof(AirFacility))
		{
			AirFacility airFacility = (AirFacility)theComp;
			if (airFacility.MaxAircraftSize > airFacility.EffectiveRunwaySize)
			{
				return Color.Yellow;
			}
		}
		return Color.LightGray;
	}

	static DarkSecondaryFormBase()
	{
		Class72.smethod_20();
	}
}
