using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class LuaSocketClient : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button _Button1;

	private TcpClient tcpClient_0;

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			Button val = _Button1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Button1 = value;
			val = _Button1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox2")]
	internal virtual TextBox TextBox2 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual TextBox TextBox1 { get; set; }

	public LuaSocketClient()
	{
		((Form)this).Load += LuaSocketClient_Load;
		tcpClient_0 = new TcpClient();
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		Button1 = new Button();
		TextBox2 = new TextBox();
		TextBox1 = new TextBox();
		((Control)this).SuspendLayout();
		((Control)Button1).Anchor = (AnchorStyles)10;
		((Control)Button1).Location = new Point(558, 281);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Size = new Size(126, 21);
		((Control)Button1).TabIndex = 5;
		((ButtonBase)Button1).Text = "Run script";
		((ButtonBase)Button1).UseVisualStyleBackColor = true;
		((Control)TextBox2).Anchor = (AnchorStyles)14;
		((Control)TextBox2).Font = new Font("Lucida Console", 8.25f);
		((Control)TextBox2).Location = new Point(3, 227);
		TextBox2.Multiline = true;
		((Control)TextBox2).Name = "TextBox2";
		TextBox2.ScrollBars = (ScrollBars)3;
		((Control)TextBox2).Size = new Size(548, 110);
		((Control)TextBox2).TabIndex = 4;
		((Control)TextBox1).Anchor = (AnchorStyles)15;
		((TextBoxBase)TextBox1).BackColor = SystemColors.ControlLightLight;
		((Control)TextBox1).Font = new Font("Lucida Console", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TextBox1).Location = new Point(3, 12);
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		((TextBoxBase)TextBox1).ReadOnly = true;
		TextBox1.ScrollBars = (ScrollBars)3;
		((Control)TextBox1).Size = new Size(681, 184);
		((Control)TextBox1).TabIndex = 3;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(747, 342);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TextBox2);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Name = "LuaSocketClient";
		((Form)this).Text = "LuaSocketClient";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void LuaSocketClient_Load(object sender, EventArgs e)
	{
		method_0("Client Started");
		tcpClient_0.Connect("127.0.0.1", 8888);
		((Form)this).Text = "Connected!";
	}

	private void method_0(string string_0)
	{
		Console.WriteLine(">> " + Strings.Trim(string_0));
	}

	private void method_1(object sender, EventArgs e)
	{
		NetworkStream stream = tcpClient_0.GetStream();
		byte[] bytes = Encoding.BigEndianUnicode.GetBytes(TextBox2.Text);
		stream.Write(bytes, 0, bytes.Length);
		stream.Flush();
		byte[] array = new byte[tcpClient_0.ReceiveBufferSize + 1];
		stream.Read(array, 0, tcpClient_0.ReceiveBufferSize);
		string text = Encoding.BigEndianUnicode.GetString(array);
		text = text.Replace("\0", "");
		text = text.Remove(text.Length - 1);
		TextBox1.Text = text;
		Client.MustRefreshMainForm = true;
	}

	static LuaSocketClient()
	{
		Class72.smethod_20();
	}
}
