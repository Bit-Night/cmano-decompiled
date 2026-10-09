using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;
using DarkUI.Docking;
using DarkUI.Forms;

namespace DarkUI.Win32;

public sealed class DockContentDragFilter : IMessageFilter
{
	private DarkDockPanel darkDockPanel_0;

	private DarkDockContent darkDockContent_0;

	private DarkTranslucentForm darkTranslucentForm_0;

	private bool bool_0;

	private DarkDockRegion darkDockRegion_0;

	private DarkDockGroup darkDockGroup_0;

	private DockInsertType dockInsertType_0;

	private Dictionary<DarkDockRegion, DockDropArea> dictionary_0 = new Dictionary<DarkDockRegion, DockDropArea>();

	private Dictionary<DarkDockGroup, DockDropCollection> dictionary_1 = new Dictionary<DarkDockGroup, DockDropCollection>();

	public DockContentDragFilter(DarkDockPanel dockPanel)
	{
		darkDockPanel_0 = dockPanel;
		darkTranslucentForm_0 = new DarkTranslucentForm(Colors.BlueSelection);
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (bool_0)
		{
			if (((Message)(ref m)).Msg != 512 && ((Message)(ref m)).Msg != 513 && ((Message)(ref m)).Msg != 514 && ((Message)(ref m)).Msg != 515 && ((Message)(ref m)).Msg != 516 && ((Message)(ref m)).Msg != 517 && ((Message)(ref m)).Msg != 518)
			{
				return false;
			}
			if (((Message)(ref m)).Msg == 512)
			{
				method_2();
				return false;
			}
			if (((Message)(ref m)).Msg == 514)
			{
				if (darkDockRegion_0 == null)
				{
					if (darkDockGroup_0 != null)
					{
						darkDockPanel_0.RemoveContent(darkDockContent_0);
						switch (dockInsertType_0)
						{
						case DockInsertType.None:
							darkDockPanel_0.AddContent(darkDockContent_0, darkDockGroup_0);
							break;
						case DockInsertType.Before:
						case DockInsertType.After:
							darkDockPanel_0.InsertContent(darkDockContent_0, darkDockGroup_0, dockInsertType_0);
							break;
						}
					}
				}
				else
				{
					darkDockPanel_0.RemoveContent(darkDockContent_0);
					darkDockContent_0.DockArea = darkDockRegion_0.DockArea;
					darkDockPanel_0.AddContent(darkDockContent_0);
				}
				method_0();
				return false;
			}
			return true;
		}
		return false;
	}

	public void StartDrag(DarkDockContent content)
	{
		dictionary_0 = new Dictionary<DarkDockRegion, DockDropArea>();
		dictionary_1 = new Dictionary<DarkDockGroup, DockDropCollection>();
		foreach (DarkDockRegion value3 in darkDockPanel_0.Regions.Values)
		{
			if (value3.DockArea == DarkDockArea.Document)
			{
				continue;
			}
			if (!((Control)value3).Visible)
			{
				DockDropArea value = new DockDropArea(darkDockPanel_0, value3);
				dictionary_0.Add(value3, value);
				continue;
			}
			foreach (DarkDockGroup group in value3.Groups)
			{
				DockDropCollection value2 = new DockDropCollection(darkDockPanel_0, group);
				dictionary_1.Add(group, value2);
			}
		}
		darkDockContent_0 = content;
		bool_0 = true;
	}

	private void method_0()
	{
		Cursor.Current = Cursors.Default;
		((Control)darkTranslucentForm_0).Hide();
		darkDockContent_0 = null;
		bool_0 = false;
	}

	private void method_1(Rectangle rectangle_0)
	{
		Cursor.Current = Cursors.SizeAll;
		((Control)darkTranslucentForm_0).SuspendLayout();
		((Form)darkTranslucentForm_0).Size = new Size(rectangle_0.Width, rectangle_0.Height);
		((Form)darkTranslucentForm_0).Location = new Point(rectangle_0.X, rectangle_0.Y);
		((Control)darkTranslucentForm_0).ResumeLayout();
		if (!((Control)darkTranslucentForm_0).Visible)
		{
			((Control)darkTranslucentForm_0).Show();
			((Control)darkTranslucentForm_0).BringToFront();
		}
	}

	private void method_2()
	{
		Point position = Cursor.Position;
		dockInsertType_0 = DockInsertType.None;
		darkDockRegion_0 = null;
		darkDockGroup_0 = null;
		foreach (DockDropArea value in dictionary_0.Values)
		{
			if (value.DropArea.Contains(position))
			{
				dockInsertType_0 = DockInsertType.None;
				darkDockRegion_0 = value.DockRegion;
				method_1(value.HighlightArea);
				return;
			}
		}
		foreach (DockDropCollection value2 in dictionary_1.Values)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (value2.DropArea.DockGroup == darkDockContent_0.DockGroup)
			{
				flag2 = true;
			}
			if (value2.DropArea.DockGroup.DockRegion == darkDockContent_0.DockRegion)
			{
				flag = true;
			}
			if (darkDockContent_0.DockGroup.ContentCount > 1)
			{
				flag3 = true;
			}
			if (!flag2 || flag3)
			{
				bool flag4 = false;
				bool flag5 = false;
				if (flag && !flag3)
				{
					if (value2.InsertBeforeArea.DockGroup.Order == darkDockContent_0.DockGroup.Order + 1)
					{
						flag4 = true;
					}
					if (value2.InsertAfterArea.DockGroup.Order == darkDockContent_0.DockGroup.Order - 1)
					{
						flag5 = true;
					}
				}
				if (!flag4 && value2.InsertBeforeArea.DropArea.Contains(position))
				{
					dockInsertType_0 = DockInsertType.Before;
					darkDockGroup_0 = value2.InsertBeforeArea.DockGroup;
					method_1(value2.InsertBeforeArea.HighlightArea);
					return;
				}
				if (!flag5 && value2.InsertAfterArea.DropArea.Contains(position))
				{
					dockInsertType_0 = DockInsertType.After;
					darkDockGroup_0 = value2.InsertAfterArea.DockGroup;
					method_1(value2.InsertAfterArea.HighlightArea);
					return;
				}
			}
			if (!flag2 && value2.DropArea.DropArea.Contains(position))
			{
				dockInsertType_0 = DockInsertType.None;
				darkDockGroup_0 = value2.DropArea.DockGroup;
				method_1(value2.DropArea.HighlightArea);
				return;
			}
		}
		if (((Control)darkTranslucentForm_0).Visible)
		{
			((Control)darkTranslucentForm_0).Hide();
		}
		Cursor.Current = Cursors.No;
	}

	static DockContentDragFilter()
	{
		Class72.smethod_20();
	}
}
