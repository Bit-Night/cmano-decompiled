using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class PlatformComponentArcControl : DarkUserControl
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("CB_PB1")]
	[CompilerGenerated]
	private DarkCheckBox _CB_PB1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PB2")]
	private DarkCheckBox _CB_PB2;

	[AccessedThroughProperty("CB_SB1")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SB1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SB2")]
	private DarkCheckBox _CB_SB2;

	[AccessedThroughProperty("CB_PMF1")]
	[CompilerGenerated]
	private DarkCheckBox _CB_PMF1;

	[AccessedThroughProperty("CB_PMF2")]
	[CompilerGenerated]
	private DarkCheckBox _CB_PMF2;

	[AccessedThroughProperty("CB_SMF2")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SMF2;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SMF1")]
	private DarkCheckBox _CB_SMF1;

	[AccessedThroughProperty("CB_PMA2")]
	[CompilerGenerated]
	private DarkCheckBox _CB_PMA2;

	[AccessedThroughProperty("CB_PMA1")]
	[CompilerGenerated]
	private DarkCheckBox _CB_PMA1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PS2")]
	private DarkCheckBox _CB_PS2;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_PS1")]
	private DarkCheckBox _CB_PS1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SS2")]
	private DarkCheckBox _CB_SS2;

	[AccessedThroughProperty("CB_SS1")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SS1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SMA1")]
	private DarkCheckBox _CB_SMA1;

	[AccessedThroughProperty("CB_SMA2")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SMA2;

	[AccessedThroughProperty("PictureBox1")]
	[CompilerGenerated]
	private PictureBox _PictureBox1;

	public PlatformComponent._Coverage theCoverage;

	internal virtual DarkCheckBox CB_PB1
	{
		[CompilerGenerated]
		get
		{
			return _CB_PB1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkCheckBox darkCheckBox = _CB_PB1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PB1 = value;
			darkCheckBox = _CB_PB1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PB2
	{
		[CompilerGenerated]
		get
		{
			return _CB_PB2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkCheckBox darkCheckBox = _CB_PB2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PB2 = value;
			darkCheckBox = _CB_PB2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SB1
	{
		[CompilerGenerated]
		get
		{
			return _CB_SB1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkCheckBox darkCheckBox = _CB_SB1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SB1 = value;
			darkCheckBox = _CB_SB1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SB2
	{
		[CompilerGenerated]
		get
		{
			return _CB_SB2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkCheckBox darkCheckBox = _CB_SB2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SB2 = value;
			darkCheckBox = _CB_SB2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PMF1
	{
		[CompilerGenerated]
		get
		{
			return _CB_PMF1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkCheckBox darkCheckBox = _CB_PMF1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PMF1 = value;
			darkCheckBox = _CB_PMF1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PMF2
	{
		[CompilerGenerated]
		get
		{
			return _CB_PMF2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkCheckBox darkCheckBox = _CB_PMF2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PMF2 = value;
			darkCheckBox = _CB_PMF2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SMF2
	{
		[CompilerGenerated]
		get
		{
			return _CB_SMF2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkCheckBox darkCheckBox = _CB_SMF2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SMF2 = value;
			darkCheckBox = _CB_SMF2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SMF1
	{
		[CompilerGenerated]
		get
		{
			return _CB_SMF1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkCheckBox darkCheckBox = _CB_SMF1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SMF1 = value;
			darkCheckBox = _CB_SMF1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PMA2
	{
		[CompilerGenerated]
		get
		{
			return _CB_PMA2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkCheckBox darkCheckBox = _CB_PMA2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PMA2 = value;
			darkCheckBox = _CB_PMA2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PMA1
	{
		[CompilerGenerated]
		get
		{
			return _CB_PMA1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkCheckBox darkCheckBox = _CB_PMA1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PMA1 = value;
			darkCheckBox = _CB_PMA1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PS2
	{
		[CompilerGenerated]
		get
		{
			return _CB_PS2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkCheckBox darkCheckBox = _CB_PS2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PS2 = value;
			darkCheckBox = _CB_PS2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_PS1
	{
		[CompilerGenerated]
		get
		{
			return _CB_PS1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkCheckBox darkCheckBox = _CB_PS1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_PS1 = value;
			darkCheckBox = _CB_PS1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SS2
	{
		[CompilerGenerated]
		get
		{
			return _CB_SS2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkCheckBox darkCheckBox = _CB_SS2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SS2 = value;
			darkCheckBox = _CB_SS2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SS1
	{
		[CompilerGenerated]
		get
		{
			return _CB_SS1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkCheckBox darkCheckBox = _CB_SS1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SS1 = value;
			darkCheckBox = _CB_SS1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SMA1
	{
		[CompilerGenerated]
		get
		{
			return _CB_SMA1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkCheckBox darkCheckBox = _CB_SMA1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SMA1 = value;
			darkCheckBox = _CB_SMA1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SMA2
	{
		[CompilerGenerated]
		get
		{
			return _CB_SMA2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkCheckBox darkCheckBox = _CB_SMA2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SMA2 = value;
			darkCheckBox = _CB_SMA2;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return _PictureBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			PictureBox val = _PictureBox1;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PictureBox1 = value;
			val = _PictureBox1;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	public bool NoArcsSelected
	{
		get
		{
			if (theCoverage.SB1)
			{
				return false;
			}
			if (!theCoverage.SB2)
			{
				if (!theCoverage.SMF1)
				{
					if (!theCoverage.SMF2)
					{
						if (theCoverage.SMA1)
						{
							return false;
						}
						if (!theCoverage.SMA2)
						{
							if (!theCoverage.SS1)
							{
								if (theCoverage.SS2)
								{
									return false;
								}
								if (theCoverage.PB1)
								{
									return false;
								}
								if (!theCoverage.PB2)
								{
									if (!theCoverage.PMF1)
									{
										if (theCoverage.PMF2)
										{
											return false;
										}
										if (theCoverage.PMA1)
										{
											return false;
										}
										if (theCoverage.PMA2)
										{
											return false;
										}
										if (theCoverage.PS1)
										{
											return false;
										}
										if (!theCoverage.PS2)
										{
											return true;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public bool AllArcsSelected
	{
		get
		{
			if (!theCoverage.SB1)
			{
				return false;
			}
			if (!theCoverage.SB2)
			{
				return false;
			}
			if (!theCoverage.SMF1)
			{
				return false;
			}
			if (theCoverage.SMF2)
			{
				if (!theCoverage.SMA1)
				{
					return false;
				}
				if (theCoverage.SMA2)
				{
					if (!theCoverage.SS1)
					{
						return false;
					}
					if (!theCoverage.SS2)
					{
						return false;
					}
					if (theCoverage.PB1)
					{
						if (!theCoverage.PB2)
						{
							return false;
						}
						if (theCoverage.PMF1)
						{
							if (!theCoverage.PMF2)
							{
								return false;
							}
							if (theCoverage.PMA1)
							{
								if (!theCoverage.PMA2)
								{
									return false;
								}
								if (theCoverage.PS1)
								{
									if (theCoverage.PS2)
									{
										return true;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public PlatformComponentArcControl()
	{
		((Control)this).DoubleClick += PlatformComponentArcControl_DoubleClick;
		((UserControl)this).Load += PlatformComponentArcControl_Load;
		theCoverage = new PlatformComponent._Coverage();
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
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PlatformComponentArcControl));
		CB_PB1 = new DarkCheckBox();
		CB_PB2 = new DarkCheckBox();
		CB_SB1 = new DarkCheckBox();
		CB_SB2 = new DarkCheckBox();
		CB_PMF1 = new DarkCheckBox();
		CB_PMF2 = new DarkCheckBox();
		CB_SMF2 = new DarkCheckBox();
		CB_SMF1 = new DarkCheckBox();
		CB_PMA2 = new DarkCheckBox();
		CB_PMA1 = new DarkCheckBox();
		CB_PS2 = new DarkCheckBox();
		CB_PS1 = new DarkCheckBox();
		CB_SS2 = new DarkCheckBox();
		CB_SS1 = new DarkCheckBox();
		CB_SMA1 = new DarkCheckBox();
		CB_SMA2 = new DarkCheckBox();
		PictureBox1 = new PictureBox();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)CB_PB1).Location = new Point(20, 8);
		((Control)CB_PB1).Name = "CB_PB1";
		((Control)CB_PB1).Size = new Size(15, 14);
		((Control)CB_PB1).TabIndex = 1;
		((Control)CB_PB2).Location = new Point(34, 4);
		((Control)CB_PB2).Name = "CB_PB2";
		((Control)CB_PB2).Size = new Size(15, 14);
		((Control)CB_PB2).TabIndex = 2;
		((Control)CB_SB1).Location = new Point(48, 4);
		((Control)CB_SB1).Name = "CB_SB1";
		((Control)CB_SB1).Size = new Size(15, 14);
		((Control)CB_SB1).TabIndex = 3;
		((Control)CB_SB2).Location = new Point(62, 7);
		((Control)CB_SB2).Name = "CB_SB2";
		((Control)CB_SB2).Size = new Size(15, 14);
		((Control)CB_SB2).TabIndex = 4;
		((Control)CB_PMF1).Location = new Point(5, 36);
		((Control)CB_PMF1).Name = "CB_PMF1";
		((Control)CB_PMF1).Size = new Size(15, 14);
		((Control)CB_PMF1).TabIndex = 5;
		((Control)CB_PMF2).Location = new Point(9, 22);
		((Control)CB_PMF2).Name = "CB_PMF2";
		((Control)CB_PMF2).Size = new Size(15, 14);
		((Control)CB_PMF2).TabIndex = 6;
		((Control)CB_SMF2).Location = new Point(78, 35);
		((Control)CB_SMF2).Name = "CB_SMF2";
		((Control)CB_SMF2).Size = new Size(15, 14);
		((Control)CB_SMF2).TabIndex = 7;
		((Control)CB_SMF1).Location = new Point(72, 21);
		((Control)CB_SMF1).Name = "CB_SMF1";
		((Control)CB_SMF1).Size = new Size(15, 14);
		((Control)CB_SMF1).TabIndex = 8;
		((Control)CB_PMA2).Location = new Point(5, 51);
		((Control)CB_PMA2).Name = "CB_PMA2";
		((Control)CB_PMA2).Size = new Size(15, 14);
		((Control)CB_PMA2).TabIndex = 9;
		((Control)CB_PMA1).Location = new Point(9, 65);
		((Control)CB_PMA1).Name = "CB_PMA1";
		((Control)CB_PMA1).Size = new Size(15, 14);
		((Control)CB_PMA1).TabIndex = 10;
		((Control)CB_PS2).Location = new Point(20, 79);
		((Control)CB_PS2).Name = "CB_PS2";
		((Control)CB_PS2).Size = new Size(15, 14);
		((Control)CB_PS2).TabIndex = 11;
		((Control)CB_PS1).Location = new Point(34, 82);
		((Control)CB_PS1).Name = "CB_PS1";
		((Control)CB_PS1).Size = new Size(15, 14);
		((Control)CB_PS1).TabIndex = 12;
		((Control)CB_SS2).Location = new Point(49, 82);
		((Control)CB_SS2).Name = "CB_SS2";
		((Control)CB_SS2).Size = new Size(15, 14);
		((Control)CB_SS2).TabIndex = 13;
		((Control)CB_SS1).Location = new Point(63, 77);
		((Control)CB_SS1).Name = "CB_SS1";
		((Control)CB_SS1).Size = new Size(15, 14);
		((Control)CB_SS1).TabIndex = 14;
		((Control)CB_SMA1).Location = new Point(78, 49);
		((Control)CB_SMA1).Name = "CB_SMA1";
		((Control)CB_SMA1).Size = new Size(15, 14);
		((Control)CB_SMA1).TabIndex = 15;
		((Control)CB_SMA2).Location = new Point(72, 63);
		((Control)CB_SMA2).Name = "CB_SMA2";
		((Control)CB_SMA2).Size = new Size(15, 14);
		((Control)CB_SMA2).TabIndex = 16;
		PictureBox1.Image = (Image)componentResourceManager.GetObject("PictureBox1.Image");
		((Control)PictureBox1).Location = new Point(22, 20);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(50, 61);
		PictureBox1.TabIndex = 17;
		PictureBox1.TabStop = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)CB_SMA2);
		((Control)this).Controls.Add((Control)(object)CB_SMA1);
		((Control)this).Controls.Add((Control)(object)CB_SS1);
		((Control)this).Controls.Add((Control)(object)CB_SS2);
		((Control)this).Controls.Add((Control)(object)CB_PS1);
		((Control)this).Controls.Add((Control)(object)CB_PS2);
		((Control)this).Controls.Add((Control)(object)CB_PMA1);
		((Control)this).Controls.Add((Control)(object)CB_PMA2);
		((Control)this).Controls.Add((Control)(object)CB_SMF1);
		((Control)this).Controls.Add((Control)(object)CB_SMF2);
		((Control)this).Controls.Add((Control)(object)CB_PMF2);
		((Control)this).Controls.Add((Control)(object)CB_PMF1);
		((Control)this).Controls.Add((Control)(object)CB_SB2);
		((Control)this).Controls.Add((Control)(object)CB_SB1);
		((Control)this).Controls.Add((Control)(object)CB_PB2);
		((Control)this).Controls.Add((Control)(object)CB_PB1);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Name = "PlatformComponentArcControl";
		((Control)this).Size = new Size(100, 100);
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void method_1(object sender, EventArgs e)
	{
		theCoverage.SB1 = ((CheckBox)CB_SB1).Checked;
	}

	private void method_2(object sender, EventArgs e)
	{
		theCoverage.SB2 = ((CheckBox)CB_SB2).Checked;
	}

	private void method_3(object sender, EventArgs e)
	{
		theCoverage.SMF1 = ((CheckBox)CB_SMF1).Checked;
	}

	private void method_4(object sender, EventArgs e)
	{
		theCoverage.SMF2 = ((CheckBox)CB_SMF2).Checked;
	}

	private void method_5(object sender, EventArgs e)
	{
		theCoverage.SMA1 = ((CheckBox)CB_SMA1).Checked;
	}

	private void method_6(object sender, EventArgs e)
	{
		theCoverage.SMA2 = ((CheckBox)CB_SMA2).Checked;
	}

	private void method_7(object sender, EventArgs e)
	{
		theCoverage.SS1 = ((CheckBox)CB_SS1).Checked;
	}

	private void method_8(object sender, EventArgs e)
	{
		theCoverage.SS2 = ((CheckBox)CB_SS2).Checked;
	}

	private void method_9(object sender, EventArgs e)
	{
		theCoverage.PB1 = ((CheckBox)CB_PB1).Checked;
	}

	private void method_10(object sender, EventArgs e)
	{
		theCoverage.PB2 = ((CheckBox)CB_PB2).Checked;
	}

	private void method_11(object sender, EventArgs e)
	{
		theCoverage.PMF1 = ((CheckBox)CB_PMF1).Checked;
	}

	private void method_12(object sender, EventArgs e)
	{
		theCoverage.PMF2 = ((CheckBox)CB_PMF2).Checked;
	}

	private void method_13(object sender, EventArgs e)
	{
		theCoverage.PMA1 = ((CheckBox)CB_PMA1).Checked;
	}

	private void method_14(object sender, EventArgs e)
	{
		theCoverage.PMA2 = ((CheckBox)CB_PMA2).Checked;
	}

	private void method_15(object sender, EventArgs e)
	{
		theCoverage.PS1 = ((CheckBox)CB_PS1).Checked;
	}

	private void method_16(object sender, EventArgs e)
	{
		theCoverage.PS2 = ((CheckBox)CB_PS2).Checked;
	}

	private void PlatformComponentArcControl_DoubleClick(object sender, EventArgs e)
	{
		method_17();
	}

	private void method_17()
	{
		if (AllArcsSelected)
		{
			method_19();
		}
		else
		{
			method_18();
		}
	}

	private void method_18()
	{
		theCoverage.PB1 = true;
		theCoverage.PB2 = true;
		theCoverage.PMA1 = true;
		theCoverage.PMA2 = true;
		theCoverage.PMF1 = true;
		theCoverage.PMF2 = true;
		theCoverage.PS1 = true;
		theCoverage.PS2 = true;
		theCoverage.SB1 = true;
		theCoverage.SB2 = true;
		theCoverage.SMA1 = true;
		theCoverage.SMA2 = true;
		theCoverage.SMF1 = true;
		theCoverage.SMF2 = true;
		theCoverage.SS1 = true;
		theCoverage.SS2 = true;
		((CheckBox)CB_PB1).Checked = true;
		((CheckBox)CB_PB2).Checked = true;
		((CheckBox)CB_PMA1).Checked = true;
		((CheckBox)CB_PMA2).Checked = true;
		((CheckBox)CB_PMF1).Checked = true;
		((CheckBox)CB_PMF2).Checked = true;
		((CheckBox)CB_PS1).Checked = true;
		((CheckBox)CB_PS2).Checked = true;
		((CheckBox)CB_SB1).Checked = true;
		((CheckBox)CB_SB2).Checked = true;
		((CheckBox)CB_SMA1).Checked = true;
		((CheckBox)CB_SMA2).Checked = true;
		((CheckBox)CB_SMF1).Checked = true;
		((CheckBox)CB_SMF2).Checked = true;
		((CheckBox)CB_SS1).Checked = true;
		((CheckBox)CB_SS2).Checked = true;
		((Control)this).Refresh();
	}

	private void method_19()
	{
		theCoverage.PB1 = false;
		theCoverage.PB2 = false;
		theCoverage.PMA1 = false;
		theCoverage.PMA2 = false;
		theCoverage.PMF1 = false;
		theCoverage.PMF2 = false;
		theCoverage.PS1 = false;
		theCoverage.PS2 = false;
		theCoverage.SB1 = false;
		theCoverage.SB2 = false;
		theCoverage.SMA1 = false;
		theCoverage.SMA2 = false;
		theCoverage.SMF1 = false;
		theCoverage.SMF2 = false;
		theCoverage.SS1 = false;
		theCoverage.SS2 = false;
		((CheckBox)CB_PB1).Checked = false;
		((CheckBox)CB_PB2).Checked = false;
		((CheckBox)CB_PMA1).Checked = false;
		((CheckBox)CB_PMA2).Checked = false;
		((CheckBox)CB_PMF1).Checked = false;
		((CheckBox)CB_PMF2).Checked = false;
		((CheckBox)CB_PS1).Checked = false;
		((CheckBox)CB_PS2).Checked = false;
		((CheckBox)CB_SB1).Checked = false;
		((CheckBox)CB_SB2).Checked = false;
		((CheckBox)CB_SMA1).Checked = false;
		((CheckBox)CB_SMA2).Checked = false;
		((CheckBox)CB_SMF1).Checked = false;
		((CheckBox)CB_SMF2).Checked = false;
		((CheckBox)CB_SS1).Checked = false;
		((CheckBox)CB_SS2).Checked = false;
		((Control)this).Refresh();
	}

	private void method_20(object sender, EventArgs e)
	{
		method_17();
	}

	private void PlatformComponentArcControl_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static PlatformComponentArcControl()
	{
		Class72.smethod_20();
	}
}
