using System.ComponentModel;

namespace AdvancedDataGridView;

public sealed class CollapsingEventArgs : CancelEventArgs
{
	private TreeGridNode treeGridNode_0;

	public TreeGridNode Node => treeGridNode_0;

	private CollapsingEventArgs()
	{
	}

	public CollapsingEventArgs(TreeGridNode node)
	{
		treeGridNode_0 = node;
	}

	static CollapsingEventArgs()
	{
		Class72.smethod_20();
	}
}
