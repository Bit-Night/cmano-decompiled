using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitFilter : DarkUserControl
{
	[CompilerGenerated]
	internal sealed class _Closure$__67-0
	{
		public int $VB$Local_TargetUnitClass_DBID;

		public string $VB$Local_TargetSide_ObjectID;

		public UnitFilter $VB$Me;

		public _Closure$__67-0(_Closure$__67-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TargetUnitClass_DBID = arg0.$VB$Local_TargetUnitClass_DBID;
				$VB$Local_TargetSide_ObjectID = arg0.$VB$Local_TargetSide_ObjectID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theAU)
		{
			return !theAU.IsGroup & (theAU.DBID == $VB$Local_TargetUnitClass_DBID);
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit theAU)
		{
			return Operators.CompareString(theAU.get_UnitSide(SetSideOnly: false).ObjectID, $VB$Local_TargetSide_ObjectID, true) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__4(ActiveUnit theAU)
		{
			return !theAU.IsGroup & (theAU.UnitType == $VB$Me.TargetType) & (theAU.DBID == $VB$Local_TargetUnitClass_DBID);
		}

		[SpecialName]
		internal bool _Lambda$__7(ActiveUnit theAU)
		{
			return Operators.CompareString(theAU.get_UnitSide(SetSideOnly: false).ObjectID, $VB$Local_TargetSide_ObjectID, true) == 0;
		}

		static _Closure$__67-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetSide")]
	private DarkUIComboBox _CB_TargetSide;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetType")]
	private DarkUIComboBox _CB_TargetType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetSubtype")]
	private DarkUIComboBox _CB_TargetSubtype;

	[AccessedThroughProperty("CB_TargetUnitClass")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_TargetUnitClass;

	[AccessedThroughProperty("CB_SpecificUnit")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_SpecificUnit;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowAllTypes")]
	private DarkCheckBox _CB_ShowAllTypes;

	private UnitFilterObject unitFilterObject_0;

	private HashSet<Weapon> hashSet_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIComboBox CB_TargetSide
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetSide;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIComboBox darkUIComboBox = _CB_TargetSide;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_TargetSide = value;
			darkUIComboBox = _CB_TargetSide;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkUIComboBox CB_TargetType
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIComboBox darkUIComboBox = _CB_TargetType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_TargetType = value;
			darkUIComboBox = _CB_TargetType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetSubtype
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetSubtype;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _CB_TargetSubtype;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_TargetSubtype = value;
			darkUIComboBox = _CB_TargetSubtype;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetUnitClass
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetUnitClass;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIComboBox darkUIComboBox = _CB_TargetUnitClass;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_TargetUnitClass = value;
			darkUIComboBox = _CB_TargetUnitClass;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_SpecificUnit
	{
		[CompilerGenerated]
		get
		{
			return _CB_SpecificUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIComboBox darkUIComboBox = _CB_SpecificUnit;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_SpecificUnit = value;
			darkUIComboBox = _CB_SpecificUnit;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ShowAllTypes
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowAllTypes;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkCheckBox darkCheckBox = _CB_ShowAllTypes;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_ShowAllTypes = value;
			darkCheckBox = _CB_ShowAllTypes;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	public GlobalVariables.ActiveUnitType TargetType => (GlobalVariables.ActiveUnitType)((ComboBox)CB_TargetType).SelectedIndex;

	public int TargetSubType
	{
		get
		{
			switch (((ComboBox)CB_TargetType).SelectedIndex)
			{
			case 0:
				return 0;
			case 1:
				return Conversions.ToInteger(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			case 2:
				return Conversions.ToInteger(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			case 3:
				return Conversions.ToInteger(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			case 4:
				return Conversions.ToShort(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			default:
			{
				int result;
				if (!Debugger.IsAttached)
				{
					result = 0;
				}
				else
				{
					Debugger.Break();
					result = 0;
				}
				return result;
			}
			case 6:
				return Conversions.ToShort(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			case 7:
				return Conversions.ToInteger(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			case 8:
				return Conversions.ToInteger(NewLateBinding.LateGet(((ListControl)CB_TargetSubtype).SelectedValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			}
		}
	}

	public string SpecificUnitClass => Conversions.ToString(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_TargetUnitClass).SelectedItem).Tag);

	public ActiveUnit SpecificUnit
	{
		get
		{
			int selectedIndex = ((ComboBox)CB_SpecificUnit).SelectedIndex;
			if (selectedIndex == 0)
			{
				return null;
			}
			if (selectedIndex > 0)
			{
				return (ActiveUnit)NewLateBinding.LateGet(((ComboBox)CB_SpecificUnit).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null);
			}
			return null;
		}
	}

	public string TargetSide
	{
		get
		{
			if (((ComboBox)CB_TargetSide).SelectedIndex == 0)
			{
				return "";
			}
			return Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
	}

	public UnitFilterObject FilterObject
	{
		get
		{
			return unitFilterObject_0;
		}
		set
		{
			bool num = value != unitFilterObject_0;
			unitFilterObject_0 = value;
			if (num)
			{
				method_1();
			}
		}
	}

	public UnitFilter()
	{
		((UserControl)this).Load += UnitFilter_Load;
		hashSet_0 = new HashSet<Weapon>();
		InitializeComponent();
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

	private void InitializeComponent()
	{
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Expected O, but got Unknown
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		CB_ShowAllTypes = new DarkCheckBox();
		CB_SpecificUnit = new DarkUIComboBox();
		CB_TargetUnitClass = new DarkUIComboBox();
		CB_TargetSubtype = new DarkUIComboBox();
		CB_TargetType = new DarkUIComboBox();
		CB_TargetSide = new DarkUIComboBox();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(13, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(84, 17);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Target side:";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(13, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(85, 17);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = "Target type:";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(13, 104);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(108, 17);
		((Control)Label3).TabIndex = 3;
		((Label)Label3).Text = "Target subtype:";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(13, 136);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(90, 17);
		((Control)Label4).TabIndex = 4;
		((Label)Label4).Text = "Target class:";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(13, 171);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(88, 17);
		((Control)Label5).TabIndex = 5;
		((Label)Label5).Text = "Specific unit:";
		((ButtonBase)CB_ShowAllTypes).AutoSize = true;
		((Control)CB_ShowAllTypes).Location = new Point(102, 74);
		((Control)CB_ShowAllTypes).Name = "CB_ShowAllTypes";
		((Control)CB_ShowAllTypes).Size = new Size(121, 21);
		((Control)CB_ShowAllTypes).TabIndex = 10;
		((ButtonBase)CB_ShowAllTypes).Text = "Show All types";
		((ComboBox)CB_SpecificUnit).BackColor = Color.Transparent;
		((ComboBox)CB_SpecificUnit).DrawMode = (DrawMode)1;
		((ComboBox)CB_SpecificUnit).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SpecificUnit).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_SpecificUnit).FormattingEnabled = true;
		((Control)CB_SpecificUnit).Location = new Point(102, 168);
		((Control)CB_SpecificUnit).Name = "CB_SpecificUnit";
		((Control)CB_SpecificUnit).Size = new Size(196, 24);
		((Control)CB_SpecificUnit).TabIndex = 9;
		((ComboBox)CB_TargetUnitClass).BackColor = Color.Transparent;
		((ComboBox)CB_TargetUnitClass).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetUnitClass).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetUnitClass).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetUnitClass).FormattingEnabled = true;
		((Control)CB_TargetUnitClass).Location = new Point(102, 133);
		((Control)CB_TargetUnitClass).Name = "CB_TargetUnitClass";
		((Control)CB_TargetUnitClass).Size = new Size(196, 24);
		((Control)CB_TargetUnitClass).TabIndex = 8;
		((ComboBox)CB_TargetSubtype).BackColor = Color.Transparent;
		((ComboBox)CB_TargetSubtype).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetSubtype).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetSubtype).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetSubtype).FormattingEnabled = true;
		((Control)CB_TargetSubtype).Location = new Point(102, 101);
		((Control)CB_TargetSubtype).Name = "CB_TargetSubtype";
		((Control)CB_TargetSubtype).Size = new Size(196, 24);
		((Control)CB_TargetSubtype).TabIndex = 7;
		((ComboBox)CB_TargetType).BackColor = Color.Transparent;
		((ComboBox)CB_TargetType).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetType).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetType).FormattingEnabled = true;
		((ComboBox)CB_TargetType).Items.AddRange(new object[9] { "None", "Aircraft", "Surface Ship", "Submarine", "Land facility", "-------", "Weapon", "Satellite", "Ground Units" });
		((Control)CB_TargetType).Location = new Point(102, 43);
		((Control)CB_TargetType).Name = "CB_TargetType";
		((Control)CB_TargetType).Size = new Size(196, 24);
		((Control)CB_TargetType).TabIndex = 6;
		((ComboBox)CB_TargetSide).BackColor = Color.Transparent;
		((ComboBox)CB_TargetSide).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetSide).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetSide).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_TargetSide).FormattingEnabled = true;
		((Control)CB_TargetSide).Location = new Point(102, 10);
		((Control)CB_TargetSide).Name = "CB_TargetSide";
		((Control)CB_TargetSide).Size = new Size(196, 24);
		((Control)CB_TargetSide).TabIndex = 1;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)CB_ShowAllTypes);
		((Control)this).Controls.Add((Control)(object)CB_SpecificUnit);
		((Control)this).Controls.Add((Control)(object)CB_TargetUnitClass);
		((Control)this).Controls.Add((Control)(object)CB_TargetSubtype);
		((Control)this).Controls.Add((Control)(object)CB_TargetType);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)CB_TargetSide);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Name = "UnitFilter";
		((Control)this).Size = new Size(311, 215);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_1()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		if (Client.CurrentScenario == null || unitFilterObject_0 == null)
		{
			return;
		}
		((ComboBox)CB_TargetSide).BeginUpdate();
		((ComboBox)CB_TargetSide).Items.Clear();
		((ListControl)CB_TargetSide).DisplayMember = "Content";
		((CheckBox)CB_ShowAllTypes).Checked = unitFilterObject_0.ShowAllTypes;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			ComboBoxItem val = new ComboBoxItem();
			if (((ComboBox)CB_TargetSide).Items.Count == 0)
			{
				ComboBoxItem val2 = new ComboBoxItem();
				((ContentControl)val2).Content = "Any Side";
				((FrameworkElement)val2).Tag = null;
				((ComboBox)CB_TargetSide).Items.Add((object)val2);
			}
			((ContentControl)val).Content = side.Name;
			((FrameworkElement)val).Tag = side.ObjectID;
			((ComboBox)CB_TargetSide).Items.Add((object)val);
		}
		((ComboBox)CB_TargetSide).EndUpdate();
		if (string.IsNullOrEmpty(unitFilterObject_0.TargetSide))
		{
			((ComboBox)CB_TargetSide).SelectedIndex = 0;
		}
		else
		{
			foreach (ComboBoxItem item in ((ComboBox)CB_TargetSide).Items)
			{
				ComboBoxItem val3 = item;
				if (Operators.CompareString(Conversions.ToString(((FrameworkElement)val3).Tag), unitFilterObject_0.TargetSide, true) == 0)
				{
					((ComboBox)CB_TargetSide).SelectedItem = val3;
					break;
				}
			}
			if (((ComboBox)CB_TargetSide).SelectedItem == null)
			{
				return;
			}
		}
		if (unitFilterObject_0.TargetType == GlobalVariables.ActiveUnitType.None)
		{
			((ComboBox)CB_TargetType).SelectedIndex = 0;
			method_2(bool_0: true);
			method_3(bool_0: true);
			method_4(bool_0: true);
			return;
		}
		((ComboBox)CB_TargetType).SelectedIndex = (int)unitFilterObject_0.TargetType;
		method_2();
		foreach (ComboBoxItem item2 in ((ComboBox)CB_TargetSubtype).Items)
		{
			ComboBoxItem val4 = item2;
			if (unitFilterObject_0.TargetSubType == Conversions.ToInteger(((FrameworkElement)val4).Tag))
			{
				((ComboBox)CB_TargetSubtype).SelectedItem = val4;
				break;
			}
		}
		if (((ComboBox)CB_TargetSubtype).SelectedItem == null)
		{
			return;
		}
		method_3();
		foreach (ComboBoxItem item3 in ((ComboBox)CB_TargetUnitClass).Items)
		{
			ComboBoxItem val5 = item3;
			if (unitFilterObject_0.SpecificUnitClass == Conversions.ToInteger(((FrameworkElement)val5).Tag))
			{
				((ComboBox)CB_TargetUnitClass).SelectedItem = val5;
				break;
			}
		}
		if (((ComboBox)CB_TargetUnitClass).SelectedItem == null)
		{
			return;
		}
		method_4();
		if (((ComboBox)CB_TargetSubtype).Items.Count == 1)
		{
			unitFilterObject_0.TargetSubType = 0;
		}
		if (((ComboBox)CB_TargetUnitClass).Items.Count == 1)
		{
			unitFilterObject_0.SpecificUnitClass = 0;
		}
		int num;
		if (((ComboBox)CB_SpecificUnit).Items.Count == 1)
		{
			unitFilterObject_0.SpecificUnitID = null;
			num = 0;
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		if (unitFilterObject_0.SpecificUnitID != null)
		{
			foreach (ComboBoxItem item4 in ((ComboBox)CB_SpecificUnit).Items)
			{
				ComboBoxItem val6 = item4;
				if (((FrameworkElement)val6).Tag != null && Operators.CompareString(unitFilterObject_0.SpecificUnitID, ((ScenarioObject)((FrameworkElement)val6).Tag).ObjectID, true) == 0)
				{
					((ComboBox)CB_SpecificUnit).SelectedItem = val6;
					flag = true;
					break;
				}
			}
		}
		if (!flag & (unitFilterObject_0.SpecificUnitID != null))
		{
			ComboBoxItem val7 = new ComboBoxItem();
			((ContentControl)val7).Content = unitFilterObject_0.SpecificUnitID + " [NOT FOUND!]";
			((FrameworkElement)val7).Tag = unitFilterObject_0.SpecificUnitID;
			((ComboBox)CB_SpecificUnit).Items.Add((object)val7);
			((ComboBox)CB_SpecificUnit).SelectedItem = val7;
			DarkMessageBox.ShowError("The specific unit does not exist in this scenario. Please select another unit.", "Error");
		}
	}

	private void UnitFilter_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_2(bool bool_0 = false)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0931: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Expected O, but got Unknown
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_0e5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e64: Expected O, but got Unknown
		//IL_1067: Unknown result type (might be due to invalid IL or missing references)
		//IL_106e: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Expected O, but got Unknown
		//IL_0da4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dab: Expected O, but got Unknown
		//IL_0fb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbf: Expected O, but got Unknown
		//IL_0c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Expected O, but got Unknown
		((ComboBox)CB_TargetSubtype).BeginUpdate();
		((ComboBox)CB_TargetSubtype).Items.Clear();
		((ListControl)CB_TargetSubtype).DisplayMember = "Content";
		ComboBoxItem val = new ComboBoxItem();
		((ContentControl)val).Content = "None";
		((ComboBox)CB_TargetSubtype).Items.Add((object)val);
		if (!bool_0)
		{
			switch (unitFilterObject_0.TargetType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				if (unitFilterObject_0.ShowAllTypes)
				{
					((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
					foreach (object value in Enum.GetValues(typeof(Aircraft._AircraftType)))
					{
						Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(value);
						string text4 = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
						if (string.IsNullOrEmpty(text4))
						{
							text4 = aircraftType.ToString();
						}
						ComboBoxItem val10 = new ComboBoxItem();
						((ContentControl)val10).Content = text4;
						((FrameworkElement)val10).Tag = aircraftType;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val10);
					}
					break;
				}
				IEnumerable<ActiveUnit> source4 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsAircraft
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					source4 = source4.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				IEnumerable<Aircraft._AircraftType> enumerable7 = source4.Select([SpecialName] (ActiveUnit theAC) => ((Aircraft)theAC).Type).Distinct();
				foreach (Aircraft._AircraftType item in enumerable7)
				{
					ComboBoxItem val11 = new ComboBoxItem();
					((ContentControl)val11).Content = item.ToString();
					((FrameworkElement)val11).Tag = item;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val11);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Ship:
				if (!unitFilterObject_0.ShowAllTypes)
				{
					IEnumerable<ActiveUnit> source5 = from theAU in Client.CurrentScenario.ActiveUnits.Values
						where theAU.IsShip
						select (theAU);
					if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
					{
						source5 = source5.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
					}
					IEnumerable<Ship._ShipType> enumerable8 = source5.Select([SpecialName] (ActiveUnit theAU) => ((Ship)theAU).Type).Distinct();
					foreach (Ship._ShipType item2 in enumerable8)
					{
						ComboBoxItem val12 = new ComboBoxItem();
						((ContentControl)val12).Content = item2.ToString();
						((FrameworkElement)val12).Tag = item2;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val12);
					}
					break;
				}
				((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
				foreach (object value2 in Enum.GetValues(typeof(Ship._ShipType)))
				{
					Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(value2);
					string text5 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(text5))
					{
						text5 = shipType.ToString();
					}
					ComboBoxItem val13 = new ComboBoxItem();
					((ContentControl)val13).Content = text5;
					((FrameworkElement)val13).Tag = shipType;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val13);
				}
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				if (!unitFilterObject_0.ShowAllTypes)
				{
					IEnumerable<ActiveUnit> source2 = from theAU in Client.CurrentScenario.ActiveUnits.Values
						where theAU.IsSubmarine
						select (theAU);
					if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
					{
						source2 = source2.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
					}
					IEnumerable<Submarine._SubmarineType> enumerable2 = source2.Select([SpecialName] (ActiveUnit theAU) => ((Submarine)theAU).Type).Distinct();
					foreach (Submarine._SubmarineType item3 in enumerable2)
					{
						ComboBoxItem val4 = new ComboBoxItem();
						((ContentControl)val4).Content = item3.ToString();
						((FrameworkElement)val4).Tag = item3;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val4);
					}
					break;
				}
				((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
				foreach (object value3 in Enum.GetValues(typeof(Submarine._SubmarineType)))
				{
					Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(value3);
					string text2 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(text2))
					{
						text2 = submarineType.ToString();
					}
					ComboBoxItem val5 = new ComboBoxItem();
					((ContentControl)val5).Content = text2;
					((FrameworkElement)val5).Tag = submarineType;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val5);
				}
				break;
			case GlobalVariables.ActiveUnitType.Facility:
			{
				if (unitFilterObject_0.ShowAllTypes)
				{
					((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
					foreach (object value4 in Enum.GetValues(typeof(Facility._FacilityCategory)))
					{
						Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(value4);
						string text6 = Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection);
						if (string.IsNullOrEmpty(text6))
						{
							text6 = facilityCategory.ToString();
						}
						ComboBoxItem val14 = new ComboBoxItem();
						((ContentControl)val14).Content = text6;
						((FrameworkElement)val14).Tag = facilityCategory;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val14);
					}
					break;
				}
				IEnumerable<ActiveUnit> source6 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsFacility
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					source6 = source6.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				IEnumerable<Facility._FacilityCategory> enumerable9 = source6.Select([SpecialName] (ActiveUnit theAU) => ((Facility)theAU).Category).Distinct();
				foreach (Facility._FacilityCategory item4 in enumerable9)
				{
					ComboBoxItem val15 = new ComboBoxItem();
					((ContentControl)val15).Content = item4.ToString();
					((FrameworkElement)val15).Tag = item4;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val15);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Weapon:
			{
				if (unitFilterObject_0.ShowAllTypes)
				{
					((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
					foreach (object value5 in Enum.GetValues(typeof(Weapon._WeaponType)))
					{
						Weapon._WeaponType weaponType = (Weapon._WeaponType)Conversions.ToShort(value5);
						ComboBoxItem val8 = new ComboBoxItem();
						((ContentControl)val8).Content = weaponType.ToString();
						((FrameworkElement)val8).Tag = weaponType;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val8);
					}
					break;
				}
				hashSet_0.Clear();
				IEnumerable<ActiveUnit> enumerable4 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsActiveUnit
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable4 = enumerable4.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item5 in enumerable4)
				{
					if (!item5.IsWeapon && !item5.IsWaypoint)
					{
						if (item5.IsAircraft)
						{
							WRA_RetreiveMountWeapons(item5);
							WRA_RetreiveLoadoutWeapons(item5);
						}
						else if (item5.IsShip || item5.IsSubmarine || item5.IsFacility)
						{
							WRA_RetreiveMountWeapons(item5);
							WRA_RetreiveMagazineWeapons(item5);
						}
					}
				}
				IEnumerable<UnguidedWeapon> enumerable5 = from theUW in Client.CurrentScenario.UnguidedWeapons.Values
					where theUW.IsMine
					select (theUW);
				if (enumerable5.Count() > 0)
				{
					if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
					{
						enumerable5 = enumerable5.Where([SpecialName] (UnguidedWeapon theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
					}
					foreach (UnguidedWeapon item6 in enumerable5)
					{
						WRA_RetreiveUnguidedWeapons(item6);
					}
				}
				if (hashSet_0.Count <= 0)
				{
					break;
				}
				IEnumerable<Weapon._WeaponType> enumerable6 = from s in hashSet_0.Select([SpecialName] (Weapon theW) => theW.Type).Distinct()
					orderby s.ToString()
					select s;
				foreach (Weapon._WeaponType item7 in enumerable6)
				{
					ComboBoxItem val9 = new ComboBoxItem();
					((ContentControl)val9).Content = item7.ToString();
					((FrameworkElement)val9).Tag = item7;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val9);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Satellite:
				if (!unitFilterObject_0.ShowAllTypes)
				{
					IEnumerable<ActiveUnit> source3 = from theAU in Client.CurrentScenario.ActiveUnits.Values
						where theAU.IsSatellite
						select (theAU);
					if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
					{
						source3 = source3.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
					}
					IEnumerable<Satellite._SatelliteType> enumerable3 = source3.Select([SpecialName] (ActiveUnit theAU) => ((Satellite)theAU).Type).Distinct();
					foreach (Satellite._SatelliteType item8 in enumerable3)
					{
						ComboBoxItem val6 = new ComboBoxItem();
						((ContentControl)val6).Content = item8.ToString();
						((FrameworkElement)val6).Tag = item8;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val6);
					}
					break;
				}
				((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
				foreach (object value6 in Enum.GetValues(typeof(Satellite._SatelliteType)))
				{
					Satellite._SatelliteType satelliteType = (Satellite._SatelliteType)Conversions.ToInteger(value6);
					string text3 = Misc.Description(satelliteType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(text3))
					{
						text3 = satelliteType.ToString();
					}
					ComboBoxItem val7 = new ComboBoxItem();
					((ContentControl)val7).Content = text3;
					((FrameworkElement)val7).Tag = satelliteType;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val7);
				}
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				if (!unitFilterObject_0.ShowAllTypes)
				{
					IEnumerable<ActiveUnit> source = from theAU in Client.CurrentScenario.ActiveUnits.Values
						where theAU.IsMobileGroundUnit
						select (theAU);
					if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
					{
						source = source.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
					}
					IEnumerable<IMobileGroundUnit._MobileUnitCategory> enumerable = source.Select([SpecialName] (ActiveUnit theAU) => ((IMobileGroundUnit)theAU).MobileUnitCategory).Distinct();
					foreach (IMobileGroundUnit._MobileUnitCategory item9 in enumerable)
					{
						ComboBoxItem val2 = new ComboBoxItem();
						((ContentControl)val2).Content = item9.ToString();
						((FrameworkElement)val2).Tag = item9;
						((ComboBox)CB_TargetSubtype).Items.Add((object)val2);
					}
					break;
				}
				((ComboBox)CB_TargetSubtype).Items.Remove((object)val);
				foreach (object value7 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
				{
					IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(value7);
					string text = Misc.ToEnglishString(mobileUnitCategory);
					if (string.IsNullOrEmpty(text))
					{
						text = mobileUnitCategory.ToString();
					}
					ComboBoxItem val3 = new ComboBoxItem();
					((ContentControl)val3).Content = text;
					((FrameworkElement)val3).Tag = mobileUnitCategory;
					((ComboBox)CB_TargetSubtype).Items.Add((object)val3);
				}
				break;
			}
		}
		if (((ComboBox)CB_TargetSubtype).Items.Count == 0)
		{
			((ComboBox)CB_TargetSubtype).Items.Add((object)val);
		}
		((ComboBox)CB_TargetSubtype).EndUpdate();
		((ComboBox)CB_TargetSubtype).SelectedIndex = 0;
	}

	private void method_3(bool bool_0 = false)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		((ComboBox)CB_TargetUnitClass).BeginUpdate();
		((ComboBox)CB_TargetUnitClass).Items.Clear();
		((ListControl)CB_TargetUnitClass).DisplayMember = "Content";
		ComboBoxItem val = new ComboBoxItem();
		((ContentControl)val).Content = "None";
		((ComboBox)CB_TargetUnitClass).Items.Add((object)val);
		if (!bool_0)
		{
			HashSet<int> hashSet = new HashSet<int>();
			switch (((ComboBox)CB_TargetType).SelectedIndex)
			{
			case 1:
			{
				IEnumerable<ActiveUnit> enumerable5 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsAircraft
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable5 = enumerable5.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item in enumerable5)
				{
					if (((Aircraft)item).Type == (Aircraft._AircraftType)Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item.DBID))
					{
						hashSet.Add(item.DBID);
						ComboBoxItem val7 = new ComboBoxItem();
						((ContentControl)val7).Content = item.UnitClass;
						((FrameworkElement)val7).Tag = item.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val7);
					}
				}
				break;
			}
			case 2:
			{
				IEnumerable<ActiveUnit> enumerable3 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsShip
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable3 = enumerable3.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item2 in enumerable3)
				{
					if (((Ship)item2).Type == (Ship._ShipType)Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item2.DBID))
					{
						hashSet.Add(item2.DBID);
						ComboBoxItem val4 = new ComboBoxItem();
						((ContentControl)val4).Content = item2.UnitClass;
						((FrameworkElement)val4).Tag = item2.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val4);
					}
				}
				break;
			}
			case 3:
			{
				IEnumerable<ActiveUnit> enumerable2 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsSubmarine
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable2 = enumerable2.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item3 in enumerable2)
				{
					if (((Submarine)item3).Type == (Submarine._SubmarineType)Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item3.DBID))
					{
						hashSet.Add(item3.DBID);
						ComboBoxItem val3 = new ComboBoxItem();
						((ContentControl)val3).Content = item3.UnitClass;
						((FrameworkElement)val3).Tag = item3.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val3);
					}
				}
				break;
			}
			case 4:
			{
				IEnumerable<ActiveUnit> enumerable4 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsFacility
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable4 = enumerable4.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item4 in enumerable4)
				{
					if ((int)((Facility)item4).Category == Conversions.ToShort(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item4.DBID))
					{
						hashSet.Add(item4.DBID);
						ComboBoxItem val6 = new ComboBoxItem();
						((ContentControl)val6).Content = item4.UnitClass;
						((FrameworkElement)val6).Tag = item4.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val6);
					}
				}
				break;
			}
			case 6:
			{
				IOrderedEnumerable<Weapon> orderedEnumerable = hashSet_0.OrderBy([SpecialName] (Weapon s) => s.Name);
				if (orderedEnumerable.Count() <= 0)
				{
					break;
				}
				foreach (Weapon item5 in orderedEnumerable)
				{
					if ((int)item5.Type == Conversions.ToShort(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item5.DBID))
					{
						hashSet.Add(item5.DBID);
						ComboBoxItem val5 = new ComboBoxItem();
						((ContentControl)val5).Content = item5.Name;
						((FrameworkElement)val5).Tag = item5.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val5);
					}
				}
				break;
			}
			case 7:
			{
				IEnumerable<ActiveUnit> enumerable6 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsSatellite
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable6 = enumerable6.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item6 in enumerable6)
				{
					if (((Satellite)item6).Type == (Satellite._SatelliteType)Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item6.DBID))
					{
						hashSet.Add(item6.DBID);
						ComboBoxItem val8 = new ComboBoxItem();
						((ContentControl)val8).Content = item6.UnitClass;
						((FrameworkElement)val8).Tag = item6.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val8);
					}
				}
				break;
			}
			case 8:
			{
				IEnumerable<ActiveUnit> enumerable = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsMobileGroundUnit
					select (theAU);
				if (((ComboBox)CB_TargetSide).SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					enumerable = enumerable.Where([SpecialName] (ActiveUnit theAU) => Operators.ConditionalCompareObjectEqual((object)theAU.get_UnitSide(SetSideOnly: false).ObjectID, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null), true));
				}
				foreach (ActiveUnit item7 in enumerable)
				{
					if (((IMobileGroundUnit)item7).MobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)) && !hashSet.Contains(item7.DBID))
					{
						hashSet.Add(item7.DBID);
						ComboBoxItem val2 = new ComboBoxItem();
						((ContentControl)val2).Content = item7.UnitClass;
						((FrameworkElement)val2).Tag = item7.DBID;
						((ComboBox)CB_TargetUnitClass).Items.Add((object)val2);
					}
				}
				break;
			}
			}
		}
		((ComboBox)CB_TargetUnitClass).EndUpdate();
		((ComboBox)CB_TargetUnitClass).SelectedIndex = 0;
	}

	private void method_4(bool bool_0 = false)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		((ComboBox)CB_SpecificUnit).BeginUpdate();
		((ComboBox)CB_SpecificUnit).Items.Clear();
		((ListControl)CB_SpecificUnit).DisplayMember = "Content";
		ComboBoxItem val = new ComboBoxItem();
		((ContentControl)val).Content = "None";
		((ComboBox)CB_SpecificUnit).Items.Add((object)val);
		if (!bool_0)
		{
			_Closure$__67-0 arg = default(_Closure$__67-0);
			_Closure$__67-0 CS$<>8__locals12 = new _Closure$__67-0(arg);
			CS$<>8__locals12.$VB$Me = this;
			CS$<>8__locals12.$VB$Local_TargetSide_ObjectID = "";
			if (((ComboBox)CB_TargetSide).SelectedItem != null && NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null) != null)
			{
				CS$<>8__locals12.$VB$Local_TargetSide_ObjectID = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			}
			CS$<>8__locals12.$VB$Local_TargetUnitClass_DBID = 0;
			if (((ComboBox)CB_TargetUnitClass).SelectedItem != null && ((FrameworkElement)(ComboBoxItem)((ComboBox)CB_TargetUnitClass).SelectedItem).Tag != null)
			{
				CS$<>8__locals12.$VB$Local_TargetUnitClass_DBID = Conversions.ToInteger(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_TargetUnitClass).SelectedItem).Tag);
			}
			switch (unitFilterObject_0.TargetType)
			{
			case GlobalVariables.ActiveUnitType.Aimpoint:
			{
				IEnumerable<ActiveUnit> enumerable2 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where !theAU.IsGroup & (theAU.DBID == CS$<>8__locals12.$VB$Local_TargetUnitClass_DBID)
					select (theAU) into theAU
					orderby theAU.Name
					select theAU;
				if (!string.IsNullOrEmpty(CS$<>8__locals12.$VB$Local_TargetSide_ObjectID))
				{
					enumerable2 = enumerable2.Where([SpecialName] (ActiveUnit theAU) => Operators.CompareString(theAU.get_UnitSide(SetSideOnly: false).ObjectID, CS$<>8__locals12.$VB$Local_TargetSide_ObjectID, true) == 0);
				}
				foreach (ActiveUnit item in enumerable2)
				{
					ComboBoxItem val3 = new ComboBoxItem();
					((ContentControl)val3).Content = item.Name;
					((FrameworkElement)val3).Tag = item;
					((ComboBox)CB_SpecificUnit).Items.Add((object)val3);
				}
				break;
			}
			default:
			{
				IEnumerable<ActiveUnit> enumerable = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where !theAU.IsGroup & (theAU.UnitType == CS$<>8__locals12.$VB$Me.TargetType) & (theAU.DBID == CS$<>8__locals12.$VB$Local_TargetUnitClass_DBID)
					select (theAU) into theAU
					orderby theAU.Name
					select theAU;
				if (!string.IsNullOrEmpty(CS$<>8__locals12.$VB$Local_TargetSide_ObjectID))
				{
					enumerable = enumerable.Where([SpecialName] (ActiveUnit theAU) => Operators.CompareString(theAU.get_UnitSide(SetSideOnly: false).ObjectID, CS$<>8__locals12.$VB$Local_TargetSide_ObjectID, true) == 0);
				}
				foreach (ActiveUnit item2 in enumerable)
				{
					ComboBoxItem val2 = new ComboBoxItem();
					((ContentControl)val2).Content = item2.Name;
					((FrameworkElement)val2).Tag = item2;
					((ComboBox)CB_SpecificUnit).Items.Add((object)val2);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.None:
				break;
			}
		}
		((ComboBox)CB_SpecificUnit).EndUpdate();
		((ComboBox)CB_SpecificUnit).SelectedIndex = 0;
	}

	private void method_5(object sender, EventArgs e)
	{
		GlobalVariables.ActiveUnitType activeUnitType = unitFilterObject_0.TargetType;
		switch (((ComboBox)CB_TargetType).SelectedIndex)
		{
		case 0:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.None;
			break;
		case 1:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Aircraft;
			break;
		case 2:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Ship;
			break;
		case 3:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Submarine;
			break;
		case 4:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Facility;
			break;
		case 5:
			activeUnitType = GlobalVariables.ActiveUnitType.None;
			break;
		case 6:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Weapon;
			break;
		case 7:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Satellite;
			break;
		case 8:
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.Vehicle;
			break;
		}
		if (unitFilterObject_0.TargetType != activeUnitType)
		{
			unitFilterObject_0.TargetSubType = 0;
			unitFilterObject_0.SpecificUnitClass = 0;
			unitFilterObject_0.SpecificUnitID = null;
			if (Operators.CompareString(((Control)((ContainerControl)this).ParentForm).Name, "EditTrigger", true) == 0 && ((EditTrigger)(object)((ContainerControl)this).ParentForm).TabPage10.Visible)
			{
				((ComboBox)((EditTrigger)(object)((ContainerControl)this).ParentForm).CB_BaseStatusCheck_Condition).Items.Clear();
				((EventTrigger_UnitBaseStatus)((EditTrigger)(object)((ContainerControl)this).ParentForm).theTrigger).TargetCondition = null;
			}
			method_1();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (((ComboBox)CB_TargetSubtype).Items.Count != 0 && Operators.ConditionalCompareObjectNotEqual((object)unitFilterObject_0.TargetSubType, NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null), true))
		{
			unitFilterObject_0.TargetSubType = Conversions.ToInteger(NewLateBinding.LateGet(((ComboBox)CB_TargetSubtype).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			unitFilterObject_0.SpecificUnitClass = 0;
			unitFilterObject_0.SpecificUnitID = null;
			method_1();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)CB_TargetUnitClass).Items.Count != 0 && unitFilterObject_0.SpecificUnitClass != Conversions.ToInteger(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_TargetUnitClass).SelectedItem).Tag))
		{
			unitFilterObject_0.SpecificUnitClass = Conversions.ToInteger(((FrameworkElement)(ComboBoxItem)((ComboBox)CB_TargetUnitClass).SelectedItem).Tag);
			unitFilterObject_0.SpecificUnitID = null;
			method_1();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (Operators.ConditionalCompareObjectNotEqual((object)unitFilterObject_0.TargetSide, NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null), true))
		{
			unitFilterObject_0.TargetSide = Conversions.ToString(NewLateBinding.LateGet(((ComboBox)CB_TargetSide).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null));
			unitFilterObject_0.TargetType = GlobalVariables.ActiveUnitType.None;
			unitFilterObject_0.TargetSubType = 0;
			unitFilterObject_0.SpecificUnitClass = 0;
			unitFilterObject_0.SpecificUnitID = null;
			method_1();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (NewLateBinding.LateGet(((ComboBox)CB_SpecificUnit).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null) is ActiveUnit)
		{
			unitFilterObject_0.SpecificUnitID = ((ActiveUnit)NewLateBinding.LateGet(((ComboBox)CB_SpecificUnit).SelectedItem, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null)).ObjectID;
		}
		else
		{
			unitFilterObject_0.SpecificUnitID = null;
		}
	}

	public void WRA_RetreiveLoadoutWeapons(ActiveUnit theUnit)
	{
		if (!Information.IsNothing((object)((Aircraft)theUnit).Loadout))
		{
			WeaponRec[] weapons = ((Aircraft)theUnit).Loadout.Weapons;
			for (int i = 0; i < weapons.Length; i = checked(i + 1))
			{
				Weapon theWeapon = weapons[i].get_ReferenceWeapon(Client.CurrentScenario);
				WRA_AddWeapon(ref theWeapon);
			}
		}
	}

	public void WRA_RetreiveMagazineWeapons(ActiveUnit theUnit)
	{
		IEnumerable<Magazine> enumerable = theUnit.SharedMagazines.OrderBy([SpecialName] (Magazine theM) => theM.Name);
		foreach (Magazine item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon theWeapon = weapon.get_ReferenceWeapon(Client.CurrentScenario);
				WRA_AddWeapon(ref theWeapon);
			}
		}
	}

	public void WRA_RetreiveMountWeapons(ActiveUnit theUnit)
	{
		IEnumerable<Mount> enumerable = theUnit.Mounts.OrderBy([SpecialName] (Mount theM) => theM.Name);
		foreach (Mount item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon theWeapon = mountWeapon.get_ReferenceWeapon(Client.CurrentScenario);
				WRA_AddWeapon(ref theWeapon);
			}
		}
	}

	public void WRA_RetreiveUnguidedWeapons(UnguidedWeapon theUnit)
	{
		Weapon theWeapon = theUnit.ReferenceWeapon;
		WRA_AddWeapon(ref theWeapon);
	}

	public void WRA_AddWeapon(ref Weapon theWeapon)
	{
		if (!hashSet_0.Contains(theWeapon))
		{
			hashSet_0.Add(theWeapon);
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		unitFilterObject_0.ShowAllTypes = ((CheckBox)CB_ShowAllTypes).Checked;
		method_2();
	}

	static UnitFilter()
	{
		Class72.smethod_20();
	}
}
