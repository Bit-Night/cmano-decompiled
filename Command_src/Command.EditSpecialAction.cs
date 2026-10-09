using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ScintillaNET;

namespace Command;

[DesignerGenerated]
public sealed class EditSpecialAction : DarkSecondaryFormBase
{
	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Name")]
	private DarkUITextBox _TB_Name;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("NUD_LuaScript")]
	[CompilerGenerated]
	private GClass9 _NUD_LuaScript;

	[AccessedThroughProperty("Button_AddLuaScript")]
	[CompilerGenerated]
	private DarkUIButton _Button_AddLuaScript;

	public SpecialAction theSA;

	public _FormAction Action;

	private LuaConsole luaConsole_0;

	internal virtual DarkUITextBox TB_Name
	{
		[CompilerGenerated]
		get
		{
			return _TB_Name;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_4;
			DarkUITextBox darkUITextBox = _TB_Name;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TB_Name = value;
			darkUITextBox = _TB_Name;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	internal virtual DarkUIButton Button2
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
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

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
			EventHandler eventHandler = method_3;
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

	[field: AccessedThroughProperty("TB_Description")]
	internal virtual DarkUITextBox TB_Description { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual GClass9 NUD_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return _NUD_LuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			EventHandler eventHandler2 = method_7;
			GClass9 gClass = _NUD_LuaScript;
			if (gClass != null)
			{
				((NumericUpDown)gClass).TextChanged -= eventHandler;
				((Control)gClass).Click -= eventHandler2;
			}
			_NUD_LuaScript = value;
			gClass = _NUD_LuaScript;
			if (gClass != null)
			{
				((NumericUpDown)gClass).TextChanged += eventHandler;
				((Control)gClass).Click += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label13")]
	internal virtual DarkLabel Label13 { get; set; }

	internal virtual DarkUIButton Button_AddLuaScript
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddLuaScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button_AddLuaScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddLuaScript = value;
			darkUIButton = _Button_AddLuaScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_LuaTemplate")]
	internal virtual DarkUIComboBox CB_LuaTemplate { get; set; }

	[field: AccessedThroughProperty("Label12")]
	internal virtual DarkLabel Label12 { get; set; }

	[field: AccessedThroughProperty("TextPanel2")]
	internal virtual Panel TextPanel2 { get; set; }

	public EditSpecialAction()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(EditSpecialAction_FormClosing);
		((Form)this).Load += EditSpecialAction_Load;
		((Control)this).KeyDown += new KeyEventHandler(EditSpecialAction_KeyDown);
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
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Expected O, but got Unknown
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Expected O, but got Unknown
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Expected O, but got Unknown
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Expected O, but got Unknown
		//IL_09dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Expected O, but got Unknown
		TB_Name = new DarkUITextBox();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		TB_Description = new DarkUITextBox();
		Label1 = new DarkLabel();
		NUD_LuaScript = new GClass9();
		Label13 = new DarkLabel();
		Button_AddLuaScript = new DarkUIButton();
		CB_LuaTemplate = new DarkUIComboBox();
		Label12 = new DarkLabel();
		TextPanel2 = new Panel();
		((ISupportInitialize)(object)NUD_LuaScript).BeginInit();
		((Control)this).SuspendLayout();
		TB_Name.AutoCompleteCustomSource = null;
		TB_Name.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Name.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Name).BackColor = Color.Transparent;
		TB_Name.Font = new Font("Segoe UI", 10f);
		((Control)TB_Name).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Name.Image = null;
		TB_Name.Lines = null;
		((Control)TB_Name).Location = new Point(90, 12);
		TB_Name.MaxLength = 32767;
		TB_Name.Multiline = false;
		((Control)TB_Name).Name = "TB_Name";
		TB_Name.ReadOnly = false;
		TB_Name.ScrollBars = (ScrollBars)0;
		TB_Name.SelectionStart = 0;
		((Control)TB_Name).Size = new Size(632, 20);
		((Control)TB_Name).TabIndex = 6;
		TB_Name.TextAlign = (HorizontalAlignment)0;
		TB_Name.UseSystemPasswordChar = false;
		TB_Name.WatermarkText = "";
		TB_Name.WordWrap = false;
		Label2.AutoSize = true;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(4, 16);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(53, 19);
		((Control)Label2).TabIndex = 5;
		((Label)Label2).Text = "Name:";
		Label3.AutoSize = true;
		((Control)Label3).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(4, 48);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(89, 19);
		((Control)Label3).TabIndex = 21;
		((Label)Label3).Text = "Description:";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(647, 614);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 24;
		Button2.Text = "Cancel";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(4, 614);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 23;
		Button1.Text = "OK";
		TB_Description.AutoCompleteCustomSource = null;
		TB_Description.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Description.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Description).BackColor = Color.Transparent;
		TB_Description.Font = new Font("Segoe UI", 10f);
		((Control)TB_Description).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Description.Image = null;
		TB_Description.Lines = null;
		((Control)TB_Description).Location = new Point(7, 64);
		TB_Description.MaxLength = 32767;
		TB_Description.Multiline = true;
		((Control)TB_Description).Name = "TB_Description";
		TB_Description.ReadOnly = false;
		TB_Description.ScrollBars = (ScrollBars)0;
		TB_Description.SelectionStart = 0;
		((Control)TB_Description).Size = new Size(715, 96);
		((Control)TB_Description).TabIndex = 25;
		TB_Description.TextAlign = (HorizontalAlignment)0;
		TB_Description.UseSystemPasswordChar = false;
		TB_Description.WatermarkText = "";
		TB_Description.WordWrap = false;
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(4, 174);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(79, 19);
		((Control)Label1).TabIndex = 21;
		((Label)Label1).Text = "Lua Script:";
		NUD_LuaScript.BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)NUD_LuaScript).BorderStyle = (BorderStyle)0;
		((Control)NUD_LuaScript).Font = new Font("Segoe UI", 10f);
		((UpDownBase)NUD_LuaScript).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_LuaScript).Location = new Point(658, 192);
		((Control)NUD_LuaScript).Name = "NUD_LuaScript";
		((Control)NUD_LuaScript).Size = new Size(64, 26);
		((Control)NUD_LuaScript).TabIndex = 31;
		Label13.AutoSize = true;
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(605, 197);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(70, 20);
		((Control)Label13).TabIndex = 30;
		((Label)Label13).Text = "Text Size:";
		((ButtonBase)Button_AddLuaScript).BackColor = Color.Transparent;
		((Control)Button_AddLuaScript).Font = new Font("Segoe UI", 10f);
		((Control)Button_AddLuaScript).ForeColor = SystemColors.Control;
		((Control)Button_AddLuaScript).Location = new Point(529, 193);
		((Control)Button_AddLuaScript).Name = "Button_AddLuaScript";
		((Control)Button_AddLuaScript).Padding = new Padding(5);
		Button_AddLuaScript.RoundRadius = 0;
		((Control)Button_AddLuaScript).Size = new Size(75, 24);
		((Control)Button_AddLuaScript).TabIndex = 29;
		Button_AddLuaScript.Text = "ADD";
		((ComboBox)CB_LuaTemplate).BackColor = Color.Transparent;
		((ComboBox)CB_LuaTemplate).DrawMode = (DrawMode)1;
		((ComboBox)CB_LuaTemplate).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_LuaTemplate).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_LuaTemplate).FormattingEnabled = true;
		((Control)CB_LuaTemplate).Location = new Point(124, 193);
		((Control)CB_LuaTemplate).Name = "CB_LuaTemplate";
		((Control)CB_LuaTemplate).Size = new Size(400, 24);
		((Control)CB_LuaTemplate).TabIndex = 28;
		Label12.AutoSize = true;
		((Control)Label12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label12).Location = new Point(4, 197);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(144, 20);
		((Control)Label12).TabIndex = 27;
		((Label)Label12).Text = "Add script template:";
		((Control)TextPanel2).Location = new Point(4, 221);
		((Control)TextPanel2).Name = "TextPanel2";
		((Control)TextPanel2).Size = new Size(718, 387);
		((Control)TextPanel2).TabIndex = 32;
		((Control)TextPanel2).Font = new Font("Segoe UI", 10f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(726, 639);
		((Control)this).Controls.Add((Control)(object)TextPanel2);
		((Control)this).Controls.Add((Control)(object)NUD_LuaScript);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)Button_AddLuaScript);
		((Control)this).Controls.Add((Control)(object)CB_LuaTemplate);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)TB_Description);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TB_Name);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditSpecialAction";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Edit special action";
		((ISupportInitialize)(object)NUD_LuaScript).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EditSpecialAction_FormClosing(object sender, FormClosingEventArgs e)
	{
		MyProject.Forms.ListSpecialActions.RefreshGrid();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void EditSpecialAction_Load(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)theSA))
		{
			((Form)this).Close();
		}
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		luaConsole_0 = new LuaConsole(TextPanel2);
		luaConsole_0.TextArea.WrapMode = WrapMode.Word;
		TB_Name.Text = theSA.Name;
		TB_Description.Text = theSA.Description;
		((Control)Button1).Visible = true;
		((Control)Button2).Visible = ((Control)Button1).Visible;
		if (!string.IsNullOrEmpty(theSA.ScriptText))
		{
			luaConsole_0.TextArea.Text = theSA.ScriptText;
		}
		((NumericUpDown)NUD_LuaScript).Value = new decimal((int)Math.Round(luaConsole_0.TextArea.Font.Size));
		((ComboBox)CB_LuaTemplate).Items.AddRange((object[])LuaSandBox.LuaMethods.OrderBy([SpecialName] (string s) => s).ToArray());
		((ComboBox)CB_LuaTemplate).SelectedIndex = 0;
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		theSA.Name = TB_Name.Text;
		theSA.ScriptText = luaConsole_0.TextArea.Text;
		theSA.Description = TB_Description.Text;
		switch (Action)
		{
		case _FormAction.AddNew:
			Client.CurrentSide.SpecialActions.Add(theSA.ObjectID, theSA);
			break;
		}
		((Form)this).Close();
	}

	private void method_4(object object_0)
	{
		theSA.Name = TB_Name.Text;
	}

	private void EditSpecialAction_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		luaConsole_0.TextArea.Text = luaConsole_0.TextArea.Text.Insert(luaConsole_0.TextArea.SelectionStart, Conversions.ToString(((ComboBox)CB_LuaTemplate).SelectedItem));
	}

	private void method_6(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_LuaScript).Value) && Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) > 0)
		{
			luaConsole_0.TextArea.Zoom = Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) - (int)Math.Round(luaConsole_0.TextArea.Font.Size);
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_LuaScript).Value) && Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) > 0)
		{
			luaConsole_0.TextArea.Zoom = Convert.ToInt32(((NumericUpDown)NUD_LuaScript).Value) - (int)Math.Round(luaConsole_0.TextArea.Font.Size);
		}
	}

	static EditSpecialAction()
	{
		Class72.smethod_20();
	}
}
