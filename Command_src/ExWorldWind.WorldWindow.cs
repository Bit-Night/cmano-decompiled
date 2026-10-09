using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Command_Core;
using CSMaterial.ExWorldWind;
using DXRenderer;
using ExWorldWind.Interop;
using Worldwind.Component;

namespace ExWorldWind;

public class WorldWindow : Control
{
	public delegate void DebugFormWriteDelegate(string str);

	public delegate void DebugFormWriteExceptionDelegate(string str, Exception e);

	public delegate void GraphicsCrashDelegate(string str);

	private bool bool_0;

	private DrawArgs drawArgs_0;

	private bool bool_1;

	private string string_0 = "";

	private long long_0;

	private int int_0;

	[CompilerGenerated]
	private float float_0;

	private string string_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private Point point_0 = Point.Empty;

	private bool bool_5;

	private System.Timers.Timer timer_0 = new System.Timers.Timer(250.0);

	private System.Timers.Timer timer_1;

	private bool bool_6;

	public bool bool_7;

	public CommandLayer CommandLayer;

	[CompilerGenerated]
	private static DebugFormWriteExceptionDelegate nObLqzMdaBu;

	[CompilerGenerated]
	private static DebugFormWriteDelegate debugFormWriteDelegate_0;

	[CompilerGenerated]
	private static GraphicsCrashDelegate graphicsCrashDelegate_0;

	private static bool bool_8;

	private ArrayList arrayList_0 = new ArrayList();

	private int hqvLwyIbvOM = 255;

	private int int_1 = 40;

	private int int_2 = 205;

	public DateTime LastMouseWheelEvent = DateTime.UtcNow;

	private bool bool_9;

	private Angle angle_0;

	private Angle angle_1;

	public float fps
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		private set
		{
			float_0 = value;
		}
	}

	public bool ControlHeld
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public System.Timers.Timer MouseHoverTimer => timer_1;

	public string Caption
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public DrawArgs DrawArgs => drawArgs_0;

	public bool IsRenderDisabled
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public static event DebugFormWriteExceptionDelegate DebugFormWriteException
	{
		[CompilerGenerated]
		add
		{
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate = nObLqzMdaBu;
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate2;
			do
			{
				debugFormWriteExceptionDelegate2 = debugFormWriteExceptionDelegate;
				DebugFormWriteExceptionDelegate value2 = (DebugFormWriteExceptionDelegate)Delegate.Combine(debugFormWriteExceptionDelegate2, value);
				debugFormWriteExceptionDelegate = Interlocked.CompareExchange(ref nObLqzMdaBu, value2, debugFormWriteExceptionDelegate2);
			}
			while ((object)debugFormWriteExceptionDelegate != debugFormWriteExceptionDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate = nObLqzMdaBu;
			DebugFormWriteExceptionDelegate debugFormWriteExceptionDelegate2;
			do
			{
				debugFormWriteExceptionDelegate2 = debugFormWriteExceptionDelegate;
				DebugFormWriteExceptionDelegate value2 = (DebugFormWriteExceptionDelegate)Delegate.Remove(debugFormWriteExceptionDelegate2, value);
				debugFormWriteExceptionDelegate = Interlocked.CompareExchange(ref nObLqzMdaBu, value2, debugFormWriteExceptionDelegate2);
			}
			while ((object)debugFormWriteExceptionDelegate != debugFormWriteExceptionDelegate2);
		}
	}

	public static event DebugFormWriteDelegate DebugFormWrite
	{
		[CompilerGenerated]
		add
		{
			DebugFormWriteDelegate debugFormWriteDelegate = debugFormWriteDelegate_0;
			DebugFormWriteDelegate debugFormWriteDelegate2;
			do
			{
				debugFormWriteDelegate2 = debugFormWriteDelegate;
				DebugFormWriteDelegate value2 = (DebugFormWriteDelegate)Delegate.Combine(debugFormWriteDelegate2, value);
				debugFormWriteDelegate = Interlocked.CompareExchange(ref debugFormWriteDelegate_0, value2, debugFormWriteDelegate2);
			}
			while ((object)debugFormWriteDelegate != debugFormWriteDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			DebugFormWriteDelegate debugFormWriteDelegate = debugFormWriteDelegate_0;
			DebugFormWriteDelegate debugFormWriteDelegate2;
			do
			{
				debugFormWriteDelegate2 = debugFormWriteDelegate;
				DebugFormWriteDelegate value2 = (DebugFormWriteDelegate)Delegate.Remove(debugFormWriteDelegate2, value);
				debugFormWriteDelegate = Interlocked.CompareExchange(ref debugFormWriteDelegate_0, value2, debugFormWriteDelegate2);
			}
			while ((object)debugFormWriteDelegate != debugFormWriteDelegate2);
		}
	}

	public static event GraphicsCrashDelegate GraphicsCrash
	{
		[CompilerGenerated]
		add
		{
			GraphicsCrashDelegate graphicsCrashDelegate = graphicsCrashDelegate_0;
			GraphicsCrashDelegate graphicsCrashDelegate2;
			do
			{
				graphicsCrashDelegate2 = graphicsCrashDelegate;
				GraphicsCrashDelegate value2 = (GraphicsCrashDelegate)Delegate.Combine(graphicsCrashDelegate2, value);
				graphicsCrashDelegate = Interlocked.CompareExchange(ref graphicsCrashDelegate_0, value2, graphicsCrashDelegate2);
			}
			while ((object)graphicsCrashDelegate != graphicsCrashDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GraphicsCrashDelegate graphicsCrashDelegate = graphicsCrashDelegate_0;
			GraphicsCrashDelegate graphicsCrashDelegate2;
			do
			{
				graphicsCrashDelegate2 = graphicsCrashDelegate;
				GraphicsCrashDelegate value2 = (GraphicsCrashDelegate)Delegate.Remove(graphicsCrashDelegate2, value);
				graphicsCrashDelegate = Interlocked.CompareExchange(ref graphicsCrashDelegate_0, value2, graphicsCrashDelegate2);
			}
			while ((object)graphicsCrashDelegate != graphicsCrashDelegate2);
		}
	}

	public WorldWindow()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		if (!smethod_1())
		{
			((Control)this).SetStyle((ControlStyles)8196, true);
			((Control)this).Size = new Size(1, 1);
			try
			{
				drawArgs_0 = DrawArgs.Instance;
				((Control)this).MouseEnter += WorldWindow_MouseEnter;
				((Control)this).MouseLeave += WorldWindow_MouseLeave;
				((Control)this).MouseMove += new MouseEventHandler(WorldWindow_MouseMove);
				timer_1 = new System.Timers.Timer();
				timer_1.Interval = 2500.0;
			}
			catch (Exception innerException)
			{
				throw new Exception("Unable to initialize WorldWindow.", innerException);
			}
		}
	}

	private void WorldWindow_MouseMove(object sender, MouseEventArgs e)
	{
		timer_1.Start();
	}

	private void WorldWindow_MouseLeave(object sender, EventArgs e)
	{
		timer_1.Stop();
	}

	private void WorldWindow_MouseEnter(object sender, EventArgs e)
	{
		timer_1.Start();
	}

	public void GotoLatLon(double latitude, double longitude)
	{
		Main.Instance?.SetProjection((float)longitude, (float)latitude, drawArgs_0.WorldCamera.Altitude);
		DrawArgs.Instance.WorldCamera.SetPosition(latitude, longitude);
	}

	[SpecialName]
	private static bool smethod_0()
	{
		ExWorldWind.Interop.NativeMethods.Message msg;
		return !ExWorldWind.Interop.NativeMethods.PeekMessage(out msg, IntPtr.Zero, 0u, 0u, 0u);
	}

	public static void DebugWrite(string s)
	{
		debugFormWriteDelegate_0(s);
	}

	public void RenderFrame()
	{
		if (bool_8)
		{
			GameGeneral.WriteLogDebugInfoToFile("Map received message to paint while painting.");
			return;
		}
		Main instance = Main.Instance;
		if (instance == null || !instance.Initialized || instance.Resizing)
		{
			return;
		}
		bool_8 = true;
		try
		{
			if (!bool_0)
			{
				if (!bool_7)
				{
					Main.Instance.ManageTiles(Convert.ToSingle(DrawArgs.Instance.WorldCamera.Longitude.Degrees), Convert.ToSingle(DrawArgs.Instance.WorldCamera.Latitude.Degrees), Convert.ToSingle(DrawArgs.Instance.WorldCamera.Altitude));
					Main.Instance.BeginDrawing();
				}
				Render();
				if (!bool_7)
				{
					Main.Instance.FinishDrawing();
				}
			}
		}
		catch (Exception ex)
		{
			bool_8 = false;
			if (ex != null && ex.InnerException != null)
			{
				GameGeneral.WriteLogDebugInfoToFile("Map exception while painting: " + ex);
				nObLqzMdaBu("WW.WW.OnPaint Exception", ex);
				throw new Exception("WorldWindow OnPaint exception", ex);
			}
		}
		finally
		{
			bool_8 = false;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		RenderFrame();
	}

	public void Render()
	{
		if (!IsRenderDisabled && Main.Instance == null)
		{
			Thread.Sleep(25);
		}
		else
		{
			CommandLayer.Render(drawArgs_0);
		}
	}

	public void ResetToolbar()
	{
	}

	public void HandleMouseWheel(MouseEventArgs e)
	{
		((Control)this).OnMouseWheel(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		try
		{
			LastMouseWheelEvent = DateTime.UtcNow;
			drawArgs_0.WorldCamera.ZoomStepped((float)e.Delta / 120f);
		}
		finally
		{
			((Control)this).OnMouseWheel(e);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			e.Handled = true;
			((Control)this).OnKeyDown(e);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Operation failed", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Control)this).OnKeyUp(e);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Operation failed", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		((Control)this).OnKeyPress(e);
	}

	[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	public override bool PreProcessMessage(ref Message msg)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (((Message)(ref msg)).Msg == 256)
		{
			Keys val = (Keys)((Message)(ref msg)).WParam.ToInt32();
			if (val - 37 <= 3)
			{
				((Control)this).OnKeyDown(new KeyEventArgs(val));
				((Message)(ref msg)).Result = (IntPtr)1;
				return true;
			}
		}
		return ((Control)this).PreProcessMessage(ref msg);
	}

	public bool HandleKeyUp(KeyEventArgs e)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		if (bool_6 && !e.Control)
		{
			bool_6 = false;
		}
		int result;
		if (e.Alt)
		{
			result = 0;
		}
		else
		{
			Keys keyCode;
			if (!e.Control)
			{
				keyCode = e.KeyCode;
				int result2;
				if ((int)keyCode != 12)
				{
					if ((int)keyCode != 32)
					{
						result = 0;
						goto IL_007c;
					}
					result2 = 1;
				}
				else
				{
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			keyCode = e.KeyCode;
			if ((int)keyCode == 68)
			{
				bool_1 = !bool_1;
				return true;
			}
			if ((int)keyCode == 87)
			{
				bool_5 = !bool_5;
				return true;
			}
			bool_6 = false;
			result = 0;
		}
		goto IL_007c;
		IL_007c:
		return (byte)result != 0;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		((Control)this).Focus();
		DrawArgs.LastMousePosition.X = e.X;
		DrawArgs.LastMousePosition.Y = e.Y;
		point_0.X = e.X;
		point_0.Y = e.Y;
		try
		{
		}
		finally
		{
			if ((int)e.Button == 1048576)
			{
				DrawArgs.IsLeftMouseButtonDown = true;
			}
			if ((int)e.Button == 2097152)
			{
				DrawArgs.IsRightMouseButtonDown = true;
			}
			((Control)this).OnMouseDown(e);
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		bool_9 = true;
		((Control)this).OnMouseDoubleClick(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Invalid comparison between Unknown and I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		DrawArgs.LastMousePosition.X = e.X;
		DrawArgs.LastMousePosition.Y = e.Y;
		try
		{
			if (point_0 == Point.Empty)
			{
				return;
			}
			point_0 = Point.Empty;
			if (Main.Instance == null || bool_9)
			{
				return;
			}
			if ((int)e.Button == 1048576)
			{
				if (bool_4)
				{
					bool_4 = false;
				}
			}
			else if ((int)e.Button == 2097152 && bool_4)
			{
				bool_4 = false;
			}
		}
		finally
		{
			if ((int)e.Button == 1048576)
			{
				DrawArgs.IsLeftMouseButtonDown = false;
			}
			if ((int)e.Button == 2097152)
			{
				DrawArgs.IsRightMouseButtonDown = false;
			}
			((Control)this).OnMouseUp(e);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Invalid comparison between Unknown and I4
		try
		{
			int num = e.X - DrawArgs.LastMousePosition.X;
			int num2 = e.Y - DrawArgs.LastMousePosition.Y;
			float num3 = (float)num2 / drawArgs_0.WorldCamera.ViewportHeight;
			if (point_0 == Point.Empty)
			{
				return;
			}
			bool flag = (e.Button & 0x100000) > 0;
			bool flag2 = (e.Button & 0x200000) > 0;
			if (flag || flag2)
			{
				int num4 = point_0.X - e.X;
				int num5 = point_0.Y - e.Y;
				if (num4 * num4 + num5 * num5 > 9)
				{
					bool_4 = true;
				}
			}
			if (!flag && flag2)
			{
				drawArgs_0.WorldCamera.PickingRayIntersection(DrawArgs.LastMousePosition.X, DrawArgs.LastMousePosition.Y, out var latitude, out var longitude);
				drawArgs_0.WorldCamera.PickingRayIntersection(e.X, e.Y, out var latitude2, out var longitude2);
				if (!Angle.IsNaN(latitude2) && !Angle.IsNaN(latitude))
				{
					Angle lat = latitude - latitude2;
					Angle lon = longitude - longitude2;
					drawArgs_0.WorldCamera.Pan(lat, lon);
				}
				else
				{
					Angle lat2 = Angle.FromRadians((double)num2 * (double)drawArgs_0.WorldCamera.Altitude / 5102509568.0);
					Angle lon2 = Angle.FromRadians((double)(-num) * (double)drawArgs_0.WorldCamera.Altitude / 5102509568.0);
					drawArgs_0.WorldCamera.Pan(lat2, lon2);
				}
			}
			else if ((!(!flag && flag2) || bool_6) && flag && flag2 && Math.Abs(num3) > float.Epsilon)
			{
				drawArgs_0.WorldCamera.Zoom((0f - num3) * 1f);
			}
		}
		catch
		{
		}
		finally
		{
			drawArgs_0.WorldCamera.PickingRayIntersection(e.X, e.Y, out angle_0, out angle_1);
			DrawArgs.LastMousePosition.X = e.X;
			DrawArgs.LastMousePosition.Y = e.Y;
			((Control)this).OnMouseMove(e);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
	}

	private static bool smethod_1()
	{
		return Application.ExecutablePath.ToUpper(CultureInfo.InvariantCulture).EndsWith("DEVENV.EXE");
	}

	static WorldWindow()
	{
		Class72.smethod_20();
		nObLqzMdaBu = delegate
		{
		};
		debugFormWriteDelegate_0 = delegate
		{
		};
		graphicsCrashDelegate_0 = delegate
		{
		};
	}
}
