using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Command_Core;
using Command.My;

namespace Command;

public class CommandSecondaryFormBase : CommandFormParent
{
	internal bool ApplyStoredPositionSettings;

	internal bool ApplyStoredSizeSettings;

	protected bool AutoFocusOnClick;

	public CommandSecondaryFormBase()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Activated += CommandSecondaryFormBase_Activated;
		((Form)this).FormClosing += new FormClosingEventHandler(CommandSecondaryFormBase_FormClosing);
		ApplyStoredPositionSettings = true;
		ApplyStoredSizeSettings = true;
		AutoFocusOnClick = true;
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
			if (!method_0(((Form)this).Location, ((Form)this).Size))
			{
				((Form)this).CenterToScreen();
			}
		}
	}

	private void CommandSecondaryFormBase_Activated(object sender, EventArgs e)
	{
		if (!Client.ShutdownInitiated)
		{
			((Form)this).Owner = (Form)(object)MyProject.Forms.MainForm;
		}
	}

	private bool method_0(Point point_0, Size size_0, double double_0 = 0.1)
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

	public Color GetComponentDamageBackColor(PlatformComponent theComp)
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
			return Color.Red;
		}
		if ((object)theComp.GetType() == typeof(AirFacility))
		{
			AirFacility airFacility = (AirFacility)theComp;
			if (airFacility.MaxAircraftSize > airFacility.EffectiveRunwaySize)
			{
				return Color.Yellow;
			}
		}
		return Color.White;
	}

	private void CommandSecondaryFormBase_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	protected override void WndProc(ref Message m)
	{
		if (AutoFocusOnClick && !((Control)this).Focused && ((Message)(ref m)).Msg == 528)
		{
			switch ((int)(0xFFFFL & (long)((Message)(ref m)).WParam))
			{
			case 513:
			case 516:
			case 519:
			case 523:
			case 582:
				((Form)this).Activate();
				break;
			}
		}
		((Form)this).WndProc(ref m);
	}

	private void method_1()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CommandSecondaryFormBase));
		((Control)this).SuspendLayout();
		((Form)this).ClientSize = new Size(284, 261);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "CommandSecondaryFormBase";
		((Control)this).ResumeLayout(false);
	}

	static CommandSecondaryFormBase()
	{
		Class72.smethod_20();
	}
}
