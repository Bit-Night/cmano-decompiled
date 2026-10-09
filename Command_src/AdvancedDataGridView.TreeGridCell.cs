using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdvancedDataGridView;

public class TreeGridCell : DataGridViewTextBoxCell
{
	private int int_0;

	private int int_1;

	internal bool IsSited;

	private Padding padding_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private Rectangle rectangle_0;

	public int Level => OwningNode?.Level ?? (-1);

	protected virtual int GlyphMargin => (Level - 1) * 20 + 5;

	protected virtual int GlyphOffset => (Level - 1) * 20;

	public TreeGridNode OwningNode => ((DataGridViewCell)this).OwningRow as TreeGridNode;

	public TreeGridCell()
	{
		int_0 = 15;
		int_1 = 0;
		IsSited = false;
	}

	public override object Clone()
	{
		TreeGridCell obj = (TreeGridCell)((DataGridViewTextBoxCell)this).Clone();
		obj.int_0 = int_0;
		obj.int_1 = int_1;
		return obj;
	}

	protected internal virtual void UnSited()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		IsSited = false;
		((DataGridViewCell)this).Style.Padding = padding_0;
	}

	protected internal virtual void Sited()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		IsSited = true;
		padding_0 = ((DataGridViewCell)this).Style.Padding;
		UpdateStyle();
	}

	protected internal virtual void UpdateStyle()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		if (IsSited)
		{
			int level = Level;
			Padding val = padding_0;
			Graphics val2 = ((Control)OwningNode._grid).CreateGraphics();
			Size preferredSize;
			try
			{
				preferredSize = ((DataGridViewCell)this).GetPreferredSize(val2, ((DataGridViewCell)this).InheritedStyle, ((DataGridViewCell)this).RowIndex, new Size(0, 0));
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			Image image = OwningNode.Image;
			if (image == null)
			{
				int_2 = int_0;
				int_3 = 0;
			}
			else
			{
				int_2 = image.Width + 2;
				int_3 = image.Height + 2;
			}
			if (preferredSize.Height >= int_3)
			{
				((DataGridViewCell)this).Style.Padding = new Padding(((Padding)(ref val)).Left + level * 20 + int_2 + 5, ((Padding)(ref val)).Top, ((Padding)(ref val)).Right, ((Padding)(ref val)).Bottom);
			}
			else
			{
				((DataGridViewCell)this).Style.Padding = new Padding(((Padding)(ref val)).Left + level * 20 + int_2 + 5, ((Padding)(ref val)).Top + int_3 / 2, ((Padding)(ref val)).Right, ((Padding)(ref val)).Bottom + int_3 / 2);
				int_4 = 2;
			}
			int_1 = (level - 1) * int_0 + int_2 + 5;
		}
	}

	protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected O, but got Unknown
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		TreeGridNode owningNode = OwningNode;
		if (owningNode == null)
		{
			return;
		}
		Image image = owningNode.Image;
		if (int_3 == 0 && image != null)
		{
			UpdateStyle();
		}
		((DataGridViewTextBoxCell)this).Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
		Rectangle rectangle = new Rectangle(cellBounds.X + GlyphMargin, cellBounds.Y, 20, cellBounds.Height - 1);
		_ = rectangle.Width / 2;
		_ = Level;
		if (image != null)
		{
			Point point = ((int_3 <= cellBounds.Height) ? new Point(rectangle.X + int_0, cellBounds.Height / 2 - int_3 / 2 + cellBounds.Y) : new Point(rectangle.X + int_0, cellBounds.Y + int_4));
			GraphicsContainer val = graphics.BeginContainer();
			graphics.SetClip(cellBounds);
			graphics.DrawImageUnscaled(image, point);
			graphics.EndContainer(val);
		}
		if (owningNode._grid.ShowLines)
		{
			Pen val2 = new Pen(SystemBrushes.ControlDark, 1f);
			try
			{
				val2.DashStyle = (DashStyle)2;
				bool isLastSibling = owningNode.IsLastSibling;
				bool isFirstSibling = owningNode.IsFirstSibling;
				if (owningNode.Level == 1)
				{
					if (isFirstSibling && isLastSibling)
					{
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
					}
					else if (isLastSibling)
					{
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2);
					}
					else if (isFirstSibling)
					{
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.X + 4, cellBounds.Bottom);
					}
					else
					{
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Bottom);
					}
				}
				else
				{
					if (!isLastSibling)
					{
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Bottom);
					}
					else
					{
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
						graphics.DrawLine(val2, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2);
					}
					TreeGridNode parent = owningNode.Parent;
					int num = rectangle.X + 4 - 20;
					while (!parent._IsRoot)
					{
						if (parent.HasChildren && !parent.IsLastSibling)
						{
							graphics.DrawLine(val2, num, cellBounds.Top, num, cellBounds.Bottom);
						}
						parent = parent.Parent;
						num -= 20;
					}
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		if (owningNode.HasChildren || owningNode._grid.VirtualNodes)
		{
			if (owningNode._IsExpanded)
			{
				Bitmap val3 = new Bitmap(Application.StartupPath + "\\Symbols\\Menu\\Minus.png");
				graphics.DrawImage((Image)(object)val3, rectangle.X, rectangle.Y + rectangle.Height / 2 - 4, 10, 10);
			}
			else
			{
				Bitmap val3 = new Bitmap(Application.StartupPath + "\\Symbols\\Menu\\Plus.png");
				graphics.DrawImage((Image)(object)val3, rectangle.X, rectangle.Y + rectangle.Height / 2 - 4, 10, 10);
			}
		}
	}

	protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
	{
		((DataGridViewCell)this).OnMouseUp(e);
		TreeGridNode owningNode = OwningNode;
		if (owningNode != null)
		{
			owningNode._grid._inExpandCollapseMouseCapture = false;
		}
	}

	protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		int x = ((MouseEventArgs)e).Location.X;
		Padding padding = ((DataGridViewCell)this).InheritedStyle.Padding;
		if (x <= ((Padding)(ref padding)).Left)
		{
			TreeGridNode owningNode = OwningNode;
			if (owningNode != null)
			{
				owningNode._grid._inExpandCollapseMouseCapture = true;
				if (owningNode._IsExpanded)
				{
					owningNode.Collapse();
				}
				else
				{
					owningNode.Expand();
				}
			}
		}
		else
		{
			((DataGridViewCell)this).OnMouseDown(e);
		}
	}

	static TreeGridCell()
	{
		Class72.smethod_20();
	}
}
