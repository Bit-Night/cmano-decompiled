using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DoctrineItem_uc : UserControl, IUIListener
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("DarkUIComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox darkUIComboBox_0;

	[AccessedThroughProperty("DarkUICheckBox1")]
	[CompilerGenerated]
	private DarkUICheckBox darkUICheckBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip toolTip_0;

	public Doctrine.DoctrineItem DoctrineItem;

	private Dictionary<int, int> dictionary_0;

	private Dictionary<int, int> dictionary_1;

	private string OohUiTkEh4;

	private DoctrineControl.DoctrineControl_Config? nullable_0;

	private static HashSet<DoctrineItem_uc> hashSet_0;

	[field: AccessedThroughProperty("Title")]
	internal virtual DarkLabel Title { get; set; }

	internal virtual DarkUIComboBox DarkUIComboBox1
	{
		[CompilerGenerated]
		get
		{
			return darkUIComboBox_0;
		}
		[CompilerGenerated]
		set
		{
			darkUIComboBox_0 = value;
		}
	}

	internal virtual DarkUICheckBox DarkUICheckBox1
	{
		[CompilerGenerated]
		get
		{
			return darkUICheckBox_0;
		}
		[CompilerGenerated]
		set
		{
			darkUICheckBox_0 = value;
		}
	}

	[field: AccessedThroughProperty("Combo_StateSelection")]
	internal virtual DarkUIComboBox Combo_StateSelection { get; set; }

	[field: AccessedThroughProperty("CB_PlayerEditable")]
	internal virtual DarkUICheckBox CB_PlayerEditable { get; set; }

	internal virtual ToolTip ToolTip1
	{
		[CompilerGenerated]
		get
		{
			return toolTip_0;
		}
		[CompilerGenerated]
		set
		{
			toolTip_0 = value;
		}
	}

	[field: AccessedThroughProperty("NumericUpDown")]
	internal virtual NumericUpDown NumericUpDown { get; set; }

	[field: AccessedThroughProperty("NumericUpDown_UnitLabel")]
	internal virtual DarkLabel NumericUpDown_UnitLabel { get; set; }

	[field: AccessedThroughProperty("InheritCB")]
	internal virtual DarkUICheckBox InheritCB { get; set; }

	[field: AccessedThroughProperty("InheritLabel")]
	internal virtual DarkLabel InheritLabel { get; set; }

	public Type SubjectType => DoctrineItem.Doctrine.SubjectType;

	static DoctrineItem_uc()
	{
		Class72.smethod_20();
		hashSet_0 = new HashSet<DoctrineItem_uc>();
	}

	public DoctrineItem_uc()
	{
		dictionary_0 = new Dictionary<int, int>();
		dictionary_1 = new Dictionary<int, int>();
		eUoUyyuFu8();
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
			((ContainerControl)this).Dispose(disposing);
		}
	}

	private void eUoUyyuFu8()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		icontainer_0 = new Container();
		Title = new DarkLabel();
		ToolTip1 = new ToolTip(icontainer_0);
		CB_PlayerEditable = new DarkUICheckBox();
		Combo_StateSelection = new DarkUIComboBox();
		NumericUpDown = new NumericUpDown();
		NumericUpDown_UnitLabel = new DarkLabel();
		InheritCB = new DarkUICheckBox();
		InheritLabel = new DarkLabel();
		((ISupportInitialize)NumericUpDown).BeginInit();
		((Control)this).SuspendLayout();
		((Control)Title).Anchor = (AnchorStyles)13;
		Title.AutoSize = true;
		((Control)Title).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Title).Location = new Point(3, 7);
		((Control)Title).Name = "Title";
		((Control)Title).Size = new Size(115, 13);
		((Control)Title).TabIndex = 0;
		((Label)Title).Text = "------------------------------------";
		((Control)CB_PlayerEditable).Anchor = (AnchorStyles)11;
		((ButtonBase)CB_PlayerEditable).AutoSize = true;
		((Control)CB_PlayerEditable).Location = new Point(358, 6);
		((Control)CB_PlayerEditable).Name = "CB_PlayerEditable";
		((Control)CB_PlayerEditable).Size = new Size(15, 14);
		((Control)CB_PlayerEditable).TabIndex = 2;
		((Control)Combo_StateSelection).Anchor = (AnchorStyles)9;
		((ComboBox)Combo_StateSelection).BackColor = Color.Transparent;
		((ComboBox)Combo_StateSelection).DrawMode = (DrawMode)1;
		((ComboBox)Combo_StateSelection).DropDownStyle = (ComboBoxStyle)2;
		((ComboBox)Combo_StateSelection).DropDownWidth = 600;
		((Control)Combo_StateSelection).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_StateSelection).FormattingEnabled = true;
		((Control)Combo_StateSelection).Location = new Point(152, 3);
		((ComboBox)Combo_StateSelection).MaximumSize = new Size(300, 0);
		((Control)Combo_StateSelection).Name = "Combo_StateSelection";
		((Control)Combo_StateSelection).Size = new Size(200, 21);
		((Control)Combo_StateSelection).TabIndex = 1;
		((UpDownBase)NumericUpDown).BackColor = Color.FromArgb(63, 63, 63);
		((UpDownBase)NumericUpDown).ForeColor = SystemColors.Info;
		((Control)NumericUpDown).Location = new Point(215, 4);
		((Control)NumericUpDown).Name = "NumericUpDown";
		((Control)NumericUpDown).Size = new Size(97, 20);
		((Control)NumericUpDown).TabIndex = 3;
		NumericUpDown_UnitLabel.AutoSize = true;
		((Control)NumericUpDown_UnitLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NumericUpDown_UnitLabel).Location = new Point(315, 7);
		((Control)NumericUpDown_UnitLabel).Name = "NumericUpDown_UnitLabel";
		((Control)NumericUpDown_UnitLabel).Size = new Size(23, 13);
		((Control)NumericUpDown_UnitLabel).TabIndex = 4;
		((Label)NumericUpDown_UnitLabel).Text = "Nm";
		((Control)InheritCB).Anchor = (AnchorStyles)15;
		((ButtonBase)InheritCB).AutoSize = true;
		((Control)InheritCB).Location = new Point(152, 6);
		((Control)InheritCB).Name = "InheritCB";
		((Control)InheritCB).Size = new Size(15, 14);
		((Control)InheritCB).TabIndex = 5;
		InheritLabel.AutoSize = true;
		((Control)InheritLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)InheritLabel).Location = new Point(173, 7);
		((Control)InheritLabel).Name = "InheritLabel";
		((Control)InheritLabel).Size = new Size(36, 13);
		((Control)InheritLabel).TabIndex = 6;
		((Label)InheritLabel).Text = "Inherit";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(60, 60, 60);
		((Control)this).Controls.Add((Control)(object)InheritLabel);
		((Control)this).Controls.Add((Control)(object)InheritCB);
		((Control)this).Controls.Add((Control)(object)NumericUpDown_UnitLabel);
		((Control)this).Controls.Add((Control)(object)NumericUpDown);
		((Control)this).Controls.Add((Control)(object)CB_PlayerEditable);
		((Control)this).Controls.Add((Control)(object)Combo_StateSelection);
		((Control)this).Controls.Add((Control)(object)Title);
		((Control)this).Margin = new Padding(0);
		((Control)this).Name = "DoctrineItem_uc";
		((Control)this).Size = new Size(380, 28);
		((ISupportInitialize)NumericUpDown).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public static void ReleaseAllReferences()
	{
		foreach (DoctrineItem_uc item in hashSet_0)
		{
			item.ReleaseReferences();
		}
		hashSet_0.Clear();
	}

	public void ReleaseReferences()
	{
		DoctrineItem = null;
	}

	public void RefreshPanel(Doctrine.DoctrineItem Item, Scenario thescen, string CustomTitle = "", DoctrineControl.DoctrineControl_Config? Config = null)
	{
		((Control)this).Visible = true;
		hashSet_0.Add(this);
		Item.AddListener(this);
		((Control)CB_PlayerEditable).Visible = Client.CurrentGame.IsScenEditGameMode;
		((CheckBox)CB_PlayerEditable).CheckedChanged -= method_2;
		((ComboBox)Combo_StateSelection).SelectionChangeCommitted -= method_1;
		((CheckBox)CB_PlayerEditable).CheckedChanged += method_2;
		((ComboBox)Combo_StateSelection).SelectionChangeCommitted += method_1;
		OohUiTkEh4 = CustomTitle;
		nullable_0 = Config;
		if (Config.HasValue)
		{
			((Control)this).Size = new Size(Config.Value.UC_Size, ((Control)this).Size.Height);
		}
		((Control)NumericUpDown).Visible = Item.Definifition.IsNumeric;
		((Control)NumericUpDown_UnitLabel).Visible = Item.Definifition.IsNumeric;
		((Control)InheritCB).Visible = Item.Definifition.IsNumeric && Item.Doctrine.CanInheritDoctrine;
		((Control)InheritLabel).Visible = Item.Definifition.IsNumeric && Item.Doctrine.CanInheritDoctrine;
		((Control)Combo_StateSelection).Visible = !Item.Definifition.IsNumeric;
		if (!Item.Definifition.IsNumeric)
		{
			((ComboBox)Combo_StateSelection).Items.Clear();
			((Control)Combo_StateSelection).Refresh();
		}
		else
		{
			((Label)NumericUpDown_UnitLabel).Text = Item.Definifition.MeasurementUnit;
			NumericUpDown.Minimum = new decimal(Item.Definifition.MinNumericValue);
			NumericUpDown.Maximum = new decimal(Item.Definifition.MaxNumericValue);
			NumericUpDown.Increment = Math.Max(new decimal((double)(Item.Definifition.MaxNumericValue - Item.Definifition.MinNumericValue) / 10.0), 1m);
			((Control)NumericUpDown).Enabled = !Item.IsInheriting;
			NumericUpDown.ValueChanged -= method_3;
			NumericUpDown.Value = new decimal(Item.get_CurrentState(ConsiderInheritance: true).Value);
			NumericUpDown.ValueChanged += method_3;
			((CheckBox)InheritCB).CheckedChanged -= method_4;
			((CheckBox)InheritCB).Checked = Item.IsInheriting;
			((CheckBox)InheritCB).CheckedChanged += method_4;
		}
		DoctrineItem = Item;
		if (!string.IsNullOrEmpty(CustomTitle))
		{
			((Label)Title).Text = CustomTitle;
		}
		else
		{
			((Label)Title).Text = Item.Definifition.Name;
		}
		((CheckBox)CB_PlayerEditable).CheckedChanged -= method_2;
		((CheckBox)CB_PlayerEditable).Checked = Item.PlayerEditable;
		((CheckBox)CB_PlayerEditable).CheckedChanged += method_2;
		if (Item.Definifition.IsNumeric)
		{
			return;
		}
		dictionary_0 = new Dictionary<int, int>();
		dictionary_1 = new Dictionary<int, int>();
		int num = 0;
		foreach (KeyValuePair<int, string> state2 in Item.Definifition.States)
		{
			if (Operators.CompareString(state2.Value, "Various", true) != 0 && Operators.CompareString(state2.Value, "Not Configured", true) != 0)
			{
				((ComboBox)Combo_StateSelection).Items.Add((object)state2.Value);
				dictionary_0.Add(num, state2.Key);
				dictionary_1.Add(state2.Key, num);
				num++;
			}
		}
		if ((object)SubjectType != typeof(Side))
		{
			if (Item.Doctrine.MultipleUnitsInherits_State.TryGetValue(Item.Definifition, out var value))
			{
				if (value.HasValue)
				{
					((ComboBox)Combo_StateSelection).Items.Add((object)("Inherited, " + Item.Definifition.States[value.Value].ToString()));
					dictionary_0.Add(num, -999);
					dictionary_1.Add(-999, num);
					num++;
				}
			}
			else
			{
				Doctrine doctrine = DoctrineItem.Doctrine;
				bool UnitIsOperating = true;
				int? num2 = doctrine.GetParentDoctrine(ref UnitIsOperating).GetElement(Item.Definifition).get_CurrentState(ConsiderInheritance: true);
				if (num2.HasValue)
				{
					((ComboBox)Combo_StateSelection).Items.Add((object)("Inherited, " + Item.Definifition.States[num2.Value].ToString()));
					dictionary_0.Add(num, -999);
					dictionary_1.Add(-999, num);
					num++;
				}
			}
		}
		if (Item.get_CurrentState(ConsiderInheritance: false).HasValue && Operators.CompareString(Item.GetStateReadableString(ConsiderInheritance: true), "Various", true) == 0)
		{
			((ComboBox)Combo_StateSelection).Items.Add((object)"Various");
			dictionary_0.Add(num, Item.get_CurrentState(ConsiderInheritance: true).Value);
			dictionary_1.Add(Item.get_CurrentState(ConsiderInheritance: true).Value, num);
			num++;
		}
		int? state = Item.Definifition.GetState("Not Configured");
		if ((object)SubjectType == typeof(Waypoint) && state.HasValue)
		{
			((ComboBox)Combo_StateSelection).Items.Add((object)"Not Configured");
			dictionary_0.Add(num, state.Value);
			dictionary_1.Add(state.Value, num);
			num++;
		}
		ToolTip1.SetToolTip((Control)(object)Title, Item.Definifition.Description);
		int? num3 = Item.get_CurrentState(ConsiderInheritance: false);
		int? num4 = Item.get_CurrentState(ConsiderInheritance: true);
		if (!num3.HasValue)
		{
			if (num4.HasValue && dictionary_1.ContainsKey(-999))
			{
				((ComboBox)Combo_StateSelection).SelectedIndex = dictionary_1[-999];
			}
			else
			{
				int? num5 = num4;
				if ((num5.HasValue ? new bool?(num5 != -1) : ((bool?)null)) == true)
				{
					((ComboBox)Combo_StateSelection).SelectedIndex = dictionary_1[Item.Doctrine.GetElementState(Item.Definifition).Value];
				}
				else if (!state.HasValue)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					((ComboBox)Combo_StateSelection).SelectedIndex = dictionary_1[state.Value];
				}
			}
		}
		else
		{
			((ComboBox)Combo_StateSelection).SelectedIndex = dictionary_1[Item.get_CurrentState(ConsiderInheritance: true).Value];
		}
		((ComboBox)Combo_StateSelection).DropDownWidth = method_5(Combo_StateSelection);
	}

	public void RefreshPanel(string text, DoctrineControl.DoctrineControl_Config? Config = null)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		hashSet_0.Add(this);
		if (Config.HasValue)
		{
			((Control)this).Size = new Size(Config.Value.UC_Size, ((Control)this).Size.Height);
		}
		((Control)this).Visible = true;
		((Label)Title).Text = text;
		((Control)Title).Font = new Font(((Control)Title).Font, (FontStyle)1);
		((Control)Title).Font = new Font(((Control)Title).Font.FontFamily, 10f);
		((Control)CB_PlayerEditable).Visible = false;
		((Control)Combo_StateSelection).Visible = false;
		((Control)NumericUpDown).Visible = false;
		((Control)NumericUpDown_UnitLabel).Visible = false;
		((Control)InheritCB).Visible = false;
		((Control)InheritLabel).Visible = false;
	}

	private void method_0()
	{
		if (Client.Realtime && DoctrineItem != null && DoctrineItem.Doctrine != null)
		{
			Client.RealtimeTerminal.PollForLocalDoctrineStateChange(DoctrineItem.Doctrine, null);
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		int selectedIndex = ((ComboBox)Combo_StateSelection).SelectedIndex;
		if (!dictionary_0.ContainsKey(selectedIndex))
		{
			return;
		}
		int num = dictionary_0[selectedIndex];
		if (num < 0)
		{
			if (num == -999)
			{
				DoctrineItem.set_CurrentState(ConsiderInheritance: false, (int?)null);
			}
		}
		else
		{
			DoctrineItem.set_CurrentState(ConsiderInheritance: false, (int?)num);
		}
		method_0();
	}

	private void method_2(object sender, EventArgs e)
	{
		DoctrineItem.PlayerEditable = ((CheckBox)CB_PlayerEditable).Checked;
		method_0();
	}

	private void method_3(object sender, EventArgs e)
	{
		DoctrineItem.set_CurrentState(ConsiderInheritance: false, (int?)Convert.ToInt32(NumericUpDown.Value));
		method_0();
	}

	private void method_4(object sender, EventArgs e)
	{
		if (DoctrineItem.get_CurrentState(ConsiderInheritance: false).HasValue)
		{
			DoctrineItem.set_CurrentState(ConsiderInheritance: false, (int?)null);
		}
		else
		{
			DoctrineItem.set_CurrentState(ConsiderInheritance: false, (int?)Convert.ToInt32(NumericUpDown.Value));
		}
		method_0();
	}

	public void updateListener()
	{
		RefreshPanel(DoctrineItem, Client.CurrentScenario, OohUiTkEh4, nullable_0);
	}

	private int method_5(DarkUIComboBox darkUIComboBox_1)
	{
		int num = 0;
		foreach (object item in ((ComboBox)darkUIComboBox_1).Items)
		{
			int length = RuntimeHelpers.GetObjectValue(item).ToString().Length;
			num = Math.Max(num, length);
		}
		return num * 6 + 30;
	}
}
