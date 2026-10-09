using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkDataGridView : DataGridView
{
	public DarkDataGridView()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		((Control)this).DoubleBuffered = true;
		((Control)this).SetStyle((ControlStyles)139266, true);
		((Control)this).UpdateStyles();
		((DataGridView)this).Padding = new Padding(2, 2, 2, 2);
		((DataGridView)this).BorderStyle = (BorderStyle)0;
		((DataGridView)this).BackgroundColor = Colors.GreyBackground;
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Colors.GreyBackground;
		val.Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Colors.BlueSelection;
		val.SelectionForeColor = Colors.GreyHighlight;
		val.WrapMode = (DataGridViewTriState)2;
		((DataGridView)this).DefaultCellStyle = val;
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Colors.BlueBackground;
		val2.Font = new Font("Segoe UI", 8f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Colors.BlueSelection;
		val2.SelectionForeColor = Colors.GreyHighlight;
		val2.WrapMode = (DataGridViewTriState)1;
		((DataGridView)this).ColumnHeadersDefaultCellStyle = val2;
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		val3.BackColor = Colors.GreyBackground;
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Colors.BlueSelection;
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)this).RowsDefaultCellStyle = val3;
		((DataGridView)this).EnableHeadersVisualStyles = false;
		((DataGridView)this).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)this).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		((DataGridView)this).BorderStyle = (BorderStyle)0;
		((DataGridView)this).AllowUserToOrderColumns = true;
	}

	static DarkDataGridView()
	{
		Class72.smethod_20();
	}
}
