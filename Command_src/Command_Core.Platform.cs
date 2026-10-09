using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Command_Core;

public abstract class Platform : ActiveUnit
{
	public delegate void PlatformMagazinesAddedEventHandler(string UnitObjectID, string NewMagObjectID);

	public delegate void PlatformMagazinesRemovedEventHandler(string UnitObjectID, string RemovedMagObjectID);

	public int Crew;

	public Magazine[] Magazines;

	public int AirThreat;

	public int SurfaceThreat;

	public int SubThreat;

	public int StrikeThreat;

	[CompilerGenerated]
	private static PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler_0;

	[CompilerGenerated]
	private static PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler_0;

	public bool HasLostControlPulse_CACHED;

	public abstract float FlatSurfaceArea_m2 { get; }

	public abstract bool RepresentsMobileGroundUnit { get; }

	public static event PlatformMagazinesAddedEventHandler PlatformMagazinesAdded
	{
		[CompilerGenerated]
		add
		{
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler = platformMagazinesAddedEventHandler_0;
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler2;
			do
			{
				platformMagazinesAddedEventHandler2 = platformMagazinesAddedEventHandler;
				PlatformMagazinesAddedEventHandler value2 = (PlatformMagazinesAddedEventHandler)Delegate.Combine(platformMagazinesAddedEventHandler2, value);
				platformMagazinesAddedEventHandler = Interlocked.CompareExchange(ref platformMagazinesAddedEventHandler_0, value2, platformMagazinesAddedEventHandler2);
			}
			while ((object)platformMagazinesAddedEventHandler != platformMagazinesAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler = platformMagazinesAddedEventHandler_0;
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler2;
			do
			{
				platformMagazinesAddedEventHandler2 = platformMagazinesAddedEventHandler;
				PlatformMagazinesAddedEventHandler value2 = (PlatformMagazinesAddedEventHandler)Delegate.Remove(platformMagazinesAddedEventHandler2, value);
				platformMagazinesAddedEventHandler = Interlocked.CompareExchange(ref platformMagazinesAddedEventHandler_0, value2, platformMagazinesAddedEventHandler2);
			}
			while ((object)platformMagazinesAddedEventHandler != platformMagazinesAddedEventHandler2);
		}
	}

	public static event PlatformMagazinesRemovedEventHandler PlatformMagazinesRemoved
	{
		[CompilerGenerated]
		add
		{
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler = platformMagazinesRemovedEventHandler_0;
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler2;
			do
			{
				platformMagazinesRemovedEventHandler2 = platformMagazinesRemovedEventHandler;
				PlatformMagazinesRemovedEventHandler value2 = (PlatformMagazinesRemovedEventHandler)Delegate.Combine(platformMagazinesRemovedEventHandler2, value);
				platformMagazinesRemovedEventHandler = Interlocked.CompareExchange(ref platformMagazinesRemovedEventHandler_0, value2, platformMagazinesRemovedEventHandler2);
			}
			while ((object)platformMagazinesRemovedEventHandler != platformMagazinesRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler = platformMagazinesRemovedEventHandler_0;
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler2;
			do
			{
				platformMagazinesRemovedEventHandler2 = platformMagazinesRemovedEventHandler;
				PlatformMagazinesRemovedEventHandler value2 = (PlatformMagazinesRemovedEventHandler)Delegate.Remove(platformMagazinesRemovedEventHandler2, value);
				platformMagazinesRemovedEventHandler = Interlocked.CompareExchange(ref platformMagazinesRemovedEventHandler_0, value2, platformMagazinesRemovedEventHandler2);
			}
			while ((object)platformMagazinesRemovedEventHandler != platformMagazinesRemovedEventHandler2);
		}
	}

	public Platform(ref Scenario theScen, string theGUID = null)
		: base(theScen, theGUID)
	{
		Magazines = new Magazine[0];
	}

	public bool HasLostControl()
	{
		HasLostControlPulse_CACHED = IsBlinded();
		return HasLostControlPulse_CACHED;
	}

	public bool IsBlinded()
	{
		if (Crew > 0)
		{
			if (!(base.TemporaryBlindness > 0f))
			{
				return !Sensory.HasEyeballOperating;
			}
			return true;
		}
		return false;
	}

	private protected override List<PlatformComponent> ComponentList()
	{
		List<PlatformComponent> list = base.ComponentList();
		list.AddRange(Magazines);
		return list;
	}

	public void AddSharedMagazine(Magazine theMag, bool RaiseUiEvent = true)
	{
		ArrayExtensions.Add(ref Magazines, theMag);
		theMag.ParentPlatform = this;
		if (RaiseUiEvent)
		{
			platformMagazinesAddedEventHandler_0?.Invoke(ObjectID, theMag.ObjectID);
		}
	}

	public void RemoveSharedMagazine(Magazine theMag)
	{
		ArrayExtensions.Remove(ref Magazines, theMag);
		theMag.ParentPlatform = null;
		platformMagazinesRemovedEventHandler_0?.Invoke(ObjectID, theMag.ObjectID);
	}

	public void ResolveDamageFromDazzler(float DazzleStrengthRatio)
	{
		if (Crew > 0)
		{
			base.TemporaryBlindness += (DazzleStrengthRatio + 0.05f) * 240f;
		}
	}

	static Platform()
	{
		Class72.smethod_20();
	}
}
