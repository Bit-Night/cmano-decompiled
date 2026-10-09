using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class VirtualCommList : UserControl
{
	public delegate void SelectionChangedEventHandler(int id, bool selected, int qty);

	private class Class0
	{
		public int ID;

		public string Name;

		public bool bool_0;

		public int Quantity;

		public Class0()
		{
			bool_0 = false;
			Quantity = 1;
		}

		static Class0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[CompilerGenerated]
	private SelectionChangedEventHandler selectionChangedEventHandler_0;

	private List<Class0> list_0;

	private int int_0;

	private int int_1;

	public event SelectionChangedEventHandler SelectionChanged
	{
		[CompilerGenerated]
		add
		{
			SelectionChangedEventHandler selectionChangedEventHandler = selectionChangedEventHandler_0;
			SelectionChangedEventHandler selectionChangedEventHandler2;
			do
			{
				selectionChangedEventHandler2 = selectionChangedEventHandler;
				SelectionChangedEventHandler value2 = (SelectionChangedEventHandler)Delegate.Combine(selectionChangedEventHandler2, value);
				selectionChangedEventHandler = Interlocked.CompareExchange(ref selectionChangedEventHandler_0, value2, selectionChangedEventHandler2);
			}
			while ((object)selectionChangedEventHandler != selectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectionChangedEventHandler selectionChangedEventHandler = selectionChangedEventHandler_0;
			SelectionChangedEventHandler selectionChangedEventHandler2;
			do
			{
				selectionChangedEventHandler2 = selectionChangedEventHandler;
				SelectionChangedEventHandler value2 = (SelectionChangedEventHandler)Delegate.Remove(selectionChangedEventHandler2, value);
				selectionChangedEventHandler = Interlocked.CompareExchange(ref selectionChangedEventHandler_0, value2, selectionChangedEventHandler2);
			}
			while ((object)selectionChangedEventHandler != selectionChangedEventHandler2);
		}
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

	private void method_0()
	{
		icontainer_0 = new Container();
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
	}

	public VirtualCommList()
	{
		list_0 = new List<Class0>();
		int_0 = 0;
		int_1 = -1;
		((Control)this).SetStyle((ControlStyles)139266, true);
		((Control)this).BackColor = Color.FromArgb(45, 45, 48);
	}

	public void LoadRows(DataView view)
	{
		list_0.Clear();
		foreach (DataRowView item in view)
		{
			list_0.Add(new Class0
			{
				ID = Conversions.ToInteger(item["ID"]),
				Name = item["Name"].ToString()
			});
		}
		int_0 = 0;
		method_1();
		((Control)this).Invalidate();
	}

	public void LoadFilteredRows(List<(int ID, string Name)> rows)
	{
		list_0.Clear();
		foreach (var row in rows)
		{
			List<Class0> list = list_0;
			Class0 @class = new Class0();
			(@class.ID, @class.Name) = row;
			list.Add(@class);
		}
		int_0 = 0;
		((Control)this).Invalidate();
	}

	public void RestoreSelections(Dictionary<int, int> dict)
	{
		foreach (Class0 item in list_0)
		{
			if (dict.ContainsKey(item.ID))
			{
				item.bool_0 = true;
				item.Quantity = dict[item.ID];
			}
		}
		((Control)this).Invalidate();
	}

	private void method_1()
	{
		if (list_0.Count * 24 > ((Control)this).Height)
		{
			((ScrollableControl)this).VScroll = true;
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		int_0 = Math.Max(0, Math.Min(int_0 - e.Delta / 3, Math.Max(0, list_0.Count * 24 - ((Control)this).Height)));
		((Control)this).Invalidate();
	}

	private int method_2(int int_2)
	{
		int num = (int_2 + int_0) / 24;
		int result;
		if (num < 0)
		{
			result = -1;
		}
		else
		{
			if (num < list_0.Count)
			{
				return num;
			}
			result = -1;
		}
		return result;
	}

	private bool method_3(int int_2)
	{
		if (int_2 >= ((Control)this).Width - 44 - 8)
		{
			return int_2 <= ((Control)this).Width - 8;
		}
		return false;
	}

	private bool method_4(int int_2)
	{
		if (int_2 >= 6)
		{
			return int_2 <= 26;
		}
		return false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		int num = method_2(e.Y);
		if (num != int_1)
		{
			int_1 = num;
			((Control)this).Invalidate();
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		int_1 = -1;
		((Control)this).Invalidate();
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		int num = method_2(e.Y);
		if (num < 0)
		{
			return;
		}
		Class0 @class = list_0[num];
		if (method_3(e.X))
		{
			int num2 = num * 24 - int_0 + 2 + 10;
			if (e.Y < num2)
			{
				@class.Quantity = Math.Min(99, @class.Quantity + 1);
				@class.bool_0 = true;
				selectionChangedEventHandler_0?.Invoke(@class.ID, selected: true, @class.Quantity);
			}
			else
			{
				@class.Quantity = Math.Max(0, @class.Quantity - 1);
				if (@class.Quantity == 0 && @class.bool_0)
				{
					@class.bool_0 = false;
					selectionChangedEventHandler_0?.Invoke(@class.ID, selected: false, @class.Quantity);
				}
				else if (@class.bool_0)
				{
					selectionChangedEventHandler_0?.Invoke(@class.ID, selected: true, @class.Quantity);
				}
			}
		}
		else
		{
			@class.bool_0 = !@class.bool_0;
			if (!@class.bool_0)
			{
				@class.Quantity = 1;
			}
			selectionChangedEventHandler_0?.Invoke(@class.ID, @class.bool_0, @class.Quantity);
		}
		((Control)this).Invalidate();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		int num = int_0 / 24;
		int num2 = Math.Min(list_0.Count - 1, (int_0 + ((Control)this).Height) / 24 + 1);
		Font val = new Font("Segoe UI", 8.5f);
		Pen val2 = new Pen(Color.FromArgb(60, 60, 60));
		int num3 = num2;
		for (int i = num; i <= num3; i++)
		{
			Class0 @class = list_0[i];
			int num4 = i * 24 - int_0;
			Color color = (@class.bool_0 ? Color.FromArgb(0, 122, 204) : ((i != int_1) ? Color.FromArgb(45, 45, 48) : Color.FromArgb(58, 58, 62)));
			SolidBrush val3 = new SolidBrush(color);
			graphics.FillRectangle((Brush)(object)val3, 0, num4, ((Control)this).Width, 24);
			int y = num4 + 4;
			Rectangle rectangle = new Rectangle(6, y, 14, 14);
			Pen val4 = new Pen(Color.FromArgb(150, 150, 150));
			graphics.DrawRectangle(val4, rectangle);
			if (@class.bool_0)
			{
				int num5 = rectangle.X + 2;
				int num6 = rectangle.Y + 2;
				graphics.FillRectangle(Brushes.White, num5, num6, 10, 10);
			}
			Color color2 = (@class.bool_0 ? Color.White : Color.FromArgb(200, 200, 200));
			SolidBrush val5 = new SolidBrush(color2);
			int num7 = ((Control)this).Width - 44 - 36;
			RectangleF rectangleF = new RectangleF(28f, num4, num7, 24f);
			StringFormat val6 = new StringFormat();
			val6.LineAlignment = (StringAlignment)1;
			val6.Trimming = (StringTrimming)3;
			graphics.DrawString(@class.Name, val, (Brush)(object)val5, rectangleF, val6);
			int x = ((Control)this).Width - 44 - 8;
			int y2 = num4 + 2;
			Rectangle rectangle2 = new Rectangle(x, y2, 44, 20);
			SolidBrush val7 = new SolidBrush(Color.FromArgb(30, 30, 30));
			Pen val8 = new Pen(Color.FromArgb(80, 80, 80));
			graphics.FillRectangle((Brush)(object)val7, rectangle2);
			graphics.DrawRectangle(val8, rectangle2);
			SolidBrush val9 = new SolidBrush(Color.FromArgb(200, 200, 200));
			RectangleF rectangleF2 = new RectangleF(rectangle2.X, rectangle2.Y, rectangle2.Width - 12, rectangle2.Height);
			StringFormat val10 = new StringFormat();
			val10.Alignment = (StringAlignment)1;
			val10.LineAlignment = (StringAlignment)1;
			graphics.DrawString(@class.Quantity.ToString(), val, (Brush)(object)val9, rectangleF2, val10);
			int num8 = rectangle2.Right - 11;
			int num9 = num4 + 12;
			SolidBrush val11 = new SolidBrush(Color.FromArgb(160, 160, 160));
			Font val12 = new Font("Segoe UI", 6f);
			graphics.DrawString("▲", val12, (Brush)(object)val11, (float)num8, (float)(num4 + 4));
			graphics.DrawString("▼", val12, (Brush)(object)val11, (float)num8, (float)(num9 + 1));
			int num10 = num4 + 24 - 1;
			graphics.DrawLine(val2, 0, num10, ((Control)this).Width, num10);
		}
		val.Dispose();
		val2.Dispose();
	}

	static VirtualCommList()
	{
		Class72.smethod_20();
	}
}
