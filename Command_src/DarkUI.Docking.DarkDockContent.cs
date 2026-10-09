using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public class DarkDockContent : UserControl
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private string string_0;

	private Image image_0;

	[CompilerGenerated]
	private DarkDockArea darkDockArea_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private DarkDockPanel darkDockPanel_0;

	[CompilerGenerated]
	private DarkDockRegion darkDockRegion_0;

	[CompilerGenerated]
	private DarkDockGroup darkDockGroup_0;

	[CompilerGenerated]
	private DarkDockArea darkDockArea_1;

	[CompilerGenerated]
	private int int_0;

	[Category("Appearance")]
	[Description("Determines the text that will appear in the content tabs and headers.")]
	public string DockText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
			((Control)this).Invalidate();
		}
	}

	[Category("Appearance")]
	[Description("Determines the icon that will appear in the content tabs and headers.")]
	public Image Icon
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

	[DefaultValue(DarkDockArea.Document)]
	[Description("Determines the default area of the dock panel this content will be added to.")]
	[Category("Layout")]
	public DarkDockArea DefaultDockArea
	{
		[CompilerGenerated]
		get
		{
			return darkDockArea_0;
		}
		[CompilerGenerated]
		set
		{
			darkDockArea_0 = value;
		}
	}

	[Category("Behavior")]
	[Description("Determines the key used by this content in the dock serialization.")]
	public string SerializationKey
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockPanel DockPanel
	{
		[CompilerGenerated]
		get
		{
			return darkDockPanel_0;
		}
		[CompilerGenerated]
		internal set
		{
			darkDockPanel_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockRegion DockRegion
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
	public DarkDockGroup DockGroup
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
	public DarkDockArea DockArea
	{
		[CompilerGenerated]
		get
		{
			return darkDockArea_1;
		}
		[CompilerGenerated]
		set
		{
			darkDockArea_1 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

	public event EventHandler DockTextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public virtual void Close()
	{
		if (DockPanel != null)
		{
			DockPanel.RemoveContent(this);
		}
	}

	protected override void OnEnter(EventArgs e)
	{
		((Control)this).OnEnter(e);
		if (DockPanel != null)
		{
			DockPanel.ActiveContent = this;
		}
	}

	static DarkDockContent()
	{
		Class72.smethod_20();
	}
}
