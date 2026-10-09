using System.Drawing;
using System.Windows.Forms;

namespace AdvancedDataGridView;

public sealed class TreeGridColumn : DataGridViewTextBoxColumn
{
	internal Image _defaultNodeImage;

	public Image DefaultNodeImage
	{
		get
		{
			return _defaultNodeImage;
		}
		set
		{
			_defaultNodeImage = value;
		}
	}

	public TreeGridColumn()
	{
		((DataGridViewColumn)this).CellTemplate = (DataGridViewCell)(object)new TreeGridCell();
	}

	public override object Clone()
	{
		TreeGridColumn obj = (TreeGridColumn)((DataGridViewColumn)this).Clone();
		obj._defaultNodeImage = _defaultNodeImage;
		return obj;
	}

	static TreeGridColumn()
	{
		Class72.smethod_20();
	}
}
