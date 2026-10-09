using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Salamander.Drawing;

namespace Salamander.Windows.Forms;

public class CollapsiblePanel : Panel
{
	[CompilerGenerated]
	private PanelStateChangedEventHandler panelStateChangedEventHandler_0;

	private ColorMatrix colorMatrix_0;

	private ImageAttributes imageAttributes_0;

	private PanelState panelState_0;

	private int int_0;

	private int int_1;

	private Color color_0 = Color.White;

	private Color color_1 = Color.FromArgb(199, 212, 247);

	private IContainer icontainer_0;

	private Label labelTitle;

	private Image image_0;

	private ImageList imageList_0;

	[Browsable(false)]
	public PanelState PanelState
	{
		get
		{
			return panelState_0;
		}
		set
		{
			PanelState num = panelState_0;
			panelState_0 = value;
			if (num != panelState_0)
			{
				method_1();
			}
		}
	}

	[Category("Title")]
	[Description("The text contained in the title bar.")]
	public string TitleText
	{
		get
		{
			return ((Control)labelTitle).Text;
		}
		set
		{
			((Control)labelTitle).Text = value;
		}
	}

	[Category("Title")]
	[Description("The foreground colour used to display the title text.")]
	public Color TitleFontColour
	{
		get
		{
			return ((Control)labelTitle).ForeColor;
		}
		set
		{
			((Control)labelTitle).ForeColor = value;
		}
	}

	[Category("Title")]
	[Description("The font used to display the title text.")]
	public Font TitleFont
	{
		get
		{
			return ((Control)labelTitle).Font;
		}
		set
		{
			((Control)labelTitle).Font = value;
		}
	}

	[Category("Title")]
	[Description("The image list to get the images displayed for expanding/collapsing the panel.")]
	public ImageList ImageList
	{
		get
		{
			return imageList_0;
		}
		set
		{
			imageList_0 = value;
			if (imageList_0 == null)
			{
				int_1 = -1;
			}
			else if (imageList_0.Images.Count > 0)
			{
				int_1 = 0;
			}
		}
	}

	[Category("Title")]
	[Description("The colour used at the start of the colour gradient displayed as the background of the title bar.")]
	public Color StartColour
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			((Control)labelTitle).Invalidate();
		}
	}

	[Description("The colour used at the end of the colour gradient displayed as the background of the title bar.")]
	[Category("Title")]
	public Color EndColour
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			((Control)labelTitle).Invalidate();
		}
	}

	[Category("Title")]
	[Description("The image that will be displayed on the left hand side of the title bar.")]
	public Image Image
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
			if (value != null)
			{
				((Control)labelTitle).Height = image_0.Height + 4;
				if (((Control)labelTitle).Height < 24)
				{
					((Control)labelTitle).Height = 24;
				}
			}
			((Control)labelTitle).Invalidate();
		}
	}

	[Category("State")]
	[Description("Raised when panel state has changed.")]
	public event PanelStateChangedEventHandler PanelStateChanged
	{
		[CompilerGenerated]
		add
		{
			PanelStateChangedEventHandler panelStateChangedEventHandler = panelStateChangedEventHandler_0;
			PanelStateChangedEventHandler panelStateChangedEventHandler2;
			do
			{
				panelStateChangedEventHandler2 = panelStateChangedEventHandler;
				PanelStateChangedEventHandler value2 = (PanelStateChangedEventHandler)Delegate.Combine(panelStateChangedEventHandler2, value);
				panelStateChangedEventHandler = Interlocked.CompareExchange(ref panelStateChangedEventHandler_0, value2, panelStateChangedEventHandler2);
			}
			while ((object)panelStateChangedEventHandler != panelStateChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PanelStateChangedEventHandler panelStateChangedEventHandler = panelStateChangedEventHandler_0;
			PanelStateChangedEventHandler panelStateChangedEventHandler2;
			do
			{
				panelStateChangedEventHandler2 = panelStateChangedEventHandler;
				PanelStateChangedEventHandler value2 = (PanelStateChangedEventHandler)Delegate.Remove(panelStateChangedEventHandler2, value);
				panelStateChangedEventHandler = Interlocked.CompareExchange(ref panelStateChangedEventHandler_0, value2, panelStateChangedEventHandler2);
			}
			while ((object)panelStateChangedEventHandler != panelStateChangedEventHandler2);
		}
	}

	private void method_0()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		icontainer_0 = new Container();
		ResourceManager resourceManager = new ResourceManager(typeof(CollapsiblePanel));
		labelTitle = new Label();
		imageList_0 = new ImageList(icontainer_0);
		((Control)this).SuspendLayout();
		((Control)labelTitle).Cursor = Cursors.Default;
		((Control)labelTitle).Dock = (DockStyle)1;
		((Control)labelTitle).Font = new Font("Tahoma", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)labelTitle).ForeColor = Color.Navy;
		((Control)labelTitle).Location = new Point(114, 17);
		((Control)labelTitle).Name = "labelTitle";
		((Control)labelTitle).Size = new Size(200, 24);
		((Control)labelTitle).TabIndex = 0;
		((Control)labelTitle).Text = "Title";
		labelTitle.TextAlign = (ContentAlignment)16;
		((Control)labelTitle).Paint += new PaintEventHandler(labelTitle_Paint);
		((Control)labelTitle).MouseUp += new MouseEventHandler(labelTitle_MouseUp);
		((Control)labelTitle).MouseMove += new MouseEventHandler(labelTitle_MouseMove);
		imageList_0.ColorDepth = (ColorDepth)32;
		imageList_0.ImageSize = new Size(16, 16);
		imageList_0.ImageStream = (ImageListStreamer)resourceManager.GetObject("imageList.ImageStream", CultureInfo.InvariantCulture);
		imageList_0.TransparentColor = Color.Transparent;
		((Control)this).Controls.AddRange((Control[])(object)new Control[1] { (Control)labelTitle });
		((Control)this).ResumeLayout(false);
	}

	public CollapsiblePanel()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		icontainer_0 = new Container();
		method_0();
		((Control)this).BackColor = Color.AliceBlue;
		int_0 = ((Control)this).Height;
		colorMatrix_0 = new ColorMatrix();
		colorMatrix_0.Matrix00 = 1f / 3f;
		colorMatrix_0.Matrix01 = 1f / 3f;
		colorMatrix_0.Matrix02 = 1f / 3f;
		colorMatrix_0.Matrix10 = 1f / 3f;
		colorMatrix_0.Matrix11 = 1f / 3f;
		colorMatrix_0.Matrix12 = 1f / 3f;
		colorMatrix_0.Matrix20 = 1f / 3f;
		colorMatrix_0.Matrix21 = 1f / 3f;
		colorMatrix_0.Matrix22 = 1f / 3f;
		imageAttributes_0 = new ImageAttributes();
		imageAttributes_0.SetColorMatrix(colorMatrix_0, (ColorMatrixFlag)0, (ColorAdjustType)1);
	}

	private bool tFaegrexvcF(int int_2, int int_3)
	{
		if (!((Control)labelTitle).Bounds.Contains(int_2, int_3))
		{
			return false;
		}
		return true;
	}

	private void method_1()
	{
		switch (panelState_0)
		{
		case PanelState.Expanded:
			((Control)this).Height = int_0;
			int_1 = 0;
			break;
		case PanelState.Collapsed:
			int_0 = ((Control)this).Height;
			((Control)this).Height = ((Control)labelTitle).Height;
			int_1 = 1;
			break;
		}
		((Control)labelTitle).Invalidate();
		OnPanelStateChanged(new PanelEventArgs(this));
	}

	protected virtual void OnPanelStateChanged(PanelEventArgs e)
	{
		if (panelStateChangedEventHandler_0 != null)
		{
			panelStateChangedEventHandler_0(this, e);
		}
	}

	private void labelTitle_Paint(object sender, PaintEventArgs e)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		int num = 7;
		Rectangle bounds = ((Control)labelTitle).Bounds;
		int num2 = 0;
		if (image_0 != null)
		{
			num2 = ((Control)labelTitle).Height - 24;
			if (num2 < 0)
			{
				num2 = 0;
			}
			bounds.Offset(0, num2);
			bounds.Height -= num2;
		}
		e.Graphics.Clear(((Control)this).Parent.BackColor);
		GraphicsPath val = new GraphicsPath();
		val.AddLine(bounds.Left + num, bounds.Top, bounds.Right - 14 - 1, bounds.Top);
		val.AddArc(bounds.Right - 14 - 1, bounds.Top, 14, 14, 270f, 90f);
		val.AddLine(bounds.Right, bounds.Top + num, bounds.Right, bounds.Bottom);
		val.AddLine(bounds.Right, bounds.Bottom, bounds.Left - 1, bounds.Bottom);
		val.AddArc(bounds.Left, bounds.Top, 14, 14, 180f, 90f);
		e.Graphics.SmoothingMode = (SmoothingMode)4;
		int num3;
		if (((Control)this).Enabled)
		{
			LinearGradientBrush val2 = new LinearGradientBrush(bounds, color_0, color_1, (LinearGradientMode)0);
			e.Graphics.FillPath((Brush)(object)val2, val);
			num3 = 1;
		}
		else
		{
			Colour colour = new Colour();
			colour.CurrentColour = color_0;
			colour.Saturation = 0f;
			Colour colour2 = new Colour();
			colour2.CurrentColour = color_1;
			colour2.Saturation = 0f;
			LinearGradientBrush val3 = new LinearGradientBrush(bounds, colour.CurrentColour, colour2.CurrentColour, (LinearGradientMode)0);
			e.Graphics.FillPath((Brush)(object)val3, val);
			num3 = 1;
		}
		GraphicsUnit val4 = (GraphicsUnit)num3;
		int num4 = 2;
		if (image_0 != null)
		{
			num4 += image_0.Width + 2;
			RectangleF bounds2 = image_0.GetBounds(ref val4);
			Rectangle rectangle = new Rectangle(2, 2, image_0.Width, image_0.Height);
			if (((Control)this).Enabled)
			{
				e.Graphics.DrawImage(image_0, rectangle, (int)bounds2.Left, (int)bounds2.Top, (int)bounds2.Width, (int)bounds2.Height, val4);
			}
			else
			{
				e.Graphics.DrawImage(image_0, rectangle, (int)bounds2.Left, (int)bounds2.Top, (int)bounds2.Width, (int)bounds2.Height, val4, imageAttributes_0);
			}
		}
		SolidBrush val5 = new SolidBrush(TitleFontColour);
		float num5 = num4;
		float y = (float)num2 + 4f;
		float width = (float)((Control)labelTitle).Width - num5 - (float)imageList_0.ImageSize.Width - 4f;
		float height = 16f;
		RectangleF rectangleF = new RectangleF(num5, y, width, height);
		StringFormat val6 = new StringFormat();
		val6.Trimming = (StringTrimming)4;
		if (((Control)this).Enabled)
		{
			e.Graphics.DrawString(((Control)labelTitle).Text, ((Control)labelTitle).Font, (Brush)(object)val5, rectangleF, val6);
		}
		else
		{
			Color grayText = SystemColors.GrayText;
			ControlPaint.DrawStringDisabled(e.Graphics, ((Control)labelTitle).Text, ((Control)labelTitle).Font, grayText, rectangleF, val6);
		}
		Pen val7 = new Pen((Brush)new SolidBrush(Color.White), 1f);
		val.Reset();
		val.AddLine(bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
		e.Graphics.DrawPath(val7, val);
		int x = bounds.Right - imageList_0.ImageSize.Width - 4;
		int y2 = bounds.Top + 4;
		RectangleF bounds3 = ImageList.Images[(int)panelState_0].GetBounds(ref val4);
		Rectangle rectangle2 = new Rectangle(x, y2, imageList_0.ImageSize.Width, imageList_0.ImageSize.Height);
		if (((Control)this).Enabled)
		{
			e.Graphics.DrawImage(ImageList.Images[(int)panelState_0], rectangle2, (int)bounds3.Left, (int)bounds3.Top, (int)bounds3.Width, (int)bounds3.Height, val4);
		}
		else
		{
			e.Graphics.DrawImage(ImageList.Images[(int)panelState_0], rectangle2, (int)bounds3.Left, (int)bounds3.Top, (int)bounds3.Width, (int)bounds3.Height, val4, imageAttributes_0);
		}
	}

	private void labelTitle_MouseUp(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)e.Button == 1048576 && tFaegrexvcF(e.X, e.Y) && imageList_0 != null && imageList_0.Images.Count >= 2)
		{
			if (int_1 == 0)
			{
				panelState_0 = PanelState.Collapsed;
			}
			else
			{
				panelState_0 = PanelState.Expanded;
			}
			method_1();
		}
	}

	private void labelTitle_MouseMove(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Button == 0 && tFaegrexvcF(e.X, e.Y))
		{
			((Control)labelTitle).Cursor = Cursors.Hand;
		}
		else
		{
			((Control)labelTitle).Cursor = Cursors.Default;
		}
	}

	static CollapsiblePanel()
	{
		Class72.smethod_20();
	}
}
