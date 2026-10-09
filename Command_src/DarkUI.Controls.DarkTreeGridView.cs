using System.Drawing;
using System.Windows.Forms;
using AdvancedDataGridView;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkTreeGridView : TreeGridView
{
	public DarkTreeGridView()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((Control)this).BackColor = Colors.DarkBackground;
		((Control)this).ForeColor = Colors.LightText;
		((DataGridView)this).BackgroundColor = Colors.DarkBackground;
		((DataGridView)this).BorderStyle = (BorderStyle)1;
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		val.BackColor = Colors.GreyBackground;
		val.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.LightGray;
		((DataGridView)this).DefaultCellStyle = val;
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Colors.BlueBackground;
		val2.Font = new Font("Segoe UI", 8.25f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Colors.BlueSelection;
		val2.SelectionForeColor = Colors.GreyHighlight;
		val2.WrapMode = (DataGridViewTriState)1;
		((DataGridView)this).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)this).EnableHeadersVisualStyles = false;
		((DataGridView)this).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)this).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		((DataGridView)this).BorderStyle = (BorderStyle)0;
	}

	public void ExpandAllItems()
	{
		foreach (TreeGridNode node in base.Nodes)
		{
			node.Expand();
		}
	}

	public void CollapseAllItem()
	{
		foreach (TreeGridNode item in base.Nodes._list)
		{
			item.Collapse();
		}
	}

	static DarkTreeGridView()
	{
		Class72.smethod_20();
	}
}
