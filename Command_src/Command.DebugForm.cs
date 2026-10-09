using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Command.Tacview;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Worldwind.Component;

namespace Command;

[DesignerGenerated]
public sealed class DebugForm : Form
{
	[CompilerGenerated]
	internal sealed class _Closure$__43-0
	{
		public string $VB$Local_s;

		public DebugForm $VB$Me;

		public _Closure$__43-0(_Closure$__43-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_s = arg0.$VB$Local_s;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			((TextBoxBase)$VB$Me.TextBox1).AppendText($VB$Local_s);
		}

		static _Closure$__43-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button UvhcuCnlPd;

	[AccessedThroughProperty("CheckedListBox1")]
	[CompilerGenerated]
	private CheckedListBox _CheckedListBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private Button _Button3;

	private Dispatcher dispatcher_0;

	private ConcurrentQueue<string> concurrentQueue_0;

	private Thread thread_0;

	private bool bool_0;

	private bool bool_1;

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual TextBox TextBox1 { get; set; }

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = oYmcWsioWZ;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	[field: AccessedThroughProperty("TextBox2")]
	internal virtual TextBox TextBox2 { get; set; }

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return UvhcuCnlPd;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			Button val = UvhcuCnlPd;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			UvhcuCnlPd = value;
			val = UvhcuCnlPd;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckedListBox CheckedListBox1
	{
		[CompilerGenerated]
		get
		{
			return _CheckedListBox1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			ItemCheckEventHandler val = new ItemCheckEventHandler(method_1);
			CheckedListBox val2 = _CheckedListBox1;
			if (val2 != null)
			{
				val2.ItemCheck -= val;
			}
			_CheckedListBox1 = value;
			val2 = _CheckedListBox1;
			if (val2 != null)
			{
				val2.ItemCheck += val;
			}
		}
	}

	internal virtual Button Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			Button val = _Button2;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button2 = value;
			val = _Button2;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			Button val = _Button3;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button3 = value;
			val = _Button3;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public DebugForm()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(DebugForm_FormClosing);
		((Form)this).Load += DebugForm_Load;
		concurrentQueue_0 = new ConcurrentQueue<string>();
		bool_0 = false;
		bool_1 = false;
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
		}
	}

	private void InitializeComponent()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		icontainer_0 = new Container();
		TextBox1 = new TextBox();
		Timer1 = new Timer(icontainer_0);
		Label1 = new Label();
		TextBox2 = new TextBox();
		Button1 = new Button();
		CheckedListBox1 = new CheckedListBox();
		Button2 = new Button();
		Button3 = new Button();
		((Control)this).SuspendLayout();
		((Control)TextBox1).Anchor = (AnchorStyles)15;
		((Control)TextBox1).Location = new Point(12, 12);
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ScrollBars = (ScrollBars)2;
		((Control)TextBox1).Size = new Size(511, 725);
		((Control)TextBox1).TabIndex = 0;
		Timer1.Enabled = true;
		Timer1.Interval = 1000;
		((Control)Label1).Anchor = (AnchorStyles)9;
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(885, 12);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(37, 13);
		((Control)Label1).TabIndex = 1;
		Label1.Text = "Status";
		((Control)TextBox2).Anchor = (AnchorStyles)9;
		((Control)TextBox2).Location = new Point(884, 28);
		TextBox2.Multiline = true;
		((Control)TextBox2).Name = "TextBox2";
		((Control)TextBox2).Size = new Size(229, 652);
		((Control)TextBox2).TabIndex = 2;
		((Control)Button1).Anchor = (AnchorStyles)9;
		((Control)Button1).Location = new Point(888, 713);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 3;
		((ButtonBase)Button1).Text = "Reset DX";
		((ButtonBase)Button1).UseVisualStyleBackColor = true;
		((Control)CheckedListBox1).Anchor = (AnchorStyles)11;
		((ListBox)CheckedListBox1).ColumnWidth = 160;
		((ListControl)CheckedListBox1).FormattingEnabled = true;
		((Control)CheckedListBox1).Location = new Point(529, 12);
		((ListBox)CheckedListBox1).MultiColumn = true;
		((Control)CheckedListBox1).Name = "CheckedListBox1";
		((Control)CheckedListBox1).Size = new Size(349, 724);
		((Control)CheckedListBox1).TabIndex = 4;
		((Control)Button2).Anchor = (AnchorStyles)9;
		((Control)Button2).Location = new Point(1013, 686);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Size = new Size(100, 23);
		((Control)Button2).TabIndex = 3;
		((ButtonBase)Button2).Text = "Reset TacView";
		((ButtonBase)Button2).UseVisualStyleBackColor = true;
		((Control)Button3).Anchor = (AnchorStyles)9;
		((Control)Button3).Location = new Point(969, 715);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Size = new Size(144, 23);
		((Control)Button3).TabIndex = 3;
		((ButtonBase)Button3).Text = "Send Junk to TacView";
		((ButtonBase)Button3).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1129, 748);
		((Control)this).Controls.Add((Control)(object)CheckedListBox1);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TextBox2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Name = "DebugForm";
		((Form)this).Text = "DebugForm";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public bool isInitialised()
	{
		return bool_1;
	}

	public void Init()
	{
		dispatcher_0 = Dispatcher.CurrentDispatcher;
		thread_0 = new Thread(ThreadSubroutine);
		thread_0.Start();
		CheckedListBox1.Items.Add((object)"DrawArea1", true);
		CheckedListBox1.Items.Add((object)"DrawEllipse1", true);
		CheckedListBox1.Items.Add((object)"FillEllipse1", true);
		CheckedListBox1.Items.Add((object)"FillRectangle1", true);
		CheckedListBox1.Items.Add((object)"FillPolygon1", true);
		CheckedListBox1.Items.Add((object)"FillPolygon2", true);
		CheckedListBox1.Items.Add((object)"FillPolygon3", true);
		CheckedListBox1.Items.Add((object)"DrawTransientBitmap", true);
		CheckedListBox1.Items.Add((object)"DrawIcon1", true);
		CheckedListBox1.Items.Add((object)"DrawIconRotated", true);
		CheckedListBox1.Items.Add((object)"DrawLine1", true);
		CheckedListBox1.Items.Add((object)"DrawLine2", true);
		CheckedListBox1.Items.Add((object)"DrawLine3", true);
		CheckedListBox1.Items.Add((object)"DrawDashedLine1", true);
		CheckedListBox1.Items.Add((object)"DrawDashedLine2", true);
		CheckedListBox1.Items.Add((object)"DrawLine4", true);
		CheckedListBox1.Items.Add((object)"DrawLine5", true);
		CheckedListBox1.Items.Add((object)"DrawClosedPointLine", true);
		CheckedListBox1.Items.Add((object)"DrawDashedClosedPointLine", true);
		CheckedListBox1.Items.Add((object)"DrawGraphicsPathLine", true);
		CheckedListBox1.Items.Add((object)"DrawPrimitiveLineStrip", true);
		CheckedListBox1.Items.Add((object)"DrawPrimitiveLineList", true);
		CheckedListBox1.Items.Add((object)"DrawGradientLine", true);
		CheckedListBox1.Items.Add((object)"DrawLoxodromicLine", true);
		CheckedListBox1.Items.Add((object)"DrawOrthodromicLine", true);
		CheckedListBox1.Items.Add((object)"DrawGeoText", true);
		CheckedListBox1.Items.Add((object)"DrawText", true);
		CheckedListBox1.Items.Add((object)"CL_DrawUncertaintyArea", true);
		CheckedListBox1.Items.Add((object)"CL_DrawActiveUnit", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFormationStation", true);
		CheckedListBox1.Items.Add((object)"CL_DrawActiveUnitDatablock", true);
		CheckedListBox1.Items.Add((object)"CL_DrawMovementVector", true);
		CheckedListBox1.Items.Add((object)"CL_DrawMouseHoverRectangleAndDatablock", true);
		CheckedListBox1.Items.Add((object)"CL_DrawContact", true);
		CheckedListBox1.Items.Add((object)"CL_DrawHealthBarForThisContact", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFireDamageBarForThisContact", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFloodDamageBarForThisContact", true);
		CheckedListBox1.Items.Add((object)"CL_DrawContactDatablock", true);
		CheckedListBox1.Items.Add((object)"CL_DrawContactEmissions", true);
		CheckedListBox1.Items.Add((object)"CL_DrawMissionAreas", true);
		CheckedListBox1.Items.Add((object)"CL_DrawMissionArea", true);
		CheckedListBox1.Items.Add((object)"CL_DrawPatrolBox", true);
		CheckedListBox1.Items.Add((object)"CL_DrawLOS", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawArea", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawPathIfPointsVisible", true);
		CheckedListBox1.Items.Add((object)"CL_DrawPlottedCourses", true);
		CheckedListBox1.Items.Add((object)"CL_DrawPlottedCourse", true);
		CheckedListBox1.Items.Add((object)"CL_DrawSalvoPlottedCourse", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFlightPlans_Planned", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFlightPlan", true);
		CheckedListBox1.Items.Add((object)"CL_DrawWeaponRoute", true);
		CheckedListBox1.Items.Add((object)"CL_DrawWeaponRouteWaypoints", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFlightPlan", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawFlightPlanWaypoints", true);
		CheckedListBox1.Items.Add((object)"CL_RangeWedgeArc_Draw", true);
		CheckedListBox1.Items.Add((object)"CL_RangeCircle_Draw", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_Merged_Friendly", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_NonFriendly", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_SelectedUnit", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_SelectedUnit_Nonfriendly", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_SingleUnits", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_SingleGroups", true);
		CheckedListBox1.Items.Add((object)"CLX_DrawRangeSymbols_SingleGroups_Nonfriendly", true);
		CheckedListBox1.Items.Add((object)"CL_DrawRangeSymbols", true);
		CheckedListBox1.Items.Add((object)"CL_DrawCZRings", true);
		CheckedListBox1.Items.Add((object)"CL_RangeWedges_Draw", true);
		CheckedListBox1.Items.Add((object)"CL_DrawPathIfPointsVisible", true);
		CheckedListBox1.Items.Add((object)"CL_DrawPathIfPointsVisible2", true);
		CheckedListBox1.Items.Add((object)"CL_DrawUnderwaterUnguidedWeapons", true);
		CheckedListBox1.Items.Add((object)"CL_DrawUnguidedWeapons", true);
		CheckedListBox1.Items.Add((object)"CL_DrawChaffClouds", true);
		CheckedListBox1.Items.Add((object)"CL_DrawTargetingVectors", true);
		CheckedListBox1.Items.Add((object)"CL_DrawIlluminationVectors", true);
		CheckedListBox1.Items.Add((object)"CL_DrawCommLinks", true);
		CheckedListBox1.Items.Add((object)"CL_DrawTargettingVector", true);
		CheckedListBox1.Items.Add((object)"CL_DrawIlluminationVector", true);
		CheckedListBox1.Items.Add((object)"CL_DrawCommLink", true);
		CheckedListBox1.Items.Add((object)"CL_DrawEventBalloons", true);
		CheckedListBox1.Items.Add((object)"CL_DrawStatusCaption", true);
		CheckedListBox1.Items.Add((object)"CL_DrawSelectedUnitsText", true);
		CheckedListBox1.Items.Add((object)"CL_DrawDataCursor", true);
		CheckedListBox1.Items.Add((object)"CL_DrawMeasuringLine", true);
		CheckedListBox1.Items.Add((object)"CL_DrawEventEditorAreas", true);
		CheckedListBox1.Items.Add((object)"CL_DrawWaterSplashes", true);
		CheckedListBox1.Items.Add((object)"CL_DrawGroundImpacts", true);
		CheckedListBox1.Items.Add((object)"CL_DrawMineSweep", true);
		CheckedListBox1.Items.Add((object)"CL_DrawSelectedMountArcs", true);
		CheckedListBox1.Items.Add((object)"CL_DrawOrbitPath", true);
		CheckedListBox1.Items.Add((object)"CL_DrawGroupLeashes", true);
		CheckedListBox1.Items.Add((object)"CL_DrawGroupLeash", true);
		CheckedListBox1.Items.Add((object)"CL_DrawHealthBars", true);
		CheckedListBox1.Items.Add((object)"CL_DrawHealthBarForThisUnit", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFuelBars", true);
		CheckedListBox1.Items.Add((object)"CL_DrawFuelBarForThisUnit", true);
		CheckedListBox1.Items.Add((object)"CL_DrawUnitSelectionRectangles", true);
		CheckedListBox1.Items.Add((object)"CL_DrawSelectionRectangle", true);
		CheckedListBox1.Items.Add((object)"CL_DrawWeaponImpacts", true);
		CheckedListBox1.Items.Add((object)"CL_DrawExplosions", true);
		CheckedListBox1.Items.Add((object)"CL_DrawCanals", true);
		CheckedListBox1.Items.Add((object)"CL_DrawPierLanes", true);
		CheckedListBox1.Items.Add((object)"CL_DrawExclusionZone", true);
		CheckedListBox1.Items.Add((object)"CL_DrawNoNavZones", true);
		CheckedListBox1.Items.Add((object)"CL_DrawRefPoints", true);
		CheckedListBox1.Items.Add((object)"CL_DrawCoursePreview", true);
		CheckedListBox1.Items.Add((object)"CL_DrawCustomEnvironmentZones", true);
		bool_1 = true;
	}

	public void ThreadSubroutine()
	{
		_Closure$__43-0 closure$__43- = default(_Closure$__43-0);
		while (!bool_0)
		{
			try
			{
				closure$__43- = new _Closure$__43-0(closure$__43-);
				closure$__43-.$VB$Me = this;
				Thread.Sleep(100);
				StringBuilder stringBuilder = new StringBuilder();
				while (concurrentQueue_0.TryDequeue(out closure$__43-.$VB$Local_s))
				{
					stringBuilder.Append(closure$__43-.$VB$Local_s + "\r\n");
				}
				closure$__43-.$VB$Local_s = stringBuilder.ToString();
				try
				{
					dispatcher_0.Invoke((Action)closure$__43-._Lambda$__0);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Write(string s)
	{
		try
		{
			concurrentQueue_0.Enqueue(s);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			concurrentQueue_0.Enqueue("Error in DebugForm.Write!");
			ProjectData.ClearProjectError();
		}
	}

	public void WriteException(string s, Exception e)
	{
		try
		{
			concurrentQueue_0.Enqueue("WriteException()");
			concurrentQueue_0.Enqueue($"Message: {s}");
			concurrentQueue_0.Enqueue($"e == null: {e == null}");
			concurrentQueue_0.Enqueue($"e.GetType().Name: {e.GetType().Name}");
			concurrentQueue_0.Enqueue($"e.Message: {e.Message}");
			concurrentQueue_0.Enqueue($"e.StackTrace: {e.StackTrace}");
			concurrentQueue_0.Enqueue($"e.InnerException  == null: {e.InnerException == null}");
			if (e.InnerException != null)
			{
				concurrentQueue_0.Enqueue($"e.InnerException .GetType().Name: {e.GetType().Name}");
				concurrentQueue_0.Enqueue($"e.InnerException .Message: {e.Message}");
				concurrentQueue_0.Enqueue($"e.InnerException .StackTrace: {e.StackTrace}");
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void DebugForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.CloseReason == 3)
		{
			((CancelEventArgs)(object)e).Cancel = true;
			((Control)this).Visible = false;
		}
		else
		{
			bool_0 = true;
		}
	}

	private void DebugForm_Load(object sender, EventArgs e)
	{
	}

	private void oYmcWsioWZ(object sender, EventArgs e)
	{
		Timer1.Enabled = false;
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void method_1(object sender, ItemCheckEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		CommandLayer.SetAlaCarteDisabled(Conversions.ToString(((ObjectCollection)CheckedListBox1.Items)[e.Index]), (int)e.NewValue == 1);
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		TacviewClient tacviewClient = TacviewServer.Clients.FirstOrDefault();
		if (tacviewClient != null)
		{
			tacviewClient.Close();
			TacviewServer.SpawnTacviewWindow();
		}
		else
		{
			Interaction.MsgBox((object)"No TVC", (MsgBoxStyle)0, (object)null);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (TacviewServer.Clients.FirstOrDefault() == null)
		{
			Interaction.MsgBox((object)"No TVC", (MsgBoxStyle)0, (object)null);
		}
	}

	static DebugForm()
	{
		Class72.smethod_20();
	}
}
