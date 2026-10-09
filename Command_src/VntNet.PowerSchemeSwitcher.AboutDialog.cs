using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VntNet.PowerSchemeSwitcher;

public class AboutDialog : Form
{
	private IContainer icontainer_0;

	private Label labelProductName;

	private Label labelVersion;

	private Label labelCompanyName;

	private Button okButton;

	private TableLayoutPanel tableLayoutPanel;

	private PictureBox logoPictureBox;

	private TextBox textBoxDescription;

	private LinkLabel linkLabel1;

	public AboutDialog()
	{
		InitializeComponent();
		((Control)this).Text = string.Format(((Control)this).Text, smethod_0());
		((Control)labelProductName).Text = smethod_4();
		((Control)labelVersion).Text = string.Format(((Control)labelVersion).Text, smethod_1(), smethod_2());
		((Control)labelCompanyName).Text = smethod_6();
		((Control)textBoxDescription).Text = smethod_3();
		((Control)labelCompanyName).Visible = false;
		((Control)textBoxDescription).Visible = false;
		linkLabel1.Links.Remove(linkLabel1.Links[0]);
		linkLabel1.Links.Add(0, ((Control)linkLabel1).Text.Length, (object)"http://powerschemeswitcher.codeplex.com");
	}

	[SpecialName]
	private static string smethod_0()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		object[] customAttributes = executingAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			return ((AssemblyTitleAttribute)customAttributes[0]).Title;
		}
		return executingAssembly.GetName().Name;
	}

	[SpecialName]
	private static string smethod_1()
	{
		return Assembly.GetExecutingAssembly().GetName().Version.ToString();
	}

	[SpecialName]
	private static string smethod_2()
	{
		return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
	}

	[SpecialName]
	private static string smethod_3()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return string.Empty;
		}
		return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
	}

	[SpecialName]
	private static string smethod_4()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			return ((AssemblyProductAttribute)customAttributes[0]).Product;
		}
		return string.Empty;
	}

	[SpecialName]
	private static string smethod_5()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
		}
		return string.Empty;
	}

	[SpecialName]
	private static string smethod_6()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
		}
		return string.Empty;
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()));
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
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
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AboutDialog));
		labelProductName = new Label();
		labelVersion = new Label();
		labelCompanyName = new Label();
		okButton = new Button();
		tableLayoutPanel = new TableLayoutPanel();
		logoPictureBox = new PictureBox();
		textBoxDescription = new TextBox();
		linkLabel1 = new LinkLabel();
		((Control)tableLayoutPanel).SuspendLayout();
		((ISupportInitialize)logoPictureBox).BeginInit();
		((Control)this).SuspendLayout();
		((Control)labelProductName).Dock = (DockStyle)5;
		labelProductName.ImeMode = (ImeMode)0;
		((Control)labelProductName).Location = new Point(141, 0);
		((Control)labelProductName).Margin = new Padding(6, 0, 3, 0);
		((Control)labelProductName).MaximumSize = new Size(0, 17);
		((Control)labelProductName).Name = "labelProductName";
		((Control)labelProductName).Size = new Size(266, 17);
		((Control)labelProductName).TabIndex = 19;
		((Control)labelProductName).Text = "Product Name";
		labelProductName.TextAlign = (ContentAlignment)16;
		((Control)labelVersion).Dock = (DockStyle)5;
		labelVersion.ImeMode = (ImeMode)0;
		((Control)labelVersion).Location = new Point(141, 25);
		((Control)labelVersion).Margin = new Padding(6, 0, 3, 0);
		((Control)labelVersion).MaximumSize = new Size(0, 17);
		((Control)labelVersion).Name = "labelVersion";
		((Control)labelVersion).Size = new Size(266, 17);
		((Control)labelVersion).TabIndex = 0;
		((Control)labelVersion).Text = "Version {0} ({1})";
		labelVersion.TextAlign = (ContentAlignment)16;
		((Control)labelCompanyName).Dock = (DockStyle)5;
		labelCompanyName.ImeMode = (ImeMode)0;
		((Control)labelCompanyName).Location = new Point(141, 75);
		((Control)labelCompanyName).Margin = new Padding(6, 0, 3, 0);
		((Control)labelCompanyName).MaximumSize = new Size(0, 17);
		((Control)labelCompanyName).Name = "labelCompanyName";
		((Control)labelCompanyName).Size = new Size(266, 17);
		((Control)labelCompanyName).TabIndex = 22;
		((Control)labelCompanyName).Text = "Company Name";
		labelCompanyName.TextAlign = (ContentAlignment)16;
		((Control)okButton).Anchor = (AnchorStyles)10;
		okButton.DialogResult = (DialogResult)2;
		((ButtonBase)okButton).ImeMode = (ImeMode)0;
		((Control)okButton).Location = new Point(332, 233);
		((Control)okButton).Name = "okButton";
		((Control)okButton).Size = new Size(75, 23);
		((Control)okButton).TabIndex = 24;
		((Control)okButton).Text = "OK";
		tableLayoutPanel.ColumnCount = 2;
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle((SizeType)2, 67f));
		tableLayoutPanel.Controls.Add((Control)(object)logoPictureBox, 0, 0);
		tableLayoutPanel.Controls.Add((Control)(object)labelProductName, 1, 0);
		tableLayoutPanel.Controls.Add((Control)(object)labelVersion, 1, 1);
		tableLayoutPanel.Controls.Add((Control)(object)labelCompanyName, 1, 3);
		tableLayoutPanel.Controls.Add((Control)(object)textBoxDescription, 1, 4);
		tableLayoutPanel.Controls.Add((Control)(object)okButton, 1, 5);
		tableLayoutPanel.Controls.Add((Control)(object)linkLabel1, 1, 2);
		((Control)tableLayoutPanel).Dock = (DockStyle)5;
		((Control)tableLayoutPanel).Location = new Point(0, 0);
		((Control)tableLayoutPanel).Name = "tableLayoutPanel";
		tableLayoutPanel.RowCount = 6;
		tableLayoutPanel.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		tableLayoutPanel.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		tableLayoutPanel.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		tableLayoutPanel.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		tableLayoutPanel.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		tableLayoutPanel.RowStyles.Add(new RowStyle((SizeType)2, 10f));
		((Control)tableLayoutPanel).Size = new Size(410, 259);
		((Control)tableLayoutPanel).TabIndex = 1;
		((Control)logoPictureBox).Dock = (DockStyle)5;
		logoPictureBox.ImeMode = (ImeMode)0;
		((Control)logoPictureBox).Location = new Point(3, 3);
		((Control)logoPictureBox).Name = "logoPictureBox";
		tableLayoutPanel.SetRowSpan((Control)(object)logoPictureBox, 6);
		((Control)logoPictureBox).Size = new Size(129, 253);
		logoPictureBox.SizeMode = (PictureBoxSizeMode)1;
		logoPictureBox.TabIndex = 12;
		logoPictureBox.TabStop = false;
		((Control)textBoxDescription).Dock = (DockStyle)5;
		((Control)textBoxDescription).Location = new Point(141, 103);
		((Control)textBoxDescription).Margin = new Padding(6, 3, 3, 3);
		((TextBoxBase)textBoxDescription).Multiline = true;
		((Control)textBoxDescription).Name = "textBoxDescription";
		((TextBoxBase)textBoxDescription).ReadOnly = true;
		textBoxDescription.ScrollBars = (ScrollBars)3;
		((Control)textBoxDescription).Size = new Size(266, 123);
		((Control)textBoxDescription).TabIndex = 23;
		((Control)textBoxDescription).TabStop = false;
		((Control)textBoxDescription).Text = "Description";
		((Control)linkLabel1).AutoSize = true;
		((Control)linkLabel1).Location = new Point(141, 50);
		((Control)linkLabel1).Margin = new Padding(6, 0, 6, 0);
		((Control)linkLabel1).Name = "linkLabel1";
		((Control)linkLabel1).Size = new Size(217, 13);
		((Control)linkLabel1).TabIndex = 25;
		linkLabel1.TabStop = true;
		((Control)linkLabel1).Text = "http://powerschemeswitcher.codeplex.com/";
		linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((Form)this).ClientSize = new Size(410, 259);
		((Control)this).Controls.Add((Control)(object)tableLayoutPanel);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "AboutDialog";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "About {0}";
		((Control)tableLayoutPanel).ResumeLayout(false);
		((Control)tableLayoutPanel).PerformLayout();
		((ISupportInitialize)logoPictureBox).EndInit();
		((Control)this).ResumeLayout(false);
	}

	static AboutDialog()
	{
		Class72.smethod_20();
	}
}
