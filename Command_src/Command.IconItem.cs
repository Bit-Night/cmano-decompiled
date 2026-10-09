using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class IconItem : UserControl
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button")]
	private Button _Button;

	public IconeCustomizer ParentCustomizer;

	public string IconFile;

	internal virtual Button Button
	{
		[CompilerGenerated]
		get
		{
			return _Button;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			Button val = _Button;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button = value;
			val = _Button;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public IconItem()
	{
		iJjHvtxosUc();
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

	private void iJjHvtxosUc()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		Button = new Button();
		((Control)this).SuspendLayout();
		Button.AutoSizeMode = (AutoSizeMode)0;
		((Control)Button).BackgroundImage = (Image)(object)Resources.Aircraft;
		((Control)Button).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)Button).FlatStyle = (FlatStyle)0;
		((Control)Button).Location = new Point(0, 0);
		((Control)Button).Name = "Button";
		((Control)Button).Size = new Size(40, 40);
		((Control)Button).TabIndex = 0;
		((ButtonBase)Button).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)Button);
		((Control)this).Name = "IconItem";
		((Control)this).Size = new Size(40, 40);
		((Control)this).ResumeLayout(false);
	}

	private void method_0(object sender, EventArgs e)
	{
		ParentCustomizer.CurrentIconSelected = IconFile;
	}

	public void Refresh(string File, IconeCustomizer _ParentCustomizer)
	{
		IconFile = File;
		ParentCustomizer = _ParentCustomizer;
		((Control)Button).BackgroundImage = Image.FromFile(Client.GetCustomIconPath(IconFile));
	}

	static IconItem()
	{
		Class72.smethod_20();
	}
}
