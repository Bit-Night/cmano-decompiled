using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Command_Core;

internal class NetworkRuleExecutionContext
{
	[CompilerGenerated]
	private Side side_0;

	private IEnumerable<ActiveUnit> ienumerable_0;

	private IEnumerable<ActiveUnit> ienumerable_1;

	[CompilerGenerated]
	private List<Scenario.NetworkLog> list_0;

	[CompilerGenerated]
	private Action<Side, IEnumerable<Module_Unit.Unit>, CommNetwork.NetworkCreationReason, List<Scenario.NetworkLog>, string, string> action_0;

	[CompilerGenerated]
	private Action<Side, ActiveUnit, ActiveUnit, CommNetwork.NetworkCreationReason, List<Scenario.NetworkLog>, string> action_1;

	[CompilerGenerated]
	private Func<string, string> func_0;

	public Side Side
	{
		[CompilerGenerated]
		get
		{
			return side_0;
		}
		[CompilerGenerated]
		set
		{
			side_0 = value;
		}
	}

	public IEnumerable<ActiveUnit> AEWUnits
	{
		get
		{
			return ienumerable_0;
		}
		set
		{
			ienumerable_0 = ((value == null) ? Enumerable.Empty<ActiveUnit>() : value);
		}
	}

	public IEnumerable<ActiveUnit> TankerUnits
	{
		get
		{
			return ienumerable_1;
		}
		set
		{
			ienumerable_1 = ((value == null) ? Enumerable.Empty<ActiveUnit>() : value);
		}
	}

	public List<Scenario.NetworkLog> Log
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public Action<Side, IEnumerable<Module_Unit.Unit>, CommNetwork.NetworkCreationReason, List<Scenario.NetworkLog>, string, string> CreateNetwork
	{
		[CompilerGenerated]
		get
		{
			return action_0;
		}
		[CompilerGenerated]
		set
		{
			action_0 = value;
		}
	}

	public Action<Side, ActiveUnit, ActiveUnit, CommNetwork.NetworkCreationReason, List<Scenario.NetworkLog>, string> AssignToNetwork
	{
		[CompilerGenerated]
		get
		{
			return action_1;
		}
		[CompilerGenerated]
		set
		{
			action_1 = value;
		}
	}

	public Func<string, string> ExecuteLua
	{
		[CompilerGenerated]
		get
		{
			return func_0;
		}
		[CompilerGenerated]
		set
		{
			func_0 = value;
		}
	}

	public NetworkRuleExecutionContext()
	{
		ienumerable_0 = Enumerable.Empty<ActiveUnit>();
		ienumerable_1 = Enumerable.Empty<ActiveUnit>();
	}

	public void AddLog(string message)
	{
		if (Log != null)
		{
			Log.Add(new Scenario.NetworkLog(null, CommNetwork.NetworkCreationReason.Generic, message));
		}
	}

	public bool IsAEW(ActiveUnit u)
	{
		if (AEWUnits == null)
		{
			return false;
		}
		return AEWUnits.Contains(u);
	}

	public bool IsTanker(ActiveUnit u)
	{
		if (TankerUnits != null)
		{
			return TankerUnits.Contains(u);
		}
		return false;
	}

	static NetworkRuleExecutionContext()
	{
		Class72.smethod_20();
	}
}
