using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class AGU_Control : Form
{
	[CompilerGenerated]
	internal sealed class _Closure$__52-0
	{
		public DarkUIRadioButton $VB$Local_TheButton;

		public _Closure$__52-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__52-0(_Closure$__52-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TheButton = arg0.$VB$Local_TheButton;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(object sender, EventArgs e)
		{
			if (((RadioButton)$VB$Local_TheButton).Checked)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Convert.ChangeType(RuntimeHelpers.GetObjectValue(((Control)$VB$Local_TheButton).Tag), $VB$NonLocal_$VB$Closure_2.$VB$Local_enumType));
				$VB$NonLocal_$VB$Closure_2.$VB$Me.method_0($VB$NonLocal_$VB$Closure_2.$VB$Local_Tactic, $VB$NonLocal_$VB$Closure_2.$VB$Local_enumType, RuntimeHelpers.GetObjectValue(objectValue));
			}
		}

		static _Closure$__52-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__52-1
	{
		public Type $VB$Local_enumType;

		public AGU_Tactic $VB$Local_Tactic;

		public AGU_Control $VB$Me;

		public _Closure$__52-1(_Closure$__52-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_enumType = arg0.$VB$Local_enumType;
				$VB$Local_Tactic = arg0.$VB$Local_Tactic;
			}
		}

		static _Closure$__52-1()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[field: AccessedThroughProperty("GroupBox_SpeedPresets")]
	internal virtual DarkGroupBox GroupBox_SpeedPresets { get; set; }

	[field: AccessedThroughProperty("ManoeuverPace_FP")]
	internal virtual FlowLayoutPanel ManoeuverPace_FP { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("ReactionOnClash_FP")]
	internal virtual FlowLayoutPanel ReactionOnClash_FP { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("Integrity_FP")]
	internal virtual FlowLayoutPanel Integrity_FP { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	[field: AccessedThroughProperty("Formation_FP")]
	internal virtual FlowLayoutPanel Formation_FP { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox4")]
	internal virtual DarkGroupBox DarkGroupBox4 { get; set; }

	[field: AccessedThroughProperty("RichTextBox1")]
	internal virtual RichTextBox RichTextBox1 { get; set; }

	public bool Initialized => ((ArrangedElementCollection)((Control)ManoeuverPace_FP).Controls).Count > 0;

	public AGU_Control()
	{
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		GroupBox_SpeedPresets = new DarkGroupBox();
		ManoeuverPace_FP = new FlowLayoutPanel();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		DarkGroupBox1 = new DarkGroupBox();
		ReactionOnClash_FP = new FlowLayoutPanel();
		DarkGroupBox2 = new DarkGroupBox();
		Integrity_FP = new FlowLayoutPanel();
		DarkGroupBox3 = new DarkGroupBox();
		Formation_FP = new FlowLayoutPanel();
		DarkGroupBox4 = new DarkGroupBox();
		RichTextBox1 = new RichTextBox();
		((Control)GroupBox_SpeedPresets).SuspendLayout();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)DarkGroupBox3).SuspendLayout();
		((Control)DarkGroupBox4).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)ManoeuverPace_FP);
		((Control)GroupBox_SpeedPresets).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_SpeedPresets).Location = new Point(13, 13);
		((Control)GroupBox_SpeedPresets).Name = "GroupBox_SpeedPresets";
		((Control)GroupBox_SpeedPresets).Size = new Size(562, 49);
		((Control)GroupBox_SpeedPresets).TabIndex = 11;
		((GroupBox)GroupBox_SpeedPresets).TabStop = false;
		((GroupBox)GroupBox_SpeedPresets).Text = "Manoeuver Pace";
		((Control)ManoeuverPace_FP).Dock = (DockStyle)5;
		((Control)ManoeuverPace_FP).Location = new Point(3, 16);
		((Control)ManoeuverPace_FP).Name = "ManoeuverPace_FP";
		((Control)ManoeuverPace_FP).Size = new Size(556, 30);
		((Control)ManoeuverPace_FP).TabIndex = 6;
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)GroupBox_SpeedPresets);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)FlowLayoutPanel2).Dock = (DockStyle)3;
		((Control)FlowLayoutPanel2).Location = new Point(0, 0);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Padding = new Padding(10);
		((Control)FlowLayoutPanel2).Size = new Size(588, 243);
		((Control)FlowLayoutPanel2).TabIndex = 12;
		((Control)DarkGroupBox1).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)ReactionOnClash_FP);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(13, 68);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(562, 49);
		((Control)DarkGroupBox1).TabIndex = 12;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Reaction on Clash";
		((Control)ReactionOnClash_FP).Dock = (DockStyle)5;
		((Control)ReactionOnClash_FP).Location = new Point(3, 16);
		((Control)ReactionOnClash_FP).Name = "ReactionOnClash_FP";
		((Control)ReactionOnClash_FP).Size = new Size(556, 30);
		((Control)ReactionOnClash_FP).TabIndex = 6;
		((Control)DarkGroupBox2).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Integrity_FP);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(13, 123);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(562, 49);
		((Control)DarkGroupBox2).TabIndex = 13;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Integrity";
		((Control)Integrity_FP).Dock = (DockStyle)5;
		((Control)Integrity_FP).Location = new Point(3, 16);
		((Control)Integrity_FP).Name = "Integrity_FP";
		((Control)Integrity_FP).Size = new Size(556, 30);
		((Control)Integrity_FP).TabIndex = 6;
		((Control)DarkGroupBox3).Anchor = (AnchorStyles)13;
		((Control)DarkGroupBox3).Controls.Add((Control)(object)Formation_FP);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(13, 178);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(562, 49);
		((Control)DarkGroupBox3).TabIndex = 14;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "Formation";
		((Control)Formation_FP).Dock = (DockStyle)5;
		((Control)Formation_FP).Location = new Point(3, 16);
		((Control)Formation_FP).Name = "Formation_FP";
		((Control)Formation_FP).Size = new Size(556, 30);
		((Control)Formation_FP).TabIndex = 6;
		((Control)DarkGroupBox4).Controls.Add((Control)(object)RichTextBox1);
		((Control)DarkGroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox4).Location = new Point(594, 13);
		((Control)DarkGroupBox4).Name = "DarkGroupBox4";
		((Control)DarkGroupBox4).Size = new Size(155, 219);
		((Control)DarkGroupBox4).TabIndex = 15;
		((GroupBox)DarkGroupBox4).TabStop = false;
		((GroupBox)DarkGroupBox4).Text = "Modifier";
		((TextBoxBase)RichTextBox1).BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox1.ForeColor = SystemColors.Window;
		((Control)RichTextBox1).Location = new Point(6, 17);
		((Control)RichTextBox1).Name = "RichTextBox1";
		((TextBoxBase)RichTextBox1).ReadOnly = true;
		((Control)RichTextBox1).Size = new Size(147, 195);
		((Control)RichTextBox1).TabIndex = 0;
		RichTextBox1.Text = "";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(763, 243);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox4);
		((Control)this).ForeColor = SystemColors.ControlLightLight;
		((Form)this).MinimumSize = new Size(578, 282);
		((Control)this).Name = "AGU_Control";
		((Form)this).Text = "Tactic";
		((Control)GroupBox_SpeedPresets).ResumeLayout(false);
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)DarkGroupBox4).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public void RefreshForm(AggregateGroundUnit AGU)
	{
		Initialise(AGU);
	}

	public void Initialise(AggregateGroundUnit AGU)
	{
		((Control)Formation_FP).Controls.Clear();
		((Control)Integrity_FP).Controls.Clear();
		((Control)ReactionOnClash_FP).Controls.Clear();
		((Control)ManoeuverPace_FP).Controls.Clear();
		PopulateTactic(AGU, typeof(AGUFormation), (int)AGU.CurrentTactic.Formation, Formation_FP);
		PopulateTactic(AGU, typeof(AGU_Integrity), (int)AGU.CurrentTactic.Integrity, Integrity_FP);
		PopulateTactic(AGU, typeof(ClashManoeuverBehaviour), (int)AGU.CurrentTactic.ManoeuverOnClash, ReactionOnClash_FP);
		PopulateTactic(AGU, typeof(ManoeuverBehaviour), (int)AGU.CurrentTactic.Manoeuver, ManoeuverPace_FP);
		RichTextBox1.Text = AGU.CurrentTactic.ToString();
	}

	public void PopulateTactic(AggregateGroundUnit AGU, Type enumType, int i, FlowLayoutPanel panel)
	{
		_Closure$__52-1 closure$__52- = new _Closure$__52-1(closure$__52-);
		closure$__52-.$VB$Me = this;
		closure$__52-.$VB$Local_enumType = enumType;
		closure$__52-.$VB$Local_Tactic = AGU.CurrentTactic;
		_Closure$__52-0 closure$__52-2 = default(_Closure$__52-0);
		foreach (object value in Enum.GetValues(closure$__52-.$VB$Local_enumType))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(value);
			closure$__52-2 = new _Closure$__52-0(closure$__52-2);
			closure$__52-2.$VB$NonLocal_$VB$Closure_2 = closure$__52-;
			closure$__52-2.$VB$Local_TheButton = new DarkUIRadioButton();
			DarkUIRadioButton darkUIRadioButton = closure$__52-2.$VB$Local_TheButton;
			object[] array;
			bool[] array2;
			object obj = NewLateBinding.LateGet((object)null, typeof(Helper), "GetReadableEnum", array = new object[1] { objectValue }, (string[])null, (Type[])null, array2 = new bool[1] { true });
			if (array2[0])
			{
				objectValue = RuntimeHelpers.GetObjectValue(array[0]);
			}
			((ButtonBase)darkUIRadioButton).Text = Conversions.ToString(obj);
			((Control)closure$__52-2.$VB$Local_TheButton).Tag = RuntimeHelpers.GetObjectValue(objectValue);
			((RadioButton)closure$__52-2.$VB$Local_TheButton).Checked = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue)) == Convert.ToInt32(RuntimeHelpers.GetObjectValue(Enum.ToObject(closure$__52-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_enumType, i)));
			((RadioButton)closure$__52-2.$VB$Local_TheButton).CheckedChanged += closure$__52-2._Lambda$__0;
			((Control)panel).Controls.Add((Control)(object)closure$__52-2.$VB$Local_TheButton);
		}
	}

	private void method_0(object object_0, Type type_0, object object_1)
	{
		if (!(type_0 == typeof(AGUFormation)))
		{
			if (type_0 == typeof(AGU_Integrity))
			{
				NewLateBinding.LateSet(object_0, (Type)null, "Integrity", new object[1] { object_1 }, (string[])null, (Type[])null);
			}
			else if (!(type_0 == typeof(ClashManoeuverBehaviour)))
			{
				if (type_0 == typeof(ManoeuverBehaviour))
				{
					NewLateBinding.LateSet(object_0, (Type)null, "Manoeuver", new object[1] { object_1 }, (string[])null, (Type[])null);
				}
			}
			else
			{
				NewLateBinding.LateSet(object_0, (Type)null, "ManoeuverOnClash", new object[1] { object_1 }, (string[])null, (Type[])null);
			}
		}
		else
		{
			NewLateBinding.LateSet(object_0, (Type)null, "Formation", new object[1] { object_1 }, (string[])null, (Type[])null);
		}
		RichTextBox1.Text = object_0.ToString();
	}

	static AGU_Control()
	{
		Class72.smethod_20();
	}
}
