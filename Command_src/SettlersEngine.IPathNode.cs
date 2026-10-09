namespace SettlersEngine;

public interface IPathNode<TUserContext>
{
	bool IsWalkable(TUserContext inContext);
}
