using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DefaultEvent("TextChanged")]
public sealed class DarkUITextBox : Control
{
	public delegate void TextChangedEventHandler(object sender);

	public TextBox _T;

	private HorizontalAlignment horizontalAlignment_0;

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private Image image_0;

	private AutoCompleteSource autoCompleteSource_0;

	private AutoCompleteMode autoCompleteMode_0;

	private AutoCompleteStringCollection autoCompleteStringCollection_0;

	private bool bool_2;

	private bool bool_3;

	private string[] string_1;

	[CompilerGenerated]
	private TextChangedEventHandler textChangedEventHandler_0;

	public TextBox T
	{
		get
		{
			return _T;
		}
		set
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			if (_T != null)
			{
				((Control)_T).TextChanged -= _T_TextChanged;
				((Control)_T).KeyDown -= new KeyEventHandler(_T_KeyDown);
				((TextBoxBase)_T).Click -= _T_Click;
			}
			_T = value;
			if (_T != null)
			{
				((Control)_T).TextChanged += _T_TextChanged;
				((Control)_T).KeyDown += new KeyEventHandler(_T_KeyDown);
				((TextBoxBase)_T).Click += _T_Click;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public BorderStyle BorderStyle => (BorderStyle)0;

	[Category("Custom")]
	[Description("Gets or sets how text is aligned in TextBox control.")]
	public HorizontalAlignment TextAlign
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return horizontalAlignment_0;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			horizontalAlignment_0 = value;
			if (T != null)
			{
				T.TextAlign = value;
			}
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets how text is aligned in TextBox control.")]
	[Category("Custom")]
	public int MaxLength
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			if (T != null)
			{
				((TextBoxBase)T).MaxLength = value;
			}
			((Control)this).Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value indicating whether text in the text box is read-only.")]
	public bool ReadOnly
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (T != null)
			{
				((TextBoxBase)T).ReadOnly = value;
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value indicating whether the text in  TextBox control should appear as the default password character.")]
	public bool UseSystemPasswordChar
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (T != null)
			{
				T.UseSystemPasswordChar = value;
			}
		}
	}

	[Description("Gets or sets a value indicating whether this is a multiline System.Windows.Forms.TextBox control.")]
	[Category("Custom")]
	public bool Multiline
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (T != null)
			{
				T.Multiline = value;
				if (value)
				{
					((Control)T).Height = ((Control)this).Height - 10;
				}
				else
				{
					((Control)this).Height = ((Control)T).Height + 10;
				}
			}
		}
	}

	[Description("Gets or sets a value indicating whether the WordWrap Property is true in the System.Windows.Forms.TextBox control.")]
	[Category("Custom")]
	public bool WordWrap
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			if (T != null)
			{
				((TextBoxBase)T).WordWrap = value;
				if (!value)
				{
					((Control)this).Width = ((Control)T).Width + 10;
				}
				else
				{
					((Control)T).Width = ((Control)this).Width - 10;
				}
			}
		}
	}

	public int SelectionStart
	{
		get
		{
			return ((TextBoxBase)T).SelectionStart;
		}
		set
		{
			((TextBoxBase)T).SelectionStart = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Image BackgroundImage => null;

	[Description("Gets or sets the current text in  TextBox.")]
	[Category("Custom")]
	public override string Text
	{
		get
		{
			return ((Control)this).Text;
		}
		set
		{
			((Control)this).Text = value;
			if (T != null)
			{
				T.Text = value;
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the text in the System.Windows.Forms.TextBox while being empty.")]
	public string WatermarkText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			SendMessage(((Control)T).Handle, 5377, 0, value);
			((Control)this).Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the image of the control.")]
	public Image Image
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
	[Category("Custom")]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return autoCompleteSource_0;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			autoCompleteSource_0 = value;
			if (T != null)
			{
				T.AutoCompleteSource = value;
			}
			((Control)this).Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
	public AutoCompleteStringCollection AutoCompleteCustomSource
	{
		get
		{
			return autoCompleteStringCollection_0;
		}
		set
		{
			autoCompleteStringCollection_0 = value;
			if (T != null)
			{
				T.AutoCompleteCustomSource = value;
			}
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets an option that controls how automatic completion works for the TextBox.")]
	[Category("Custom")]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return autoCompleteMode_0;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			autoCompleteMode_0 = value;
			if (T != null)
			{
				T.AutoCompleteMode = value;
			}
			((Control)this).Invalidate();
		}
	}

	[Description("Gets or sets the font of the text displayed by the control.")]
	[Category("Custom")]
	public Font Font
	{
		get
		{
			return ((Control)this).Font;
		}
		set
		{
			((Control)this).Font = value;
			if (T != null)
			{
				((Control)T).Font = value;
				((Control)T).Location = new Point(5, 5);
				((Control)T).Width = ((Control)this).Width - 8;
				if (!Multiline)
				{
					((Control)this).Height = ((Control)T).Height + 11;
				}
			}
		}
	}

	[Description("Gets or sets the lines of text in the control.")]
	[Category("Custom")]
	public string[] Lines
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			if (T != null)
			{
				((TextBoxBase)T).Lines = value;
				((Control)this).Invalidate();
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the ContextMenuStrip associated with this control.")]
	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return ((Control)this).ContextMenuStrip;
		}
		set
		{
			((Control)this).ContextMenuStrip = value;
			if (T != null)
			{
				((Control)T).ContextMenuStrip = value;
				((Control)this).Invalidate();
			}
		}
	}

	public override bool Focused => ((Control)T).Focused;

	public ScrollBars ScrollBars
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return T.ScrollBars;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			T.ScrollBars = value;
		}
	}

	public event TextChangedEventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			TextChangedEventHandler textChangedEventHandler = textChangedEventHandler_0;
			TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				TextChangedEventHandler value2 = (TextChangedEventHandler)Delegate.Combine(textChangedEventHandler2, value);
				textChangedEventHandler = Interlocked.CompareExchange(ref textChangedEventHandler_0, value2, textChangedEventHandler2);
			}
			while ((object)textChangedEventHandler != textChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TextChangedEventHandler textChangedEventHandler = textChangedEventHandler_0;
			TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				TextChangedEventHandler value2 = (TextChangedEventHandler)Delegate.Remove(textChangedEventHandler2, value);
				textChangedEventHandler = Interlocked.CompareExchange(ref textChangedEventHandler_0, value2, textChangedEventHandler2);
			}
			while ((object)textChangedEventHandler != textChangedEventHandler2);
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int SendMessage(IntPtr intptr_0, int int_1, int int_2, [MarshalAs(UnmanagedType.LPWStr)] string string_2);

	public DarkUITextBox()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		_T = new TextBox();
		horizontalAlignment_0 = (HorizontalAlignment)0;
		int_0 = 32767;
		bool_0 = false;
		bool_1 = false;
		string_0 = string.Empty;
		autoCompleteSource_0 = (AutoCompleteSource)128;
		autoCompleteMode_0 = (AutoCompleteMode)0;
		bool_2 = false;
		bool_3 = false;
		string_1 = null;
		((Control)this).SetStyle((ControlStyles)133138, true);
		((Control)this).DoubleBuffered = true;
		((Control)this).UpdateStyles();
		((Control)this).BackColor = Colors.MediumBackground;
		((Control)this).ForeColor = Colors.LightText;
		T.Multiline = false;
		((Control)T).Cursor = Cursors.IBeam;
		((TextBoxBase)T).BackColor = ((Control)this).BackColor;
		((TextBoxBase)T).ForeColor = ((Control)this).ForeColor;
		((TextBoxBase)T).BorderStyle = (BorderStyle)0;
		((Control)T).Location = new Point(7, 4);
		((Control)T).Font = Font;
		T.UseSystemPasswordChar = UseSystemPasswordChar;
		((Control)this).Size = new Size(135, 30);
		if (Multiline)
		{
			((Control)T).Height = ((Control)this).Height - 11;
		}
		else
		{
			((Control)this).Height = ((Control)T).Height + 11;
		}
		((Control)_T).TextChanged += _T_TextChanged;
		((Control)_T).KeyDown += new KeyEventHandler(_T_KeyDown);
		((TextBoxBase)_T).Click += _T_Click;
	}

	public void Clear()
	{
		((TextBoxBase)T).Clear();
		Text = string.Empty;
	}

	public bool Focus()
	{
		return ((Control)T).Focus();
	}

	protected override void OnCreateControl()
	{
		((Control)this).OnCreateControl();
		if (!((Control)this).Controls.Contains((Control)(object)T))
		{
			((Control)this).Controls.Add((Control)(object)T);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		((Control)this).OnResize(e);
		((Control)T).Size = new Size(((Control)this).Width - 10, ((Control)this).Height - 10);
	}

	private void _T_TextChanged(object sender, EventArgs e)
	{
		Text = T.Text;
		if (textChangedEventHandler_0 != null)
		{
			textChangedEventHandler_0?.Invoke(this);
		}
		((Control)this).Invalidate();
	}

	private void _T_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		if (e.Control && (int)e.KeyCode == 65)
		{
			e.SuppressKeyPress = true;
		}
		if (e.Control && (int)e.KeyCode == 67)
		{
			((TextBoxBase)T).Copy();
			e.SuppressKeyPress = true;
		}
		((Control)this).Invalidate();
	}

	private void _T_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(T.Text, "Mission: <name>", true) == 0 || Operators.CompareString(T.Text, "Not specified", true) == 0)
		{
			((TextBoxBase)T).SelectAll();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = (TextRenderingHint)5;
		new Rectangle(0, 0, ((Control)T).Width + 8, ((Control)T).Height + 8);
		SolidBrush val = new SolidBrush(Colors.MediumBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(Colors.LightBorder, 1f);
		try
		{
			Rectangle rectangle = new Rectangle(((Control)this).ClientRectangle.Left, ((Control)this).ClientRectangle.Top, ((Control)this).ClientRectangle.Width - 1, ((Control)this).ClientRectangle.Height - 1);
			graphics.DrawRectangle(val2, rectangle);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		if (Image != null)
		{
			((Control)T).Location = new Point(31, 2);
			((Control)T).Width = ((Control)this).Width - 60;
			graphics.InterpolationMode = (InterpolationMode)7;
			graphics.DrawImage(Image, new Rectangle(8, 6, 16, 16));
		}
		else
		{
			((Control)T).Location = new Point(5, 2);
		}
	}

	static DarkUITextBox()
	{
		Class72.smethod_20();
	}
}
