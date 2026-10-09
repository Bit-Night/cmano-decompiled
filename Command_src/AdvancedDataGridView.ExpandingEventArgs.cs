using System.ComponentModel;

namespace AdvancedDataGridView;

public sealed class ExpandingEventArgs : CancelEventArgs
{
	private TreeGridNode treeGridNode_0;

	public TreeGridNode Node => treeGridNode_0;

	private ExpandingEventArgs()
	{
	}

	public ExpandingEventArgs(TreeGridNode node)
	{
		treeGridNode_0 = node;
	}

	static ExpandingEventArgs()
	{
		Class72.smethod_20();
	}
}
