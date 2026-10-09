using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Docking;

namespace DarkUI.Win32;

public sealed class DockResizeFilter : IMessageFilter
{
	private DarkDockPanel darkDockPanel_0;

	private Timer timer_0;

	private bool bool_0;

	private Point point_0;

	private DarkDockSplitter darkDockSplitter_0;

	public DockResizeFilter(DarkDockPanel dockPanel)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		darkDockPanel_0 = dockPanel;
		timer_0 = new Timer();
		timer_0.Interval = 1;
		timer_0.Tick += timer_0_Tick;
	}

	public bool PreFilterMessage(ref Message m)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		if (((Message)(ref m)).Msg != 512 && ((Message)(ref m)).Msg != 513 && ((Message)(ref m)).Msg != 514 && ((Message)(ref m)).Msg != 515 && ((Message)(ref m)).Msg != 516 && ((Message)(ref m)).Msg != 517 && ((Message)(ref m)).Msg != 518)
		{
			return false;
		}
		if (((Message)(ref m)).Msg == 514 && bool_0)
		{
			method_1();
			return true;
		}
		if (((Message)(ref m)).Msg == 514 && !bool_0)
		{
			return false;
		}
		if (bool_0)
		{
			Cursor.Current = darkDockSplitter_0.ResizeCursor;
		}
		if (((Message)(ref m)).Msg == 512 && !bool_0 && (int)darkDockPanel_0.MouseButtonState != 0)
		{
			return false;
		}
		Control val = Control.FromHandle(((Message)(ref m)).HWnd);
		if (val != null)
		{
			if ((object)val != darkDockPanel_0 && !((Control)darkDockPanel_0).Contains(val))
			{
				return false;
			}
			method_3();
			if (((Message)(ref m)).Msg == 513)
			{
				DarkDockSplitter darkDockSplitter = method_2();
				if (darkDockSplitter != null)
				{
					method_0(darkDockSplitter);
					return true;
				}
			}
			if (method_2() == null)
			{
				if (!bool_0)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if ((int)darkDockPanel_0.MouseButtonState != 1048576)
		{
			method_1();
			return;
		}
		Point difference = new Point(point_0.X - Cursor.Position.X, point_0.Y - Cursor.Position.Y);
		darkDockSplitter_0.UpdateOverlay(difference);
	}

	private void method_0(DarkDockSplitter darkDockSplitter_1)
	{
		darkDockSplitter_0 = darkDockSplitter_1;
		Cursor.Current = darkDockSplitter_0.ResizeCursor;
		point_0 = Cursor.Position;
		bool_0 = true;
		darkDockSplitter_0.ShowOverlay();
		timer_0.Start();
	}

	private void method_1()
	{
		timer_0.Stop();
		darkDockSplitter_0.HideOverlay();
		Point difference = new Point(point_0.X - Cursor.Position.X, point_0.Y - Cursor.Position.Y);
		darkDockSplitter_0.Move(difference);
		bool_0 = false;
	}

	private DarkDockSplitter method_2()
	{
		foreach (DarkDockSplitter splitter in darkDockPanel_0.Splitters)
		{
			if (splitter.Bounds.Contains(Cursor.Position))
			{
				return splitter;
			}
		}
		return null;
	}

	private void method_3()
	{
		if (!bool_0)
		{
			DarkDockSplitter darkDockSplitter = method_2();
			if (darkDockSplitter != null)
			{
				Cursor.Current = darkDockSplitter.ResizeCursor;
			}
		}
	}

	private void method_4()
	{
		Cursor.Current = Cursors.Default;
		method_3();
	}

	static DockResizeFilter()
	{
		Class72.smethod_20();
	}
}
