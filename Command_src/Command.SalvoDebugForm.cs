using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
internal class SalvoDebugForm : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__89-0
	{
		public WeaponSalvo.Shooter $VB$Local_theShooter;

		public _Closure$__89-0(_Closure$__89-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theShooter = arg0.$VB$Local_theShooter;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit x)
		{
			return Operators.CompareString(x.ObjectID, $VB$Local_theShooter.ShooterObjectID, true) == 0;
		}

		static _Closure$__89-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__91-0
	{
		public WeaponSalvo.Shooter $VB$Local_sh;

		public _Closure$__91-0(_Closure$__91-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_sh = arg0.$VB$Local_sh;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit x)
		{
			return Operators.CompareString(x.ObjectID, $VB$Local_sh.ShooterObjectID, true) == 0;
		}

		static _Closure$__91-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("btnRefresh")]
	private DarkUIButton _btnRefresh;

	[AccessedThroughProperty("chkAutoRefresh")]
	[CompilerGenerated]
	private CheckBox _chkAutoRefresh;

	private Side side_0;

	private Timer timer_0;

	private WeaponSalvo weaponSalvo_0;

	private int int_0;

	private int int_1;

	public Action<ActiveUnit> SelectUnitAction;

	[field: AccessedThroughProperty("tblMain")]
	internal virtual TableLayoutPanel tblMain { get; set; }

	[field: AccessedThroughProperty("pnlTop")]
	internal virtual Panel pnlTop { get; set; }

	internal virtual DarkUIButton btnRefresh
	{
		[CompilerGenerated]
		get
		{
			return _btnRefresh;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _btnRefresh;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnRefresh = value;
			darkUIButton = _btnRefresh;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkAutoRefresh
	{
		[CompilerGenerated]
		get
		{
			return _chkAutoRefresh;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			CheckBox val = _chkAutoRefresh;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkAutoRefresh = value;
			val = _chkAutoRefresh;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lblRefresh")]
	internal virtual DarkLabel lblRefresh { get; set; }

	[field: AccessedThroughProperty("lstSalvos")]
	internal virtual DarkListView lstSalvos { get; set; }

	[field: AccessedThroughProperty("pnlRight")]
	internal virtual TableLayoutPanel pnlRight { get; set; }

	[field: AccessedThroughProperty("pnlActions")]
	internal virtual Panel pnlActions { get; set; }

	[field: AccessedThroughProperty("btnGoTarget")]
	internal virtual DarkUIButton btnGoTarget { get; set; }

	[field: AccessedThroughProperty("lblShooterLbl")]
	internal virtual DarkLabel lblShooterLbl { get; set; }

	[field: AccessedThroughProperty("btnPrevShooter")]
	internal virtual DarkUIButton btnPrevShooter { get; set; }

	[field: AccessedThroughProperty("lblShooterPos")]
	internal virtual DarkLabel lblShooterPos { get; set; }

	[field: AccessedThroughProperty("btnNextShooter")]
	internal virtual DarkUIButton btnNextShooter { get; set; }

	[field: AccessedThroughProperty("lblWeaponLbl")]
	internal virtual DarkLabel lblWeaponLbl { get; set; }

	[field: AccessedThroughProperty("btnPrevWeapon")]
	internal virtual DarkUIButton btnPrevWeapon { get; set; }

	[field: AccessedThroughProperty("lblWeaponPos")]
	internal virtual DarkLabel lblWeaponPos { get; set; }

	[field: AccessedThroughProperty("btnNextWeapon")]
	internal virtual DarkUIButton btnNextWeapon { get; set; }

	[field: AccessedThroughProperty("txtDetail")]
	internal virtual RichTextBox txtDetail { get; set; }

	[field: AccessedThroughProperty("lblStatus")]
	internal virtual DarkLabel lblStatus { get; set; }

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1d: Expected O, but got Unknown
		//IL_0cfb: Unknown result type (might be due to invalid IL or missing references)
		tblMain = new TableLayoutPanel();
		pnlTop = new Panel();
		btnRefresh = new DarkUIButton();
		chkAutoRefresh = new CheckBox();
		lblRefresh = new DarkLabel();
		lstSalvos = new DarkListView();
		pnlRight = new TableLayoutPanel();
		pnlActions = new Panel();
		btnGoTarget = new DarkUIButton();
		lblShooterLbl = new DarkLabel();
		btnPrevShooter = new DarkUIButton();
		lblShooterPos = new DarkLabel();
		btnNextShooter = new DarkUIButton();
		lblWeaponLbl = new DarkLabel();
		btnPrevWeapon = new DarkUIButton();
		lblWeaponPos = new DarkLabel();
		btnNextWeapon = new DarkUIButton();
		txtDetail = new RichTextBox();
		lblStatus = new DarkLabel();
		((Control)tblMain).SuspendLayout();
		((Control)pnlTop).SuspendLayout();
		((Control)pnlRight).SuspendLayout();
		((Control)pnlActions).SuspendLayout();
		((Control)this).SuspendLayout();
		tblMain.ColumnCount = 2;
		tblMain.ColumnStyles.Add(new ColumnStyle((SizeType)1, 540f));
		tblMain.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		tblMain.Controls.Add((Control)(object)pnlTop, 0, 0);
		tblMain.Controls.Add((Control)(object)lstSalvos, 0, 1);
		tblMain.Controls.Add((Control)(object)pnlRight, 1, 1);
		tblMain.Controls.Add((Control)(object)lblStatus, 0, 2);
		((Control)tblMain).Dock = (DockStyle)5;
		((Control)tblMain).Location = new Point(0, 0);
		((Control)tblMain).Name = "tblMain";
		tblMain.RowCount = 3;
		tblMain.RowStyles.Add(new RowStyle((SizeType)1, 36f));
		tblMain.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		tblMain.RowStyles.Add(new RowStyle((SizeType)1, 26f));
		((Control)tblMain).Size = new Size(1000, 650);
		((Control)tblMain).TabIndex = 0;
		tblMain.SetColumnSpan((Control)(object)pnlTop, 2);
		((Control)pnlTop).Controls.Add((Control)(object)btnRefresh);
		((Control)pnlTop).Controls.Add((Control)(object)chkAutoRefresh);
		((Control)pnlTop).Controls.Add((Control)(object)lblRefresh);
		((Control)pnlTop).Dock = (DockStyle)5;
		((Control)pnlTop).Location = new Point(3, 3);
		((Control)pnlTop).Name = "pnlTop";
		((Control)pnlTop).Padding = new Padding(4, 4, 4, 0);
		((Control)pnlTop).Size = new Size(994, 30);
		((Control)pnlTop).TabIndex = 0;
		((Control)btnRefresh).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnRefresh).Location = new Point(4, 4);
		((Control)btnRefresh).Name = "btnRefresh";
		((Control)btnRefresh).Padding = new Padding(5);
		btnRefresh.RoundRadius = 0;
		((Control)btnRefresh).Size = new Size(80, 26);
		((Control)btnRefresh).TabIndex = 0;
		btnRefresh.Text = "Refresh";
		((ButtonBase)chkAutoRefresh).AutoSize = true;
		((Control)chkAutoRefresh).Location = new Point(92, 8);
		((Control)chkAutoRefresh).Name = "chkAutoRefresh";
		((Control)chkAutoRefresh).Size = new Size(72, 19);
		((Control)chkAutoRefresh).TabIndex = 1;
		((ButtonBase)chkAutoRefresh).Text = "auto (1s)";
		lblRefresh.AutoSize = true;
		((Control)lblRefresh).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblRefresh).Location = new Point(200, 8);
		((Control)lblRefresh).Name = "lblRefresh";
		((Control)lblRefresh).Size = new Size(43, 15);
		((Control)lblRefresh).TabIndex = 2;
		((Label)lblRefresh).Text = "--:--:--";
		((Control)lstSalvos).Dock = (DockStyle)5;
		lstSalvos.ItemHeight = 34;
		((Control)lstSalvos).Location = new Point(3, 39);
		((Control)lstSalvos).Name = "lstSalvos";
		lstSalvos.RelatedInfos = null;
		((Control)lstSalvos).Size = new Size(534, 582);
		((Control)lstSalvos).TabIndex = 0;
		pnlRight.ColumnCount = 1;
		pnlRight.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		pnlRight.Controls.Add((Control)(object)pnlActions, 0, 0);
		pnlRight.Controls.Add((Control)(object)txtDetail, 0, 1);
		((Control)pnlRight).Dock = (DockStyle)5;
		((Control)pnlRight).Location = new Point(543, 39);
		((Control)pnlRight).Name = "pnlRight";
		pnlRight.RowCount = 2;
		pnlRight.RowStyles.Add(new RowStyle((SizeType)1, 44f));
		pnlRight.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)pnlRight).Size = new Size(454, 582);
		((Control)pnlRight).TabIndex = 0;
		((Control)pnlActions).Controls.Add((Control)(object)btnGoTarget);
		((Control)pnlActions).Controls.Add((Control)(object)lblShooterLbl);
		((Control)pnlActions).Controls.Add((Control)(object)btnPrevShooter);
		((Control)pnlActions).Controls.Add((Control)(object)lblShooterPos);
		((Control)pnlActions).Controls.Add((Control)(object)btnNextShooter);
		((Control)pnlActions).Controls.Add((Control)(object)lblWeaponLbl);
		((Control)pnlActions).Controls.Add((Control)(object)btnPrevWeapon);
		((Control)pnlActions).Controls.Add((Control)(object)lblWeaponPos);
		((Control)pnlActions).Controls.Add((Control)(object)btnNextWeapon);
		((Control)pnlActions).Dock = (DockStyle)5;
		((Control)pnlActions).Location = new Point(3, 3);
		((Control)pnlActions).Name = "pnlActions";
		((Control)pnlActions).Padding = new Padding(4, 6, 4, 0);
		((Control)pnlActions).Size = new Size(448, 38);
		((Control)pnlActions).TabIndex = 0;
		((Control)btnGoTarget).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnGoTarget).Location = new Point(4, 6);
		((Control)btnGoTarget).Name = "btnGoTarget";
		((Control)btnGoTarget).Padding = new Padding(5);
		btnGoTarget.RoundRadius = 0;
		((Control)btnGoTarget).Size = new Size(100, 28);
		((Control)btnGoTarget).TabIndex = 0;
		btnGoTarget.Text = "Target";
		lblShooterLbl.AutoSize = true;
		((Control)lblShooterLbl).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblShooterLbl).Location = new Point(114, 11);
		((Control)lblShooterLbl).Name = "lblShooterLbl";
		((Control)lblShooterLbl).Size = new Size(51, 15);
		((Control)lblShooterLbl).TabIndex = 1;
		((Label)lblShooterLbl).Text = "Shooter:";
		((Control)btnPrevShooter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnPrevShooter).Location = new Point(178, 6);
		((Control)btnPrevShooter).Name = "btnPrevShooter";
		((Control)btnPrevShooter).Padding = new Padding(5);
		btnPrevShooter.RoundRadius = 0;
		((Control)btnPrevShooter).Size = new Size(36, 28);
		((Control)btnPrevShooter).TabIndex = 1;
		btnPrevShooter.Text = "<";
		lblShooterPos.AutoSize = true;
		((Control)lblShooterPos).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblShooterPos).Location = new Point(220, 11);
		((Control)lblShooterPos).Name = "lblShooterPos";
		((Control)lblShooterPos).Size = new Size(24, 15);
		((Control)lblShooterPos).TabIndex = 2;
		((Label)lblShooterPos).Text = "0/0";
		((Control)btnNextShooter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnNextShooter).Location = new Point(258, 6);
		((Control)btnNextShooter).Name = "btnNextShooter";
		((Control)btnNextShooter).Padding = new Padding(5);
		btnNextShooter.RoundRadius = 0;
		((Control)btnNextShooter).Size = new Size(36, 28);
		((Control)btnNextShooter).TabIndex = 2;
		btnNextShooter.Text = ">";
		lblWeaponLbl.AutoSize = true;
		((Control)lblWeaponLbl).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblWeaponLbl).Location = new Point(308, 11);
		((Control)lblWeaponLbl).Name = "lblWeaponLbl";
		((Control)lblWeaponLbl).Size = new Size(54, 15);
		((Control)lblWeaponLbl).TabIndex = 3;
		((Label)lblWeaponLbl).Text = "Weapon:";
		((Control)btnPrevWeapon).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnPrevWeapon).Location = new Point(372, 6);
		((Control)btnPrevWeapon).Name = "btnPrevWeapon";
		((Control)btnPrevWeapon).Padding = new Padding(5);
		btnPrevWeapon.RoundRadius = 0;
		((Control)btnPrevWeapon).Size = new Size(36, 28);
		((Control)btnPrevWeapon).TabIndex = 3;
		btnPrevWeapon.Text = "<";
		lblWeaponPos.AutoSize = true;
		((Control)lblWeaponPos).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblWeaponPos).Location = new Point(414, 11);
		((Control)lblWeaponPos).Name = "lblWeaponPos";
		((Control)lblWeaponPos).Size = new Size(24, 15);
		((Control)lblWeaponPos).TabIndex = 4;
		((Label)lblWeaponPos).Text = "0/0";
		((Control)btnNextWeapon).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnNextWeapon).Location = new Point(452, 6);
		((Control)btnNextWeapon).Name = "btnNextWeapon";
		((Control)btnNextWeapon).Padding = new Padding(5);
		btnNextWeapon.RoundRadius = 0;
		((Control)btnNextWeapon).Size = new Size(36, 28);
		((Control)btnNextWeapon).TabIndex = 4;
		btnNextWeapon.Text = ">";
		((TextBoxBase)txtDetail).BorderStyle = (BorderStyle)0;
		((Control)txtDetail).Dock = (DockStyle)5;
		txtDetail.Font = new Font("Consolas", 9f);
		((Control)txtDetail).Location = new Point(3, 47);
		((Control)txtDetail).Name = "txtDetail";
		((TextBoxBase)txtDetail).ReadOnly = true;
		txtDetail.ScrollBars = (RichTextBoxScrollBars)2;
		((Control)txtDetail).Size = new Size(448, 532);
		((Control)txtDetail).TabIndex = 0;
		txtDetail.Text = "";
		tblMain.SetColumnSpan((Control)(object)lblStatus, 2);
		((Control)lblStatus).Dock = (DockStyle)5;
		((Control)lblStatus).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblStatus).Location = new Point(3, 624);
		((Control)lblStatus).Name = "lblStatus";
		((Control)lblStatus).Padding = new Padding(4, 4, 0, 0);
		((Control)lblStatus).Size = new Size(994, 26);
		((Control)lblStatus).TabIndex = 1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1000, 650);
		((Control)this).Controls.Add((Control)(object)tblMain);
		((Form)this).MinimumSize = new Size(800, 480);
		((Control)this).Name = "SalvoDebugForm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "Salvo Debugger";
		((Control)tblMain).ResumeLayout(false);
		((Control)pnlTop).ResumeLayout(false);
		((Control)pnlTop).PerformLayout();
		((Control)pnlRight).ResumeLayout(false);
		((Control)pnlActions).ResumeLayout(false);
		((Control)pnlActions).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public SalvoDebugForm(Side side)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(SalvoDebugForm_FormClosing);
		side_0 = null;
		timer_0 = new Timer
		{
			Interval = 1000
		};
		weaponSalvo_0 = null;
		int_0 = 0;
		int_1 = 0;
		SelectUnitAction = null;
		InitializeComponent_1();
		side_0 = side;
		((Form)this).Text = "Salvo Debugger — " + side.Name;
		lstSalvos.SelectedIndicesChanged += method_5;
		timer_0.Tick += [SpecialName] (object sender, EventArgs e) =>
		{
			method_2();
		};
		((Control)btnGoTarget).Click += [SpecialName] (object sender, EventArgs e) =>
		{
			method_8();
		};
		((Control)btnPrevShooter).Click += [SpecialName] (object sender, EventArgs e) =>
		{
			_Lambda$__85-2();
		};
		((Control)btnNextShooter).Click += [SpecialName] (object sender, EventArgs e) =>
		{
			_Lambda$__85-3();
		};
		((Control)btnPrevWeapon).Click += [SpecialName] (object sender, EventArgs e) =>
		{
			_Lambda$__85-4();
		};
		((Control)btnNextWeapon).Click += [SpecialName] (object sender, EventArgs e) =>
		{
			_Lambda$__85-5();
		};
		method_3();
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		timer_0.Stop();
		((Form)this).OnFormClosing(e);
	}

	private void method_2()
	{
		if (Client.CurrentGame.Status != Game._GameStatus.Running)
		{
			return;
		}
		if (!((Control)this).InvokeRequired)
		{
			method_3();
			return;
		}
		((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			method_3();
		}));
	}

	private void method_3()
	{
		if (side_0 != null)
		{
			method_4();
			((Label)lblRefresh).Text = DateTime.Now.ToString("HH:mm:ss");
		}
	}

	private void method_4()
	{
		int num = -1;
		if (lstSalvos.SelectedIndices.Count > 0)
		{
			num = lstSalvos.SelectedIndices.First();
		}
		lstSalvos.Items.Clear();
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			list = side_0.WeaponSalvos.ToList();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return;
		}
		_Closure$__89-0 closure$__89- = default(_Closure$__89-0);
		foreach (WeaponSalvo item in list)
		{
			int num2 = item.ShootersList.Sum([SpecialName] (WeaponSalvo.Shooter x) => x?.QuantityAssigned ?? 0);
			int num3 = item.ShootersList.Sum([SpecialName] (WeaponSalvo.Shooter x) => x?.QuantityFired ?? 0);
			int num4 = item.ShootersList.Count([SpecialName] (WeaponSalvo.Shooter x) => x != null);
			string text = "";
			text = ((item.Target == null || item.Target == null) ? "NO TARGET" : item.Target.Name);
			string text2 = "";
			WeaponSalvo.Shooter[] shootersList = item.ShootersList;
			for (int num5 = 0; num5 < shootersList.Length; num5 = checked(num5 + 1))
			{
				closure$__89- = new _Closure$__89-0(closure$__89-);
				closure$__89-.$VB$Local_theShooter = shootersList[num5];
				if (closure$__89-.$VB$Local_theShooter == null)
				{
					continue;
				}
				try
				{
					ActiveUnit activeUnit = side_0.Units.FirstOrDefault(closure$__89-._Lambda$__3);
					if (activeUnit != null)
					{
						text2 = text2 + Environment.NewLine + "  [" + activeUnit.Name + "]";
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			string text3 = text + text2 + "   FIRED " + Conversions.ToString(num3) + "/" + Conversions.ToString(num2) + "   AIRBOURNE " + Conversions.ToString(item.WeaponList.Count) + "   SHOOTERS " + Conversions.ToString(num4);
			DarkListItem darkListItem = new DarkListItem(text3);
			darkListItem.Tag = item;
			lstSalvos.Items.Add(darkListItem);
		}
		if (num >= 0 && num < lstSalvos.Items.Count)
		{
			lstSalvos.SelectItem(num);
		}
		else if (lstSalvos.Items.Count > 0)
		{
			lstSalvos.SelectItem(0);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		if (lstSalvos.SelectedIndices.Count != 0)
		{
			int num = lstSalvos.SelectedIndices.First();
			if (num >= 0 && num < lstSalvos.Items.Count)
			{
				weaponSalvo_0 = lstSalvos.Items[num].Tag as WeaponSalvo;
				int_0 = 0;
				int_1 = 0;
				method_6();
			}
		}
	}

	private void method_6()
	{
		if (weaponSalvo_0 == null)
		{
			txtDetail.Text = "";
			method_7();
			return;
		}
		WeaponSalvo weaponSalvo = weaponSalvo_0;
		StringBuilder stringBuilder = new StringBuilder();
		int num = weaponSalvo.ShootersList.Sum([SpecialName] (WeaponSalvo.Shooter x) => x?.QuantityAssigned ?? 0);
		int num2 = weaponSalvo.ShootersList.Sum([SpecialName] (WeaponSalvo.Shooter x) => x?.QuantityFired ?? 0);
		stringBuilder.AppendLine("SALVO");
		stringBuilder.AppendLine("ID:            " + weaponSalvo.ObjectID);
		stringBuilder.AppendLine("weapon DBID:   " + Conversions.ToString(weaponSalvo.int_1));
		if (weaponSalvo.Target != null && weaponSalvo.Target.ActualUnit != null)
		{
			stringBuilder.AppendLine("Target:        " + weaponSalvo.Target.ActualUnit.Name + "  [" + weaponSalvo.Target.ObjectID + "]");
		}
		else
		{
			stringBuilder.AppendLine("Target:        none");
		}
		stringBuilder.AppendLine("Weapons:       " + Conversions.ToString(num2) + " fired / " + Conversions.ToString(num) + " assigned  |  " + Conversions.ToString(weaponSalvo.WeaponList.Count) + " airborne");
		stringBuilder.AppendLine("Manual fire:   " + Conversions.ToString(weaponSalvo.ManualFire));
		stringBuilder.AppendLine("Simultaneous:  " + Conversions.ToString(weaponSalvo.FireSimultaneouslyFromMultipleMounts));
		string text = ((DateTime.Compare(weaponSalvo.ScheduledFireTime, DateTime.MinValue) == 0) ? "IMMEDIATELY" : ((DateTime.Compare(weaponSalvo.ScheduledFireTime, DateTime.MaxValue) != 0) ? weaponSalvo.ScheduledFireTime.ToString("HH:mm:ss") : "PALLETIZED"));
		stringBuilder.AppendLine("Scheduled:     " + text);
		stringBuilder.AppendLine("Special mode:  " + weaponSalvo.ActiveSpecialMode);
		stringBuilder.AppendLine();
		List<WeaponSalvo.Shooter> list = weaponSalvo.ShootersList.Where([SpecialName] (WeaponSalvo.Shooter x) => x != null).ToList();
		stringBuilder.AppendLine("SHOOTERS  (" + Conversions.ToString(list.Count) + ")");
		int num3 = list.Count - 1;
		_Closure$__91-0 closure$__91- = default(_Closure$__91-0);
		for (int num4 = 0; num4 <= num3; num4++)
		{
			closure$__91- = new _Closure$__91-0(closure$__91-);
			closure$__91-.$VB$Local_sh = list[num4];
			string text2 = "?";
			try
			{
				ActiveUnit activeUnit = side_0.Units.FirstOrDefault(closure$__91-._Lambda$__3);
				if (activeUnit != null)
				{
					text2 = activeUnit.Name;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			string text3 = ((num4 != int_0 % Math.Max(1, list.Count)) ? "" : "  [selected]");
			stringBuilder.AppendLine("[" + Conversions.ToString(num4 + 1) + "]  " + text2 + "   Assigned:" + Conversions.ToString(closure$__91-.$VB$Local_sh.QuantityAssigned) + "  Fired:" + Conversions.ToString(closure$__91-.$VB$Local_sh.QuantityFired) + "  Left:" + Conversions.ToString(closure$__91-.$VB$Local_sh.QuantityAssigned - closure$__91-.$VB$Local_sh.QuantityFired) + "  Ready:" + Conversions.ToString(closure$__91-.$VB$Local_sh.WeaponIsReadyToFire) + "  T/O:" + Conversions.ToString(closure$__91-.$VB$Local_sh.Timeout) + text3);
		}
		stringBuilder.AppendLine();
		List<string> list2 = weaponSalvo.WeaponList.Keys.ToList();
		stringBuilder.AppendLine("AIRBORNE WEAPONS  (" + Conversions.ToString(list2.Count) + ")");
		int num5 = list2.Count - 1;
		for (int num6 = 0; num6 <= num5; num6++)
		{
			string text4 = list2[num6];
			string text5 = "?";
			try
			{
				ActiveUnit activeUnit2 = side_0.ParentScen?.ActiveUnits[text4];
				if (activeUnit2 != null)
				{
					text5 = activeUnit2.Name;
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			string text6 = ((num6 != int_1 % Math.Max(1, list2.Count)) ? "" : "  [selected]");
			stringBuilder.AppendLine("[" + Conversions.ToString(num6 + 1) + "]  " + text5 + "  [" + text4.Substring(0, Math.Min(8, text4.Length)) + "]" + text6);
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("FIRING PROPOSALS");
		try
		{
			if (side_0.FiringProposals != null)
			{
				foreach (FiringProposal item in side_0.FiringProposals.Values.ToList())
				{
					string text7 = ((item.int_1 != weaponSalvo.int_1 || weaponSalvo.Target == null || item.Target == null || Operators.CompareString(item.Target.ObjectID, weaponSalvo.Target.ObjectID, true) != 0) ? "       " : "MATCH  ");
					string text8 = ((item.FiringUnit == null) ? "?" : item.FiringUnit.Name);
					string text9 = ((item.Target == null || item.Target.ActualUnit == null) ? "?" : item.Target.ActualUnit.Name);
					string text10 = ((!item.QuantityToFire.HasValue) ? "?" : item.QuantityToFire.Value.ToString());
					string text11 = ((!item.QuantityAvailable.HasValue) ? "?" : item.QuantityAvailable.Value.ToString());
					string text12 = ((DateTime.Compare(item.ETA, DateTime.MinValue) != 0) ? item.ETA.ToString("HH:mm:ss") : "n/a");
					stringBuilder.AppendLine(text7 + "Shooter:" + text8 + "  Target:" + text9 + "  Qty:" + text10 + "/" + text11 + "  Dist:" + item.Distance.ToString("0") + "nm  ETA:" + text12);
				}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		txtDetail.Text = stringBuilder.ToString();
		method_7();
	}

	private void method_7()
	{
		if (weaponSalvo_0 != null)
		{
			WeaponSalvo weaponSalvo = weaponSalvo_0;
			int num = weaponSalvo.ShootersList.Count([SpecialName] (WeaponSalvo.Shooter x) => x != null);
			int count = weaponSalvo.WeaponList.Count;
			btnGoTarget.Enabled = weaponSalvo.Target != null && weaponSalvo.Target.ActualUnit != null;
			btnPrevShooter.Enabled = num > 0;
			btnNextShooter.Enabled = num > 0;
			btnPrevWeapon.Enabled = count > 0;
			btnNextWeapon.Enabled = count > 0;
			if (num > 0)
			{
				((Label)lblShooterPos).Text = int_0 % num + 1 + "/" + Conversions.ToString(num);
			}
			else
			{
				((Label)lblShooterPos).Text = "0/0";
			}
			if (count <= 0)
			{
				((Label)lblWeaponPos).Text = "0/0";
			}
			else
			{
				((Label)lblWeaponPos).Text = int_1 % count + 1 + "/" + Conversions.ToString(count);
			}
		}
		else
		{
			btnGoTarget.Enabled = false;
			btnPrevShooter.Enabled = false;
			btnNextShooter.Enabled = false;
			btnPrevWeapon.Enabled = false;
			btnNextWeapon.Enabled = false;
			((Label)lblShooterPos).Text = "";
			((Label)lblWeaponPos).Text = "";
		}
	}

	private void method_8()
	{
		if (weaponSalvo_0 != null && weaponSalvo_0.Target != null)
		{
			ActiveUnit actualUnit = weaponSalvo_0.Target.ActualUnit;
			if (actualUnit != null && SelectUnitAction != null)
			{
				SelectUnitAction(actualUnit);
				((Label)lblStatus).Text = "Centered: " + actualUnit.Name;
			}
		}
	}

	private void method_9(int int_2)
	{
		if (weaponSalvo_0 == null)
		{
			return;
		}
		List<WeaponSalvo.Shooter> list = weaponSalvo_0.ShootersList.Where([SpecialName] (WeaponSalvo.Shooter x) => x != null).ToList();
		if (list.Count == 0)
		{
			return;
		}
		int_0 = ((int_0 + int_2) % list.Count + list.Count) % list.Count;
		WeaponSalvo.Shooter shooter = list[int_0];
		try
		{
			ActiveUnit activeUnit = side_0.Units.FirstOrDefault([SpecialName] (ActiveUnit x) => Operators.CompareString(x.ObjectID, shooter.ShooterObjectID, true) == 0);
			if (activeUnit != null)
			{
				ActiveUnit activeUnit2 = activeUnit;
				if (activeUnit2 != null && SelectUnitAction != null)
				{
					SelectUnitAction(activeUnit2);
				}
				((Label)lblStatus).Text = "Shooter " + Conversions.ToString(int_0 + 1) + "/" + Conversions.ToString(list.Count) + ": " + activeUnit.Name;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		method_6();
	}

	private void method_10(int int_2)
	{
		if (weaponSalvo_0 == null)
		{
			return;
		}
		List<string> list = weaponSalvo_0.WeaponList.Keys.ToList();
		if (list.Count == 0)
		{
			return;
		}
		int_1 = ((int_1 + int_2) % list.Count + list.Count) % list.Count;
		string text = list[int_1];
		try
		{
			ActiveUnit activeUnit = side_0.ParentScen?.ActiveUnits[text];
			if (activeUnit == null)
			{
				((Label)lblStatus).Text = "Weapon " + Conversions.ToString(int_1 + 1) + "/" + Conversions.ToString(list.Count) + ": " + text.Substring(0, Math.Min(8, text.Length)) + " (not found)";
			}
			else
			{
				ActiveUnit activeUnit2 = activeUnit;
				if (activeUnit2 != null && SelectUnitAction != null)
				{
					SelectUnitAction(activeUnit2);
				}
				((Label)lblStatus).Text = "Weapon " + Conversions.ToString(int_1 + 1) + "/" + Conversions.ToString(list.Count) + ": " + activeUnit.Name;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		method_6();
	}

	private void method_11(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_12(object sender, EventArgs e)
	{
		if (!chkAutoRefresh.Checked)
		{
			timer_0.Stop();
		}
		else
		{
			timer_0.Start();
		}
	}

	private void SalvoDebugForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		timer_0.Stop();
		((Component)(object)timer_0).Dispose();
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__85-2()
	{
		method_9(-1);
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__85-3()
	{
		method_9(1);
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__85-4()
	{
		method_10(-1);
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__85-5()
	{
		method_10(1);
	}

	static SalvoDebugForm()
	{
		Class72.smethod_20();
	}
}
