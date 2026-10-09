using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class VisualIndicator
{
	public Control ContainingControl;

	public bool Animation_IsShrinkink;

	public int Animation_CurrentStep;

	private ToolStripItem toolStripItem_0;

	private Control control_0;

	private ToolStrip OeMyednHhCW;

	public string AnchorType;

	public bool SubmenuHighlight;

	public Color RetaindedElementColor;

	public Color DrawColor;

	public VisualIndicatorDesign DesignShape;

	public float LifeTime;

	public DateTime TimeStamp;

	public Rectangle Bounds;

	public bool Activated;

	public List<VisualIndicator> ChildIndicators;

	public Module_Unit.Unit TargetUnit;

	public VisualIndicator(Control MainformControl, Module_Unit.Unit _TargetUnit, bool IsAnimated = true, Color DesignColor = default(Color))
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "UnitTracking";
		if (IsAnimated)
		{
			DesignShape = VisualIndicatorDesign.AnimatedCircle;
		}
		else
		{
			DesignShape = VisualIndicatorDesign.StaticCircle;
		}
		TargetUnit = _TargetUnit;
		DrawColor = DesignColor;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Activated = true;
		ContainingControl = MainformControl;
	}

	public VisualIndicator(ToolStripItem _AnchoredtoToolStripItem, VisualIndicatorDesign design, Color _color, bool _SubmenuHighlight, Control _ContainingControl)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "ToolStripItem";
		toolStripItem_0 = _AnchoredtoToolStripItem;
		DesignShape = design;
		DrawColor = _color;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = toolStripItem_0.Bounds;
		Activated = true;
		SubmenuHighlight = _SubmenuHighlight;
		RetaindedElementColor = _AnchoredtoToolStripItem.BackColor;
		ContainingControl = _ContainingControl;
		RefreshSubMenuHighlight();
	}

	public VisualIndicator(Control _AnchoredtoControl, VisualIndicatorDesign design, Color _color, bool _SubmenuHighlight, Control _ContainingControl)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "Control";
		control_0 = _AnchoredtoControl;
		DesignShape = design;
		DrawColor = _color;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = control_0.Bounds;
		Activated = true;
		SubmenuHighlight = _SubmenuHighlight;
		RetaindedElementColor = _AnchoredtoControl.BackColor;
		ContainingControl = _ContainingControl;
		RefreshSubMenuHighlight();
	}

	public VisualIndicator(ToolStrip _AnchoredtoControl, VisualIndicatorDesign design, Color _color, Control _ContainingControl)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "ToolStrip";
		OeMyednHhCW = _AnchoredtoControl;
		DesignShape = design;
		DrawColor = _color;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = ((Control)OeMyednHhCW).Bounds;
		RetaindedElementColor = _AnchoredtoControl.BackColor;
		ContainingControl = _ContainingControl;
		Activated = true;
		RefreshSubMenuHighlight();
	}

	public VisualIndicator(Point _Position, Size _Size, Color _color, Control _ContainingControl, VisualIndicatorDesign Design = VisualIndicatorDesign.AnimatedCircle)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "None";
		DesignShape = Design;
		DrawColor = _color;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = new Rectangle(_Position, _Size);
		ContainingControl = _ContainingControl;
		Activated = true;
	}

	public void RefreshSubMenuHighlight()
	{
		if (!SubmenuHighlight && DesignShape != VisualIndicatorDesign.Highlight)
		{
			return;
		}
		if (Operators.CompareString(AnchorType, "ToolStripItem", false) != 0)
		{
			if (Operators.CompareString(AnchorType, "Control", false) != 0)
			{
				if (Operators.CompareString(AnchorType, "ToolStrip", false) == 0)
				{
					if (Activated)
					{
						OeMyednHhCW.BackColor = DrawColor;
					}
					else
					{
						OeMyednHhCW.BackColor = DrawColor;
					}
				}
			}
			else if (!Activated)
			{
				control_0.BackColor = DrawColor;
			}
			else
			{
				control_0.BackColor = DrawColor;
			}
		}
		else if (Activated)
		{
			toolStripItem_0.BackColor = DrawColor;
		}
		else
		{
			toolStripItem_0.BackColor = DrawColor;
		}
	}

	internal Size GetSize()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		if (Operators.CompareString(AnchorType, "ToolStripItem", false) != 0)
		{
			if (Operators.CompareString(AnchorType, "Control", false) != 0)
			{
				Size result = default(Size);
				if (Operators.CompareString(AnchorType, "ToolStrip", false) == 0)
				{
					int num = default(int);
					foreach (object item in (ArrangedElementCollection)OeMyednHhCW.Items)
					{
						ToolStripItem val = (ToolStripItem)RuntimeHelpers.GetObjectValue(item);
						num += val.Width;
					}
					result = new Size(num, ((Control)OeMyednHhCW).Height);
				}
				else if (Operators.CompareString(AnchorType, "None", false) == 0)
				{
					return Bounds.Size;
				}
				return result;
			}
			return control_0.Size;
		}
		return toolStripItem_0.Size;
	}

	internal bool HasToBeDrawn()
	{
		if (SubmenuHighlight)
		{
			RefreshSubMenuHighlight();
			return false;
		}
		if (Operators.CompareString(AnchorType, "ToolStripItem", false) == 0)
		{
			return toolStripItem_0.Visible;
		}
		if (Operators.CompareString(AnchorType, "Control", false) == 0)
		{
			return control_0.Visible;
		}
		if (Operators.CompareString(AnchorType, "ToolStrip", false) == 0)
		{
			return ((Control)OeMyednHhCW).Visible;
		}
		return true;
	}

	internal Point GetAnchorPosition()
	{
		if (Operators.CompareString(AnchorType, "ToolStripItem", false) == 0)
		{
			Point location = toolStripItem_0.Bounds.Location;
			Point location2 = ((Control)toolStripItem_0.GetCurrentParent()).Bounds.Location;
			return new Point(location.X + location2.X, location.Y + location2.Y);
		}
		if (Operators.CompareString(AnchorType, "Control", false) != 0)
		{
			if (Operators.CompareString(AnchorType, "ToolStrip", false) == 0)
			{
				return ((Control)OeMyednHhCW).Location;
			}
			if (Operators.CompareString(AnchorType, "None", false) == 0)
			{
				return Bounds.Location;
			}
			Point result = default(Point);
			return result;
		}
		Point offset = default(Point);
		GetCumulativeOffset(control_0, ref offset);
		return control_0.Location;
	}

	public void GetCumulativeOffset(Control Source, ref Point offset)
	{
		if (Source.Parent == null)
		{
			offset.Offset(Source.PointToScreen(default(Point)));
			return;
		}
		offset.Offset(Source.Location);
		GetCumulativeOffset(Source.Parent, ref offset);
	}

	static VisualIndicator()
	{
		Class72.smethod_20();
	}
}
