using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;

namespace DarkUI.Forms;

public class DarkDialog : DarkForm
{
	private DarkDialogButton darkDialogButton_0;

	private List<DarkButton> wqUycBiEhml;

	protected DarkButton btnOk;

	protected DarkButton btnCancel;

	protected DarkButton btnClose;

	protected DarkButton btnYes;

	protected DarkButton btnNo;

	protected DarkButton btnAbort;

	protected DarkButton btnRetry;

	protected DarkButton btnIgnore;

	protected DarkButton btnDoNotNotify;

	[CompilerGenerated]
	private int int_0;

	private IContainer CbCyckEkojD;

	private Panel pnlFooter;

	private FlowLayoutPanel flowInner;

	[Description("Determines the type of the dialog window.")]
	[DefaultValue(DarkDialogButton.Ok)]
	public DarkDialogButton DialogButtons
	{
		get
		{
			return darkDialogButton_0;
		}
		set
		{
			if (darkDialogButton_0 != value)
			{
				darkDialogButton_0 = value;
				method_0();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TotalButtonSize
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IButtonControl AcceptButton
	{
		get
		{
			return ((Form)this).AcceptButton;
		}
		private set
		{
			((Form)this).AcceptButton = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IButtonControl CancelButton
	{
		get
		{
			return ((Form)this).CancelButton;
		}
		private set
		{
			((Form)this).CancelButton = value;
		}
	}

	public DarkDialog()
	{
		InitializeComponent();
		wqUycBiEhml = new List<DarkButton> { btnAbort, btnRetry, btnIgnore, btnOk, btnCancel, btnClose, btnYes, btnNo, btnDoNotNotify };
	}

	protected override void OnLoad(EventArgs e)
	{
		((Form)this).OnLoad(e);
		method_0();
	}

	private void method_0()
	{
		foreach (DarkButton item in wqUycBiEhml)
		{
			((Control)item).Visible = false;
		}
		switch (darkDialogButton_0)
		{
		case DarkDialogButton.Ok:
			method_1(btnOk, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnOk;
			break;
		case DarkDialogButton.Close:
			method_1(btnClose, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnClose;
			CancelButton = (IButtonControl)(object)btnClose;
			break;
		case DarkDialogButton.OkCancel:
			method_1(btnOk);
			method_1(btnCancel, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnOk;
			CancelButton = (IButtonControl)(object)btnCancel;
			break;
		case DarkDialogButton.YesNo:
			method_1(btnYes);
			method_1(btnNo, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnYes;
			CancelButton = (IButtonControl)(object)btnNo;
			break;
		case DarkDialogButton.YesNoCancel:
			method_1(btnYes);
			method_1(btnNo);
			method_1(btnCancel, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnYes;
			CancelButton = (IButtonControl)(object)btnCancel;
			break;
		case DarkDialogButton.AbortRetryIgnore:
			method_1(btnAbort);
			method_1(btnRetry);
			method_1(btnIgnore, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnAbort;
			CancelButton = (IButtonControl)(object)btnIgnore;
			break;
		case DarkDialogButton.RetryCancel:
			method_1(btnRetry);
			method_1(btnCancel, bool_1: true);
			AcceptButton = (IButtonControl)(object)btnRetry;
			CancelButton = (IButtonControl)(object)btnCancel;
			break;
		case DarkDialogButton.OKDoNotNotify:
			method_1(btnOk);
			method_1(btnDoNotNotify);
			AcceptButton = (IButtonControl)(object)btnOk;
			CancelButton = (IButtonControl)(object)btnDoNotNotify;
			break;
		}
		method_2();
	}

	private void method_1(DarkButton darkButton_0, bool bool_1 = false)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		((Control)darkButton_0).SendToBack();
		if (!bool_1)
		{
			((Control)darkButton_0).Margin = new Padding(0, 0, 10, 0);
		}
		((Control)darkButton_0).Visible = true;
	}

	private void method_2()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		Padding val = ((Control)flowInner).Padding;
		int num = ((Padding)(ref val)).Horizontal;
		foreach (DarkButton item in wqUycBiEhml)
		{
			if (((Control)item).Visible)
			{
				int num2 = num;
				int width = ((Control)item).Width;
				val = ((Control)item).Margin;
				num = num2 + (width + ((Padding)(ref val)).Right);
			}
		}
		((Control)flowInner).Width = num;
		TotalButtonSize = num;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && CbCyckEkojD != null)
		{
			CbCyckEkojD.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected O, but got Unknown
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		pnlFooter = new Panel();
		flowInner = new FlowLayoutPanel();
		btnOk = new DarkButton();
		btnCancel = new DarkButton();
		btnClose = new DarkButton();
		btnYes = new DarkButton();
		btnNo = new DarkButton();
		btnAbort = new DarkButton();
		btnRetry = new DarkButton();
		btnIgnore = new DarkButton();
		btnDoNotNotify = new DarkButton();
		((Control)pnlFooter).SuspendLayout();
		((Control)flowInner).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)pnlFooter).Controls.Add((Control)(object)flowInner);
		((Control)pnlFooter).Dock = (DockStyle)2;
		((Control)pnlFooter).Location = new Point(0, 357);
		((Control)pnlFooter).Name = "pnlFooter";
		((Control)pnlFooter).Size = new Size(767, 45);
		((Control)pnlFooter).TabIndex = 1;
		((Control)flowInner).Controls.Add((Control)(object)btnOk);
		((Control)flowInner).Controls.Add((Control)(object)btnCancel);
		((Control)flowInner).Controls.Add((Control)(object)btnClose);
		((Control)flowInner).Controls.Add((Control)(object)btnYes);
		((Control)flowInner).Controls.Add((Control)(object)btnNo);
		((Control)flowInner).Controls.Add((Control)(object)btnAbort);
		((Control)flowInner).Controls.Add((Control)(object)btnRetry);
		((Control)flowInner).Controls.Add((Control)(object)btnIgnore);
		((Control)flowInner).Controls.Add((Control)(object)btnDoNotNotify);
		((Control)flowInner).Dock = (DockStyle)4;
		((Control)flowInner).Location = new Point(55, 0);
		((Control)flowInner).Name = "flowInner";
		((Control)flowInner).Padding = new Padding(10);
		((Control)flowInner).Size = new Size(712, 45);
		((Control)flowInner).TabIndex = 10014;
		((Button)btnOk).DialogResult = (DialogResult)1;
		((Control)btnOk).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnOk).Location = new Point(10, 10);
		((Control)btnOk).Margin = new Padding(0);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Padding = new Padding(5);
		((Control)btnOk).Size = new Size(75, 26);
		((Control)btnOk).TabIndex = 3;
		btnOk.Text = "Ok";
		((Button)btnCancel).DialogResult = (DialogResult)2;
		((Control)btnCancel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnCancel).Location = new Point(85, 10);
		((Control)btnCancel).Margin = new Padding(0);
		((Control)btnCancel).Name = "btnCancel";
		((Control)btnCancel).Padding = new Padding(5);
		((Control)btnCancel).Size = new Size(75, 26);
		((Control)btnCancel).TabIndex = 4;
		btnCancel.Text = "Cancel";
		((Button)btnClose).DialogResult = (DialogResult)2;
		((Control)btnClose).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnClose).Location = new Point(160, 10);
		((Control)btnClose).Margin = new Padding(0);
		((Control)btnClose).Name = "btnClose";
		((Control)btnClose).Padding = new Padding(5);
		((Control)btnClose).Size = new Size(75, 26);
		((Control)btnClose).TabIndex = 5;
		btnClose.Text = "Close";
		((Button)btnYes).DialogResult = (DialogResult)6;
		((Control)btnYes).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnYes).Location = new Point(235, 10);
		((Control)btnYes).Margin = new Padding(0);
		((Control)btnYes).Name = "btnYes";
		((Control)btnYes).Padding = new Padding(5);
		((Control)btnYes).Size = new Size(75, 26);
		((Control)btnYes).TabIndex = 6;
		btnYes.Text = "Yes";
		((Button)btnNo).DialogResult = (DialogResult)7;
		((Control)btnNo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnNo).Location = new Point(310, 10);
		((Control)btnNo).Margin = new Padding(0);
		((Control)btnNo).Name = "btnNo";
		((Control)btnNo).Padding = new Padding(5);
		((Control)btnNo).Size = new Size(75, 26);
		((Control)btnNo).TabIndex = 7;
		btnNo.Text = "No";
		((Button)btnAbort).DialogResult = (DialogResult)3;
		((Control)btnAbort).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnAbort).Location = new Point(385, 10);
		((Control)btnAbort).Margin = new Padding(0);
		((Control)btnAbort).Name = "btnAbort";
		((Control)btnAbort).Padding = new Padding(5);
		((Control)btnAbort).Size = new Size(75, 26);
		((Control)btnAbort).TabIndex = 8;
		btnAbort.Text = "Abort";
		((Button)btnRetry).DialogResult = (DialogResult)4;
		((Control)btnRetry).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnRetry).Location = new Point(460, 10);
		((Control)btnRetry).Margin = new Padding(0);
		((Control)btnRetry).Name = "btnRetry";
		((Control)btnRetry).Padding = new Padding(5);
		((Control)btnRetry).Size = new Size(75, 26);
		((Control)btnRetry).TabIndex = 9;
		btnRetry.Text = "Retry";
		((Button)btnIgnore).DialogResult = (DialogResult)5;
		((Control)btnIgnore).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnIgnore).Location = new Point(535, 10);
		((Control)btnIgnore).Margin = new Padding(0);
		((Control)btnIgnore).Name = "btnIgnore";
		((Control)btnIgnore).Padding = new Padding(5);
		((Control)btnIgnore).Size = new Size(75, 26);
		((Control)btnIgnore).TabIndex = 10;
		btnIgnore.Text = "Ignore";
		((Button)btnDoNotNotify).DialogResult = (DialogResult)2;
		((Control)btnDoNotNotify).Font = new Font("Microsoft Sans Serif", 7f);
		((Control)btnDoNotNotify).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnDoNotNotify).Location = new Point(610, 10);
		((Control)btnDoNotNotify).Margin = new Padding(0);
		((Control)btnDoNotNotify).Name = "btnDoNotNotify";
		((Control)btnDoNotNotify).Padding = new Padding(5);
		((Control)btnDoNotNotify).Size = new Size(75, 26);
		((Control)btnDoNotNotify).TabIndex = 11;
		btnDoNotNotify.Text = "Do not Notify";
		((Form)this).ClientSize = new Size(767, 402);
		((Control)this).Controls.Add((Control)(object)pnlFooter);
		((Control)this).Name = "DarkDialog";
		((Control)this).Text = "DarkDialog";
		((Control)pnlFooter).ResumeLayout(false);
		((Control)flowInner).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	static DarkDialog()
	{
		Class72.smethod_20();
	}
}
