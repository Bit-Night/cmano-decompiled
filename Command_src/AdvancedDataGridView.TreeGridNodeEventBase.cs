namespace AdvancedDataGridView;

public class TreeGridNodeEventBase
{
	private TreeGridNode treeGridNode_0;

	public TreeGridNode Node => treeGridNode_0;

	public TreeGridNodeEventBase(TreeGridNode node)
	{
		treeGridNode_0 = node;
	}

	static TreeGridNodeEventBase()
	{
		Class72.smethod_20();
	}
}
