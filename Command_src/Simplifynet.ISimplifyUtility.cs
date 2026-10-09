using System.Collections.Generic;

namespace Simplifynet;

public interface ISimplifyUtility
{
	List<Point> Simplify(Point[] points, double tolerance = 0.3, bool highestQuality = false);
}
