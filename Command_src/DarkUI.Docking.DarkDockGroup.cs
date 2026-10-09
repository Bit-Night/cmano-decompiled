using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkDockGroup : Panel
{
	private List<DarkDockContent> list_0 = new List<DarkDockContent>();

	private Dictionary<DarkDockContent, DarkDockTab> dictionary_0 = new Dictionary<DarkDockContent, DarkDockTab>();

	private DarkDockTabArea darkDockTabArea_0;

	private DarkDockTab darkDockTab_0;

	[CompilerGenerated]
	private DarkDockPanel darkDockPanel_0;

	[CompilerGenerated]
	private DarkDockRegion darkDockRegion_0;

	[CompilerGenerated]
	private DarkDockArea darkDockArea_0;

	[CompilerGenerated]
	private DarkDockContent darkDockContent_0;

	[CompilerGenerated]
	private int int_0;

	public DarkDockPanel DockPanel
	{
		[CompilerGenerated]
		get
		{
			return darkDockPanel_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockPanel_0 = value;
		}
	}

	public DarkDockRegion DockRegion
	{
		[CompilerGenerated]
		get
		{
			return darkDockRegion_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockRegion_0 = value;
		}
	}

	public DarkDockArea DockArea
	{
		[CompilerGenerated]
		get
		{
			return darkDockArea_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockArea_0 = value;
		}
	}

	public DarkDockContent VisibleContent
	{
		[CompilerGenerated]
		get
		{
			return darkDockContent_0;
		}
		[CompilerGenerated]
		private set
		{
			darkDockContent_0 = value;
		}
	}

	public int Order
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int ContentCount => list_0.Count;

	public DarkDockGroup(DarkDockPanel dockPanel, DarkDockRegion dockRegion, int order)
	{
		((Control)this).SetStyle((ControlStyles)131090, true);
		DockPanel = dockPanel;
		DockRegion = dockRegion;
		DockArea = dockRegion.DockArea;
		Order = order;
		darkDockTabArea_0 = new DarkDockTabArea(DockArea);
		DockPanel.ActiveContentChanged += method_5;
	}

	public void AddContent(DarkDockContent dockContent)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		dockContent.DockGroup = this;
		((Control)dockContent).Dock = (DockStyle)5;
		dockContent.Order = 0;
		if (list_0.Count > 0)
		{
			int num = -1;
			foreach (DarkDockContent item in list_0)
			{
				if (item.Order >= num)
				{
					num = item.Order + 1;
				}
			}
			dockContent.Order = num;
		}
		list_0.Add(dockContent);
		((Control)this).Controls.Add((Control)(object)dockContent);
		dockContent.DockTextChanged += method_6;
		dictionary_0.Add(dockContent, new DarkDockTab(dockContent));
		if (VisibleContent == null)
		{
			((Control)dockContent).Visible = true;
			VisibleContent = dockContent;
		}
		else
		{
			((Control)dockContent).Visible = false;
		}
		ToolStripMenuItem val = new ToolStripMenuItem(dockContent.DockText);
		((ToolStripItem)val).Tag = dockContent;
		((ToolStripItem)val).Click += method_4;
		((ToolStripItem)val).Image = dockContent.Icon;
		darkDockTabArea_0.AddMenuItem(val);
		method_0();
	}

	public void RemoveContent(DarkDockContent dockContent)
	{
		dockContent.DockGroup = null;
		int order = dockContent.Order;
		list_0.Remove(dockContent);
		((Control)this).Controls.Remove((Control)(object)dockContent);
		foreach (DarkDockContent item in list_0)
		{
			if (item.Order > order)
			{
				item.Order--;
			}
		}
		dockContent.DockTextChanged -= method_6;
		if (dictionary_0.ContainsKey(dockContent))
		{
			dictionary_0.Remove(dockContent);
		}
		if (VisibleContent == dockContent)
		{
			VisibleContent = null;
			if (list_0.Count > 0)
			{
				DarkDockContent darkDockContent = list_0[0];
				((Control)darkDockContent).Visible = true;
				VisibleContent = darkDockContent;
			}
		}
		ToolStripMenuItem menuItem = darkDockTabArea_0.GetMenuItem(dockContent);
		((ToolStripItem)menuItem).Click -= method_4;
		darkDockTabArea_0.RemoveMenuItem(menuItem);
		method_0();
	}

	public List<DarkDockContent> GetContents()
	{
		return list_0.OrderBy((DarkDockContent c) => c.Order).ToList();
	}

	private void method_0()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		int num;
		if (DockArea == DarkDockArea.Document)
		{
			darkDockTabArea_0.Visible = list_0.Count > 0;
			num = 0;
		}
		else
		{
			darkDockTabArea_0.Visible = list_0.Count > 1;
			num = 0;
		}
		int num2 = num;
		Padding padding;
		switch (DockArea)
		{
		case DarkDockArea.Document:
		{
			num2 = (darkDockTabArea_0.Visible ? 24 : 0);
			((Control)this).Padding = new Padding(0, num2, 0, 0);
			DarkDockTabArea darkDockTabArea3 = darkDockTabArea_0;
			padding = ((Control)this).Padding;
			int left3 = ((Padding)(ref padding)).Left;
			int width3 = ((Control)this).ClientRectangle.Width;
			padding = ((Control)this).Padding;
			darkDockTabArea3.ClientRectangle = new Rectangle(left3, 0, width3 - ((Padding)(ref padding)).Horizontal, num2);
			break;
		}
		case DarkDockArea.Left:
		case DarkDockArea.Right:
		{
			num2 = (darkDockTabArea_0.Visible ? 21 : 0);
			((Control)this).Padding = new Padding(0, 0, 0, num2);
			DarkDockTabArea darkDockTabArea2 = darkDockTabArea_0;
			padding = ((Control)this).Padding;
			int left2 = ((Padding)(ref padding)).Left;
			int y2 = ((Control)this).ClientRectangle.Bottom - num2;
			int width2 = ((Control)this).ClientRectangle.Width;
			padding = ((Control)this).Padding;
			darkDockTabArea2.ClientRectangle = new Rectangle(left2, y2, width2 - ((Padding)(ref padding)).Horizontal, num2);
			break;
		}
		case DarkDockArea.Bottom:
		{
			num2 = (darkDockTabArea_0.Visible ? 21 : 0);
			((Control)this).Padding = new Padding(1, 0, 0, num2);
			DarkDockTabArea darkDockTabArea = darkDockTabArea_0;
			padding = ((Control)this).Padding;
			int left = ((Padding)(ref padding)).Left;
			int y = ((Control)this).ClientRectangle.Bottom - num2;
			int width = ((Control)this).ClientRectangle.Width;
			padding = ((Control)this).Padding;
			darkDockTabArea.ClientRectangle = new Rectangle(left, y, width - ((Padding)(ref padding)).Horizontal, num2);
			break;
		}
		}
		if (DockArea == DarkDockArea.Document)
		{
			darkDockTabArea_0.DropdownRectangle = new Rectangle(darkDockTabArea_0.ClientRectangle.Right - 24, 0, 24, 24);
		}
		method_1();
		EnsureVisible();
	}

	private void method_1()
	{
		if (!darkDockTabArea_0.Visible)
		{
			return;
		}
		((Control)this).SuspendLayout();
		int width = ((Image)DockIcons.close).Width;
		int num = 0;
		IOrderedEnumerable<DarkDockContent> orderedEnumerable = list_0.OrderBy((DarkDockContent c) => c.Order);
		foreach (DarkDockContent item in orderedEnumerable)
		{
			DarkDockTab darkDockTab = dictionary_0[item];
			Graphics val = ((Control)this).CreateGraphics();
			int num2;
			try
			{
				num2 = darkDockTab.CalculateWidth(val, ((Control)this).Font);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			if (DockArea == DarkDockArea.Document)
			{
				num2 += 5;
				num2 += width;
				if (darkDockTab.DockContent.Icon != null)
				{
					num2 += darkDockTab.DockContent.Icon.Width + 5;
				}
			}
			darkDockTab.ShowSeparator = true;
			num2++;
			int y = ((DockArea != DarkDockArea.Document) ? (((Control)this).ClientRectangle.Height - 21) : 0);
			int height = ((DockArea == DarkDockArea.Document) ? 24 : 21);
			Rectangle clientRectangle = new Rectangle(darkDockTabArea_0.ClientRectangle.Left + num, y, num2, height);
			darkDockTab.ClientRectangle = clientRectangle;
			num += num2;
		}
		if (DockArea != DarkDockArea.Document && num > darkDockTabArea_0.ClientRectangle.Width)
		{
			int num3 = num - darkDockTabArea_0.ClientRectangle.Width;
			DarkDockTab darkDockTab2 = dictionary_0[orderedEnumerable.Last()];
			Rectangle clientRectangle2 = darkDockTab2.ClientRectangle;
			darkDockTab2.ClientRectangle = new Rectangle(clientRectangle2.Left, clientRectangle2.Top, clientRectangle2.Width - 1, clientRectangle2.Height);
			darkDockTab2.ShowSeparator = false;
			int num4 = 1;
			while (num4 < num3)
			{
				int width2 = dictionary_0.Values.OrderByDescending((DarkDockTab tab) => tab.ClientRectangle.Width).First().ClientRectangle.Width;
				foreach (DarkDockContent item2 in orderedEnumerable)
				{
					DarkDockTab darkDockTab3 = dictionary_0[item2];
					if (num4 < num3)
					{
						if (darkDockTab3.ClientRectangle.Width >= width2)
						{
							Rectangle clientRectangle3 = darkDockTab3.ClientRectangle;
							darkDockTab3.ClientRectangle = new Rectangle(clientRectangle3.Left, clientRectangle3.Top, clientRectangle3.Width - 1, clientRectangle3.Height);
							num4++;
						}
						continue;
					}
					break;
				}
			}
			int num5 = 0;
			foreach (DarkDockContent item3 in orderedEnumerable)
			{
				DarkDockTab darkDockTab4 = dictionary_0[item3];
				Rectangle clientRectangle4 = darkDockTab4.ClientRectangle;
				darkDockTab4.ClientRectangle = new Rectangle(darkDockTabArea_0.ClientRectangle.Left + num5, clientRectangle4.Top, clientRectangle4.Width, clientRectangle4.Height);
				num5 += clientRectangle4.Width;
			}
		}
		if (DockArea == DarkDockArea.Document)
		{
			foreach (DarkDockContent item4 in orderedEnumerable)
			{
				DarkDockTab darkDockTab5 = dictionary_0[item4];
				Rectangle closeButtonRectangle = new Rectangle(darkDockTab5.ClientRectangle.Right - 7 - width - 1, darkDockTab5.ClientRectangle.Top + darkDockTab5.ClientRectangle.Height / 2 - width / 2 - 1, width, width);
				darkDockTab5.CloseButtonRectangle = closeButtonRectangle;
			}
		}
		num = 0;
		foreach (DarkDockContent item5 in orderedEnumerable)
		{
			DarkDockTab darkDockTab6 = dictionary_0[item5];
			num += darkDockTab6.ClientRectangle.Width;
		}
		darkDockTabArea_0.TotalTabSize = num;
		((Control)this).ResumeLayout();
		((Control)this).Invalidate();
	}

	public void EnsureVisible()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (DockArea != DarkDockArea.Document || VisibleContent == null)
		{
			return;
		}
		int width = ((Control)this).ClientRectangle.Width;
		Padding padding = ((Control)this).Padding;
		int num = width - ((Padding)(ref padding)).Horizontal - darkDockTabArea_0.DropdownRectangle.Width;
		padding = ((Control)this).Padding;
		Rectangle rectangle = new Rectangle(((Padding)(ref padding)).Left, 0, num, 0);
		DarkDockTab darkDockTab = dictionary_0[VisibleContent];
		if (darkDockTab.ClientRectangle.IsEmpty)
		{
			return;
		}
		if (method_3(darkDockTab.ClientRectangle).Left < rectangle.Left)
		{
			darkDockTabArea_0.Offset = darkDockTab.ClientRectangle.Left;
		}
		else if (method_3(darkDockTab.ClientRectangle).Right > rectangle.Right)
		{
			darkDockTabArea_0.Offset = darkDockTab.ClientRectangle.Right - num;
		}
		if (darkDockTabArea_0.TotalTabSize < rectangle.Width)
		{
			darkDockTabArea_0.Offset = 0;
		}
		if (darkDockTabArea_0.TotalTabSize > rectangle.Width)
		{
			IOrderedEnumerable<DarkDockContent> source = list_0.OrderBy((DarkDockContent x) => x.Order);
			DarkDockTab darkDockTab2 = dictionary_0[source.Last()];
			if (darkDockTab2 != null && method_3(darkDockTab2.ClientRectangle).Right < rectangle.Right)
			{
				darkDockTabArea_0.Offset = darkDockTab2.ClientRectangle.Right - num;
			}
		}
		((Control)this).Invalidate();
	}

	public void SetVisibleContent(DarkDockContent content)
	{
		if (!list_0.Contains(content) || VisibleContent == content)
		{
			return;
		}
		VisibleContent = content;
		((Control)content).Visible = true;
		foreach (DarkDockContent item in list_0)
		{
			if (item != content)
			{
				((Control)item).Visible = false;
			}
		}
		((Control)this).Invalidate();
	}

	private Point method_2(Point point_0)
	{
		return new Point(point_0.X - darkDockTabArea_0.Offset, point_0.Y);
	}

	private Rectangle method_3(Rectangle rectangle_0)
	{
		return new Rectangle(method_2(rectangle_0.Location), rectangle_0.Size);
	}

	protected override void OnResize(EventArgs eventargs)
	{
		((Panel)this).OnResize(eventargs);
		method_0();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		((Control)this).OnMouseMove(e);
		if (darkDockTab_0 != null)
		{
			int num = e.Location.X + darkDockTabArea_0.Offset;
			if (num >= darkDockTab_0.ClientRectangle.Left)
			{
				if (num <= darkDockTab_0.ClientRectangle.Right)
				{
					return;
				}
				int count = list_0.Count;
				if (darkDockTab_0.DockContent.Order >= count)
				{
					return;
				}
				List<DarkDockTab> list = dictionary_0.Values.Where((DarkDockTab darkDockTab_1) => darkDockTab_1.DockContent.Order == darkDockTab_0.DockContent.Order + 1).ToList();
				if (list.Count != 0)
				{
					DarkDockTab darkDockTab = list.First();
					if (darkDockTab != null)
					{
						int order = darkDockTab_0.DockContent.Order;
						darkDockTab_0.DockContent.Order = order + 1;
						darkDockTab.DockContent.Order = order;
						method_1();
						EnsureVisible();
						darkDockTabArea_0.RebuildMenu();
					}
				}
			}
			else
			{
				if (darkDockTab_0.DockContent.Order <= 0)
				{
					return;
				}
				List<DarkDockTab> list2 = dictionary_0.Values.Where((DarkDockTab darkDockTab_1) => darkDockTab_1.DockContent.Order == darkDockTab_0.DockContent.Order - 1).ToList();
				if (list2.Count != 0)
				{
					DarkDockTab darkDockTab2 = list2.First();
					if (darkDockTab2 != null)
					{
						int order2 = darkDockTab_0.DockContent.Order;
						darkDockTab_0.DockContent.Order = order2 - 1;
						darkDockTab2.DockContent.Order = order2;
						method_1();
						EnsureVisible();
						darkDockTabArea_0.RebuildMenu();
					}
				}
			}
			return;
		}
		if (darkDockTabArea_0.DropdownRectangle.Contains(e.Location))
		{
			darkDockTabArea_0.DropdownHot = true;
			foreach (DarkDockTab value in dictionary_0.Values)
			{
				value.Hot = false;
			}
			((Control)this).Invalidate();
			return;
		}
		darkDockTabArea_0.DropdownHot = false;
		foreach (DarkDockTab value2 in dictionary_0.Values)
		{
			bool flag = method_3(value2.ClientRectangle).Contains(e.Location);
			if (value2.Hot != flag)
			{
				value2.Hot = flag;
				((Control)this).Invalidate();
			}
			bool flag2 = method_3(value2.CloseButtonRectangle).Contains(e.Location);
			if (value2.CloseButtonHot != flag2)
			{
				value2.CloseButtonHot = flag2;
				((Control)this).Invalidate();
			}
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		((Control)this).OnMouseDown(e);
		if (!darkDockTabArea_0.DropdownRectangle.Contains(e.Location))
		{
			foreach (DarkDockTab value in dictionary_0.Values)
			{
				if (method_3(value.ClientRectangle).Contains(e.Location))
				{
					if ((int)e.Button == 4194304)
					{
						value.DockContent.Close();
					}
					else if (!method_3(value.CloseButtonRectangle).Contains(e.Location))
					{
						DockPanel.ActiveContent = value.DockContent;
						EnsureVisible();
						darkDockTab_0 = value;
					}
					else
					{
						darkDockTabArea_0.ClickedCloseButton = value;
					}
					return;
				}
			}
			if (VisibleContent != null)
			{
				DockPanel.ActiveContent = VisibleContent;
			}
		}
		else
		{
			darkDockTabArea_0.DropdownHot = true;
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Control)this).OnMouseUp(e);
		darkDockTab_0 = null;
		if (darkDockTabArea_0.DropdownRectangle.Contains(e.Location))
		{
			if (darkDockTabArea_0.DropdownHot)
			{
				darkDockTabArea_0.ShowMenu((Control)(object)this, new Point(darkDockTabArea_0.DropdownRectangle.Left, darkDockTabArea_0.DropdownRectangle.Bottom - 2));
			}
		}
		else if (darkDockTabArea_0.ClickedCloseButton != null && method_3(darkDockTabArea_0.ClickedCloseButton.CloseButtonRectangle).Contains(e.Location))
		{
			darkDockTabArea_0.ClickedCloseButton.DockContent.Close();
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		((Control)this).OnMouseLeave(e);
		foreach (DarkDockTab value in dictionary_0.Values)
		{
			value.Hot = false;
		}
		((Control)this).Invalidate();
	}

	private void method_4(object sender, EventArgs e)
	{
		ToolStripMenuItem val = (ToolStripMenuItem)((sender is ToolStripMenuItem) ? sender : null);
		if (val != null && ((ToolStripItem)val).Tag is DarkDockContent activeContent)
		{
			DockPanel.ActiveContent = activeContent;
		}
	}

	private void method_5(object sender, DockContentEventArgs e)
	{
		if (!list_0.Contains(e.Content))
		{
			return;
		}
		if (e.Content == VisibleContent)
		{
			((Control)VisibleContent).Focus();
			return;
		}
		VisibleContent = e.Content;
		foreach (DarkDockContent item in list_0)
		{
			((Control)item).Visible = item == VisibleContent;
		}
		((Control)VisibleContent).Focus();
		EnsureVisible();
		((Control)this).Invalidate();
	}

	private void method_6(object sender, EventArgs e)
	{
		method_1();
	}

	public void Redraw()
	{
		((Control)this).Invalidate();
		foreach (DarkDockContent item in list_0)
		{
			((Control)item).Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		SolidBrush val = new SolidBrush(Colors.GreyBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (!darkDockTabArea_0.Visible)
		{
			return;
		}
		SolidBrush val2 = new SolidBrush(Colors.MediumBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val2, darkDockTabArea_0.ClientRectangle);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		foreach (DarkDockTab value in dictionary_0.Values)
		{
			if (DockArea == DarkDockArea.Document)
			{
				method_7(graphics, value);
			}
			else
			{
				method_8(graphics, value);
			}
		}
		if (DockArea == DarkDockArea.Document)
		{
			SolidBrush val3 = new SolidBrush((DockPanel.ActiveGroup != this) ? Colors.GreySelection : Colors.BlueSelection);
			try
			{
				Rectangle rectangle = new Rectangle(darkDockTabArea_0.ClientRectangle.Left, darkDockTabArea_0.ClientRectangle.Bottom - 2, darkDockTabArea_0.ClientRectangle.Width, 2);
				graphics.FillRectangle((Brush)(object)val3, rectangle);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			Rectangle rectangle2 = new Rectangle(darkDockTabArea_0.DropdownRectangle.Left, darkDockTabArea_0.DropdownRectangle.Top, darkDockTabArea_0.DropdownRectangle.Width, darkDockTabArea_0.DropdownRectangle.Height - 2);
			SolidBrush val4 = new SolidBrush(Colors.MediumBackground);
			try
			{
				graphics.FillRectangle((Brush)(object)val4, rectangle2);
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
			Bitmap arrow = DockIcons.arrow;
			try
			{
				graphics.DrawImageUnscaled((Image)(object)arrow, rectangle2.Left + rectangle2.Width / 2 - ((Image)arrow).Width / 2, rectangle2.Top + rectangle2.Height / 2 - ((Image)arrow).Height / 2 + 1);
			}
			finally
			{
				((IDisposable)arrow)?.Dispose();
			}
		}
	}

	private void method_7(Graphics graphics_0, DarkDockTab darkDockTab_1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		Rectangle rectangle = method_3(darkDockTab_1.ClientRectangle);
		bool flag = VisibleContent == darkDockTab_1.DockContent;
		bool flag2 = DockPanel.ActiveGroup == this;
		Color color = ((!flag) ? Colors.DarkBackground : Colors.BlueSelection);
		if (!flag2)
		{
			color = (flag ? Colors.GreySelection : Colors.DarkBackground);
		}
		if (darkDockTab_1.Hot && !flag)
		{
			color = Colors.MediumBackground;
		}
		SolidBrush val = new SolidBrush(color);
		try
		{
			graphics_0.FillRectangle((Brush)(object)val, rectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (darkDockTab_1.ShowSeparator)
		{
			Pen val2 = new Pen(Colors.DarkBorder);
			try
			{
				graphics_0.DrawLine(val2, rectangle.Right - 1, rectangle.Top, rectangle.Right - 1, rectangle.Bottom);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		int num = 0;
		if (darkDockTab_1.DockContent.Icon != null)
		{
			graphics_0.DrawImageUnscaled(darkDockTab_1.DockContent.Icon, rectangle.Left + 5, rectangle.Top + 4);
			num += darkDockTab_1.DockContent.Icon.Width + 2;
		}
		StringFormat val3 = new StringFormat
		{
			Alignment = (StringAlignment)0,
			LineAlignment = (StringAlignment)1,
			FormatFlags = (StringFormatFlags)4096,
			Trimming = (StringTrimming)3
		};
		SolidBrush val4 = new SolidBrush(flag ? Colors.LightText : Colors.DisabledText);
		try
		{
			Rectangle rectangle2 = new Rectangle(rectangle.Left + 5 + num, rectangle.Top, rectangle.Width - darkDockTab_1.CloseButtonRectangle.Width - 7 - 5 - num, rectangle.Height);
			graphics_0.DrawString(darkDockTab_1.DockContent.DockText, ((Control)this).Font, (Brush)(object)val4, (RectangleF)rectangle2, val3);
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
		Bitmap val5 = (darkDockTab_1.CloseButtonHot ? DockIcons.inactive_close_selected : DockIcons.inactive_close);
		if (flag)
		{
			val5 = (flag2 ? (darkDockTab_1.CloseButtonHot ? DockIcons.close_selected : DockIcons.close) : (darkDockTab_1.CloseButtonHot ? DockIcons.close_selected : DockIcons.active_inactive_close));
		}
		Rectangle rectangle3 = method_3(darkDockTab_1.CloseButtonRectangle);
		graphics_0.DrawImageUnscaled((Image)(object)val5, rectangle3.Left, rectangle3.Top);
	}

	private void method_8(Graphics graphics_0, DarkDockTab darkDockTab_1)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		Rectangle clientRectangle = darkDockTab_1.ClientRectangle;
		bool flag;
		Color color = ((!(flag = VisibleContent == darkDockTab_1.DockContent)) ? Colors.DarkBackground : Colors.GreyBackground);
		if (darkDockTab_1.Hot && !flag)
		{
			color = Colors.MediumBackground;
		}
		SolidBrush val = new SolidBrush(color);
		try
		{
			graphics_0.FillRectangle((Brush)(object)val, clientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (darkDockTab_1.ShowSeparator)
		{
			Pen val2 = new Pen(Colors.DarkBorder);
			try
			{
				graphics_0.DrawLine(val2, clientRectangle.Right - 1, clientRectangle.Top, clientRectangle.Right - 1, clientRectangle.Bottom);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		StringFormat val3 = new StringFormat
		{
			Alignment = (StringAlignment)0,
			LineAlignment = (StringAlignment)1,
			FormatFlags = (StringFormatFlags)4096,
			Trimming = (StringTrimming)3
		};
		SolidBrush val4 = new SolidBrush(flag ? Colors.BlueHighlight : Colors.DisabledText);
		try
		{
			Rectangle rectangle = new Rectangle(clientRectangle.Left + 5, clientRectangle.Top, clientRectangle.Width - 5, clientRectangle.Height);
			graphics_0.DrawString(darkDockTab_1.DockContent.DockText, ((Control)this).Font, (Brush)(object)val4, (RectangleF)rectangle, val3);
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	[CompilerGenerated]
	private bool method_9(DarkDockTab darkDockTab_1)
	{
		return darkDockTab_1.DockContent.Order == darkDockTab_0.DockContent.Order - 1;
	}

	[CompilerGenerated]
	private bool bDrycAjkLnu(DarkDockTab darkDockTab_1)
	{
		return darkDockTab_1.DockContent.Order == darkDockTab_0.DockContent.Order + 1;
	}

	static DarkDockGroup()
	{
		Class72.smethod_20();
	}
}
