using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DoctrineControl : DarkUserControl
{
	public struct DoctrineControl_Config
	{
		public int UC_Size;

		public bool DisplayName;

		public bool DisplayCategories;

		public bool DisplayParent;

		public DoctrineControl_Config(int _UC_Size, bool _DisplayName, bool _DisplayCategories, bool _DisplayParent)
		{
			this = default(DoctrineControl_Config);
			UC_Size = _UC_Size;
			DisplayName = _DisplayName;
			DisplayCategories = _DisplayCategories;
			DisplayParent = _DisplayParent;
		}

		public static DoctrineControl_Config DefaultConfig()
		{
			return new DoctrineControl_Config(365, _DisplayName: true, _DisplayCategories: true, _DisplayParent: true);
		}

		static DoctrineControl_Config()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("DoctrineButton")]
	[CompilerGenerated]
	private DarkButton _DoctrineButton;

	[CompilerGenerated]
	[AccessedThroughProperty("ParentDoctrine")]
	private DarkButton _ParentDoctrine;

	[AccessedThroughProperty("ButtonPrevious")]
	[CompilerGenerated]
	private DarkButton _ButtonPrevious;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetToDefault")]
	private DarkUIButton _Button_ResetToDefault;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Inherit")]
	private DarkUIButton _Button_Inherit;

	private int ActualWidth;

	public bool isMissionEdit;

	public Dictionary<Doctrine.DoctrineDefinition, DoctrineItem_uc> UC_Pool;

	public Dictionary<Doctrine.DoctrineCategory, DoctrineItem_uc> UC_Pool_CategorieTitle;

	private DoctrineControl_Config? nullable_0;

	public List<ActiveUnit> _SelectedUnits;

	public Doctrine theDoc;

	public Doctrine SourceDoctrine;

	public static HashSet<DoctrineControl> Instances;

	internal virtual DarkButton DoctrineButton
	{
		[CompilerGenerated]
		get
		{
			return _DoctrineButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkButton darkButton = _DoctrineButton;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_DoctrineButton = value;
			darkButton = _DoctrineButton;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DoctrineContainer")]
	internal virtual FlowLayoutPanel DoctrineContainer { get; set; }

	[field: AccessedThroughProperty("CategoryPanel")]
	internal virtual FlowLayoutPanel CategoryPanel { get; set; }

	[field: AccessedThroughProperty("DarkUIButton1")]
	internal virtual DarkUIButton DarkUIButton1 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton3")]
	internal virtual DarkUIButton DarkUIButton3 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton4")]
	internal virtual DarkUIButton DarkUIButton4 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton5")]
	internal virtual DarkUIButton DarkUIButton5 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton6")]
	internal virtual DarkUIButton DarkUIButton6 { get; set; }

	internal virtual DarkButton ParentDoctrine
	{
		[CompilerGenerated]
		get
		{
			return _ParentDoctrine;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkButton darkButton = _ParentDoctrine;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ParentDoctrine = value;
			darkButton = _ParentDoctrine;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TopPanel")]
	internal virtual FlowLayoutPanel TopPanel { get; set; }

	[field: AccessedThroughProperty("LabelSubjectName")]
	internal virtual DarkLabel LabelSubjectName { get; set; }

	internal virtual DarkButton ButtonPrevious
	{
		[CompilerGenerated]
		get
		{
			return _ButtonPrevious;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkButton darkButton = _ButtonPrevious;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonPrevious = value;
			darkButton = _ButtonPrevious;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	internal virtual DarkUIButton Button_ResetToDefault
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetToDefault;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _Button_ResetToDefault;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetToDefault = value;
			darkUIButton = _Button_ResetToDefault;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Inherit
	{
		[CompilerGenerated]
		get
		{
			return _Button_Inherit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIButton darkUIButton = _Button_Inherit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Inherit = value;
			darkUIButton = _Button_Inherit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	public List<ActiveUnit> SelectedUnits
	{
		get
		{
			if (isMissionEdit)
			{
				return null;
			}
			return _SelectedUnits;
		}
		set
		{
			_SelectedUnits = value;
		}
	}

	static DoctrineControl()
	{
		Class72.smethod_20();
		Instances = new HashSet<DoctrineControl>();
	}

	public DoctrineControl()
	{
		((UserControl)this).Load += DoctrineControl_Load;
		((Control)this).HandleDestroyed += DoctrineControl_HandleDestroyed;
		UC_Pool = new Dictionary<Doctrine.DoctrineDefinition, DoctrineItem_uc>();
		UC_Pool_CategorieTitle = new Dictionary<Doctrine.DoctrineCategory, DoctrineItem_uc>();
		SourceDoctrine = null;
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Expected O, but got Unknown
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Expected O, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0991: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
		DoctrineButton = new DarkButton();
		DoctrineContainer = new FlowLayoutPanel();
		CategoryPanel = new FlowLayoutPanel();
		ParentDoctrine = new DarkButton();
		TopPanel = new FlowLayoutPanel();
		LabelSubjectName = new DarkLabel();
		ButtonPrevious = new DarkButton();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		DarkLabel1 = new DarkLabel();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		DarkUIButton1 = new DarkUIButton();
		DarkUIButton3 = new DarkUIButton();
		DarkUIButton4 = new DarkUIButton();
		DarkUIButton5 = new DarkUIButton();
		DarkUIButton6 = new DarkUIButton();
		Button_ResetToDefault = new DarkUIButton();
		Button_Inherit = new DarkUIButton();
		((Control)CategoryPanel).SuspendLayout();
		((Control)TopPanel).SuspendLayout();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)DoctrineButton).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)DoctrineButton).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DoctrineButton).Location = new Point(44, 3);
		((Control)DoctrineButton).Margin = new Padding(0, 3, 3, 3);
		((Control)DoctrineButton).Name = "DoctrineButton";
		((Control)DoctrineButton).Padding = new Padding(5);
		((Control)DoctrineButton).Size = new Size(186, 25);
		((Control)DoctrineButton).TabIndex = 23;
		DoctrineButton.Text = "Doctrine Window (Ctrl + F9)";
		((Control)DoctrineContainer).Anchor = (AnchorStyles)13;
		((ScrollableControl)DoctrineContainer).AutoScroll = true;
		((Panel)DoctrineContainer).AutoSizeMode = (AutoSizeMode)0;
		DoctrineContainer.FlowDirection = (FlowDirection)1;
		((Control)DoctrineContainer).Location = new Point(0, 83);
		((Control)DoctrineContainer).Name = "DoctrineContainer";
		((Control)DoctrineContainer).Padding = new Padding(0, 0, 0, 10);
		((Control)DoctrineContainer).Size = new Size(886, 500);
		((Control)DoctrineContainer).TabIndex = 24;
		((Panel)CategoryPanel).AutoSize = true;
		((Control)CategoryPanel).Controls.Add((Control)(object)DarkUIButton1);
		((Control)CategoryPanel).Controls.Add((Control)(object)DarkUIButton3);
		((Control)CategoryPanel).Controls.Add((Control)(object)DarkUIButton4);
		((Control)CategoryPanel).Controls.Add((Control)(object)DarkUIButton5);
		((Control)CategoryPanel).Controls.Add((Control)(object)DarkUIButton6);
		((Control)CategoryPanel).Location = new Point(0, 40);
		((Control)CategoryPanel).Margin = new Padding(0, 3, 0, 0);
		((Control)CategoryPanel).Name = "CategoryPanel";
		((Control)CategoryPanel).Size = new Size(765, 29);
		((Control)CategoryPanel).TabIndex = 6;
		((Control)ParentDoctrine).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)ParentDoctrine).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ParentDoctrine).Location = new Point(233, 3);
		((Control)ParentDoctrine).Margin = new Padding(0, 3, 3, 3);
		((Control)ParentDoctrine).Name = "ParentDoctrine";
		((Control)ParentDoctrine).Padding = new Padding(5);
		((Control)ParentDoctrine).Size = new Size(179, 25);
		((Control)ParentDoctrine).TabIndex = 25;
		ParentDoctrine.Text = "Parent :";
		((Control)TopPanel).Anchor = (AnchorStyles)13;
		((Panel)TopPanel).AutoSize = true;
		((Control)TopPanel).Controls.Add((Control)(object)LabelSubjectName);
		((Control)TopPanel).Controls.Add((Control)(object)DoctrineButton);
		((Control)TopPanel).Controls.Add((Control)(object)ParentDoctrine);
		((Control)TopPanel).Controls.Add((Control)(object)ButtonPrevious);
		((Control)TopPanel).Location = new Point(0, 3);
		((Control)TopPanel).Margin = new Padding(0, 3, 0, 3);
		((Control)TopPanel).Name = "TopPanel";
		((Control)TopPanel).Size = new Size(765, 31);
		((Control)TopPanel).TabIndex = 26;
		((Control)LabelSubjectName).Anchor = (AnchorStyles)15;
		LabelSubjectName.AutoSize = true;
		((Control)LabelSubjectName).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)LabelSubjectName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelSubjectName).Location = new Point(3, 0);
		((Control)LabelSubjectName).Name = "LabelSubjectName";
		((Control)LabelSubjectName).Size = new Size(38, 31);
		((Control)LabelSubjectName).TabIndex = 26;
		((Label)LabelSubjectName).Text = "-----";
		((Label)LabelSubjectName).TextAlign = (ContentAlignment)32;
		((Control)ButtonPrevious).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)ButtonPrevious).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonPrevious).Location = new Point(415, 3);
		((Control)ButtonPrevious).Margin = new Padding(0, 3, 3, 3);
		((Control)ButtonPrevious).Name = "ButtonPrevious";
		((Control)ButtonPrevious).Padding = new Padding(5);
		((Control)ButtonPrevious).Size = new Size(179, 25);
		((Control)ButtonPrevious).TabIndex = 27;
		ButtonPrevious.Text = "Previous";
		((Control)FlowLayoutPanel2).Anchor = (AnchorStyles)14;
		((Panel)FlowLayoutPanel2).AutoSizeMode = (AutoSizeMode)0;
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)DarkLabel1);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)Button_ResetToDefault);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)Button_Inherit);
		((Control)FlowLayoutPanel2).Location = new Point(0, 604);
		((Control)FlowLayoutPanel2).Margin = new Padding(0, 3, 0, 3);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Size = new Size(889, 35);
		((Control)FlowLayoutPanel2).TabIndex = 28;
		FlowLayoutPanel2.WrapContents = false;
		((Control)DarkLabel1).Anchor = (AnchorStyles)15;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(3, 0);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(160, 29);
		((Control)DarkLabel1).TabIndex = 29;
		((Label)DarkLabel1).Text = "On all doctrine definitions :";
		((Label)DarkLabel1).TextAlign = (ContentAlignment)32;
		((Control)FlowLayoutPanel3).Anchor = (AnchorStyles)13;
		((Panel)FlowLayoutPanel3).AutoSizeMode = (AutoSizeMode)0;
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)TopPanel);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)CategoryPanel);
		FlowLayoutPanel3.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel3).Location = new Point(0, 0);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(886, 77);
		((Control)FlowLayoutPanel3).TabIndex = 29;
		((Control)DarkUIButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkUIButton1).Location = new Point(3, 3);
		((Control)DarkUIButton1).Name = "DarkUIButton1";
		((Control)DarkUIButton1).Padding = new Padding(5);
		DarkUIButton1.RoundRadius = 0;
		((Control)DarkUIButton1).Size = new Size(147, 23);
		((Control)DarkUIButton1).TabIndex = 2;
		DarkUIButton1.Text = "RoE";
		((Control)DarkUIButton3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkUIButton3).Location = new Point(156, 3);
		((Control)DarkUIButton3).Name = "DarkUIButton3";
		((Control)DarkUIButton3).Padding = new Padding(5);
		DarkUIButton3.RoundRadius = 0;
		((Control)DarkUIButton3).Size = new Size(147, 23);
		((Control)DarkUIButton3).TabIndex = 3;
		DarkUIButton3.Text = "RoE";
		((Control)DarkUIButton4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkUIButton4).Location = new Point(309, 3);
		((Control)DarkUIButton4).Name = "DarkUIButton4";
		((Control)DarkUIButton4).Padding = new Padding(5);
		DarkUIButton4.RoundRadius = 0;
		((Control)DarkUIButton4).Size = new Size(147, 23);
		((Control)DarkUIButton4).TabIndex = 4;
		DarkUIButton4.Text = "RoE";
		((Control)DarkUIButton5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkUIButton5).Location = new Point(462, 3);
		((Control)DarkUIButton5).Name = "DarkUIButton5";
		((Control)DarkUIButton5).Padding = new Padding(5);
		DarkUIButton5.RoundRadius = 0;
		((Control)DarkUIButton5).Size = new Size(147, 23);
		((Control)DarkUIButton5).TabIndex = 5;
		DarkUIButton5.Text = "RoE";
		((Control)DarkUIButton6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkUIButton6).Location = new Point(615, 3);
		((Control)DarkUIButton6).Name = "DarkUIButton6";
		((Control)DarkUIButton6).Padding = new Padding(5);
		DarkUIButton6.RoundRadius = 0;
		((Control)DarkUIButton6).Size = new Size(147, 23);
		((Control)DarkUIButton6).TabIndex = 6;
		DarkUIButton6.Text = "RoE";
		((Control)Button_ResetToDefault).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_ResetToDefault).Location = new Point(169, 3);
		((Control)Button_ResetToDefault).Name = "Button_ResetToDefault";
		((Control)Button_ResetToDefault).Padding = new Padding(5);
		Button_ResetToDefault.RoundRadius = 0;
		((Control)Button_ResetToDefault).Size = new Size(147, 23);
		((Control)Button_ResetToDefault).TabIndex = 27;
		Button_ResetToDefault.Text = "Reset to Default";
		((Control)Button_Inherit).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Inherit).Location = new Point(322, 3);
		((Control)Button_Inherit).Name = "Button_Inherit";
		((Control)Button_Inherit).Padding = new Padding(5);
		Button_Inherit.RoundRadius = 0;
		((Control)Button_Inherit).Size = new Size(147, 23);
		((Control)Button_Inherit).TabIndex = 28;
		Button_Inherit.Text = "Set to 'Inherit'";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((UserControl)this).AutoSizeMode = (AutoSizeMode)0;
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel3);
		((Control)this).Controls.Add((Control)(object)DoctrineContainer);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Control)this).Margin = new Padding(0);
		((Control)this).MinimumSize = new Size(829, 559);
		((Control)this).Name = "DoctrineControl";
		((Control)this).Size = new Size(889, 639);
		((Control)CategoryPanel).ResumeLayout(false);
		((Control)TopPanel).ResumeLayout(false);
		((Control)TopPanel).PerformLayout();
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)FlowLayoutPanel2).PerformLayout();
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((Control)FlowLayoutPanel3).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	private ScenarioObject method_1()
	{
		return theDoc.Subject;
	}

	public static void ReleaseAllReferences()
	{
		foreach (DoctrineControl instance in Instances)
		{
			instance.ReleaseReferences();
		}
		Instances.Clear();
	}

	public void ReleaseReferences()
	{
		theDoc = null;
		SourceDoctrine = null;
		_SelectedUnits?.Clear();
		UC_Pool?.Clear();
		UC_Pool_CategorieTitle?.Clear();
		((Control)DoctrineContainer).Controls.Clear();
	}

	private void DoctrineControl_Load(object sender, EventArgs e)
	{
		Client.SelectedUnitChanged += method_2;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void DoctrineControl_HandleDestroyed(object sender, EventArgs e)
	{
		Client.SelectedUnitChanged -= method_2;
	}

	private void method_2(Module_Unit.Unit unit_0)
	{
		if (!((Control)this).IsDisposed)
		{
			RefreshForm(unit_0);
		}
	}

	public void RefreshParentDoctrine_Button()
	{
		if (SourceDoctrine != null && SourceDoctrine != theDoc)
		{
			((Control)ButtonPrevious).Visible = true;
			if (SourceDoctrine.Subject != null)
			{
				ButtonPrevious.Text = "(Previous " + SourceDoctrine.SubjectType.Name + ") " + SourceDoctrine.Subject.Name;
			}
			else
			{
				ButtonPrevious.Text = "Previous Doctrine";
			}
		}
		else
		{
			((Control)ButtonPrevious).Visible = false;
		}
		if (theDoc == null)
		{
			return;
		}
		Doctrine doctrine = theDoc;
		bool UnitIsOperating = true;
		Doctrine parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
		if (parentDoctrine != null && parentDoctrine != theDoc)
		{
			((Control)ParentDoctrine).Visible = true;
			if (parentDoctrine.Subject != null)
			{
				ParentDoctrine.Text = "(Parent " + parentDoctrine.SubjectType.Name + ") " + parentDoctrine.Subject.Name;
			}
			else
			{
				ParentDoctrine.Text = "Parent Doctrine";
			}
		}
		else
		{
			((Control)ParentDoctrine).Visible = false;
		}
		if (theDoc.Subject != null && theDoc != parentDoctrine)
		{
			((Label)LabelSubjectName).Text = theDoc.Subject.Name + " (" + theDoc.SubjectType.Name + ")";
		}
		else
		{
			((Label)LabelSubjectName).Text = "";
		}
	}

	public void RefreshForm(Module_Unit.Unit theUnit, DoctrineControl_Config? Config = null)
	{
		if (theUnit != null && theUnit.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)theUnit;
			if (theUnit != null)
			{
				((Control)this).Visible = activeUnit.CommStuff.IsConnectedToSideNetwork || Module1.IsSelectedForIsolatedPOV(activeUnit) || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient;
			}
			RefreshForm(activeUnit.Doctrine, null, Config);
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.OnDoctrineSelected(theUnit);
			}
		}
	}

	public void RefreshForm(Doctrine theDoc, Doctrine.DoctrineCategory? SelectedCategory = null, DoctrineControl_Config? Config = null)
	{
		Instances.Add(this);
		if (Information.IsNothing((object)theDoc))
		{
			return;
		}
		ApplyDoctrineControl_Config(Config);
		((Control)Button_Inherit).Visible = theDoc.CanInheritDoctrine;
		this.theDoc = theDoc;
		RefreshParentDoctrine_Button();
		if (Client.DPI_scale != 1f)
		{
			if (ActualWidth == 0)
			{
				ActualWidth = ((Control)this).Width;
			}
			if (ActualWidth == ((Control)this).Width)
			{
				((Control)this).Width = (int)Math.Round((float)((Control)this).Width * Client.DPI_scale);
			}
		}
		((Control)this).Enabled = theDoc.GetSide(Client.CurrentSide) == Client.CurrentSide;
		((Control)DoctrineButton).Visible = !Information.IsNothing((object)method_1());
		method_3(theDoc, SelectedCategory);
	}

	private void method_3(Doctrine doctrine_0, Doctrine.DoctrineCategory? nullable_1 = null)
	{
		HashSet<Doctrine.DoctrineCategory> hashSet = method_6(doctrine_0, nullable_1);
		((Control)CategoryPanel).Controls.Clear();
		((Control)CategoryPanel).Controls.Add((Control)(object)method_7(null));
		foreach (Doctrine.DoctrineCategory item in hashSet)
		{
			if (item != Doctrine.DoctrineCategory.WithdrawCondition && item != Doctrine.DoctrineCategory.RedeployCondition)
			{
				((Control)CategoryPanel).Controls.Add((Control)(object)method_7(item));
			}
		}
	}

	private DoctrineItem_uc method_4(Doctrine.DoctrineDefinition doctrineDefinition_0)
	{
		if (!UC_Pool.ContainsKey(doctrineDefinition_0))
		{
			DoctrineItem_uc doctrineItem_uc = new DoctrineItem_uc();
			UC_Pool.Add(doctrineDefinition_0, doctrineItem_uc);
			((Control)DoctrineContainer).Controls.Add((Control)(object)doctrineItem_uc);
		}
		return UC_Pool[doctrineDefinition_0];
	}

	private DoctrineItem_uc xUmHvncpnby(Doctrine.DoctrineCategory doctrineCategory_0)
	{
		if (!UC_Pool_CategorieTitle.ContainsKey(doctrineCategory_0))
		{
			DoctrineItem_uc doctrineItem_uc = new DoctrineItem_uc();
			UC_Pool_CategorieTitle.Add(doctrineCategory_0, doctrineItem_uc);
			((Control)DoctrineContainer).Controls.Add((Control)(object)doctrineItem_uc);
		}
		return UC_Pool_CategorieTitle[doctrineCategory_0];
	}

	private void method_5()
	{
		foreach (KeyValuePair<Doctrine.DoctrineDefinition, DoctrineItem_uc> item in UC_Pool)
		{
			((Control)item.Value).Visible = false;
		}
		foreach (KeyValuePair<Doctrine.DoctrineCategory, DoctrineItem_uc> item2 in UC_Pool_CategorieTitle)
		{
			((Control)item2.Value).Visible = false;
		}
	}

	private HashSet<Doctrine.DoctrineCategory> method_6(Doctrine doctrine_0, Doctrine.DoctrineCategory? nullable_1 = null)
	{
		bool flag = false;
		Dictionary<Doctrine.DoctrineCategory, List<Doctrine.DoctrineDefinition>> dictionary = new Dictionary<Doctrine.DoctrineCategory, List<Doctrine.DoctrineDefinition>>();
		Color backColor = Color.FromArgb(255, 50, 50, 50);
		Color backColor2 = Color.FromArgb(255, 60, 60, 60);
		Color backColor3 = Color.FromArgb(255, 35, 35, 35);
		foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition in Doctrine.DoctrineDefinitions)
		{
			if (doctrineDefinition.Value.IsThisDoctrineAppliesToObject(method_1()))
			{
				if (!dictionary.ContainsKey(doctrineDefinition.Value.Category))
				{
					dictionary.Add(doctrineDefinition.Value.Category, new List<Doctrine.DoctrineDefinition> { doctrineDefinition.Value });
				}
				else
				{
					dictionary[doctrineDefinition.Value.Category].Add(doctrineDefinition.Value);
				}
			}
		}
		((Control)DoctrineContainer).SuspendLayout();
		method_5();
		foreach (KeyValuePair<Doctrine.DoctrineCategory, List<Doctrine.DoctrineDefinition>> item in dictionary)
		{
			if (item.Key == Doctrine.DoctrineCategory.WithdrawCondition || item.Key == Doctrine.DoctrineCategory.RedeployCondition)
			{
				continue;
			}
			if (nullable_1.HasValue)
			{
				int? num = (int?)nullable_1;
				int key = (int)item.Key;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == key)) != true)
				{
					continue;
				}
			}
			if (!nullable_1.HasValue)
			{
				DoctrineItem_uc doctrineItem_uc = xUmHvncpnby(item.Key);
				doctrineItem_uc.RefreshPanel(Helper.GetReadableEnum_Description(item.Key), nullable_0);
				((Control)doctrineItem_uc).BackColor = backColor3;
			}
			foreach (Doctrine.DoctrineDefinition item2 in item.Value)
			{
				if (item2.IsThisDoctrineAppliesToObject(method_1()))
				{
					DoctrineItem_uc doctrineItem_uc2 = method_4(item2);
					doctrineItem_uc2.RefreshPanel(doctrine_0.GetElement(item2, Doctrine.DoctrineItemAutopopulate.Inherited), Client.CurrentScenario, "", nullable_0);
					if (!flag)
					{
						((Control)doctrineItem_uc2).BackColor = backColor2;
					}
					else
					{
						((Control)doctrineItem_uc2).BackColor = backColor;
					}
					flag = !flag;
				}
			}
		}
		((Control)DoctrineContainer).ResumeLayout(false);
		((Control)DoctrineContainer).PerformLayout();
		return dictionary.Keys.ToHashSet();
	}

	public Doctrine GetDoctrine_MultipleUnit(List<ActiveUnit> _SelectedUnits)
	{
		SelectedUnits = _SelectedUnits;
		int num = 0;
		Doctrine doctrine = null;
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			selectedUnit.Doctrine.ClearCachedParentDoctrine();
			num++;
			if (num != 1)
			{
				continue;
			}
			Aircraft aircraft = new Aircraft(ref selectedUnit.ParentScen);
			((ActiveUnit)aircraft).set_UnitSide(SetSideOnly: false, selectedUnit.get_UnitSide(SetSideOnly: false));
			if (selectedUnit.AssignedMissionOrPackage() != null)
			{
				Mission value = selectedUnit.AssignedMissionOrPackage();
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				aircraft.Set_AssignedMissionOrPackage(value, SetMissionOnly: true, IgnoreCommsState: false, ref Result);
			}
			aircraft.AI.IsEscort = selectedUnit.AI.IsEscort;
			if (!selectedUnit.IsAircraft)
			{
				aircraft.DockingOps.Condition = selectedUnit.DockingOps.Condition;
			}
			else
			{
				aircraft.AirOps.Condition = ((Aircraft)selectedUnit).AirOps.Condition;
			}
			Scenario parentScen = selectedUnit.ParentScen;
			List<ActiveUnit> DoctrineSelectedUnits = SelectedUnits;
			Doctrine doctrine2 = new Doctrine(parentScen, aircraft, ref DoctrineSelectedUnits);
			SelectedUnits = DoctrineSelectedUnits;
			doctrine = doctrine2;
			foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition in Doctrine.DoctrineDefinitions)
			{
				Doctrine.DoctrineItem element = selectedUnit.Doctrine.GetElement(doctrineDefinition.Value);
				Doctrine.DoctrineItem element2 = doctrine.GetElement(doctrineDefinition.Value);
				int? value2;
				if (!element.IsInheriting)
				{
					element2.set_CurrentState(ConsiderInheritance: false, element.get_CurrentState(ConsiderInheritance: false));
					Doctrine doctrine3 = selectedUnit.Doctrine;
					bool UnitIsOperating = true;
					value2 = doctrine3.GetParentDoctrine(ref UnitIsOperating).GetElement(doctrineDefinition.Value).get_CurrentState(ConsiderInheritance: false);
				}
				else
				{
					value2 = element.get_CurrentState(ConsiderInheritance: false);
				}
				if (!doctrine.MultipleUnitsInherits_State.ContainsKey(doctrineDefinition.Value))
				{
					doctrine.MultipleUnitsInherits_State.Add(doctrineDefinition.Value, value2);
				}
				else
				{
					doctrine.MultipleUnitsInherits_State[doctrineDefinition.Value] = value2;
				}
				int? num2 = element2.get_CurrentState(ConsiderInheritance: false);
				bool? flag = (num2.HasValue ? new bool?(num2 == 2) : ((bool?)null));
				if (((!flag) ?? flag) != true)
				{
					continue;
				}
				if (!element2.IsInheriting && !element.IsInheriting)
				{
					num2 = element2.get_CurrentState(ConsiderInheritance: false);
					int? num3 = element.get_CurrentState(ConsiderInheritance: false);
					if (((!(num2.HasValue & num3.HasValue)) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault())) == true)
					{
						element2.set_CurrentState(ConsiderInheritance: false, (int?)2);
					}
				}
				else if (element2.IsInheriting && !element.IsInheriting)
				{
					element2.set_CurrentState(ConsiderInheritance: false, (int?)2);
				}
				else if (!doctrine.IgnoreEMCONunderAttack_Inherits() && selectedUnit.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					element2.set_CurrentState(ConsiderInheritance: false, (int?)2);
				}
			}
			if (selectedUnit.Doctrine.EMCON_Inherits)
			{
				doctrine.EMCON_Inherits = true;
				continue;
			}
			doctrine.EMCON_Inherits = false;
			doctrine.SetEMCON_Radar(selectedUnit.Doctrine.EMCON(Client.CurrentScenario).Radar(), Client.CurrentScenario);
			doctrine.SetEMCON_Sonar(selectedUnit.Doctrine.EMCON(Client.CurrentScenario).Sonar(), Client.CurrentScenario);
			doctrine.SetEMCON_OECM(selectedUnit.Doctrine.EMCON(Client.CurrentScenario).OECM(), Client.CurrentScenario);
		}
		return doctrine;
	}

	public Doctrine GetDoctrine_Group(Group theGroup)
	{
		int num = 0;
		Doctrine doctrine = null;
		foreach (KeyValuePair<string, ActiveUnit> unit in theGroup.Units)
		{
			ActiveUnit value = unit.Value;
			value.Doctrine.ClearCachedParentDoctrine();
			num++;
			if (num == 1)
			{
				Doctrine doctrine2 = value.Doctrine;
				ref Doctrine doctrine3 = ref value.Doctrine;
				Scenario theScen = Client.CurrentScenario;
				doctrine = doctrine2.CopyDoctrine(ref doctrine3, value, ref theScen);
				continue;
			}
			byte? b = (byte?)doctrine.get_LandNavigation(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 6));
			if (((!flag) ?? flag) != true)
			{
				continue;
			}
			if (!doctrine.LandNavigation_Inherits() && !value.Doctrine.LandNavigation_Inherits())
			{
				b = (byte?)doctrine.get_LandNavigation(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				byte? b2 = (byte?)value.Doctrine.get_LandNavigation(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!(b.HasValue & b2.HasValue)) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault())) == true)
				{
					doctrine.set_LandNavigation(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: true, ViaRightColumn: true, (Doctrine._NavigationMethod?)Doctrine._NavigationMethod.Various);
				}
			}
			else if (doctrine.LandNavigation_Inherits() && !value.Doctrine.LandNavigation_Inherits())
			{
				doctrine.set_LandNavigation(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: true, ViaRightColumn: true, (Doctrine._NavigationMethod?)Doctrine._NavigationMethod.Various);
			}
			else if (!doctrine.LandNavigation_Inherits() && value.Doctrine.LandNavigation_Inherits())
			{
				doctrine.set_LandNavigation(Client.CurrentScenario, MultipleUnits: false, ViaDoctrineForm: true, ViaRightColumn: true, (Doctrine._NavigationMethod?)Doctrine._NavigationMethod.Various);
			}
		}
		return doctrine;
	}

	private DarkUIButton method_7(Doctrine.DoctrineCategory? nullable_1)
	{
		DarkUIButton darkUIButton = new DarkUIButton();
		((Control)darkUIButton).Tag = nullable_1;
		((Control)darkUIButton).Width = 100;
		((Control)darkUIButton).Height = 23;
		if (!nullable_1.HasValue)
		{
			darkUIButton.Text = "ALL";
		}
		else
		{
			darkUIButton.Text = Helper.GetReadableEnum(nullable_1.Value);
		}
		((Control)darkUIButton).Click += method_9;
		return darkUIButton;
	}

	private void method_8(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)method_1()))
		{
			((Control)new DoctrineForm
			{
				Subject = method_1()
			}).Show();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		Doctrine.DoctrineCategory? selectedCategory = (Doctrine.DoctrineCategory?)((Control)(DarkUIButton)sender).Tag;
		RefreshForm(theDoc, selectedCategory, nullable_0);
	}

	private void method_10(object sender, EventArgs e)
	{
		if (theDoc != null)
		{
			Doctrine doctrine = theDoc;
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
			if (SourceDoctrine == null)
			{
				SourceDoctrine = theDoc;
			}
			if (parentDoctrine != null)
			{
				RefreshForm(parentDoctrine, null, nullable_0);
			}
		}
	}

	public void ApplyDoctrineControl_Config(DoctrineControl_Config? _Config)
	{
		nullable_0 = _Config;
		if (_Config.HasValue)
		{
			((Control)LabelSubjectName).Visible = _Config.Value.DisplayName;
			((Control)CategoryPanel).Visible = _Config.Value.DisplayCategories;
			((Control)ParentDoctrine).Visible = _Config.Value.DisplayParent;
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (SourceDoctrine != null)
		{
			RefreshForm(SourceDoctrine, null, nullable_0);
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		theDoc.ApplyInheritanceToAllDoctrineDefinitions();
	}

	private void method_13(object sender, EventArgs e)
	{
		theDoc.ResetDefaultToAllDoctrineDefinitions();
	}
}
