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
public sealed class DarkDockRegion : Panel
{
	private List<DarkDockGroup> list_0;

	private Form form_0;

	private DarkDockSplitter darkDockSplitter_0;

	[CompilerGenerated]
	private DarkDockPanel darkDockPanel_0;

	[CompilerGenerated]
	private DarkDockArea darkDockArea_0;

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

	public DarkDockContent ActiveDocument
	{
		get
		{
			if (DockArea == DarkDockArea.Document && list_0.Count != 0)
			{
				return list_0[0].VisibleContent;
			}
			return null;
		}
	}

	public List<DarkDockGroup> Groups => list_0.ToList();

	public DarkDockRegion(DarkDockPanel dockPanel, DarkDockArea dockArea)
	{
		list_0 = new List<DarkDockGroup>();
		DockPanel = dockPanel;
		DockArea = dockArea;
		method_5();
	}

	internal void AddContent(DarkDockContent dockContent)
	{
		AddContent(dockContent, null);
	}

	internal void AddContent(DarkDockContent dockContent, DarkDockGroup dockGroup)
	{
		if (dockGroup == null)
		{
			dockGroup = ((DockArea != DarkDockArea.Document || list_0.Count <= 0) ? method_0() : list_0[0]);
		}
		dockContent.DockRegion = this;
		dockGroup.AddContent(dockContent);
		if (!((Control)this).Visible)
		{
			((Control)this).Visible = true;
			method_6();
		}
		method_3();
	}

	internal void InsertContent(DarkDockContent dockContent, DarkDockGroup dockGroup, DockInsertType insertType)
	{
		int num = dockGroup.Order;
		if (insertType == DockInsertType.After)
		{
			num++;
		}
		DarkDockGroup darkDockGroup = method_1(num);
		dockContent.DockRegion = this;
		darkDockGroup.AddContent(dockContent);
		if (!((Control)this).Visible)
		{
			((Control)this).Visible = true;
			method_6();
		}
		method_3();
	}

	internal void RemoveContent(DarkDockContent dockContent)
	{
		dockContent.DockRegion = null;
		DarkDockGroup dockGroup = dockContent.DockGroup;
		dockGroup.RemoveContent(dockContent);
		dockContent.DockArea = DarkDockArea.None;
		if (dockGroup.ContentCount == 0)
		{
			method_2(dockGroup);
		}
		if (list_0.Count == 0 && DockArea != DarkDockArea.Document)
		{
			((Control)this).Visible = false;
			method_7();
		}
		method_3();
	}

	public List<DarkDockContent> GetContents()
	{
		List<DarkDockContent> list = new List<DarkDockContent>();
		foreach (DarkDockGroup item in list_0)
		{
			list.AddRange(item.GetContents());
		}
		return list;
	}

	private DarkDockGroup method_0()
	{
		int num = 0;
		if (list_0.Count >= 1)
		{
			num = -1;
			foreach (DarkDockGroup item in list_0)
			{
				if (item.Order >= num)
				{
					num = item.Order + 1;
				}
			}
		}
		DarkDockGroup darkDockGroup = new DarkDockGroup(DockPanel, this, num);
		list_0.Add(darkDockGroup);
		((Control)this).Controls.Add((Control)(object)darkDockGroup);
		return darkDockGroup;
	}

	private DarkDockGroup method_1(int int_0)
	{
		foreach (DarkDockGroup item in list_0)
		{
			if (item.Order >= int_0)
			{
				item.Order++;
			}
		}
		DarkDockGroup darkDockGroup = new DarkDockGroup(DockPanel, this, int_0);
		list_0.Add(darkDockGroup);
		((Control)this).Controls.Add((Control)(object)darkDockGroup);
		return darkDockGroup;
	}

	private void method_2(DarkDockGroup darkDockGroup_0)
	{
		int order = darkDockGroup_0.Order;
		list_0.Remove(darkDockGroup_0);
		((Control)this).Controls.Remove((Control)(object)darkDockGroup_0);
		foreach (DarkDockGroup item in list_0)
		{
			if (item.Order > order)
			{
				item.Order--;
			}
		}
	}

	private void method_3()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		int num;
		DockStyle dock;
		switch (DockArea)
		{
		default:
			num = 5;
			goto IL_0023;
		case DarkDockArea.Document:
			num = 5;
			goto IL_0023;
		case DarkDockArea.Left:
		case DarkDockArea.Right:
			dock = (DockStyle)1;
			break;
		case DarkDockArea.Bottom:
			{
				dock = (DockStyle)3;
				break;
			}
			IL_0023:
			dock = (DockStyle)num;
			break;
		}
		if (list_0.Count == 1)
		{
			((Control)list_0[0]).Dock = (DockStyle)5;
		}
		else
		{
			if (list_0.Count <= 1)
			{
				return;
			}
			DarkDockGroup darkDockGroup = list_0.OrderByDescending((DarkDockGroup g) => g.Order).First();
			foreach (DarkDockGroup item in list_0.OrderByDescending((DarkDockGroup g) => g.Order))
			{
				((Control)item).SendToBack();
				if (item.Order == darkDockGroup.Order)
				{
					((Control)item).Dock = (DockStyle)5;
				}
				else
				{
					((Control)item).Dock = dock;
				}
			}
			method_4();
		}
	}

	private void method_4()
	{
		if (list_0.Count <= 1)
		{
			return;
		}
		Size size = new Size(0, 0);
		switch (DockArea)
		{
		default:
			return;
		case DarkDockArea.Left:
		case DarkDockArea.Right:
			size = new Size(((Control)this).ClientRectangle.Width, ((Control)this).ClientRectangle.Height / list_0.Count);
			break;
		case DarkDockArea.Bottom:
			size = new Size(((Control)this).ClientRectangle.Width / list_0.Count, ((Control)this).ClientRectangle.Height);
			break;
		}
		foreach (DarkDockGroup item in list_0)
		{
			((Control)item).Size = size;
		}
	}

	private void method_5()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).MinimumSize = new Size(50, 50);
		switch (DockArea)
		{
		default:
			((Control)this).Dock = (DockStyle)5;
			((Control)this).Padding = new Padding(0, 1, 0, 0);
			break;
		case DarkDockArea.Left:
			((Control)this).Dock = (DockStyle)3;
			((Control)this).Padding = new Padding(0, 0, 1, 0);
			((Control)this).Visible = false;
			break;
		case DarkDockArea.Right:
			((Control)this).Dock = (DockStyle)4;
			((Control)this).Padding = new Padding(1, 0, 0, 0);
			((Control)this).Visible = false;
			break;
		case DarkDockArea.Bottom:
			((Control)this).Dock = (DockStyle)2;
			((Control)this).Padding = new Padding(0, 0, 0, 0);
			((Control)this).Visible = false;
			break;
		}
	}

	private void method_6()
	{
		if (darkDockSplitter_0 != null && DockPanel.Splitters.Contains(darkDockSplitter_0))
		{
			DockPanel.Splitters.Remove(darkDockSplitter_0);
		}
		switch (DockArea)
		{
		default:
			return;
		case DarkDockArea.Left:
			darkDockSplitter_0 = new DarkDockSplitter((Control)(object)DockPanel, (Control)(object)this, DarkSplitterType.Right);
			break;
		case DarkDockArea.Right:
			darkDockSplitter_0 = new DarkDockSplitter((Control)(object)DockPanel, (Control)(object)this, DarkSplitterType.Left);
			break;
		case DarkDockArea.Bottom:
			darkDockSplitter_0 = new DarkDockSplitter((Control)(object)DockPanel, (Control)(object)this, DarkSplitterType.Top);
			break;
		}
		DockPanel.Splitters.Add(darkDockSplitter_0);
	}

	private void method_7()
	{
		if (DockPanel.Splitters.Contains(darkDockSplitter_0))
		{
			DockPanel.Splitters.Remove(darkDockSplitter_0);
		}
	}

	protected override void OnCreateControl()
	{
		((Control)this).OnCreateControl();
		form_0 = ((Control)this).FindForm();
		form_0.ResizeEnd += form_0_ResizeEnd;
	}

	protected override void OnResize(EventArgs eventargs)
	{
		((Panel)this).OnResize(eventargs);
		method_4();
	}

	private void form_0_ResizeEnd(object sender, EventArgs e)
	{
		if (darkDockSplitter_0 != null)
		{
			darkDockSplitter_0.UpdateBounds();
		}
	}

	protected override void OnLayout(LayoutEventArgs e)
	{
		((ScrollableControl)this).OnLayout(e);
		if (darkDockSplitter_0 != null)
		{
			darkDockSplitter_0.UpdateBounds();
		}
	}

	public void Redraw()
	{
		((Control)this).Invalidate();
		foreach (DarkDockGroup item in list_0)
		{
			item.Redraw();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		if (!((Control)this).Visible)
		{
			return;
		}
		SolidBrush val = new SolidBrush(Colors.GreyBackground);
		try
		{
			graphics.FillRectangle((Brush)(object)val, ((Control)this).ClientRectangle);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(Colors.DarkBorder);
		try
		{
			if (DockArea == DarkDockArea.Document)
			{
				graphics.DrawLine(val2, ((Control)this).ClientRectangle.Left, 0, ((Control)this).ClientRectangle.Right, 0);
			}
			if (DockArea == DarkDockArea.Right)
			{
				graphics.DrawLine(val2, ((Control)this).ClientRectangle.Left, 0, ((Control)this).ClientRectangle.Left, ((Control)this).ClientRectangle.Height);
			}
			if (DockArea == DarkDockArea.Left)
			{
				graphics.DrawLine(val2, ((Control)this).ClientRectangle.Right - 1, 0, ((Control)this).ClientRectangle.Right - 1, ((Control)this).ClientRectangle.Height);
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	static DarkDockRegion()
	{
		Class72.smethod_20();
	}
}
