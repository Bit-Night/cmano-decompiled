using Easy.Common;

namespace Command_Core;

public class ScenarioObject : ISortable
{
	internal string ObjectID;

	private string string_0;

	internal bool IsActiveUnit;

	internal bool IsGroup;

	internal bool IsAircraft;

	internal bool IsBoat;

	internal bool IsSubmarine;

	internal bool IsShip;

	internal bool IsTorpedo;

	internal bool IsFacility;

	internal bool IsVehicle;

	internal bool IsSatellite;

	internal bool IsMobileGroundUnit;

	internal bool IsMission;

	internal bool IsWaypoint;

	internal bool IsGuidedProjectile;

	internal bool IsAggregatedUnit;

	private int int_0;

	internal virtual string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal bool IsFixedFacility
	{
		get
		{
			if (IsFacility)
			{
				if (!((Facility)this).RepresentsMobileGroundUnit)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	internal string SortByName => Name;

	public sealed override int GetHashCode()
	{
		return int_0;
	}

	internal void Reinitialize()
	{
		ObjectID = null;
		string_0 = null;
		IsActiveUnit = false;
		IsGroup = false;
		IsAircraft = false;
		IsBoat = false;
		IsSubmarine = false;
		IsShip = false;
		IsTorpedo = false;
		IsFacility = false;
		IsVehicle = false;
		IsSatellite = false;
		IsMobileGroundUnit = false;
		IsMission = false;
		IsWaypoint = false;
		IsGuidedProjectile = false;
		IsAggregatedUnit = false;
	}

	internal ScenarioObject()
	{
		IsActiveUnit = false;
		IsGroup = false;
		IsAircraft = false;
		IsBoat = false;
		IsSubmarine = false;
		IsShip = false;
		IsTorpedo = false;
		IsFacility = false;
		IsVehicle = false;
		IsSatellite = false;
		IsMobileGroundUnit = false;
		IsMission = false;
		IsWaypoint = false;
		IsGuidedProjectile = false;
		IsAggregatedUnit = false;
		int_0 = base.GetHashCode();
		ObjectID = IDGenerator.Instance.Next;
	}

	internal ScenarioObject(bool AssignObjectID = true)
	{
		IsActiveUnit = false;
		IsGroup = false;
		IsAircraft = false;
		IsBoat = false;
		IsSubmarine = false;
		IsShip = false;
		IsTorpedo = false;
		IsFacility = false;
		IsVehicle = false;
		IsSatellite = false;
		IsMobileGroundUnit = false;
		IsMission = false;
		IsWaypoint = false;
		IsGuidedProjectile = false;
		IsAggregatedUnit = false;
		int_0 = base.GetHashCode();
		if (AssignObjectID)
		{
			ObjectID = IDGenerator.Instance.Next;
		}
	}

	internal virtual void ObjectID_Set(string newValue, bool NeedToCheckForSpaces = true)
	{
		if (NeedToCheckForSpaces && Misc.ContainsChar(newValue, ' '))
		{
			newValue = newValue.Replace(" ", "-");
		}
		ObjectID = newValue;
	}

	public virtual void ResetIDs()
	{
		ObjectID = IDGenerator.Instance.Next;
	}

	public void AddMessage(Scenario theScen, string theMessageText, string theSummary, LoggedMessage.MessageType theMessageType, byte theMessageLevel)
	{
		if ((object)GetType() == typeof(Side))
		{
			theScen.AddMessage(theMessageText, theSummary, theMessageType, theMessageLevel, null, (Side)this);
			return;
		}
		checked
		{
			if (!IsMission)
			{
				if (IsActiveUnit)
				{
					ActiveUnit[] array = theScen.ActiveUnits_List.InternalArray();
					int num = 0;
					ActiveUnit activeUnit;
					while (true)
					{
						if (num < array.Length)
						{
							activeUnit = array[num];
							if (activeUnit != null && activeUnit == this)
							{
								break;
							}
							num++;
							continue;
						}
						return;
					}
					activeUnit.AddMessage(theMessageText, theSummary, theMessageType, theMessageLevel, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					if (!IsWaypoint)
					{
						return;
					}
					ActiveUnit[] array2 = theScen.ActiveUnits_List.InternalArray();
					foreach (ActiveUnit activeUnit2 in array2)
					{
						if (activeUnit2 == null)
						{
							continue;
						}
						Waypoint[] plottedCourse = activeUnit2.Navigator.PlottedCourse;
						for (int j = 0; j < plottedCourse.Length; j++)
						{
							if (plottedCourse[j] == this)
							{
								activeUnit2.AddMessage(theMessageText, theSummary, theMessageType, theMessageLevel, new Geopoint_Struct(activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
								return;
							}
						}
					}
				}
				return;
			}
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				foreach (Mission mission in side.Missions)
				{
					if (mission == this)
					{
						theScen.AddMessage(theMessageText, theSummary, theMessageType, theMessageLevel, null, side);
						return;
					}
				}
			}
		}
	}

	internal bool IsUnit()
	{
		return (object)GetType() == typeof(Module_Unit.Unit);
	}

	internal bool IsReferencePoint()
	{
		return (object)GetType() == typeof(ReferencePoint);
	}

	internal bool IsContact()
	{
		return (object)GetType() == typeof(Contact);
	}

	internal bool HasMoved()
	{
		if (!IsContact())
		{
			if (IsActiveUnit)
			{
				return ((ActiveUnit)this).HasMoved();
			}
			bool result = default(bool);
			return result;
		}
		return ((Contact)this).HasMoved();
	}

	static ScenarioObject()
	{
		Class72.smethod_20();
	}
}
