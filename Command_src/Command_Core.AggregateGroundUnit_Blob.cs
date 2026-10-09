using System.Collections.Generic;

namespace Command_Core;

public class AggregateGroundUnit_Blob
{
	public HashSet<AggregateGroundUnit> Members;

	public AggregateGroundUnit_Blob(AggregateGroundUnit aggregateGroundUnit_0, bool IncludeAllies, bool includeHostiles, HashSet<AggregateGroundUnit> hashSet_0)
	{
		Members = new HashSet<AggregateGroundUnit>();
		hashSet_0.Add(aggregateGroundUnit_0);
		Members.Add(aggregateGroundUnit_0);
		AddAdjacents(aggregateGroundUnit_0, IncludeAllies, includeHostiles, hashSet_0);
	}

	public void AddAdjacents(AggregateGroundUnit aggregateGroundUnit_0, bool IncludeAllies, bool includeHostiles, HashSet<AggregateGroundUnit> hashSet_0)
	{
		lock (aggregateGroundUnit_0._frictionsLock)
		{
			foreach (KeyValuePair<AggregateGroundUnit, float> friction in aggregateGroundUnit_0.Frictions)
			{
				if (!hashSet_0.Contains(friction.Key))
				{
					Misc.PostureStance postureStance = ((ActiveUnit)friction.Key).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(((ActiveUnit)friction.Key).get_UnitSide(SetSideOnly: false), (Scenario)null);
					if (((postureStance == Misc.PostureStance.Friendly && IncludeAllies) || (postureStance == Misc.PostureStance.Hostile && includeHostiles)) && !Members.Contains(friction.Key))
					{
						Members.Add(friction.Key);
						hashSet_0.Add(friction.Key);
						AddAdjacents(friction.Key, IncludeAllies, includeHostiles, hashSet_0);
					}
				}
			}
		}
	}

	static AggregateGroundUnit_Blob()
	{
		Class72.smethod_20();
	}
}
