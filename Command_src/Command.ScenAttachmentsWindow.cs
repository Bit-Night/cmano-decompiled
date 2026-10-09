using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScenAttachmentsWindow : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("ListBox1")]
	[CompilerGenerated]
	private DarkListView _ListBox1;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("ToolStripButton2")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton2;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton3")]
	private ToolStripButton _ToolStripButton3;

	private Keys[] keys_0;

	internal virtual DarkListView ListBox1
	{
		[CompilerGenerated]
		get
		{
			return _ListBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_5;
			DarkListView darkListView = _ListBox1;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_ListBox1 = value;
			darkListView = _ListBox1;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	internal virtual ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			ToolStripButton val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton1 = value;
			val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton2
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			ToolStripButton val = _ToolStripButton2;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton2 = value;
			val = _ToolStripButton2;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TSCB1")]
	internal virtual ToolStripComboBox TSCB1 { get; set; }

	internal virtual ToolStripButton ToolStripButton3
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			ToolStripButton val = _ToolStripButton3;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton3 = value;
			val = _ToolStripButton3;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PropertyGrid1")]
	internal virtual PropertyGrid PropertyGrid1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	public ScenAttachmentsWindow()
	{
		((Form)this).Shown += ScenAttachmentsWindow_Shown;
		((Form)this).Load += ScenAttachmentsWindow_Load;
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ScenAttachmentsWindow));
		ListBox1 = new DarkListView();
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		TSCB1 = new ToolStripComboBox();
		ToolStripButton3 = new ToolStripButton();
		ToolStripButton2 = new ToolStripButton();
		PropertyGrid1 = new PropertyGrid();
		Label1 = new DarkLabel();
		((Control)ToolStrip1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)ListBox1).Anchor = (AnchorStyles)15;
		((Control)ListBox1).Location = new Point(0, 25);
		((Control)ListBox1).Name = "ListBox1";
		((Control)ListBox1).Size = new Size(530, 264);
		((Control)ListBox1).TabIndex = 3;
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[4]
		{
			(ToolStripItem)ToolStripButton1,
			(ToolStripItem)TSCB1,
			(ToolStripItem)ToolStripButton3,
			(ToolStripItem)ToolStripButton2
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(742, 25);
		((Control)ToolStrip1).TabIndex = 2;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripButton1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton1).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton1).Name = "ToolStripButton1";
		((ToolStripItem)ToolStripButton1).Size = new Size(119, 22);
		((ToolStripItem)ToolStripButton1).Text = "Create new, of type :";
		((ToolStripControlHost)TSCB1).BackColor = Color.FromArgb(60, 63, 65);
		TSCB1.DropDownStyle = (ComboBoxStyle)2;
		((ToolStripControlHost)TSCB1).ForeColor = Color.FromArgb(220, 220, 220);
		TSCB1.Items.AddRange(new object[6] { "Map Overlay (Single Image)", "Lua Script", "Inst Import", "Local Video", "Local Sound", "Local HTML" });
		((ToolStripItem)TSCB1).Name = "TSCB1";
		((ToolStripControlHost)TSCB1).Size = new Size(180, 25);
		((ToolStripItem)ToolStripButton3).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton3).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton3).Image = (Image)componentResourceManager.GetObject("ToolStripButton3.Image");
		((ToolStripItem)ToolStripButton3).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton3).Name = "ToolStripButton3";
		((ToolStripItem)ToolStripButton3).Size = new Size(92, 22);
		((ToolStripItem)ToolStripButton3).Text = "Add existing";
		((ToolStripItem)ToolStripButton2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton2).Image = (Image)componentResourceManager.GetObject("ToolStripButton2.Image");
		((ToolStripItem)ToolStripButton2).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton2).Name = "ToolStripButton2";
		((ToolStripItem)ToolStripButton2).Size = new Size(117, 22);
		((ToolStripItem)ToolStripButton2).Text = "Remove Selected";
		((Control)PropertyGrid1).Anchor = (AnchorStyles)11;
		PropertyGrid1.CategoryForeColor = SystemColors.InactiveCaptionText;
		((Control)PropertyGrid1).Location = new Point(536, 25);
		((Control)PropertyGrid1).Name = "PropertyGrid1";
		((Control)PropertyGrid1).Size = new Size(206, 264);
		((Control)PropertyGrid1).TabIndex = 4;
		((Control)Label1).Anchor = (AnchorStyles)9;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(535, 4);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(128, 15);
		((Control)Label1).TabIndex = 5;
		((Label)Label1).Text = "Properties of selected:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(742, 288);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)PropertyGrid1);
		((Control)this).Controls.Add((Control)(object)ListBox1);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ScenAttachmentsWindow";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Scenario Attachments";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
				int result;
				if (((Control)this).Visible)
				{
					((Form)this).Close();
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void ScenAttachmentsWindow_Shown(object sender, EventArgs e)
	{
		TSCB1.SelectedIndex = 0;
		RefreshAttachments();
	}

	public void RefreshAttachments()
	{
		ListBox1.Items.Clear();
		foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in Client.CurrentScenario.ScenAttachments)
		{
			DarkListItem darkListItem = new DarkListItem(scenAttachment.Value.Description);
			darkListItem.Tag = scenAttachment.Key;
			ListBox1.Items.Add(darkListItem);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		LoadAttachment();
		RefreshAttachments();
	}

	public void LoadAttachment()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Invalid comparison between Unknown and I4
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Invalid comparison between Unknown and I4
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Invalid comparison between Unknown and I4
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Invalid comparison between Unknown and I4
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Invalid comparison between Unknown and I4
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Invalid comparison between Unknown and I4
		switch (TSCB1.SelectedIndex)
		{
		case 0:
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GameGeneral.TopLevelWritablePath;
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "Image file (*.*)|*.*";
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName = "";
			if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				string fileName4 = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName;
				SAO_OverlaySingle sAO_OverlaySingle = new SAO_OverlaySingle();
				sAO_OverlaySingle.ImageFileName = Path.GetFileName(fileName4);
				sAO_OverlaySingle.Description = "Map Overlay Image: " + sAO_OverlaySingle.ImageFileName;
				sAO_OverlaySingle.CopyToLocalRepository(fileName4);
				sAO_OverlaySingle.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_OverlaySingle.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_OverlaySingle.ObjectID, sAO_OverlaySingle);
				break;
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at 200395", ex8.Message);
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 1:
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GameGeneral.TopLevelWritablePath;
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "Lua script file (*.lua)|*.lua";
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName = "";
			if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				string fileName6 = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName;
				SAO_LuaScript sAO_LuaScript = new SAO_LuaScript();
				sAO_LuaScript.ScriptFileName = Path.GetFileName(fileName6);
				sAO_LuaScript.Description = "Lua script: " + sAO_LuaScript.ScriptFileName;
				sAO_LuaScript.CopyToLocalRepository(fileName6);
				sAO_LuaScript.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LuaScript.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LuaScript.ObjectID, sAO_LuaScript);
				break;
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				ex12?.Data.Add("Error at 200396", ex12.Message);
				GameGeneral.WriteExceptionsToLog(ex12);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 2:
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GameGeneral.TopLevelWritablePath;
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "Inst Import file (*.inst)|*.inst";
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName = "";
			if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				string fileName2 = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName;
				SAO_Inst sAO_Inst = new SAO_Inst();
				sAO_Inst.InstFileName = Path.GetFileName(fileName2);
				sAO_Inst.Description = "Inst File: " + sAO_Inst.InstFileName;
				sAO_Inst.CopyToLocalRepository(fileName2);
				sAO_Inst.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_Inst.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_Inst.ObjectID, sAO_Inst);
				break;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200397", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 3:
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GameGeneral.TopLevelWritablePath;
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "Video file (*.*)|*.*";
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName = "";
			if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				string fileName5 = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName;
				SAO_LocalVideo sAO_LocalVideo = new SAO_LocalVideo();
				sAO_LocalVideo.VideoFileName = Path.GetFileName(fileName5);
				sAO_LocalVideo.Description = "Local Video: " + sAO_LocalVideo.VideoFileName;
				sAO_LocalVideo.CopyToLocalRepository(fileName5);
				sAO_LocalVideo.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LocalVideo.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LocalVideo.ObjectID, sAO_LocalVideo);
				break;
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ex10?.Data.Add("Error at 200398", ex10.Message);
				GameGeneral.WriteExceptionsToLog(ex10);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 4:
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GameGeneral.TopLevelWritablePath;
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "sound file (*.*)|*.*";
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName = "";
			if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				string fileName3 = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName;
				SAO_LocalSound sAO_LocalSound = new SAO_LocalSound();
				sAO_LocalSound.SoundFileName = Path.GetFileName(fileName3);
				sAO_LocalSound.Description = "Local Sound: " + sAO_LocalSound.SoundFileName;
				sAO_LocalSound.CopyToLocalRepository(fileName3);
				sAO_LocalSound.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LocalSound.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LocalSound.ObjectID, sAO_LocalSound);
				break;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 200399", ex6.Message);
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 5:
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).InitialDirectory = GlobalVariables.ApplicationStartupPath;
			((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).Filter = "HTML file (*.*)|*.*";
			if ((int)((CommonDialog)MyProject.Forms.MainForm.LoadPicDlg).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				string fileName = ((FileDialog)MyProject.Forms.MainForm.LoadPicDlg).FileName;
				SAO_LocalHTML sAO_LocalHTML = new SAO_LocalHTML();
				sAO_LocalHTML.HTMLFileName = Path.GetFileName(fileName);
				sAO_LocalHTML.Description = "Local HTML: " + sAO_LocalHTML.HTMLFileName;
				sAO_LocalHTML.CopyToLocalRepository(fileName);
				sAO_LocalHTML.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LocalHTML.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LocalHTML.ObjectID, sAO_LocalHTML);
				break;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200399", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			Client.CurrentScenario.ScenAttachments.Remove(selectedItem.Tag.ToString());
		}
		RefreshAttachments();
	}

	public void RefreshForm()
	{
		RefreshAttachments();
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		bool flag = false;
		if ((int)((Form)MyProject.Forms.SelectSAO).ShowDialog() == 1)
		{
			foreach (ScenAttachmentObject selectedSAO in MyProject.Forms.SelectSAO.SelectedSAOs)
			{
				if (!Client.CurrentScenario.ScenAttachments.ContainsKey(selectedSAO.ObjectID))
				{
					Client.CurrentScenario.ScenAttachments.Add(selectedSAO.ObjectID, selectedSAO);
					flag = true;
				}
			}
			RefreshAttachments();
		}
		if (flag)
		{
			RefreshAttachments();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		if (ListBox1.SelectedItems.Count <= 0)
		{
			PropertyGrid1.SelectedObject = null;
		}
		else
		{
			PropertyGrid1.SelectedObject = Client.CurrentScenario.ScenAttachments[Conversions.ToString(ListBox1.SelectedItems[0].Tag).ToString()];
		}
	}

	private void ScenAttachmentsWindow_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static ScenAttachmentsWindow()
	{
		Class72.smethod_20();
	}
}
