using System.Collections.Generic;
using System.Drawing;

namespace Algorithms;

[Author("Franco, Gustavo")]
public interface IPathFinder
{
	bool Stopped { get; }

	HeuristicFormula Formula { get; set; }

	bool Diagonals { get; set; }

	bool HeavyDiagonals { get; set; }

	int HeuristicEstimate { get; set; }

	bool PunishChangeDirection { get; set; }

	bool ReopenCloseNodes { get; set; }

	bool TieBreaker { get; set; }

	int SearchLimit { get; set; }

	double CompletedTime { get; set; }

	bool DebugProgress { get; set; }

	bool DebugFoundPath { get; set; }

	event PathFinderDebugHandler PathFinderDebug;

	void FindPathStop();

	List<PathFinderNode> FindPath(Point start, Point end);
}
