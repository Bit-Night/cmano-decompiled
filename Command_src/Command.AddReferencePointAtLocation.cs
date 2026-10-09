using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class AddReferencePointAtLocation : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton _Button_Cancel;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private DarkUIButton _Button_OK;

	[CompilerGenerated]
	private bool bool_2;

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _Button_OK;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_OK = value;
			darkUIButton = _Button_OK;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox_Latitude")]
	internal virtual DarkUITextBox TextBox_Latitude { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("TextBox_Longitude")]
	internal virtual DarkUITextBox TextBox_Longitude { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public AddReferencePointAtLocation()
	{
		((Form)this).Load += AddReferencePointAtLocation_Load;
		RTMPEnabled = true;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		Button_Cancel = new DarkUIButton();
		Button_OK = new DarkUIButton();
		TextBox_Latitude = new DarkUITextBox();
		Label1 = new DarkLabel();
		TextBox_Longitude = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((ButtonBase)Button_Cancel).BackColor = Color.Transparent;
		((Button)Button_Cancel).DialogResult = (DialogResult)0;
		((Control)Button_Cancel).Font = new Font("Segoe UI", 10f);
		((Control)Button_Cancel).ForeColor = SystemColors.Control;
		((Control)Button_Cancel).Location = new Point(165, 100);
		((Control)Button_Cancel).Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		((Control)Button_Cancel).Size = new Size(75, 23);
		((Control)Button_Cancel).TabIndex = 3;
		Button_Cancel.Text = "Cancel";
		((ButtonBase)Button_OK).BackColor = Color.Transparent;
		((Button)Button_OK).DialogResult = (DialogResult)0;
		((Control)Button_OK).Font = new Font("Segoe UI", 10f);
		((Control)Button_OK).ForeColor = SystemColors.Control;
		((Control)Button_OK).Location = new Point(60, 100);
		((Control)Button_OK).Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		((Control)Button_OK).Size = new Size(75, 23);
		((Control)Button_OK).TabIndex = 2;
		Button_OK.Text = "OK";
		TextBox_Latitude.AutoCompleteCustomSource = null;
		TextBox_Latitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_Latitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_Latitude).BackColor = Color.Transparent;
		TextBox_Latitude.Font = new Font("Segoe UI", 10f);
		((Control)TextBox_Latitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_Latitude.Image = null;
		TextBox_Latitude.Lines = null;
		((Control)TextBox_Latitude).Location = new Point(114, 12);
		TextBox_Latitude.MaxLength = 32767;
		TextBox_Latitude.Multiline = false;
		((Control)TextBox_Latitude).Name = "TextBox_Latitude";
		TextBox_Latitude.ReadOnly = false;
		TextBox_Latitude.ScrollBars = (ScrollBars)0;
		TextBox_Latitude.SelectionStart = 0;
		((Control)TextBox_Latitude).Size = new Size(159, 20);
		((Control)TextBox_Latitude).TabIndex = 0;
		TextBox_Latitude.TextAlign = (HorizontalAlignment)0;
		TextBox_Latitude.UseSystemPasswordChar = false;
		TextBox_Latitude.WatermarkText = "";
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(38, 16);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(56, 23);
		((Control)Label1).TabIndex = 10;
		((Label)Label1).Text = "Latitude:";
		TextBox_Longitude.AutoCompleteCustomSource = null;
		TextBox_Longitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_Longitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_Longitude).BackColor = Color.Transparent;
		TextBox_Longitude.Font = new Font("Segoe UI", 10f);
		((Control)TextBox_Longitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_Longitude.Image = null;
		TextBox_Longitude.Lines = null;
		((Control)TextBox_Longitude).Location = new Point(114, 51);
		TextBox_Longitude.MaxLength = 32767;
		TextBox_Longitude.Multiline = false;
		((Control)TextBox_Longitude).Name = "TextBox_Longitude";
		TextBox_Longitude.ReadOnly = false;
		TextBox_Longitude.ScrollBars = (ScrollBars)0;
		TextBox_Longitude.SelectionStart = 0;
		((Control)TextBox_Longitude).Size = new Size(159, 20);
		((Control)TextBox_Longitude).TabIndex = 1;
		TextBox_Longitude.TextAlign = (HorizontalAlignment)0;
		TextBox_Longitude.UseSystemPasswordChar = false;
		TextBox_Longitude.WatermarkText = "";
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(28, 55);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(66, 23);
		((Control)DarkLabel1).TabIndex = 12;
		((Label)DarkLabel1).Text = "Longitude:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(301, 140);
		((Control)this).Controls.Add((Control)(object)TextBox_Longitude);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)TextBox_Latitude);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)Button_OK);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddReferencePointAtLocation";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).Text = "Add Reference Point at Location";
		((Control)this).ResumeLayout(false);
	}

	private void AddReferencePointAtLocation_Load(object sender, EventArgs e)
	{
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		try
		{
			num = LuaUtility.ParseLatitudeString(TextBox_Latitude.Text);
			num2 = LuaUtility.ParseLongitudeString(TextBox_Longitude.Text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (ex2 is LuaError)
			{
				DarkMessageBox.ShowError(((LuaError)ex2).sMessage, "Coordinate Parsing Error");
			}
			if (num == double.MaxValue)
			{
				TextBox_Latitude.Focus();
			}
			else if (num2 == double.MaxValue)
			{
				TextBox_Longitude.Focus();
			}
			ProjectData.ClearProjectError();
			return;
		}
		num = Math2.NormalizeLatitude(num);
		num2 = Math2.NormalizeLongitude(num2);
		ReferencePoint referencePoint = new ReferencePoint();
		referencePoint.Longitude = num2;
		referencePoint.Latitude = num;
		referencePoint.Name = "RP-" + Conversions.ToString(Interlocked.Increment(ref Client.CurrentScenario.UnitsAutoIncrement));
		referencePoint.color = Color.White;
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendCreateReferencePoint(referencePoint.Latitude, referencePoint.Longitude, Client.CurrentSide);
		}
		else
		{
			Client.CurrentSide.RefPoints.Add(referencePoint);
		}
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		TextBox_Latitude.Text = "";
		TextBox_Longitude.Text = "";
		((Form)this).Close();
	}

	static AddReferencePointAtLocation()
	{
		Class72.smethod_20();
	}
}
