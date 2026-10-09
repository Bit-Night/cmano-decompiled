using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;
using DarkUI.Win32;

namespace DarkUI.Docking;

public sealed class DarkDockPanel : UserControl
{
	[CompilerGenerated]
	private EventHandler<DockContentEventArgs> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<DockContentEventArgs> eventHandler_1;

	[CompilerGenerated]
	private EventHandler<DockContentEventArgs> eventHandler_2;

	private List<DarkDockContent> list_0;

	private Dictionary<DarkDockArea, DarkDockRegion> dictionary_0;

	private DarkDockContent darkDockContent_0;

	private bool bool_0;

	[CompilerGenerated]
	private DarkDockRegion darkDockRegion_0;

	[CompilerGenerated]
	private DarkDockGroup darkDockGroup_0;

	[CompilerGenerated]
	private DockContentDragFilter dockContentDragFilter_0;

	[CompilerGenerated]
	private DockResizeFilter dockResizeFilter_0;

	[CompilerGenerated]
	private List<DarkDockSplitter> list_1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockContent ActiveContent
	{
		get
		{
			return darkDockContent_0;
		}
		set
		{
			if (bool_0)
			{
				return;
			}
			bool_0 = true;
			darkDockContent_0 = value;
			ActiveGroup = darkDockContent_0.DockGroup;
			ActiveRegion = ActiveGroup.DockRegion;
			foreach (DarkDockRegion value2 in dictionary_0.Values)
			{
				value2.Redraw();
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new DockContentEventArgs(darkDockContent_0));
			}
			bool_0 = false;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockRegion ActiveRegion
	{
		[CompilerGenerated]
		get
		{
			return darkDockRegion_0;
		}
		[CompilerGenerated]
		internal set
		{
			darkDockRegion_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockGroup ActiveGroup
	{
		[CompilerGenerated]
		get
		{
			return darkDockGroup_0;
		}
		[CompilerGenerated]
		internal set
		{
			darkDockGroup_0 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkDockContent ActiveDocument => dictionary_0[DarkDockArea.Document].ActiveDocument;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DockContentDragFilter DockContentDragFilter
	{
		[CompilerGenerated]
		get
		{
			return dockContentDragFilter_0;
		}
		[CompilerGenerated]
		private set
		{
			dockContentDragFilter_0 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DockResizeFilter DockResizeFilter
	{
		[CompilerGenerated]
		get
		{
			return dockResizeFilter_0;
		}
		[CompilerGenerated]
		private set
		{
			dockResizeFilter_0 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public List<DarkDockSplitter> Splitters
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		private set
		{
			list_1 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public MouseButtons MouseButtonState => Control.MouseButtons;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Dictionary<DarkDockArea, DarkDockRegion> Regions => dictionary_0;

	public event EventHandler<DockContentEventArgs> ActiveContentChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DockContentEventArgs> eventHandler = eventHandler_0;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DockContentEventArgs> eventHandler = eventHandler_0;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<DockContentEventArgs> ContentAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DockContentEventArgs> eventHandler = eventHandler_1;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DockContentEventArgs> eventHandler = eventHandler_1;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<DockContentEventArgs> ContentRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DockContentEventArgs> eventHandler = eventHandler_2;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DockContentEventArgs> eventHandler = eventHandler_2;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkDockPanel()
	{
		Splitters = new List<DarkDockSplitter>();
		DockContentDragFilter = new DockContentDragFilter(this);
		DockResizeFilter = new DockResizeFilter(this);
		dictionary_0 = new Dictionary<DarkDockArea, DarkDockRegion>();
		list_0 = new List<DarkDockContent>();
		((Control)this).BackColor = Colors.GreyBackground;
		method_0();
	}

	public void AddContent(DarkDockContent dockContent)
	{
		AddContent(dockContent, null);
	}

	public void AddContent(DarkDockContent dockContent, DarkDockGroup dockGroup)
	{
		if (list_0.Contains(dockContent))
		{
			RemoveContent(dockContent);
		}
		dockContent.DockPanel = this;
		list_0.Add(dockContent);
		if (dockGroup != null)
		{
			dockContent.DockArea = dockGroup.DockArea;
		}
		if (dockContent.DockArea == DarkDockArea.None)
		{
			dockContent.DockArea = dockContent.DefaultDockArea;
		}
		dictionary_0[dockContent.DockArea].AddContent(dockContent, dockGroup);
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, new DockContentEventArgs(dockContent));
		}
		((Control)dockContent).Select();
	}

	public void InsertContent(DarkDockContent dockContent, DarkDockGroup dockGroup, DockInsertType insertType)
	{
		if (list_0.Contains(dockContent))
		{
			RemoveContent(dockContent);
		}
		dockContent.DockPanel = this;
		list_0.Add(dockContent);
		dockContent.DockArea = dockGroup.DockArea;
		dictionary_0[dockGroup.DockArea].InsertContent(dockContent, dockGroup, insertType);
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, new DockContentEventArgs(dockContent));
		}
		((Control)dockContent).Select();
	}

	public void RemoveContent(DarkDockContent dockContent)
	{
		if (list_0.Contains(dockContent))
		{
			dockContent.DockPanel = null;
			list_0.Remove(dockContent);
			dictionary_0[dockContent.DockArea].RemoveContent(dockContent);
			if (eventHandler_2 != null)
			{
				eventHandler_2(this, new DockContentEventArgs(dockContent));
			}
		}
	}

	public bool ContainsContent(DarkDockContent dockContent)
	{
		return list_0.Contains(dockContent);
	}

	public List<DarkDockContent> GetDocuments()
	{
		return dictionary_0[DarkDockArea.Document].GetContents();
	}

	private void method_0()
	{
		DarkDockRegion darkDockRegion = new DarkDockRegion(this, DarkDockArea.Document);
		dictionary_0.Add(DarkDockArea.Document, darkDockRegion);
		DarkDockRegion darkDockRegion2 = new DarkDockRegion(this, DarkDockArea.Left);
		dictionary_0.Add(DarkDockArea.Left, darkDockRegion2);
		DarkDockRegion darkDockRegion3 = new DarkDockRegion(this, DarkDockArea.Right);
		dictionary_0.Add(DarkDockArea.Right, darkDockRegion3);
		DarkDockRegion darkDockRegion4 = new DarkDockRegion(this, DarkDockArea.Bottom);
		dictionary_0.Add(DarkDockArea.Bottom, darkDockRegion4);
		((Control)this).Controls.Add((Control)(object)darkDockRegion);
		((Control)this).Controls.Add((Control)(object)darkDockRegion4);
		((Control)this).Controls.Add((Control)(object)darkDockRegion2);
		((Control)this).Controls.Add((Control)(object)darkDockRegion3);
		((Control)darkDockRegion).TabIndex = 0;
		((Control)darkDockRegion3).TabIndex = 1;
		((Control)darkDockRegion4).TabIndex = 2;
		((Control)darkDockRegion2).TabIndex = 3;
	}

	public void DragContent(DarkDockContent content)
	{
		DockContentDragFilter.StartDrag(content);
	}

	public DockPanelState GetDockPanelState()
	{
		DockPanelState dockPanelState = new DockPanelState();
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Document));
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Left, ((Control)dictionary_0[DarkDockArea.Left]).Size));
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Right, ((Control)dictionary_0[DarkDockArea.Right]).Size));
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Bottom, ((Control)dictionary_0[DarkDockArea.Bottom]).Size));
		Dictionary<DarkDockGroup, DockGroupState> dictionary = new Dictionary<DarkDockGroup, DockGroupState>();
		foreach (DarkDockContent item in list_0.OrderBy((DarkDockContent c) => c.Order))
		{
			foreach (DockRegionState region in dockPanelState.Regions)
			{
				if (region.Area == item.DockArea)
				{
					DockGroupState dockGroupState;
					if (dictionary.ContainsKey(item.DockGroup))
					{
						dockGroupState = dictionary[item.DockGroup];
					}
					else
					{
						dockGroupState = new DockGroupState();
						region.Groups.Add(dockGroupState);
						dictionary.Add(item.DockGroup, dockGroupState);
					}
					dockGroupState.Contents.Add(item.SerializationKey);
					dockGroupState.VisibleContent = item.DockGroup.VisibleContent.SerializationKey;
				}
			}
		}
		return dockPanelState;
	}

	public void RestoreDockPanelState(DockPanelState state, Func<string, DarkDockContent> getContentBySerializationKey)
	{
		foreach (DockRegionState region in state.Regions)
		{
			switch (region.Area)
			{
			case DarkDockArea.Left:
				((Control)dictionary_0[DarkDockArea.Left]).Size = region.Size;
				break;
			case DarkDockArea.Right:
				((Control)dictionary_0[DarkDockArea.Right]).Size = region.Size;
				break;
			case DarkDockArea.Bottom:
				((Control)dictionary_0[DarkDockArea.Bottom]).Size = region.Size;
				break;
			}
			foreach (DockGroupState group in region.Groups)
			{
				DarkDockContent darkDockContent = null;
				DarkDockContent darkDockContent2 = null;
				foreach (string content in group.Contents)
				{
					DarkDockContent darkDockContent3 = getContentBySerializationKey(content);
					if (darkDockContent3 != null)
					{
						darkDockContent3.DockArea = region.Area;
						if (darkDockContent != null)
						{
							AddContent(darkDockContent3, darkDockContent.DockGroup);
						}
						else
						{
							AddContent(darkDockContent3);
						}
						darkDockContent = darkDockContent3;
						if (group.VisibleContent == content)
						{
							darkDockContent2 = darkDockContent3;
						}
					}
				}
				if (darkDockContent2 != null)
				{
					((Control)darkDockContent2).Select();
				}
			}
		}
	}

	static DarkDockPanel()
	{
		Class72.smethod_20();
	}
}
