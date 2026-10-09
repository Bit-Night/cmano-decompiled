using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[DesignerGenerated]
public sealed class SteamPublishScenarioForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MapScreenshot")]
	private DarkUIButton _Button_MapScreenshot;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _Button3;

	[CompilerGenerated]
	[AccessedThroughProperty("OFD_CustomImage")]
	private OpenFileDialog openFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UpdateExistingItem")]
	private DarkUIButton _Button_UpdateExistingItem;

	[AccessedThroughProperty("VisibleOnSteamCB")]
	[CompilerGenerated]
	private DarkUIComboBox _VisibleOnSteamCB;

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1 { get; set; }

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_MapScreenshot
	{
		[CompilerGenerated]
		get
		{
			return _Button_MapScreenshot;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_MapScreenshot;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_MapScreenshot = value;
			darkUIButton = _Button_MapScreenshot;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("TextBox2")]
	internal virtual DarkUITextBox TextBox2 { get; set; }

	[field: AccessedThroughProperty("TextBox3")]
	internal virtual DarkUITextBox TextBox3 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual OpenFileDialog OFD_CustomImage
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_0 = value;
		}
	}

	internal virtual DarkUIButton Button_UpdateExistingItem
	{
		[CompilerGenerated]
		get
		{
			return _Button_UpdateExistingItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _Button_UpdateExistingItem;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_UpdateExistingItem = value;
			darkUIButton = _Button_UpdateExistingItem;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox VisibleOnSteamCB
	{
		[CompilerGenerated]
		get
		{
			return _VisibleOnSteamCB;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIComboBox darkUIComboBox = _VisibleOnSteamCB;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_VisibleOnSteamCB = value;
			darkUIComboBox = _VisibleOnSteamCB;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("VisibleOnSteamLabel")]
	internal virtual DarkLabel VisibleOnSteamLabel { get; set; }

	public SteamPublishScenarioForm()
	{
		((Form)this).Shown += SteamPublishScenarioForm_Shown;
		((Form)this).Closed += SteamPublishScenarioForm_Closed;
		((Form)this).Load += SteamPublishScenarioForm_Load;
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected O, but got Unknown
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Expected O, but got Unknown
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Expected O, but got Unknown
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected O, but got Unknown
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Expected O, but got Unknown
		PictureBox1 = new PictureBox();
		Button1 = new DarkUIButton();
		Button_MapScreenshot = new DarkUIButton();
		Button3 = new DarkUIButton();
		TextBox1 = new DarkUITextBox();
		TextBox2 = new DarkUITextBox();
		TextBox3 = new DarkUITextBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		OFD_CustomImage = new OpenFileDialog();
		Button_UpdateExistingItem = new DarkUIButton();
		VisibleOnSteamCB = new DarkUIComboBox();
		VisibleOnSteamLabel = new DarkLabel();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PictureBox1).Anchor = (AnchorStyles)9;
		((Control)PictureBox1).Location = new Point(422, 13);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(256, 256);
		PictureBox1.SizeMode = (PictureBoxSizeMode)3;
		PictureBox1.TabIndex = 1;
		PictureBox1.TabStop = false;
		((Control)Button1).Anchor = (AnchorStyles)9;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(423, 283);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(255, 23);
		((Control)Button1).TabIndex = 2;
		Button1.Text = "Select Preview Image";
		((Control)Button_MapScreenshot).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_MapScreenshot).BackColor = Color.Transparent;
		((Control)Button_MapScreenshot).Font = new Font("Segoe UI", 10f);
		((Control)Button_MapScreenshot).ForeColor = SystemColors.Control;
		((Control)Button_MapScreenshot).Location = new Point(422, 313);
		((Control)Button_MapScreenshot).Name = "Button_MapScreenshot";
		((Control)Button_MapScreenshot).Padding = new Padding(5);
		Button_MapScreenshot.RoundRadius = 0;
		((Control)Button_MapScreenshot).Size = new Size(256, 23);
		((Control)Button_MapScreenshot).TabIndex = 3;
		Button_MapScreenshot.Text = "Use Screenshot";
		((Control)Button3).Anchor = (AnchorStyles)9;
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).Font = new Font("Segoe UI", 10f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(422, 343);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(256, 23);
		((Control)Button3).TabIndex = 4;
		Button3.Text = "Publish New Item";
		((Control)TextBox1).Anchor = (AnchorStyles)13;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(104, 13);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(312, 24);
		((Control)TextBox1).TabIndex = 5;
		TextBox1.TextAlign = (HorizontalAlignment)2;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		((Control)TextBox2).Anchor = (AnchorStyles)15;
		TextBox2.AutoCompleteCustomSource = null;
		TextBox2.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox2.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox2).BackColor = Color.Transparent;
		TextBox2.Font = new Font("Segoe UI", 8f);
		((Control)TextBox2).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox2.Image = null;
		TextBox2.Lines = null;
		((Control)TextBox2).Location = new Point(12, 67);
		TextBox2.MaxLength = 32767;
		TextBox2.Multiline = true;
		((Control)TextBox2).Name = "TextBox2";
		TextBox2.ReadOnly = false;
		TextBox2.ScrollBars = (ScrollBars)0;
		TextBox2.SelectionStart = 0;
		((Control)TextBox2).Size = new Size(404, 380);
		((Control)TextBox2).TabIndex = 6;
		TextBox2.TextAlign = (HorizontalAlignment)0;
		TextBox2.UseSystemPasswordChar = false;
		TextBox2.WatermarkText = "";
		TextBox2.WordWrap = false;
		TextBox3.AutoCompleteCustomSource = null;
		TextBox3.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox3.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox3).BackColor = Color.Transparent;
		TextBox3.Font = new Font("Segoe UI", 8f);
		((Control)TextBox3).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox3.Image = null;
		TextBox3.Lines = null;
		((Control)TextBox3).Location = new Point(104, 41);
		TextBox3.MaxLength = 32767;
		TextBox3.Multiline = false;
		((Control)TextBox3).Name = "TextBox3";
		TextBox3.ReadOnly = false;
		TextBox3.ScrollBars = (ScrollBars)0;
		TextBox3.SelectionStart = 0;
		((Control)TextBox3).Size = new Size(312, 20);
		((Control)TextBox3).TabIndex = 7;
		TextBox3.TextAlign = (HorizontalAlignment)0;
		TextBox3.UseSystemPasswordChar = false;
		TextBox3.WatermarkText = "";
		TextBox3.WordWrap = false;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(12, 20);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(86, 17);
		((Control)Label1).TabIndex = 8;
		((Label)Label1).Text = "Scenario Title:";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(12, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(72, 17);
		((Control)Label2).TabIndex = 9;
		((Label)Label2).Text = "Filename:";
		((Control)Button_UpdateExistingItem).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_UpdateExistingItem).BackColor = Color.Transparent;
		((Control)Button_UpdateExistingItem).Font = new Font("Segoe UI", 10f);
		((Control)Button_UpdateExistingItem).ForeColor = SystemColors.Control;
		((Control)Button_UpdateExistingItem).Location = new Point(423, 373);
		((Control)Button_UpdateExistingItem).Name = "Button_UpdateExistingItem";
		((Control)Button_UpdateExistingItem).Padding = new Padding(5);
		Button_UpdateExistingItem.RoundRadius = 0;
		((Control)Button_UpdateExistingItem).Size = new Size(255, 23);
		((Control)Button_UpdateExistingItem).TabIndex = 10;
		Button_UpdateExistingItem.Text = "Update Existing Workshop Item";
		((ComboBox)VisibleOnSteamCB).BackColor = Color.Transparent;
		((ComboBox)VisibleOnSteamCB).DrawMode = (DrawMode)1;
		((ComboBox)VisibleOnSteamCB).DropDownStyle = (ComboBoxStyle)2;
		((Control)VisibleOnSteamCB).Font = new Font("Segoe UI", 9f);
		((ListControl)VisibleOnSteamCB).FormattingEnabled = true;
		((ComboBox)VisibleOnSteamCB).Items.AddRange(new object[3] { "Public", "Friends", "Hidden" });
		((Control)VisibleOnSteamCB).Location = new Point(551, 402);
		((ComboBox)VisibleOnSteamCB).MaxDropDownItems = 4;
		((Control)VisibleOnSteamCB).Name = "VisibleOnSteamCB";
		((Control)VisibleOnSteamCB).Size = new Size(121, 24);
		((Control)VisibleOnSteamCB).TabIndex = 11;
		VisibleOnSteamLabel.AutoSize = true;
		((Control)VisibleOnSteamLabel).Font = new Font("Segoe UI", 10f);
		((Control)VisibleOnSteamLabel).ForeColor = SystemColors.Control;
		((Control)VisibleOnSteamLabel).Location = new Point(422, 403);
		((Control)VisibleOnSteamLabel).Name = "VisibleOnSteamLabel";
		((Control)VisibleOnSteamLabel).Size = new Size(56, 19);
		((Control)VisibleOnSteamLabel).TabIndex = 12;
		((Label)VisibleOnSteamLabel).Text = "Visibilty";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(684, 455);
		((Control)this).Controls.Add((Control)(object)VisibleOnSteamLabel);
		((Control)this).Controls.Add((Control)(object)VisibleOnSteamCB);
		((Control)this).Controls.Add((Control)(object)Button_UpdateExistingItem);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TextBox3);
		((Control)this).Controls.Add((Control)(object)TextBox2);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)Button_MapScreenshot);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "SteamPublishScenarioForm";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Steam Workshop Publishing";
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Invalid comparison between Unknown and I4
		((FileDialog)OFD_CustomImage).Filter = "";
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		string text = string.Empty;
		ImageCodecInfo[] array = imageEncoders;
		foreach (ImageCodecInfo val in array)
		{
			string text2 = val.CodecName.Substring(8).Replace("Codec", "Files").Trim();
			((FileDialog)OFD_CustomImage).Filter = string.Format("{0}{1}{2} ({3})|{3}", ((FileDialog)OFD_CustomImage).Filter, text, text2, val.FilenameExtension);
			text = "|";
		}
		((FileDialog)OFD_CustomImage).Filter = string.Format("{0}{1}{2} ({3})|{3}", ((FileDialog)OFD_CustomImage).Filter, text, "All Files", "*.*");
		((FileDialog)OFD_CustomImage).FilterIndex = 1;
		if ((int)((CommonDialog)OFD_CustomImage).ShowDialog() == 1)
		{
			if (FileExistsNative.FileExistsFast(method_3()))
			{
				File.Delete(method_3());
			}
			File.Copy(((FileDialog)OFD_CustomImage).FileName, method_3());
			Image val2 = Image.FromFile(((FileDialog)OFD_CustomImage).FileName);
			method_8(val2, val2.RawFormat);
		}
	}

	[SpecialName]
	private string method_3()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "screenshot.png");
	}

	[SpecialName]
	private string method_4()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "screenshot_thumb.png");
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(TextBox1.Text))
		{
			DarkMessageBox.ShowError("Please provide a scenario title!", "No title");
		}
		else if (!string.IsNullOrEmpty(TextBox2.Text))
		{
			if (!string.IsNullOrEmpty(TextBox3.Text) && Operators.CompareString(TextBox3.Text, "Input Scenario Filename Here", true) != 0)
			{
				SteamWorkshop.SteamWorkshopScenario a = new SteamWorkshop.SteamWorkshopScenario
				{
					Name = TextBox1.Text,
					Description = TextBox2.Text,
					PreviewFilePath = method_4(),
					ScenFileName = TextBox3.Text.Replace("/", "").Replace("\\", "").Replace(":", "")
				};
				MyProject.Forms.MainForm.Timer_SteamWorkshop.Interval = 1000;
				SteamWorkshop.Publish(a);
			}
			else
			{
				DarkMessageBox.ShowError("Please provide a scenario filename!", "No filename");
			}
		}
		else
		{
			DarkMessageBox.ShowError("Please provide a scenario description!", "No description");
		}
	}

	private void SteamPublishScenarioForm_Shown(object sender, EventArgs e)
	{
		if (!MyProject.Forms.MainForm.Timer_SteamWorkshop.Enabled)
		{
			MyProject.Forms.MainForm.Timer_SteamWorkshop.Start();
		}
		TextBox1.Text = Client.CurrentScenario.Title;
		if (!string.IsNullOrEmpty(Client.CurrentScenario.Description))
		{
			TextBox2.Text = StripHTML.StripTagsRegexCompiled(Client.CurrentScenario.Description);
		}
		if (!string.IsNullOrEmpty(Client.SaveScenarioPath))
		{
			TextBox3.Text = Path.GetFileNameWithoutExtension(Client.SaveScenarioPath);
		}
		else
		{
			TextBox3.Text = "Input Scenario Filename Here";
		}
		string text = Path.ChangeExtension(Client.SaveScenarioPath, "jpg");
		if (!Information.IsNothing((object)Client.SaveScenarioPath) && FileExistsNative.FileExistsFast(text))
		{
			Image val = Image.FromFile(text);
			method_8(val, val.RawFormat);
		}
		else
		{
			method_6();
		}
		((ComboBox)VisibleOnSteamCB).SelectedIndex = 0;
	}

	private void SteamPublishScenarioForm_Closed(object sender, EventArgs e)
	{
		if (MyProject.Forms.m_SteamUpdateScenarioForm == null || !((Control)MyProject.Forms.SteamUpdateScenarioForm).Visible)
		{
			MyProject.Forms.MainForm.Timer_SteamWorkshop.Stop();
		}
	}

	private void method_6()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		try
		{
			if (FileExistsNative.FileExistsFast(method_3()))
			{
				File.Delete(method_3());
			}
			Bitmap val = new Bitmap(((Control)MyProject.Forms.MainForm.WorldWindow1).Width, ((Control)MyProject.Forms.MainForm.WorldWindow1).Height);
			Graphics obj = Graphics.FromImage((Image)(object)val);
			((Control)this).Visible = false;
			Thread.Sleep(50);
			Application.DoEvents();
			((Control)this).Visible = false;
			Thread.Sleep(50);
			Application.DoEvents();
			obj.CopyFromScreen(((Control)MyProject.Forms.MainForm.WorldWindow1).PointToScreen(default(Point)).X, ((Control)MyProject.Forms.MainForm.WorldWindow1).PointToScreen(default(Point)).Y, 0, 0, ((Image)val).Size);
			((Control)this).Visible = true;
			((Image)val).Save(method_3(), ImageFormat.Png);
			method_8((Image)(object)val, ImageFormat.Png);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200407", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		method_6();
	}

	private void method_8(Image image_0, ImageFormat imageFormat_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		Image val = (Image)(object)Module1.ResizeImage((Bitmap)image_0, new Size(637, 358));
		val.Save(method_4(), imageFormat_0);
		PictureBox1.Image = (Image)(object)Module1.ResizeImage((Bitmap)val, new Size(256, 256));
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(TextBox1.Text))
		{
			if (string.IsNullOrEmpty(TextBox2.Text))
			{
				DarkMessageBox.ShowError("Please provide a scenario description!", "Error");
			}
			else if (!string.IsNullOrEmpty(TextBox3.Text) && Operators.CompareString(TextBox3.Text, "Input Scenario Filename Here", true) != 0)
			{
				SteamWorkshop.SteamWorkshopScenario steam_scenario = new SteamWorkshop.SteamWorkshopScenario
				{
					Name = TextBox1.Text,
					Description = TextBox2.Text,
					PreviewFilePath = method_4(),
					ScenFileName = TextBox3.Text.Replace("/", "").Replace("\\", "").Replace(":", "")
				};
				MyProject.Forms.MainForm.Timer_SteamWorkshop.Interval = 1000;
				SteamUpdateScenarioForm.steam_scenario = steam_scenario;
				((Control)MyProject.Forms.SteamUpdateScenarioForm).Show();
			}
			else
			{
				DarkMessageBox.ShowError("Please provide a scenario filename!", "Error");
			}
		}
		else
		{
			DarkMessageBox.ShowError("Please provide a scenario title!", "Error");
		}
	}

	private void SteamPublishScenarioForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		switch (((ComboBox)VisibleOnSteamCB).SelectedIndex)
		{
		case 0:
			SteamWorkshop.visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
			break;
		case 1:
			SteamWorkshop.visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly;
			break;
		case 2:
			SteamWorkshop.visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
			break;
		}
	}

	static SteamPublishScenarioForm()
	{
		Class72.smethod_20();
	}
}
