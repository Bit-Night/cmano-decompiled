using System;
using System.Runtime.CompilerServices;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class RightColumnPhony
{
	[CompilerGenerated]
	private bool bool_0;

	public DoctrineControlPhony DoctrineControl1;

	public EmconControlPhony EmconControl1;

	public bool UpdateData
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public RightColumnPhony()
	{
		UpdateData = true;
		DoctrineControl1 = new DoctrineControlPhony();
		EmconControl1 = new EmconControlPhony();
	}

	public void RefreshPanels(Scenario currentScenario, Side currentSide, Module_Unit.Unit selectedUnit, bool v, bool IsCyclicRefresh = false)
	{
		Refresh(selectedUnit, IsCyclicRefresh);
	}

	public void ReleaseReferences()
	{
		try
		{
			ReleaseReferencesInternal();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal void AdjustToSelectionChange(Module_Unit.Unit value, Module_Unit.Unit previousUnit)
	{
		Refresh(value);
	}

	public static void Refresh(Module_Unit.Unit newSelectedUnit, bool IsCyclicRefresh = false)
	{
		if (Client.CurrentSide != null)
		{
			((RightColumnWPF)(object)Client.theElementHostRightColumn.Child).RefreshPanels(Client.CurrentScenario, Client.CurrentSide, newSelectedUnit, IsCyclicRefresh);
		}
	}

	public static void ReleaseReferencesInternal()
	{
		((RightColumnWPF)(object)Client.theElementHostRightColumn.Child).ReleaseReferences();
	}

	static RightColumnPhony()
	{
		Class72.smethod_20();
	}
}
